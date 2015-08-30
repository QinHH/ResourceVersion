using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourceVersion
{
    public partial class FormMain : Form
    {
        private ResourceOperation.ResourceManager m_ResourceManager = null;

        public FormMain()
        {
            m_ResourceManager = new ResourceOperation.ResourceManager();
            InitializeComponent();
        }

        private void labStandaloneOutPtah_Click(object sender, EventArgs e)
        {
            Common.PathMgr.strStandAloneOutPath = ShowDirectionSelect();
            labStandaloneOutPtah.Text = Common.PathMgr.strStandAloneOutPath;
        }

        private void labStandaloneResourcePtah_Click(object sender, EventArgs e)
        {
            Common.PathMgr.strStandAloneGetPath = ShowDirectionSelect();
            labStandaloneResourcePtah.Text = Common.PathMgr.strStandAloneGetPath;
        }

        private void labAndroidResourcePtah_Click(object sender, EventArgs e)
        {
            Common.PathMgr.strAndroidGetPath = ShowDirectionSelect();
            labAndroidResourcePtah.Text = Common.PathMgr.strAndroidGetPath;
        }

        private void labAndroidOutPtah_Click(object sender, EventArgs e)
        {
            Common.PathMgr.strAndroidOutPath = ShowDirectionSelect();
            this.labAndroidOutPtah.Text = Common.PathMgr.strAndroidOutPath;
        }

        private void labIOSResourcePath_Click(object sender, EventArgs e)
        {
            Common.PathMgr.strIOSGetPath = ShowDirectionSelect();
            this.labIOSResourcePath.Text = Common.PathMgr.strIOSGetPath;
        }

        private void labIOSOutPath_Click(object sender, EventArgs e)
        {
            Common.PathMgr.strIOSOutPath = ShowDirectionSelect();
            this.labIOSOutPath.Text = Common.PathMgr.strIOSOutPath;
        }

        private void btnStandalone_Click(object sender, EventArgs e)
        {

        }

        private void btnAndroid_Click(object sender, EventArgs e)
        {

        }

        private void btnIOS_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            SetPathLabel();
        }

        private void SetPathLabel()
        {
            labStandaloneOutPtah.Text = string.IsNullOrEmpty(Common.PathMgr.strAndroidGetPath) ?
                Common.CustomDefine.showPathNone : Common.PathMgr.strAndroidGetPath;

            labAndroidOutPtah.Text = string.IsNullOrEmpty(Common.PathMgr.strAndroidOutPath) ?
                Common.CustomDefine.showPathNone : Common.PathMgr.strAndroidOutPath;

            labIOSOutPath.Text = string.IsNullOrEmpty(Common.PathMgr.strIOSOutPath) ?
                Common.CustomDefine.showPathNone : Common.PathMgr.strIOSOutPath;

            labStandaloneResourcePtah.Text = string.IsNullOrEmpty(Common.PathMgr.strStandAloneGetPath) ?
                Common.CustomDefine.showPathNone : Common.PathMgr.strStandAloneGetPath;

            labAndroidResourcePtah.Text = string.IsNullOrEmpty(Common.PathMgr.strAndroidGetPath) ?
                Common.CustomDefine.showPathNone : Common.PathMgr.strAndroidGetPath;

            labIOSResourcePath.Text = string.IsNullOrEmpty(Common.PathMgr.strIOSGetPath) ?
                Common.CustomDefine.showPathNone : Common.PathMgr.strIOSGetPath;
        }

        private string ShowDirectionSelect()
        {
            if (this.SelectWindow.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(this.SelectWindow.SelectedPath))
                {
                    return Common.CustomDefine.showPathNone;
                }
                else
                {
                    return this.SelectWindow.SelectedPath;
                }
            }

            return "";
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.PathMgr.SavePath();
        }
    }
}
