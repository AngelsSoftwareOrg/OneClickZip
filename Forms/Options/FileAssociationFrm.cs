using OneClickZip.Includes.Classes;
using OneClickZip.Includes.Models;
using OneClickZip.Includes.Resources;
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
    public partial class FileAssociationFrm : Form
    {
        private FileAssociationModel[] fileAssoc;

        public FileAssociationFrm()
        {
            InitializeComponent();
            fileAssoc = new FileAssociationModel[]{
                    ResourcesUtil.GetFileAssociationProjectDesignerModel(""),
                    ResourcesUtil.GetFileAssociationBatchFileModel(""),
                };
        }

        private void FileAssociationFrm_Load(object sender, EventArgs e)
        {
            listViewFileAssc.Items.Clear();
            listViewFileAssc.BeginUpdate();

            foreach(FileAssociationModel fam in fileAssoc)
            {
                ListViewItem lvi = new ListViewItem(new string[]{
                    fam.Extension,
                    fam.FileTypeDescription
                });
                listViewFileAssc.Items.Add(lvi);
            }
            listViewFileAssc.EndUpdate();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAssociateNow_Click(object sender, EventArgs e)
        {
            if (FileAssociation.IsApplicationProgramAlreadyAssociatedWith())
            {
                DialogResult dr1 = MessageBox.Show("The application program was already associated with! " +
                    "Do you want to replace/refresh the file association again?", "File Association", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr1 == DialogResult.No) return;
            }

            DialogResult dr = MessageBox.Show("Proceed association on the system?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if(dr == DialogResult.Yes)
            {
                FileAssociation.EnsureAssociationsSet();
                MessageBox.Show("File association done!", "File Association", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FileAssociationFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fileAssoc = null;
        }
    }
}
