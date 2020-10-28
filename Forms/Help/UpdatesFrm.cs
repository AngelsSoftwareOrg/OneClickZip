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
using OneClickZip.Includes.Interface.API;
using OneClickZip.Includes.Resources;

namespace OneClickZip.Forms.Help
{
    public partial class UpdatesFrm : Form
    {
        private ProjectRepositoryEndpoint projectRepositoryEndpoint = new ProjectRepositoryEndpoint();

        public UpdatesFrm()
        {
            InitializeComponent();
        }

        private void btnCheckForUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                btnCheckForUpdate.Enabled = false;
                richTxtBoxMessage.Clear();
                AddRichtextMessage("Application version:", Color.Black);
                AddRichtextMessage("   > " + ApplicationSettings.ApplicationVersion, Color.Orange);
                AddRichtextMessage(Environment.NewLine, Color.Black);
                AddRichtextMessage("Checking for updates...", Color.Black);
                IRepositoryRelease release = projectRepositoryEndpoint.RepositoryLatestRelease();

                if (projectRepositoryEndpoint.IsApplicationVersionUpToDate(release))
                {
                    AddRichtextMessage(Environment.NewLine, Color.Black);
                    AddRichtextMessage("[Release Notice of this update]", Color.Blue);
                    AddRichtextMessage(release.ReleaseNote, Color.Black);
                    AddRichtextMessage(Environment.NewLine, Color.Black);
                    AddRichtextMessage("Application is up to date...", Color.Green);
                    AddRichtextMessage(Environment.NewLine, Color.Black);
                }
                else
                {
                    AddRichtextMessage(Environment.NewLine, Color.Black);
                    AddRichtextMessage("!!! A new version was available !!!", Color.Orange);
                    AddRichtextMessage(Environment.NewLine, Color.Black);
                    AddRichtextMessage("[New Version]", Color.Blue);
                    AddRichtextMessage(release.ReleaseTagName, Color.Black);
                    AddRichtextMessage(Environment.NewLine, Color.Black);
                    AddRichtextMessage("[Release Notice]", Color.Blue);
                    AddRichtextMessage(release.ReleaseNote, Color.Black);
                    AddRichtextMessage(Environment.NewLine, Color.Black);
                    AddRichtextMessage("[Release package download URL]", Color.Blue);
                    AddRichtextMessage(release.ReleaseURL, Color.Black);
                }
            }
            catch (Exception ex)
            {
                AddRichtextMessage(Environment.NewLine, Color.Black);
                AddRichtextMessage(">>>>>>>>>>", Color.DarkBlue);
                AddRichtextMessage(ex.Message, Color.Red);
                AddRichtextMessage("<<<<<<<<<<", Color.DarkBlue);
                AddRichtextMessage(Environment.NewLine, Color.Black);
                AddRichtextMessage("Try again later to refresh request update quota or if your internet is stable...", Color.Orange);
            }
            btnCheckForUpdate.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddRichtextMessage(String message, Color color)
        {
            richTxtBoxMessage.SelectionStart = richTxtBoxMessage.TextLength;
            richTxtBoxMessage.SelectionLength = 0;

            richTxtBoxMessage.SelectionColor = color;
            richTxtBoxMessage.AppendText(message);
            richTxtBoxMessage.SelectionColor = richTxtBoxMessage.ForeColor;
            richTxtBoxMessage.AppendText(Environment.NewLine);
            richTxtBoxMessage.ScrollToCaret();
        }

    }
}
