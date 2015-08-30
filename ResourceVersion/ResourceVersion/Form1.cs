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
        }

        private void labStandaloneResourcePtah_Click(object sender, EventArgs e)
        {

        }

        private void labAndroidResourcePtah_Click(object sender, EventArgs e)
        {

        }

        private void labAndroidOutPtah_Click(object sender, EventArgs e)
        {

        }

        private void labIOSResourcePath_Click(object sender, EventArgs e)
        {

        }

        private void labIOSOutPath_Click(object sender, EventArgs e)
        {

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
    }
}
