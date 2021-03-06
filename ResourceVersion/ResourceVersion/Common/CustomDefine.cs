﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceVersion.Common
{
    public class CustomDefine
    {
        public const string configKey_StandealoneOutPath = "StandealoneOutPath";
        public const string configKey_StandealoneGetPath = "StandealoneGetPath";
        public const string configKey_AndroidOutPath = "AndroidOutPath";
        public const string configKey_AndroidGetPath = "AndroidGetPath";
        public const string configKey_IOSOutPath = "IOSOutPath";
        public const string configKey_IOSGetPath = "IOSGetPath";

        public const string configKey_VersionNum = "VersionNum";

        public const string showPathNone = "点击选择路径";
    }

    public struct AeestStruce
    {
        public string ID;
        public long Size;
        public string Folder;
        public string Path;
        public string Key;
        public string FullName;
        public long OriginalSize;
    }
}
