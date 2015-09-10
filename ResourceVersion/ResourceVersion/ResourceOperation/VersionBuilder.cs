using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceVersion.ResourceOperation
{
    public class VersionBuilder
    {
        static public void BuildVersion()
        {
            DeleteOldResource();

            
        }

        static void DeleteOldResource()
        {
            if(Directory.Exists(VersionManager.strCueOutPath))
            {
                Directory.Delete(VersionManager.strCueOutPath);
            }

            Directory.CreateDirectory(VersionManager.strCueOutPath);
        }
    }
}
