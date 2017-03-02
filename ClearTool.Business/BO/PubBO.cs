using System;
using System.Collections.Generic;
using LysExtend;

namespace ClearTool.Business.BO
{
    /// <summary>
    /// 表变化标识
    /// </summary>
    public enum StatusFlag
    {
        Add,    // 新增
        Edit,   // 修改
        Delete, // 删除
        None    // 无变化
    }

    /// <summary>
    /// 配置信息
    /// </summary>
    public class SettingInfo
    {
        public List<string> InFilter { get; set; }
        public List<string> NotFilter { get; set; }
        public ExtDBInfo TargetDB { get; set; }
        public ExtDBInfo ComparaDB { get; set; }
    }
    
    /// <summary>
    /// 比较结果
    /// </summary>
    [Serializable]
    public class ComparaResult
    {
        public string TableName { get; set; }
        public string TableNameChn { get; set; }
        public string TargetTableName { get; set; }
        public string ComparaTableName { get; set; }
        public StatusFlag Flag { get; set; } = StatusFlag.None;
        public bool IsClear { get; set; } = false;    // 是否清空
        public bool IsClearOfBU { get; set; } = false;// 公司级分支-是否清空
        public string SysCode { get; set; } = "";     // 系统代码
        public string Remark { get; set; } = "";      // 备注
        public bool IsAssert { get; set; } = false;   // 是否强调备注

        public List<ComparaField> FieldList { get; set; }

        public string AllSQL { get; set; } = "";
        public string BUSQL { get; set; } = "";
    }
    
    [Serializable]
    public class ComparaField
    {
        public string FieldName { get; set; }
        public string FieldNameChn { get; set; }
        public string TargetFieldName { get; set; }
        public bool IsProjField { get; set; } = false;
        public string Remark { get; set; } = "";

        public static explicit operator ComparaField(FieldInfo obj)
        {
            return new ComparaField
            {
                FieldName = obj.FieldName,
                FieldNameChn = obj.FieldNameChn,
                TargetFieldName = obj.FieldName
            };
        }
    }

    /// <summary>
        /// 展示用
        /// </summary>
        public class ComparaInfo
    {
        public string TableName { get; set; }
        public string TableNameChn { get; set; }
        public string TargetTableName { get; set; }
        public string ComparaTableName { get; set; }
        public string Flag { get; set; } = "";
        public string IsClear { get; set; } = "否";
        public string IsClearOfBU { get; set; } = "否";
        public string Remark { get; set; } = "";

        public static Dictionary<StatusFlag, string> StatusDic = new Dictionary<StatusFlag, string>
        {
            [StatusFlag.Add] = "新增",
            [StatusFlag.Edit] = "修改",
            [StatusFlag.Delete] = "删除",
            [StatusFlag.None] = "无变化"
        };

        public static explicit operator ComparaInfo(ComparaResult obj)
        {
            return new ComparaInfo
            {
                TableName = obj.TableName,
                TableNameChn = obj.TableNameChn.IsEmpty() ? "--" : obj.TableNameChn,
                ComparaTableName = obj.ComparaTableName,
                TargetTableName = obj.TargetTableName,
                Flag = StatusDic[obj.Flag],
                IsClear = obj.IsClear ? "是" : "否",
                IsClearOfBU = obj.IsClearOfBU ? "是" : "否",
                Remark = obj.Remark
            };
        }
    }
}
