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
using OneClickZip.Includes.Resources;

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
            txtBoxStatMsg.Text = String.Format(@"App Version {0}. Loading...", ApplicationSettings.ApplicationVersion);
            ApplicationArgumentModel appArg = ProjectSession.Instance().ApplicationArgumentModel;

            if (appArg.IsFileOpenCase)
            {
                txtBoxStatMsg.Text = String.Format(@"App Version {0}. Opening project '{1}' ...", 
                    ApplicationSettings.ApplicationVersion, appArg.FileName);
            }
        }

    }
}
