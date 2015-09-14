using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
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
        static List<AutoPb.ResourceItem> m_lstResourceList = null;

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
                string[] strs = item.FullName.Split('.');
                if (!strs[1].Equals("encoder"))
                {
                    continue;
                }

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
            m_lstResourceList = new List<AutoPb.ResourceItem>();

            foreach (Common.AeestStruce item in m_AssetList)
            {
                ProcessFile(item);
            }

            m_XMlDoc.Save(VersionManager.strCueOutPath + "/version.xml");
            //             using (FileStream fileStream = new FileStream(VersionManager.strCueOutPath + "/SourceList.encoder", FileMode.Create, FileAccess.ReadWrite))
            //             {
            //                 ProtoBuf.Serializer.Serialize<List<AutoPb.ResourceItem>>(fileStream, m_lstResourceList);
            //             }
            //              using (FileStream fileStream = File.Create(VersionManager.strCueOutPath + "/SourceList.encoder"))
            //              {
            //                  using (MemoryStream memoryStream = new MemoryStream())
            //                  {
            //                      ProtoBuf.Serializer.Serialize<List<AutoPb.ResourceItem>>(memoryStream, m_lstResourceList);
            //  
            //                      SevenZip.Compression.LZMA.Encoder encoder = new SevenZip.Compression.LZMA.Encoder();
            //                      encoder.WriteCoderProperties(fileStream);
            //  
            //                      fileStream.Write(System.BitConverter.GetBytes(memoryStream.Length), 0, 8);
            //  
            //                      encoder.Code(memoryStream, fileStream, memoryStream.Length, -1, null);
            //                  }
            //              }
            using (MemoryStream memoryStream = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize<List<AutoPb.ResourceItem>>(memoryStream, m_lstResourceList);
                EncoderStream.Encoder(VersionManager.strCueOutPath + "/SourceList.encoder", memoryStream);
            }
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
            AddToSourceList(fileInfo);

            WriteVersionNum();
        }

        static void WriteXML(Common.AeestStruce fileInfo)
        {
            XmlElement elementContact = m_XMlDoc.CreateElement("Contact");

            elementContact.SetAttribute("ID", fileInfo.ID);
            elementContact.SetAttribute("Size", fileInfo.Size.ToString());
            elementContact.SetAttribute("Key", fileInfo.Key);
            elementContact.SetAttribute("Folder", fileInfo.Folder);
            elementContact.SetAttribute("Path", fileInfo.Path);

            m_rootElement.AppendChild(elementContact);
        }

        static void AddToSourceList(Common.AeestStruce fileInfo)
        {
            AutoPb.ResourceItem item = new AutoPb.ResourceItem();

            item.ID = fileInfo.ID;
            item.Key = fileInfo.Key;
            item.Size = fileInfo.Size;
            item.Folder = fileInfo.Folder;
            item.Path = fileInfo.Path;

            m_lstResourceList.Add(item);
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

        static void WriteVersionNum()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                byte[] byteArray = System.Text.Encoding.Default.GetBytes(VersionManager.VersionNum);
                stream.Write(byteArray, 0, byteArray.Length);
                EncoderStream.Encoder(VersionManager.strCueOutPath + "/VersionNum.encoder", stream);
            }
        }
    }
}
