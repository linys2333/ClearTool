using ClearTool.Business.BO;
using DomainCore;
using LysExtend;

namespace ClearTool.Business.DS
{
    public class ConfigDS
    {
        public static Config SysList;

        public static ConfigDS GetInstance()
        {
            return ServiceFactory.GetService<ConfigDS>();
        }

        public virtual void LoadConfig(string path)
        {
            SysList = SerializeExt.XmlDeserialize<Config>(path, true);
        }

        public virtual void SaveConfig(string path)
        {
            SerializeExt.XmlSerialize(SysList ,path);
        }
    }
}
