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
using OneClickZip.Includes.Resources;
using OneClickZip.Includes.Utilities;

namespace OneClickZip.Forms.Options
{
    public partial class FilterRuleFrm : Form
    {
        private FolderFilterRule folderFilterRule = new FolderFilterRule();
        private FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

        public FilterRuleFrm()
        {
            InitializeComponent();
        }


        #region Buttons Area

        private void btnCancelExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }
        private void btnSaveAndExit_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        #endregion


        #region Custom Functions
        private void SaveChanges()
        {
            FolderFilterRule.ConsumeAggregatedExcludedList(txtBoxExclude.Text);
            FolderFilterRule.ConsumeAggregatedIncludedList(txtBoxInclude.Text);
            FolderFilterRule.TargetFolderPath = txtBoxTargetDir.Text;
            FolderFilterRule.HasMinimumFileSize = checkBoxHasMinFileSize.Checked;
            FolderFilterRule.MinimumFileSize = long.Parse(numericUpDownMinFileSize.Value.ToString());
            FolderFilterRule.HasMaximumFileSize = checkBoxHasMaxFileSize.Checked;
            FolderFilterRule.MaximumFileSize = long.Parse(numericUpDownMaxFileSize.Value.ToString());
            FolderFilterRule.TimeSpanOptionValue = FolderFilterRule.GetTypeBaseOnValue(comboBoxTimeSpanOption.SelectedItem.ToString());
            FolderFilterRule.LastNumberOfDaysValue = int.Parse(numericUpDownLastXXDays.Value.ToString());
            FolderFilterRule.IncludeEmptyFolder = checkBoxIncludeEmptyFolder.Checked;
        }
        #endregion


        #region Form Events
        private void FilterRuleFrm_Load(object sender, EventArgs e)
        {
            txtBoxTargetDir.Text = FolderFilterRule.TargetFolderPath;
            checkBoxHasMinFileSize.Checked = FolderFilterRule.HasMinimumFileSize;
            checkBoxHasMaxFileSize.Checked = FolderFilterRule.HasMaximumFileSize;
            checkBoxIncludeEmptyFolder.Checked = FolderFilterRule.IncludeEmptyFolder;
            comboBoxTimeSpanOption.Items.AddRange(FolderFilterRule.GetAllTimeSpanOptions());
            comboBoxTimeSpanOption.SelectedIndex = 0;
            numericUpDownLastXXDays.Enabled = false;
            numericUpDownMinFileSize.Enabled = false;
            numericUpDownMaxFileSize.Enabled = false;
            txtBoxInclude.Text = FolderFilterRule.GetAggregatedIncludedList();
            txtBoxExclude.Text = FolderFilterRule.GetAggregatedExcludedList();
        }
        private void checkBoxHasMinFileSize_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMinFileSize.Enabled = checkBoxHasMinFileSize.Checked;
        }
        private void checkBoxHasMaxFileSize_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMaxFileSize.Enabled = checkBoxHasMaxFileSize.Checked;
        }
        private void numericUpDownFileSize_ValueChanged(object sender, EventArgs e)
        {
            SetMinFileSizeHumanReadable();
        }
        private void numericUpDownFileSize_KeyUp(object sender, KeyEventArgs e)
        {
            SetMinFileSizeHumanReadable();
        }
        private void numericUpDownMaxFileSize_ValueChanged(object sender, EventArgs e)
        {
            SetMaxFileSizeHumanReadable();
        }
        private void numericUpDownMaxFileSize_KeyUp(object sender, KeyEventArgs e)
        {
            SetMaxFileSizeHumanReadable();
        }
        private void SetMinFileSizeHumanReadable()
        {
            lblFileMinSizeReadable.Text = ConverterUtils.HumanReadableFileSize(long.Parse(numericUpDownMinFileSize.Value.ToString()), 2);
        }
        private void SetMaxFileSizeHumanReadable()
        {
            lblFileMaxSizeReadable.Text = ConverterUtils.HumanReadableFileSize(long.Parse(numericUpDownMaxFileSize.Value.ToString()), 2);
        }
        private void btnTargetDirBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = ApplicationSettings.GetLastOpenedDirectory();
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.ShowDialog();

            if (String.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath)) return;
            txtBoxTargetDir.Text = folderBrowserDialog.SelectedPath;
            ApplicationSettings.SaveLastOpenedDirectory(folderBrowserDialog.SelectedPath);
        }
        private void comboBoxTimeSpanOption_SelectedValueChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBoxTimeSpanOption.SelectedItem.ToString())) return;
            if(FolderFilterRule.GetTypeBaseOnValue(
                comboBoxTimeSpanOption.SelectedItem.ToString()) == FolderFilterRule.TimeSpanOption.LAST_XX_DAYS)
            {
                numericUpDownLastXXDays.Enabled = true;
            }
            else
            {
                numericUpDownLastXXDays.Enabled = false;
            }
        }
        #endregion



        #region Getters and Setters
        public FolderFilterRule FolderFilterRule {
            get
            {
                if (folderFilterRule == null) return new FolderFilterRule();
                return folderFilterRule;
            }
            set
            {
                folderFilterRule = value;
            }
        }








        #endregion

    }
}
