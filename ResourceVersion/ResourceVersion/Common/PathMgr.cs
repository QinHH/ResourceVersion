using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceVersion.Common
{
    internal class PathMgr
    {
        static public string strStandAloneOutPath = string.Empty;
        static public string strIOSOutPath = string.Empty;
        static public string strAndroidOutPath = string.Empty;
         
        static public string strStandAloneGetPath = string.Empty;
        static public string strIOSGetPath = string.Empty;
        static public string strAndroidGetPath = string.Empty;

        static public void SavePath()
        {
            ConfigurationMgr.AddConfigurationElement(CustomDefine.configKey_StandealoneOutPath, strStandAloneOutPath);
            ConfigurationMgr.AddConfigurationElement(CustomDefine.configKey_IOSOutPath, strIOSOutPath);
            ConfigurationMgr.AddConfigurationElement(CustomDefine.configKey_AndroidOutPath, strAndroidOutPath);
            ConfigurationMgr.AddConfigurationElement(CustomDefine.configKey_IOSGetPath, strIOSGetPath);
            ConfigurationMgr.AddConfigurationElement(CustomDefine.configKey_AndroidGetPath, strStandAloneOutPath);
            ConfigurationMgr.AddConfigurationElement(CustomDefine.configKey_StandealoneOutPath, strAndroidGetPath);
        }

        static PathMgr()
        {
            strStandAloneOutPath = ConfigurationMgr.ReadConfigurationElement(CustomDefine.configKey_StandealoneOutPath);

            strIOSOutPath = ConfigurationMgr.ReadConfigurationElement(CustomDefine.configKey_IOSOutPath);

            strAndroidOutPath = ConfigurationMgr.ReadConfigurationElement(CustomDefine.configKey_AndroidOutPath);

            strStandAloneGetPath = ConfigurationMgr.ReadConfigurationElement(CustomDefine.configKey_StandealoneGetPath);

            strIOSGetPath = ConfigurationMgr.ReadConfigurationElement(CustomDefine.configKey_IOSGetPath);

            strAndroidGetPath = ConfigurationMgr.ReadConfigurationElement(CustomDefine.configKey_AndroidGetPath);
        }
    }
}
