using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneClickZip.Forms.Options
{
    public partial class FileNameCreatorFrm : Form
    {
        public FileNameCreatorFrm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FileNameCreatorFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
