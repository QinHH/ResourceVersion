using System;
using System.Configuration;

namespace ResourceVersion
{
    class ConfigurationMgr
    {
        static ConfigurationMgr()
        {
            KeyValueConfigurationElement element = null;
        }

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

        static public void AddConfigurationElement(string key,string value)
        {
            config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, value);

            config.Save(ConfigurationSaveMode.Modified);
        }

        static public string ReadConfigurationElement(string key)
        {
            KeyValueConfigurationElement element = null;
            element = config.AppSettings.Settings[key];

            return null == element ? string.Empty : element.Value;
        }
    }
}
