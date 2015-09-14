using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

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

        static private Configuration m_Config = null;
        static private Configuration config
        {
            get
            {
                if (null == m_Config)
                {
                    string file = System.Windows.Forms.Application.ExecutablePath;
                    m_Config = ConfigurationManager.OpenExeConfiguration(file);
                }

                return m_Config;
            }
        }

        static public void SavePath()
        {
            config.AppSettings.Settings.Remove(CustomDefine.configKey_StandealoneOutPath);
            config.AppSettings.Settings.Remove(CustomDefine.configKey_IOSOutPath);
            config.AppSettings.Settings.Remove(CustomDefine.configKey_AndroidOutPath);
            config.AppSettings.Settings.Remove(CustomDefine.configKey_StandealoneGetPath);
            config.AppSettings.Settings.Remove(CustomDefine.configKey_IOSGetPath);
            config.AppSettings.Settings.Remove(CustomDefine.configKey_AndroidGetPath);

            config.AppSettings.Settings.Add(CustomDefine.configKey_StandealoneOutPath, strStandAloneOutPath);
            config.AppSettings.Settings.Add(CustomDefine.configKey_IOSOutPath, strIOSOutPath);
            config.AppSettings.Settings.Add(CustomDefine.configKey_AndroidOutPath, strAndroidOutPath);
            config.AppSettings.Settings.Add(CustomDefine.configKey_StandealoneGetPath, strStandAloneGetPath);
            config.AppSettings.Settings.Add(CustomDefine.configKey_IOSGetPath, strIOSGetPath);
            config.AppSettings.Settings.Add(CustomDefine.configKey_AndroidGetPath, strAndroidGetPath);

            config.Save(ConfigurationSaveMode.Modified);
        }

        static PathMgr()
        {
            KeyValueConfigurationElement element = null;

            element = config.AppSettings.Settings[CustomDefine.configKey_StandealoneOutPath];
            strStandAloneOutPath = null == element ? string.Empty : element.Value;

            element = config.AppSettings.Settings[CustomDefine.configKey_IOSOutPath];
            strIOSOutPath = null == element ? string.Empty : element.Value;

            element = config.AppSettings.Settings[CustomDefine.configKey_AndroidOutPath];
            strAndroidOutPath = null == element ? string.Empty : element.Value;

            element = config.AppSettings.Settings[CustomDefine.configKey_StandealoneGetPath];
            strStandAloneGetPath = null == element ? string.Empty : element.Value;

            element = config.AppSettings.Settings[CustomDefine.configKey_IOSGetPath];
            strIOSGetPath = null == element ? string.Empty : element.Value;

            element = config.AppSettings.Settings[CustomDefine.configKey_AndroidGetPath];
            strAndroidGetPath = null == element ? string.Empty : element.Value;
        }
    }
}
