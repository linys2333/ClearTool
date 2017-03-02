using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using ClearTool.Business.BO;
using ClearTool.Business.DS;
using LysExtend;
using Mysoft.Map.Extensions.DAL;
using static LysExtend.Util;

namespace ClearTool.Business
{
    public class DataOpr
    {
        /// <summary>
        /// 根据系统表前缀，获取表信息
        /// </summary>
        public static List<TableInfo> GetTableList(List<SysTablePrefix> sysTablePrefix)
        {
            return sysTablePrefix.SelectMany(code => GetTableList(code.InFilter, code.NotFilter)).ToList();
        }

        /// <summary>
        /// 根据过滤条件，获取表信息
        /// </summary>
        public static List<TableInfo> GetTableList(List<string> inFilter, List<string> notFilter)
        {
            // 处理过滤条件
            Func<string, string> toSafe = filter =>
            {
                // % _ [ ] ^
                return Regex.Replace(filter.Trim().Replace("'", "''"), @"[%_\[\]^]", match => @"\" + match);
            };

            var inFilterSql = new List<string> { "1=2" };
            var notFilterSql = new List<string> { "1=1" };

            inFilter.ForEach(str =>
            {
                inFilterSql.AddFormat(@"s.name LIKE '{0}%' ESCAPE '\'", toSafe(str));
            });

            notFilter.ForEach(str =>
            {
                notFilterSql.AddFormat(@"s.name NOT LIKE '{0}%' ESCAPE '\'", toSafe(str));
            });
            
            // 查询表信息
            string sql = $@"
                SELECT s.name AS 'TableName', ISNULL(t.TableNameChn, '') AS 'TableNameChn'
                FROM sys.sysobjects s
                LEFT JOIN
                (
                        SELECT DISTINCT table_name AS TableName, 
                            table_name_c AS TableNameChn
                        FROM data_dict
                        WHERE table_name <> ''
                ) t ON s.name = t.TableName
                WHERE s.type = 'U'
                        AND ({inFilterSql.Join(" OR ")})
                        AND ({notFilterSql.Join(" AND ")})
                ORDER BY s.name";

            DataTable dt = CPQuery.From(sql).FillDataTable();

            // 处理结果值
            return dt.Select().Select(row =>new TableInfo(ConvertType<string>(row["TableName"]))).ToList();
        }

        /// <summary>
        /// 获取表中文名
        /// </summary>
        public static string GetTableNameChn(string tableName)
        {
            return CPQuery.From(@"SELECT TOP 1 table_name_c FROM data_dict WHERE table_name = @TableName",
                new { TableName = tableName }).ExecuteScalar<string>() ?? "";
        }

        /// <summary>
        /// 获取单表字段
        /// </summary>
        public static List<FieldInfo> GetFieldList(string tableName)
        {
            return GetFieldList(new List<string> { tableName });
        }

        /// <summary>
        /// 获取多表字段
        /// </summary>
        public static List<FieldInfo> GetFieldList(List<string> tableNameList)
        {
            return CPQuery.From(@"
                SELECT  o.name AS TableName ,
                        c.name AS FieldName ,
		                dict.field_name_c AS FieldNameChn ,
                        t.name AS DataType ,
                        c.Length ,
                        CAST(c.isnullable AS BIT) AS IsNullable ,
                        m.text AS DefaultValue
                FROM    syscolumns c
                        INNER JOIN systypes t ON c.xusertype = t.xusertype
                        INNER JOIN sysobjects o ON c.id = o.id
                        LEFT JOIN syscomments m ON c.cdefault = m.id
                        LEFT JOIN data_dict dict ON dict.table_name = o.name
                                                    AND dict.field_name_c = c.name
                WHERE   o.xtype = 'U'
                        AND c.status >= 0
                        AND o.name IN @TableName
                ORDER BY dict.field_sequence, c.name",
                new { TableName = tableNameList }).ToList<FieldInfo>();
        }

        /// <summary>
        /// 获取清空存储过程脚本
        /// </summary>
        public static string GetProcText(string procName)
        {
            string clearProc = CPQuery.From(SQLExt.GetProcTextSQL, 
                new {proc = procName}).ExecuteScalar<string>();

            return clearProc?.Trim() ?? "";
        }

        /// <summary>
        /// 根据系统编码获取对应清空存储过程名
        /// </summary>
        public static string GetClearProcName(string sysCode)
        {
            return "usp_p_ClearData_" + ConfigDS.SysList.GetSysInfo(sysCode).ClearProcSuffix;
        }
    }
}
