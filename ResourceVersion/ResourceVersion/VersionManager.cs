using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourceVersion
{
    public class VersionManager
    {
        public enum E_BUILDTYPE
        {
            E_BUILDTYPE_STANDALONE,
            E_BUILDTYPE_IOS,
            E_BUILDTYPE_ANDROID,
        }

        static string m_VersiongNum = string.Empty;
        static public string VersionNum
        {
            get
            {
                return m_VersiongNum;
            }
        }

        static private E_BUILDTYPE m_buildType = E_BUILDTYPE.E_BUILDTYPE_STANDALONE;
        static public E_BUILDTYPE buildType
        {
            get
            {
                return m_buildType;
            }
        }

        static private string m_strCurOutPath = string.Empty;
        static public string strCueOutPath
        {
            get
            {
                return m_strCurOutPath;
            }
        }

        static private string m_strCurGetPath = string.Empty;
        static public string strCueGetPath
        {
            get
            {
                return m_strCurGetPath;
            }
        }

        public VersionManager()
        {
        }


        static public void Build(E_BUILDTYPE doType,string VersionNum)
        {
            if (string.IsNullOrEmpty(VersionNum))
            {
                MessageBox.Show("请输入版本号！");
                return;
            }

            m_VersiongNum = VersionNum;
            ConfigurationMgr.AddConfigurationElement(Common.CustomDefine.configKey_VersionNum, m_VersiongNum);

            m_buildType = doType;

            switch (VersionManager.buildType)
            {
                case (VersionManager.E_BUILDTYPE.E_BUILDTYPE_STANDALONE):
                    {
                        m_strCurGetPath = Common.PathMgr.strStandAloneGetPath;
                        m_strCurOutPath = Common.PathMgr.strStandAloneOutPath;
                    }
                    break;

                case (VersionManager.E_BUILDTYPE.E_BUILDTYPE_IOS):
                    {
                        m_strCurGetPath = Common.PathMgr.strIOSGetPath;
                        m_strCurOutPath = Common.PathMgr.strIOSOutPath;
                    }
                    break;

                case (VersionManager.E_BUILDTYPE.E_BUILDTYPE_ANDROID):
                    {
                        m_strCurGetPath = Common.PathMgr.strAndroidGetPath;
                        m_strCurOutPath = Common.PathMgr.strAndroidOutPath;
                    }
                    break;
            }

            ResourceOperation.VersionBuilder.BuildVersion();

            Application.Exit();
        }
    }
}
