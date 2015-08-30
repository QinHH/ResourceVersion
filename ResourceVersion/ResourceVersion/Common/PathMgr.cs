using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceVersion.Common
{
    internal class PathMgr
    {
        private readonly string strStandAloneOutPath = string.Empty;
        private readonly string strIOSOutPath = string.Empty;
        private readonly string strAndroidOutPath = string.Empty;

        private readonly string strStandAloneGetPath = string.Empty;
        private readonly string strIOSGetPath = string.Empty;
        private readonly string strAndroidGetPath = string.Empty;

        public PathMgr()
        {
            GetAllPath();
        }

        private void GetAllPath()
        {

        }
    }
}
