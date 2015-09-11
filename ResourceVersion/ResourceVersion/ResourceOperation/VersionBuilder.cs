using System;
using System.IO;
using System.Collections;
using System.Xml;

namespace ResourceVersion.ResourceOperation
{
    public class VersionBuilder
    {
        static ArrayList m_AssetList = null;
        static XmlDocument m_XMlDoc = null;

        static public void BuildVersion()
        {
            DeleteOldResource();
            GetBaseInfo();
        }

        static void DeleteOldResource()
        {
            if(Directory.Exists(VersionManager.strCueOutPath))
            {
                Directory.Delete(VersionManager.strCueOutPath);
            }

            Directory.CreateDirectory(VersionManager.strCueOutPath);
        }

        static void GetBaseInfo()
        {
            ArrayList files = ResourceManager.GetAllAsset();
            m_AssetList = new ArrayList();

            foreach (FileInfo item in files)
            {
                Common.AeestStruce asset = new Common.AeestStruce();

                asset.ID = item.Name;
                asset.Path = item.FullName;

                m_AssetList.Add(asset);
            }
        }

        static void Process()
        {
            InitXML();


        }

        static void InitXML()
        {
            m_XMlDoc = new XmlDocument();
            XmlDeclaration dec = m_XMlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            m_XMlDoc.AppendChild(dec);
        }
    }
}
