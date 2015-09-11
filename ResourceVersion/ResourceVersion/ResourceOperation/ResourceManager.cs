using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace ResourceVersion.ResourceOperation
{
    public class ResourceManager
    {
        public static ArrayList GetAllAsset()
        {
            ArrayList list = new ArrayList();
            DirectoryInfo info = new DirectoryInfo(VersionManager.strCueGetPath);
            GetAllFile(info, list);
            return list;
        }

        public static void GetAllFile(DirectoryInfo info,ArrayList list)
        {
            FileInfo[] files = info.GetFiles();
            for (int i = 0, max = files.Length; i < max; i++)
            {
                list.Add(files[i]);
            }

            DirectoryInfo[] directions = info.GetDirectories();
            for (int i = 0, max = directions.Length; i < max; i++)
            {
                GetAllFile(info, list);
            }
        }
    }
}
