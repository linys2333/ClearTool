using System.Collections.Generic;
using System.Linq;
using ClearTool.Business.BO;
using DomainCore;
using LysExtend;

namespace ClearTool.Business.DS
{
    public class AnalysisDS
    {
        public static AnalysisDS GetInstance()
        {
            return ServiceFactory.GetService<AnalysisDS>();
        }

        /// <summary>
        /// 根据配置信息进行表比较
        /// </summary>
        public virtual List<ComparaResult> Compara(SettingInfo settinInfo)
        {
            settinInfo.TargetDB.InitConn();
            var targetTbList = DataOpr.GetTableList(settinInfo.InFilter, settinInfo.NotFilter);

            settinInfo.ComparaDB.InitConn();
            var comparaTbList = DataOpr.GetTableList(settinInfo.InFilter, settinInfo.NotFilter);

            // 重置（清空）小平台数据库连接
            ExtDBInfo.SetDefault();

            return ComparaTable(targetTbList, comparaTbList)
                .Where(data => data.Flag != StatusFlag.None).ToList();
        }

        /// <summary>
        /// 比较表，标识变化
        /// </summary>
        public virtual List<ComparaResult> ComparaTable(List<TableInfo> targetTbList, List<TableInfo> comparaTbList)
        {
            // 全关联
            var fullJoinData = (from tb1 in targetTbList
                                join tb2 in comparaTbList on tb1.TableName equals tb2.TableName into tbList
                                from tb2 in tbList.DefaultIfEmpty()
                                select new
                                {
                                    Target = tb1,
                                    Compara = tb2
                                }).Union
                                (from tb2 in comparaTbList
                                 join tb1 in targetTbList on tb2.TableName equals tb1.TableName into tbList
                                 from tb1 in tbList.DefaultIfEmpty()
                                 select new
                                 {
                                     Target = tb1,
                                     Compara = tb2
                                 }).ToList();

            // 对比
            var resultList = fullJoinData.Select(data =>
            {
                var result = new ComparaResult
                {
                    TableName = data.Target?.TableName ?? data.Compara.TableName,
                    TableNameChn = data.Target?.TableNameChn ?? data.Compara.TableNameChn,
                    TargetTableName = data.Target?.TableName ?? "",
                    ComparaTableName = data.Compara?.TableName ?? "",
                    FieldList = new List<BO.ComparaField>()
                };

                // 标示表的变化
                bool targetHasValue = !result.TargetTableName.IsEmpty();
                bool comparaHasValue = !result.ComparaTableName.IsEmpty();

                if (targetHasValue || comparaHasValue)
                {
                    if (!targetHasValue)
                    {
                        result.Flag = StatusFlag.Delete;
                        result.IsClear = false;
                        result.IsClearOfBU = false;
                    }
                    else if (!comparaHasValue)
                    {
                        result.Flag = StatusFlag.Add;
                        result.IsClear = true;
                        result.IsClearOfBU = true;
                    }
                    else
                    {
                        result.Flag = data.Target.FieldList.SequenceEqual(data.Compara.FieldList)
                            ? StatusFlag.None
                            : StatusFlag.Edit;
                        result.IsClear = true;
                        result.IsClearOfBU = true;
                    }
                }

                if (data.Target != null)
                {
                    result.FieldList = data.Target.FieldList.Select(e => (ComparaField) e).ToList();
                }

                return result;
            }).OrderBy(data => data.TableName).ToList();

            return resultList;
        }
    }
}
