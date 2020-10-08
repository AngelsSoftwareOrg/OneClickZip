using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OneClickZip.Includes.Classes;
using OneClickZip.Includes.Classes.TreeNodeSerialize;
using OneClickZip.Includes.Models.Events;
using OneClickZip.Includes.Resources;
using OneClickZip.Includes.Utilities;

namespace OneClickZip.Forms.Options
{
    public partial class FilterRuleFrm : Form
    {
        private FolderFilterRule folderFilterRule;
        private FolderFilterRule originalFolderFilterRule;
        private FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        private GenerateSerializableTreeNode generateSerializableTreeNode = new GenerateSerializableTreeNode();
        private bool isFormAlreadyLoaded = false;
        private readonly long PREVIEW_LIMIT = long.Parse(ResourcesUtil.GetSerializedTreeNodeGenerationPreviewLimit());

        public FilterRuleFrm(FolderFilterRule originalFolderFilterRule=null)
        {
            InitializeComponent();

            if (originalFolderFilterRule != null)
            {
                this.originalFolderFilterRule = originalFolderFilterRule;
                this.FolderFilterRule = (FolderFilterRule)originalFolderFilterRule.Clone();
            }
        }

        #region Buttons Area

        private void btnCancelExit_Click(object sender, EventArgs e)
        {
            this.generateSerializableTreeNode.StopGenerationProcess();
            this.FolderFilterRule = this.originalFolderFilterRule;
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveChanges();
            MessageBox.Show("Filter rule has been save into memory", "Save Successful!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void btnSaveAndExit_Click(object sender, EventArgs e)
        {
            SaveChanges();
            this.Close();
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
            FolderFilterRule.TimeSpanOptionValue = GetSelectedTimeSpanOption();
            FolderFilterRule.LastNumberOfDaysValue = int.Parse(numericUpDownLastXXDays.Value.ToString());
            FolderFilterRule.IncludeEmptyFolder = checkBoxIncludeEmptyFolder.Checked;
        }
        private void ManageTabContainerControls()
        {
            if (FolderFilterRule == null) return;
            if (tabControlMain.SelectedTab == tabPageFilterRule)
            {
                btnSaveLog.Visible = false;
                btnStopPreview.Visible = false;
                btnStartPreview.Visible = false;
                btnSave.Visible = true;
                btnSaveAndExit.Visible = true;
                generateSerializableTreeNode.StopGenerationProcess();
            }
            else
            {
                tabPagePreview.Show();
                btnSaveLog.Visible = true;
                btnStopPreview.Visible = false;
                btnStartPreview.Visible = true;
            }
            Application.DoEvents();
        }
        private void SetMinFileSizeHumanReadable()
        {
            lblFileMinSizeReadable.Text = ConverterUtils.HumanReadableFileSize(long.Parse(numericUpDownMinFileSize.Value.ToString()), 2);
        }
        private void SetMaxFileSizeHumanReadable()
        {
            lblFileMaxSizeReadable.Text = ConverterUtils.HumanReadableFileSize(long.Parse(numericUpDownMaxFileSize.Value.ToString()), 2);
        }
        private int SetTimeSpanDefault()
        {
            if (comboBoxTimeSpanOption.Items.Count<=0) return 0;
            for(int ctr=0; ctr< comboBoxTimeSpanOption.Items.Count; ctr++)
            {
                if (FolderFilterRule.GetTypeBaseOnValue(comboBoxTimeSpanOption.Items[ctr].ToString()) 
                                        == FolderFilterRule.TimeSpanOptionValue)
                {
                    return ctr;
                }
            }
            return 0;
        }
        private void AddListViewItem(GeneratingSerializeTreeNodeEventArgs e)
        {
            ListViewItem lvItem = new ListViewItem(new string[]
            {
                e.SequenceNumber.ToString(),
                e.HitFilterRule,
                e.ActionTaken,
                e.RelativeEvaluatedPath
            });
            listViewLogs.Items.Add(lvItem);
        }
        private void SetLabelProcessingText(String actionLabel, String description)
        {
            txtBoxProcessLog.Text = String.Format("{0} => {1}", actionLabel, description);
        }
        private void SetDescriptionForPreviewLimit()
        {
            txtBoxProcessLog.Text = String.Format("Preview Limit count of {0} for Files and Folder has been hit. " +
                        "Preview has been stopped automatically", this.PREVIEW_LIMIT);
        }
        private FolderFilterRule.TimeSpanOption GetSelectedTimeSpanOption()
        {
            return FolderFilterRule.GetTypeBaseOnValue(comboBoxTimeSpanOption.SelectedItem.ToString());
        }
        private bool IsFormValuesValidated()
        {
            String message = String.Empty;
            if (String.IsNullOrEmpty(txtBoxTargetDir.Text))
            {
                message = "Please select a target directory.";
            }
            else if (!FileSystemUtilities.IsDirectoryExistInTheSystem(txtBoxTargetDir.Text))
            {
                message = "Target directory value is not a valid or an existing directiory.";
            }
            else if (checkBoxHasMinFileSize.Checked && String.IsNullOrEmpty(((Control)numericUpDownMinFileSize).Text.ToString()))
            {
                message = "Please put a Minimum File Size";
            }
            else if (checkBoxHasMaxFileSize.Checked && String.IsNullOrEmpty(((Control)numericUpDownMaxFileSize).Text.ToString()))
            {
                message = "Please put a Maximum File Size";
            }
            else if (GetSelectedTimeSpanOption() == FolderFilterRule.TimeSpanOption.LAST_XX_DAYS 
                && String.IsNullOrEmpty(((Control)numericUpDownLastXXDays).Text.ToString()))
            {
                message = "Please put at least on day on the Last XX days field";
            }
            else if(checkBoxHasMaxFileSize.Checked && numericUpDownMaxFileSize.Value == 0)
            {
                message = "Please put a non zero value on Maximum File Size";
            }
            else if (checkBoxHasMinFileSize.Checked && checkBoxHasMaxFileSize.Checked)
            {
                if(numericUpDownMaxFileSize.Value <= numericUpDownMinFileSize.Value)
                {
                    message = "Maximum File Size should be higher";
                }
            }
            if (message == String.Empty) return true;
            MessageBox.Show(message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
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
            comboBoxTimeSpanOption.SelectedIndex = SetTimeSpanDefault();
            numericUpDownLastXXDays.Enabled = FolderFilterRule.TimeSpanOptionValue == FolderFilterRule.TimeSpanOption.LAST_XX_DAYS;
            numericUpDownLastXXDays.Value = FolderFilterRule.LastNumberOfDaysValue;
            numericUpDownMinFileSize.Enabled = FolderFilterRule.HasMinimumFileSize;
            numericUpDownMaxFileSize.Enabled = FolderFilterRule.HasMaximumFileSize;
            numericUpDownMinFileSize.Value = FolderFilterRule.MinimumFileSize;
            numericUpDownMaxFileSize.Value = FolderFilterRule.MaximumFileSize;
            txtBoxInclude.Text = FolderFilterRule.GetAggregatedIncludedList();
            txtBoxExclude.Text = FolderFilterRule.GetAggregatedExcludedList();
            txtBoxHelp.Text = ResourcesUtil.GetResourceFolderFilterHelpModel().Aggregate((x, y) => x + Environment.NewLine + y);

            //Events
            generateSerializableTreeNode.FinishedGeneration += GenerateSerializableTreeNode_FinishedGeneration;
            generateSerializableTreeNode.GenerationInitialization += GenerateSerializableTreeNode_GenerationInitialization;
            generateSerializableTreeNode.RuleEnforcementStatus += GenerateSerializableTreeNode_RuleEnforcementStatus;
            generateSerializableTreeNode.StopGeneration += GenerateSerializableTreeNode_StopGeneration;
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
            if(GetSelectedTimeSpanOption() == FolderFilterRule.TimeSpanOption.LAST_XX_DAYS)
            {
                numericUpDownLastXXDays.Enabled = true;
            }
            else
            {
                numericUpDownLastXXDays.Enabled = false;
            }
        }
        private void btnSaveLog_Click(object sender, EventArgs e)
        {
            FileSystemUtilities.SaveListViewItemsToLogFile(listViewLogs);
        }
        private void tabPagePreview_Enter(object sender, EventArgs e)
        {
            if(IsFormAlreadyLoaded) ManageTabContainerControls();
        }
        private void tabPageFilterRule_Enter(object sender, EventArgs e)
        {
            if (IsFormAlreadyLoaded) ManageTabContainerControls();
        }
        private void FilterRuleFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            generateSerializableTreeNode = null;
        }
        private void btnStopPreview_Click(object sender, EventArgs e)
        {
            generateSerializableTreeNode.StopGenerationProcess();
        }
        private void btnStartPreview_Click(object sender, EventArgs e)
        {
            OnGenerationProcessing_ButtonsHandlings(true);
            listViewLogs.Items.Clear();
            listViewLogs.BeginUpdate();
            SaveChanges();
            generateSerializableTreeNode.FolderFilterRuleObj = (FolderFilterRule)FolderFilterRule.Clone();
            generateSerializableTreeNode.StartGeneration();
        }
        private void FilterRuleFrm_Shown(object sender, EventArgs e)
        {
            IsFormAlreadyLoaded = true;
        }
        private void OnGenerationProcessing_ButtonsHandlings(bool started)
        {
            btnSave.Visible = !started;
            btnSaveAndExit.Visible = !started;
            btnStartPreview.Visible = !started;
            btnSaveLog.Visible = !started;
            btnStopPreview.Visible = started;

            if (tabControlMain.SelectedTab == tabPageFilterRule)
            {
                btnSaveLog.Visible = false;
                btnStartPreview.Visible = false;
                btnStopPreview.Visible = false;
            }
        }
        #endregion

        #region Events Serialized Tree Node Generation
        private void GenerateSerializableTreeNode_StopGeneration(object sender, GeneratingSerializeTreeNodeEventArgs e)
        {
            listViewLogs.EndUpdate();
            OnGenerationProcessing_ButtonsHandlings(false);
            txtBoxProcessLog.Text = "Rule filtering generation has been stop successfully...";
            if (e.ActualFilesProcessedCount > this.PREVIEW_LIMIT) SetDescriptionForPreviewLimit();
        }
        private void GenerateSerializableTreeNode_RuleEnforcementStatus(object sender, GeneratingSerializeTreeNodeEventArgs e)
        {
            if(e.ProcessingStage == GeneratingSerializeTreeNodeProcessingStage.ENFORCING_RULE_TO_FILE)
            {
                SetLabelProcessingText("Adding File", e.EvaluatedPath);
            }else if (e.ProcessingStage == GeneratingSerializeTreeNodeProcessingStage.ENFORCING_RULE_TO_FOLDER)
            {
                SetLabelProcessingText("Adding Folder", e.EvaluatedPath);
            }
            
            AddListViewItem(e);

            //If preview limit has been hit
            if (e.ActualFilesProcessedCount > this.PREVIEW_LIMIT) generateSerializableTreeNode.StopGenerationProcess();
        }
        private void GenerateSerializableTreeNode_GenerationInitialization(object sender, GeneratingSerializeTreeNodeEventArgs e)
        {
            SetLabelProcessingText("Initializing...", "Generation details");
            AddListViewItem(e);
        }
        private void GenerateSerializableTreeNode_FinishedGeneration(object sender, GeneratingSerializeTreeNodeEventArgs e)
        {
            txtBoxProcessLog.Text = "Rule filtering generation has been successfully finished...";
            listViewLogs.EndUpdate();
            OnGenerationProcessing_ButtonsHandlings(false);
            AddListViewItem(e);
        }
        private void tabControlMain_Click(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabPagePreview)
            {
                if (!IsFormValuesValidated())
                {
                    tabControlMain.SelectedTab = tabPageFilterRule;
                    tabPageFilterRule.Show();
                }
            }
        }
        #endregion

        #region Getters and Setters
        public FolderFilterRule FolderFilterRule {
            get
            {
                if (folderFilterRule == null) folderFilterRule = new FolderFilterRule();
                return folderFilterRule;
            }
            set
            {
                folderFilterRule = value;
            }
        }
        private bool IsFormAlreadyLoaded { get => isFormAlreadyLoaded; set => isFormAlreadyLoaded = value; }
        #endregion

    }
}
