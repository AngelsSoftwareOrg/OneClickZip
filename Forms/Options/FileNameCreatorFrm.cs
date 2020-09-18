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
    public partial class FileNameCreatorFrm : Form
    {
        private FileNameCreator filenameCreator = new FileNameCreator();

        public FileNameCreatorFrm()
        {
            InitializeComponent();
            CommonInitialization();
        }

        public FileNameCreatorFrm(String initialFileName)
        {
            InitializeComponent();
            filenameCreator.FileFormulaName = initialFileName;
            txtFileNameFormula.Text = initialFileName;
            CommonInitialization();
        }

        private void CommonInitialization()
        {
            InitializeControls();
        }

        private void InitializeControls()
        {
            listViewInstruction.Items.Clear();
            listViewInstruction.BeginUpdate();
            AddListViewInstructionItems(filenameCreator.GetResourcePropertiesList());
            listViewInstruction.EndUpdate();
        }

        private void AddListViewInstructionItems(List<ResourcePropertiesModel> arrayRpm)
        {
            foreach (ResourcePropertiesModel rpm in arrayRpm)
            {
                ListViewItem lvItem = new ListViewItem(new string[] { rpm.PropertyValue, rpm.Description });
                lvItem.Tag = rpm;
                listViewInstruction.Items.Add(lvItem);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FileNameCreatorFrm_Load(object sender, EventArgs e)
        {
            //DEBUG
            //txtFileNameFormula.Text = "Sample File Name - $RC{SHA1} - $RC{SHA256} - $RC{SHA512} - $DT{dddd} - $DT{hh} - $DT{ffffff} - $DT{fffffff} - $DT{yyyy}/$DT{MM}/$DT{dd} - $DT{HH}:$DT{mm}:$DT{ss} - $RN{3} - $RN{34,999}";
            //DEBUG END
        }

        private void ListViewInstruction_ItemSelectionChange(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewInstruction.SelectedItems == null) return;
            if (listViewInstruction.SelectedItems.Count <= 0) return;
            if (listViewInstruction.SelectedItems[0] == null) return;
            ResourcePropertiesModel rpm = (ResourcePropertiesModel) listViewInstruction.SelectedItems[0].Tag;
            txtSelectedVariable.Text = rpm.PropertyValue;
        }

        private void BtnSimulateFormula_Click(object sender, EventArgs e)
        {
            this.filenameCreator.FileFormulaName = txtFileNameFormula.Text;
            txtSimulatedFilename.Text = this.filenameCreator.GetDerivedFormula();
        }

        private void BtnCopyVar_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtSelectedVariable.Text);
        }

        private void BtnInsertVar_Click(object sender, EventArgs e)
        {
            txtFileNameFormula.Text = txtFileNameFormula.Text + " " + txtSelectedVariable.Text;
        }

        private void btnClearFilename_Click(object sender, EventArgs e)
        {
            txtFileNameFormula.Text = "";
        }

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            this.filenameCreator.FileFormulaName = txtFileNameFormula.Text;
            this.Close();
        }

        public FileNameCreator GetFileCreatorName()
        {
            return filenameCreator;
        }
    }
}
