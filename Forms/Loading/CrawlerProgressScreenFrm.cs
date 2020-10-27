using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OneClickZip.Includes.Models.Events;

namespace OneClickZip.Forms.Loading
{
    public partial class CrawlerProgressScreenFrm : Form
    {
        public event EventHandler<CrawlerProgressScreenEventArgs> CancelProgressEvent;
        private CrawlerProgressScreenEventArgs crawlerProgressScreenEventArgs = new CrawlerProgressScreenEventArgs();

        public CrawlerProgressScreenFrm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelProgress();
        }

        private void CrawlerProgressScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            CancelProgress();
        }

        private void CancelProgress()
        {
            progressBarStatus.Value = progressBarStatus.Maximum;
            txtBoxInfo.Text = "Cancelling, please wait...";
            CancelProgressEvent.Invoke(this, crawlerProgressScreenEventArgs);
        }

        private void CrawlerProgressScreen_Load(object sender, EventArgs e)
        {
            //ResetForms();
        }

        public String StatusText{
            set 
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    txtBoxStatusLabel.Text = "";
                }
                else
                {
                    txtBoxStatusLabel.Text = value;
                }
            }
        }

        public void ResetForms()
        {
            progressBarStatus.Value = 0;
            StatusText = "";
            txtBoxInfo.Text = "";
        }

        public int ProgressStatus
        {
            get
            {
                return progressBarStatus.Value;
            }
            set
            {
                if (value < 0) return;
                if(value > progressBarStatus.Maximum)
                {
                    progressBarStatus.Value = progressBarStatus.Maximum;
                }
                else
                {
                    progressBarStatus.Value = value;
                }
            }
        }

        public String Title
        {
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    this.Text = "Loading...";
                }
                else
                {
                    this.Text = value;
                }
            }
        }

    }
}
