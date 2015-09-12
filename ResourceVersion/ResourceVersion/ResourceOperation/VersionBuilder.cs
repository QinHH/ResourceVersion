using System;
using System.IO;
using System.Collections;
using System.Xml;
using System.Text;
using System.Windows.Forms;

namespace ResourceVersion.ResourceOperation
{
    public class VersionBuilder
    {
        static ArrayList m_AssetList = null;
        static XmlDocument m_XMlDoc = null;
        static XmlElement m_rootElement = null;

        static public void BuildVersion()
        {
            DeleteOldResource();
            GetBaseInfo();
            Process();
        }

        static void DeleteOldResource()
        {
            if(Directory.Exists(VersionManager.strCueOutPath))
            {
                Directory.Delete(VersionManager.strCueOutPath, true);
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

                asset.ID = Path.GetFileNameWithoutExtension(item.FullName);
                asset.FullName = item.FullName;
                asset.Size = item.Length;

                m_AssetList.Add(asset);
            }
        }

        static void Process()
        {
            InitXML();

            foreach (Common.AeestStruce item in m_AssetList)
            {
                ProcessFile(item);
            }

            m_XMlDoc.Save(VersionManager.strCueOutPath + "/version.xml");
            Application.Exit();
        }

        static void InitXML()
        {
            m_XMlDoc = new XmlDocument();
            XmlDeclaration dec = m_XMlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            m_XMlDoc.AppendChild(dec);

            m_rootElement = m_XMlDoc.CreateElement("Contacts");
            m_XMlDoc.AppendChild(m_rootElement);
        }

        static void ProcessFile(Common.AeestStruce fileInfo)
        {
            FileStream stream = File.Open(fileInfo.FullName, FileMode.Open);
            string hashCode = GetMD5HashFromFile(stream);
            stream.Close();

            string folderName = hashCode.Substring(0, 1);

            string folderPath = VersionManager.strCueOutPath + "/" + folderName;
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            folderPath += ("/" + hashCode + ".encoder");
            File.Copy(fileInfo.FullName, folderPath);

            stream = File.Open(folderPath, FileMode.Open);

            folderPath = folderName + "/" + hashCode + ".encoder";
            fileInfo.Folder = folderName;
            fileInfo.Path = folderPath;
            fileInfo.Key = hashCode;
            fileInfo.Size = stream.Length;

            stream.Close();

            WriteXML(fileInfo);
        }

        static void WriteXML(Common.AeestStruce fileInfo)
        {
            XmlElement elementContact = m_XMlDoc.CreateElement("Contact");
            //             XmlAttribute attrID = m_XMlDoc.CreateAttribute("ID");
            //             attrID.Value = fileInfo.ID;
            //             elementContact.Attributes.Append(attrID);
            //             m_rootElement.AppendChild(elementContact);

            elementContact.SetAttribute("Path", fileInfo.Path);
            elementContact.SetAttribute("Folder", fileInfo.Folder);
            elementContact.SetAttribute("Key", fileInfo.Key);
            elementContact.SetAttribute("Size", fileInfo.Size.ToString());
            elementContact.SetAttribute("ID", fileInfo.ID);

            //XmlElement elementID = m_XMlDoc.CreateElement("ID");
            //elementID.InnerText = fileInfo.ID;
            //elementContact.AppendChild(elementID);

            //XmlElement elementSize = m_XMlDoc.CreateElement("Size");
            //elementSize.InnerText = fileInfo.Size.ToString();
            //elementContact.AppendChild(elementSize);

            //XmlElement elementKey = m_XMlDoc.CreateElement("Key");
            //elementKey.InnerText = fileInfo.Key;
            //elementContact.AppendChild(elementKey);

            //XmlElement elementFolder = m_XMlDoc.CreateElement("Folder");
            //elementFolder.InnerText = fileInfo.Folder;
            //elementContact.AppendChild(elementFolder);

            //XmlElement elementPath = m_XMlDoc.CreateElement("Path");
            //elementPath.InnerText = fileInfo.Path;
            //elementContact.AppendChild(elementPath);

            m_rootElement.AppendChild(elementContact);
        }

        static string GetMD5HashFromFile(FileStream stream)
        {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(stream);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
