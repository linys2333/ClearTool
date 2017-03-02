using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using LysExtend;

namespace ClearTool.Business.BO
{
    [Serializable]
    public class Config
    {
        public string SelectSys { get; set; }

        [XmlArray]
        public List<SysTablePrefix> SysTablePrefixDic { get; set; }

        [XmlArray]
        public List<SysInfo> SysInfoDic { get; set; }

        public Config()
        {
            SysTablePrefixDic = new List<SysTablePrefix>();
            SysInfoDic = new List<SysInfo>();
        }

        public SysTablePrefix GetSysTablePrefix(string sysCode)
        {
            return SysTablePrefixDic.SingleOrNew(dic => dic.SysCode == sysCode);
        }

        public SysInfo GetSysInfo(string sysCode)
        {
            return SysInfoDic.SingleOrNew(dic => dic.SysCode == sysCode);
        }
    }

    /// <summary>
    /// 系统表前缀
    /// </summary>
    public class SysTablePrefix
    {
        public string SysCode { get; set; }
        public List<string> InFilter { get; set; }
        public List<string> NotFilter { get; set; }

        public SysTablePrefix()
        {
            InFilter = new List<string>();
            NotFilter = new List<string>();
        }
    }

    /// <summary>
    /// 系统信息
    /// </summary>
    public class SysInfo
    {
        public string SysCode { get; set; }
        public string SysName { get; set; }
        /// <summary>
        /// 清空存储过程后缀
        /// </summary>
        public string ClearProcSuffix { get; set; }
    }
}
