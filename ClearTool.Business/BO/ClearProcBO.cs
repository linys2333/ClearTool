using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ClearTool.Business.DS;
using LysExtend;

namespace ClearTool.Business.BO
{
    public class ClearProcBO
    {
        public string ProcName { get; }

        /// <summary>
        /// 完整脚本
        /// </summary>
        public string OriginProcText { get; }
        public string ProcText { get; set; }

        /// <summary>
        /// 无注释脚本
        /// </summary>
        public string ProcNoNotes { get; }
        
        /// <summary>
        /// 走ALL分支的代码
        /// </summary>
        public string AllSQL { get; }

        /// <summary>
        /// 走公司分支的代码
        /// </summary>
        public string BUSQL { get; }

        public ClearProcBO(string sysCode)
        {
            ProcName = DataOpr.GetClearProcName(sysCode);
            OriginProcText = DataOpr.GetProcText(ProcName);

            if (OriginProcText.IsEmpty())
            {
                OriginProcText = SQLTemplet.GetInitClearProc(sysCode, ConfigDS.SysList.GetSysInfo(sysCode).SysName);
            }

            ProcNoNotes = SQLExt.DelNotes(OriginProcText);
            ProcText = OriginProcText;

            // TODO：需要拆分吗？
            AllSQL = GetAllSQL();
            BUSQL = GetBUSQL();
        }

        /// <summary>
        /// 分割为行级脚本
        /// </summary>
        /// <param name="sql">待分割SQL</param>
        /// <returns></returns>
        public List<string> SplitRow(string sql)
        {
            return sql.Split("\r\n").ToList();
        }

        /// <summary>
        /// 获取走ALL分支的代码
        /// </summary>
        /// <returns></returns>
        public string GetAllSQL()
        {
            return OriginProcText;
        }

        /// <summary>
        /// 获取走公司分支的代码
        /// </summary>
        /// <returns></returns>
        public string GetBUSQL()
        {
            return OriginProcText;
        }

        /// <summary>
        /// 在存储过程中查找表
        /// </summary>
        /// <param name="tableName">待查找表名</param>
        /// <param name="isReplace">是否替换</param>
        /// <returns></returns>
        public bool IsFind(string tableName, bool isReplace = false)
        {
            bool isFind = Regex.IsMatch(ProcNoNotes, $@"\b{tableName}\b");
            if (isFind && isReplace)
            {
                ProcText = Regex.Replace(ProcText, $@"\b{tableName}\b", m => $"【'待删除：{m}'】");
            }
            return isFind;
        }

        /// <summary>
        /// ALL分支的清空SQL
        /// </summary>
        /// <param name="data">表信息</param>
        /// <returns></returns>
        public string FormatAllSQL(ComparaResult data)
        {
            return data.TableNameChn.IsEmpty()
                ? $"TRUNCATE TABLE {data.TableName}"
                : $"TRUNCATE TABLE {data.TableName} -- {data.TableNameChn}";
        }

        /// <summary>
        /// 公司分支的清空SQL
        /// </summary>
        /// <param name="data">表信息</param>
        /// <returns></returns>
        public string FormatBUSQL(ComparaResult data)
        {
            string projField = data.FieldList.SingleOrNew(e => e.FieldName.In("ProjGUID,ProjectGUID")).FieldName;

            string childSelect = "SELECT ProjGUID FROM p_Project WHERE BUGUID IN ('+ @chvBUList +')";
            return projField.IsEmpty() ? $@"
-- {data.TableNameChn}
EXEC ('DELETE FROM {data.TableName} WHERE 【'外键'】 IN (
SELECT 【'主键'】 FROM 【'主表'】 WHERE ProjGUID IN ({childSelect}))')
            ".Trim() : $@"
-- {data.TableNameChn}
EXEC ('DELETE FROM {data.TableName} WHERE {projField} IN (
{childSelect})')".Trim();
        }
    }
}
