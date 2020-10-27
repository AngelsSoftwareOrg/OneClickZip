using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            splashScreenDesigner.Dispose(true);
        }
    }
}
