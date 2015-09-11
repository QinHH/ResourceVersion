using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public void Build(E_BUILDTYPE doType)
        {
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
        }
    }
}
