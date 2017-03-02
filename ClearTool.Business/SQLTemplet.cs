using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LysExtend;

namespace ClearTool.Business
{
    public static class SQLTemplet
    {
        /// <summary>
        /// 获取清空存储过程初始脚本
        /// </summary>
        /// <returns></returns>
        public static string GetInitClearProc(string sysCode, string sysName)
        {
            var paramList = new Dictionary<string, string>
            {
                {nameof(sysCode), sysCode},
                {nameof(sysName), sysName}
            };

            return ReplaceSQL("InitClearProc", paramList);
        }

        /// <summary>
        /// 规范存储过程脚本格式
        /// </summary>
        /// <returns></returns>
        public static string FormatClearProc(string procName, string procText)
        {
            var paramList = new Dictionary<string, string>
            {
                {nameof(procName), procName},
                {nameof(procText), procText}
            };

            return ReplaceSQL("FormatProc", paramList);
        }

        private static string ReplaceSQL(string templetName, Dictionary<string,string> paramList)
        {
            string sql = IOExt.Read($@"{Directory.GetCurrentDirectory()}\SQL模板\{templetName}.sql");
            paramList.ForEach(param =>
            {
                sql = sql.ReplaceNoCase($"{{{param.Key}}}", param.Value);
            });
            return sql;
        }
    }
}
