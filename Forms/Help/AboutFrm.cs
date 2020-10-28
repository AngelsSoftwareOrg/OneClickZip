using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OneClickZip.Includes.Resources;

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
            txtBoxWebSiteLink.Text = ApplicationSettings.ApplicationWebsiteLink;
            txtBoxVersion.Text = ApplicationSettings.ApplicationVersion;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
