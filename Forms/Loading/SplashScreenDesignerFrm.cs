using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OneClickZip.Includes.Classes;
using OneClickZip.Includes.Models;

namespace OneClickZip.Forms.Loading
{
    public partial class SplashScreenDesignerFrm : Form
    {
        private static SplashScreenDesignerFrm splashScreenDesigner;

        public static SplashScreenDesignerFrm GetIntance()
        {
            if (splashScreenDesigner == null) splashScreenDesigner = new SplashScreenDesignerFrm();
            return splashScreenDesigner;
        }

        private SplashScreenDesignerFrm()
        {
            InitializeComponent();
        }

        public void DisposeInstance()
        {
            Hide();
            if (splashScreenDesigner !=null) splashScreenDesigner.Dispose(true);
        }

        private void SplashScreenDesignerFrm_Load(object sender, EventArgs e)
        {
            txtBoxStatMsg.Text = "Loading...";
            ApplicationArgumentModel appArg = ProjectSession.Instance().ApplicationArgumentModel;

            if (appArg.IsFileOpenCase)
            {
                txtBoxStatMsg.Text = String.Format(@"Opening project '{0}' ...", appArg.FileName);
            }
        }

    }
}
