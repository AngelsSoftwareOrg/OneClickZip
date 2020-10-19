using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneClickZip.Forms.Help
{
    public partial class AboutFrm : Form
    {
        public AboutFrm()
        {
            InitializeComponent();
            
        }

        private void About_Load(object sender, EventArgs e)
        {
            txtBoxTitle.Text = Properties.Settings.Default.about_title;
            txtBoxAuthor.Text = Properties.Settings.Default.about_author;
            txtBoxEmail.Text = Properties.Settings.Default.about_email;
            txtBoxWebsiteTitle.Text = Properties.Settings.Default.about_website_title;
            txtBoxWebSiteLink.Text = Properties.Settings.Default.about_website_link;
            txtBoxVersion.Text = String.Format("v{0}.{1}.{2} {3}",
                                    Properties.Settings.Default.app_version_major,
                                    Properties.Settings.Default.app_version_minor,
                                    Properties.Settings.Default.app_version_patch,
                                    Properties.Settings.Default.app_version_revision);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
