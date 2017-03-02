using System;
using System.Collections.Generic;
using System.Linq;
using LysExtend;

namespace ClearTool.Business.BO
{
    /// <summary>
    /// 扩展数据库信息
    /// </summary>
    public class ExtDBInfo : DBInfo
    {
        public ExtDBInfo(DBInfo db)
            : base(db.Server, db.Database, db.UserName, db.Password)
        {
        }

        public ExtDBInfo(string server, string database, string userName, string password)
            :base(server,database, userName, password)
        {
        }

        public void InitConn()
        {
            SetDefault();
            Mysoft.Map.Extensions.Initializer.UnSafeInit(ConnString);
        }

        public static void SetDefault()
        {
            Type t = typeof(Mysoft.Map.Extensions.Initializer);
            ReflectExt.InvokeStaticField(t, "s_inited", false);

            t = typeof(Mysoft.Map.Extensions.DAL.ConnectionScope);
            ReflectExt.InvokeStaticField(t, "s_connectionString", "");
        }
    }
    
    /// <summary>
    /// 表信息
    /// </summary>
    public class TableInfo
    {
        public string TableName { get; }
        public string TableNameChn { get; }
        public List<FieldInfo> FieldList { get; }

        public TableInfo(string tableName)
        {
            TableName = tableName;
            TableNameChn = DataOpr.GetTableNameChn(TableName);
            FieldList = DataOpr.GetFieldList(TableName);
        }
    }
    
    /// <summary>
    /// 字段信息
    /// </summary>
    public class FieldInfo
    {
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public string FieldNameChn { get; set; }
        public string DataType { get; set; }
        public int Length { get; set; }
        public bool IsNullable { get; set; }
        public string DefaultValue { get; set; }

        public override int GetHashCode() => this.ToString().GetHashCode();

        public override bool Equals(Object a)
        {
            if (a == null)
            {
                return false;
            }

            return this == (FieldInfo)a;
        }

        public static bool operator ==(FieldInfo a, FieldInfo b)
        {
            if ((object)a == null || (object)b == null)
            {
                return Equals(a, b);
            }

            var aProps = a.GetType().GetProperties().OrderBy(p => p.Name).ToArray();
            var bProps = b.GetType().GetProperties().OrderBy(p => p.Name).ToArray();
            
            for (int i = 0; i < aProps.Length; i++)
            {
                Type type = aProps[i].PropertyType;
                if (type == typeof (int))
                {
                    int aValue = Util.ConvertType<int>(aProps[i].GetValue(a));
                    int bValue = Util.ConvertType<int>(bProps[i].GetValue(b));

                    if (aValue != bValue)
                    {
                        return false;
                    }
                }
                else if (type == typeof (bool))
                {
                    bool aValue = Util.ConvertType<bool>(aProps[i].GetValue(a));
                    bool bValue = Util.ConvertType<bool>(bProps[i].GetValue(b));

                    if (aValue != bValue)
                    {
                        return false;
                    }
                }
                else
                {
                    string aValue = Util.ConvertType<string>(aProps[i].GetValue(a));
                    string bValue = Util.ConvertType<string>(bProps[i].GetValue(b));

                    if (aValue != bValue)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator !=(FieldInfo a, FieldInfo b) => !(a == b);
    }
}
