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
using System.Text.RegularExpressions;
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
                ListViewItem lvItem = new ListViewItem(new string[] { rpm.PropertyValue, rpm.Description })
                {
                    Tag = rpm
                };
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
            DeriveCreateFileNameFormula();
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
            DeriveCreateFileNameFormula();

            if (IsFileNameCreatedValid())
            {
                this.filenameCreator.FileFormulaName = txtFileNameFormula.Text;
                this.Close();
            }
        }

        private void DeriveCreateFileNameFormula()
        {
            this.filenameCreator.FileFormulaName = txtFileNameFormula.Text;
            txtSimulatedFilename.Text = this.filenameCreator.GetDerivedFormula();
            CountFileNameCharacters();
        }

        private void CountFileNameCharacters()
        {
            long totalCount = 0;
            totalCount = (txtSimulatedFilename.Text == null) ? 0 : txtSimulatedFilename.Text.Length;
            String labelDisplay = "(Character Count: {0})";
            lblCharCount.Text = String.Format(labelDisplay, totalCount);
        }
        private bool IsFileNameCreatedValid()
        {
            if(txtSimulatedFilename.Text == null)
            {
                MessageBox.Show("Please input Zip File Name to use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtSimulatedFilename.Text.Trim().Length<=0)
            {
                MessageBox.Show("Please input Zip File Name to use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtSimulatedFilename.Text.Trim().Length >= 256)
            {
                MessageBox.Show("Please limit your zip file name within 256 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            MatchCollection matchValueCol = Regex.Matches(txtFileNameFormula.Text.Trim(), CreatorModel.FORMULA_PATTER_REGEX_COMPLETE);
            if (matchValueCol.Count <= 0)
            {
                MessageBox.Show("It seems you had no dynamic reference added in your file name. It is better to " +
                    "add a dynamic value to minimize overwriting the same zip file on the system", 
                    "Warning to prevent OVERWRITING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            return true;
        }

        public FileNameCreator GetFileCreatorNameModel()
        {
            return filenameCreator;
        }
    }
}
