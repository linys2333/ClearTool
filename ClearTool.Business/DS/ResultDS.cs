using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using ClearTool.Business.BO;
using DomainCore;
using LysExtend;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;

namespace ClearTool.Business.DS
{
    public class ResultDS
    {
        public static ResultDS GetInstance()
        {
            return ServiceFactory.GetService<ResultDS>();
        }
        
        /// <summary>
        /// 根据比较结果生成脚本和文档
        /// </summary>
        public virtual void Create(ref List<ComparaResult> comparaData, string folder)
        {
            var dataList = comparaData.Where(e => e.Flag != StatusFlag.None).GroupBy(e => e.SysCode)
                .Select(e => new KeyValuePair<string, List<ComparaResult>>(e.Key, e.ToList()));

            var procList = new List<KeyValuePair<string, string>>();
            var resultDic = new Dictionary<string, List<ComparaResult>>();

            // 生成脚本
            dataList.ForEach(e =>
            {
                procList.Add(CreateSQL(ref e));
                resultDic.Add(ConfigDS.SysList.GetSysInfo(e.Key).SysName, e.Value);
            });

            // 保存结果
            ExportSQL(procList, folder);
            ExportDoc(resultDic, folder);
        }
        
        /// <summary>
        /// 导出脚本
        /// <para>procList：key-存储过程名称，value-存储过程文本</para>
        /// </summary>
        public virtual void ExportSQL(List<KeyValuePair<string, string>> procList, string folder)
        {
            procList.ForEach(proc =>
            { 
                string path = folder + proc.Key + ".sql";

                IOExt.Write(path, proc.Value);
            });
        }

        /// <summary>
        /// 导出文档
        /// <para>resultDic：key-系统名称，value-对应表信息</para>
        /// </summary>
        public virtual void ExportDoc(Dictionary<string, List<ComparaResult>> resultDic, string folder)
        {
            // 导出Excel
            var excel = new HSSFWorkbook();
            
            // 单元格样式
            ICellStyle cellStyle = excel.CreateCellStyle();
            cellStyle.VerticalAlignment = VerticalAlignment.Center;
            cellStyle.BorderTop = BorderStyle.Thin;
            cellStyle.BorderBottom = BorderStyle.Thin;
            cellStyle.BorderLeft = BorderStyle.Thin;
            cellStyle.BorderRight = BorderStyle.Thin;
            
            // 标题样式
            ICellStyle titleStyle = excel.CreateCellStyle();
            titleStyle.CloneStyleFrom(cellStyle);
            titleStyle.Alignment = HorizontalAlignment.Center;
            IFont font = excel.CreateFont();
            font.Boldweight = (short)FontBoldWeight.Bold;
            titleStyle.SetFont(font);

            // 备注样式
            // 样式尽可能定义好并复用，动态创建可能会导致导出的Excel样式错乱（和NPOI内部实现有关）
            ICellStyle remarkStyle = excel.CreateCellStyle();
            remarkStyle.CloneStyleFrom(cellStyle);
            remarkStyle.FillPattern = FillPattern.SolidForeground;
            remarkStyle.FillForegroundColor = HSSFColor.Yellow.Index;

            // 设置
            resultDic.ForEach(dic =>
            {
                ISheet sheet = excel.CreateSheet(dic.Key);

                // 创建标题
                IRow rowTitle = sheet.CreateRow(0);
                CreateCell(ref rowTitle, 0, titleStyle, "表中文名");
                CreateCell(ref rowTitle, 1, titleStyle, "对比表名");
                CreateCell(ref rowTitle, 2, titleStyle, "目标表名");
                CreateCell(ref rowTitle, 3, titleStyle, "标志");
                CreateCell(ref rowTitle, 4, titleStyle, "是否清空");
                CreateCell(ref rowTitle, 5, titleStyle, "备注");

                // 创建内容
                dic.Value.ForEach((result, i) =>
                {
                    var e = (ComparaInfo)result;
                    
                    IRow row = sheet.CreateRow(i + 1);
                    CreateCell(ref row, 0, cellStyle, e.TableNameChn);
                    CreateCell(ref row, 1, cellStyle, e.ComparaTableName);
                    CreateCell(ref row, 2, cellStyle, e.TargetTableName);
                    CreateCell(ref row, 3, cellStyle, e.Flag);
                    CreateCell(ref row, 4, cellStyle, e.IsClear);
                    CreateCell(ref row, 5, result.IsAssert ? remarkStyle : cellStyle, e.Remark);
                });

                // 列宽自适应
                for (int i = 0; i < rowTitle.Cells.Count; i++)
                {
                    sheet.AutoSizeColumn(i);
                }
            });
            
            // 写入文件
            string path = folder + "清空升级.xls";

            IOExt.CreateFile(path);
            File.SetAttributes(path, FileAttributes.Normal);

            using (var fs = new FileStream(path, FileMode.Create))
            {
                excel.Write(fs);
            }
        }

        #region 私有方法

        /// <summary>
        /// 生成脚本
        /// </summary>
        /// <param name="comparaResult">会将提示信息标识在Remark字段中</param>
        /// <returns>存储过程名：存储过程脚本</returns>
        private KeyValuePair<string, string> CreateSQL(ref KeyValuePair<string, List<ComparaResult>> comparaResult)
        {
            string sysCode = comparaResult.Key;
            var comparaData = comparaResult.Value;

            // 获取清空存储过程
            var clearProc = new ClearProcBO(sysCode);
            
            if (clearProc.ProcNoNotes.IsEmpty())
            {
                throw new DomainException($"不存在存储过程：{clearProc.ProcName}，请创建后重试！");
            }
            
            #region 分析
            
            // 存储新增的清空脚本
            var addSQLOfAll = new List<string>();
            var addSQLOfBU = new List<string>();

            comparaData.ForEach(e =>
            {
                if (e.IsClear)
                {
                    switch (e.Flag)
                    {
                        case StatusFlag.Add:
                            if (clearProc.IsFind(e.TableName))
                            {
                                e.Remark = clearProc.ProcName + "中已存在该表，请检查！\r\nPS：未添加该表的清空SQL，请确认。";
                                e.IsAssert = true;
                            }
                            else
                            {
                                e.Remark = "已添加该表的清空SQL，请确认。";

                                addSQLOfAll.Add(clearProc.FormatAllSQL(e));

                                if (e.IsClearOfBU)
                                {
                                    addSQLOfBU.Add("\r\n" + clearProc.FormatBUSQL(e));
                                }
                            }
                            break;
                        case StatusFlag.Edit:
                            if (!clearProc.IsFind(e.TableName))
                            {
                                e.Remark = clearProc.ProcName + "中不存在该表，请检查！\r\nPS：已补充该表的清空SQL，请确认。";
                                e.IsAssert = true;

                                addSQLOfAll.Add(clearProc.FormatAllSQL(e));

                                if (e.IsClearOfBU)
                                {
                                    addSQLOfBU.Add("\r\n" + clearProc.FormatBUSQL(e));
                                }
                            }
                            break;
                        case StatusFlag.Delete:
                            if (!clearProc.IsFind(e.TableName, true))
                            {
                                e.Remark = clearProc.ProcName + "中已删除该表，请检查！";
                            }
                            else
                            {
                                e.Remark = "请【手动删除】该表相关清空SQL！";
                                e.IsAssert = true;
                            }
                            break;
                    }
                }
                else
                {
                    if (clearProc.IsFind(e.TableName, true))
                    {
                        e.Remark = clearProc.ProcName + "中存在该表，请【手动删除】该表相关清空SQL！";
                        e.IsAssert = true;
                    }
                }
            });
            
            #endregion

            #region 更新

            List<string> rows = clearProc.SplitRow(clearProc.ProcText);
            int beginEndCount = 0;  // 记录Begin-End对出现次数
            int insertIndexAll = 0;
            int insertIndexBU = 0;
            bool isAddAll = false;

            // TODO:查找追加位置
            rows.SafeForEach((str, i) =>
            {
                if (Regex.IsMatch(str, @"\bBEGIN\b"))
                {
                    beginEndCount++;
                    return true;
                }

                if (Regex.IsMatch(str, @"\bEND\b"))
                {
                    beginEndCount--;

                    if (beginEndCount == 0)
                    {
                        if (!isAddAll)
                        {
                            isAddAll = true;
                            insertIndexAll = i;
                        }
                        else
                        {
                            insertIndexBU = i;
                            return false;
                        }
                    }
                }

                return true;
            });

            rows.InsertRange(insertIndexBU, addSQLOfBU);
            rows.InsertRange(insertIndexAll, addSQLOfAll);

            string result = SQLTemplet.FormatClearProc(clearProc.ProcName, rows.Join("\r\n"));

            #endregion

            return new KeyValuePair<string, string>(clearProc.ProcName, result);
        }

        private ICell CreateCell(ref IRow row, int index, ICellStyle style, string value)
        {
            ICell cell = row.GetCell(index) ?? row.CreateCell(index);

            cell.CellStyle = style;
            cell.SetCellValue(value);

            return cell;
        }

        #endregion
    }
}
