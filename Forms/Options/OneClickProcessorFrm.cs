using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OneClickZip.Includes.Classes;
using OneClickZip.Includes.Classes.Extensions;
using OneClickZip.Includes.Classes.TreeNodeSerialize;
using OneClickZip.Includes.Models;
using OneClickZip.Includes.Models.Events;
using OneClickZip.Includes.Resources;
using OneClickZip.Includes.Utilities;

namespace OneClickZip.Forms.Options
{
    public partial class OneClickProcessorFrm : Form
    {
        private ProjectSession projectSession;
        private ApplicationArgumentModel applicationArgumentModel;
        private ZipFileModel zipModel;
        private ZipFileStatisticsModel zipFileStatisticsModel;
        private long elapseTime = 0;
        private ZipArchiving zipArchiving = new ZipArchiving();
        private bool isWindowCanBeClose = false;
        public OneClickProcessorFrm()
        {
            InitializeComponent();
            projectSession = ProjectSession.Instance();
            applicationArgumentModel = projectSession.ApplicationArgumentModel;
        }

        private void OneClickProcessor_Load(object sender, EventArgs e)
        {
            lblElapsedTime.Text = "00:00:00";
            lblFilesAdded.Text = "0% > 0";
            lblFoldersCreated.Text = "0% > 0";
            lblTotalFilesCount.Text = "0";
            lblTotalFoldersCount.Text = "0";
            lblEstimatedSize.Text = "0";
            listViewLogs.DoubleBuffering(true);
            listViewLogs.Items.Clear();
            listViewLogs.BeginUpdate();
            timerElapseTime.Enabled = true;
            timerElapseTime.Start();
            linkSaveLogs.Enabled = false;
            elapseTime = 0;
            isWindowCanBeClose = false;
            this.Show();
            zipArchiving.ProcessingStatus += ZipArchiving_ProcessingStatus;
            zipArchiving.ProgressStatus += ZipArchiving_ProgressStatus;
            zipArchiving.FinishedArchiving += ZipArchiving_FinishedArchiving;
            zipArchiving.StopProcess += ZipArchiving_StopProcess;
            zipArchiving.SerializedTreeNodeGeneratedComplete += ZipArchiving_SerializedTreeNodeGeneratedComplete;
            OpenProjectFileForZipping();
        }

        private void ZipArchiving_StopProcess(object sender, ZipArchivingEventArgs e)
        {
            timerElapseTime.Stop();
            progressBarStatus.Value = progressBarStatus.Maximum;
            txtBoxCurrentAction.Text = "Zip Archiving Stopped...";
            AddLogItems("Archiving Ended", "Successfully stop further zip archiving");
            AddLogItems("Project File", @"Project file that has been processed is ");
            AddLogItems("Project File", e.ZipFileToCreateFullPath);
            AddLogItems("Zip Archive Location", @"Partial zip file has been save into....");
            AddLogItems("Zip Archive Location", zipArchiving.NewArchiveName);
            linkSaveLogs.Enabled = true;
            btnStop.Enabled = false;
            isWindowCanBeClose = true;
            listViewLogs.EndUpdate();
        }

        private void ZipArchiving_FinishedArchiving(object sender, ZipArchivingEventArgs e)
        {
            timerElapseTime.Stop();
            txtBoxCurrentAction.Text = "Finished Zip Archiving...";
            AddLogItems("Wrapping up", txtBoxCurrentAction.Text);
            AddLogItems("Project File", @"Project file that has been processed is ");
            AddLogItems("Project File", e.ZipFileToCreateFullPath);
            AddLogItems("Zip Archive Location", @"Zip file has been save into....");
            AddLogItems("Zip Archive Location", zipArchiving.NewArchiveName);
            linkSaveLogs.Enabled = true;
            btnStop.Enabled = false;
            isWindowCanBeClose = true;
            listViewLogs.EndUpdate();
        }

        private void ZipArchiving_ProgressStatus(object sender, ZipArchivingEventArgs e)
        {
            if(this.progressBarStatus.Value != e.ProgressStatusPercentage)
            {
                this.progressBarStatus.Value = e.ProgressStatusPercentage;
            }
            DisplayProcessedFile(e);
        }
        private void ZipArchiving_SerializedTreeNodeGeneratedComplete(object sender, ZipArchivingEventArgs e)
        {
            GetStatistic(zipArchiving.GetStatistic());
        }
        private void ZipArchiving_ProcessingStatus(object sender, ZipArchivingEventArgs e)
        {
            DisplayProcessedFile(e);
        }

        private void DisplayProcessedFile(ZipArchivingEventArgs e)
        {
            Application.DoEvents();
            if (e.ProcessingStage == ZipProcessingStages.ADDING_FOLDER)
            {
                txtBoxCurrentAction.Text = "Creating Folder => " + e.FileName;
                AddLogItems("Adding Folder", e.FileName);
                lblFoldersCreated.Text = String.Format("{0}% > {1}",
                    ConverterUtils.GetPercentageFloored(e.FolderProcessedCount, zipFileStatisticsModel.EstimatedFoldersCount),
                    zipFileStatisticsModel.EstimatedFoldersCount);
            }
            else if (e.ProcessingStage == ZipProcessingStages.ADDING_FILE || e.ProcessingStage == ZipProcessingStages.ADDING_FILE_FAILED)
            {
                String fail = (e.ProcessingStage == ZipProcessingStages.ADDING_FILE) ? "" : "Failed";
                txtBoxCurrentAction.Text = String.Format("Adding File {0} => ", fail) + e.ZipFileToCreateFullPath;
                AddLogItems(String.Format("Adding File {0}", fail), e.ZipFileToCreateFullPath);
                lblFilesAdded.Text = String.Format("{0}% > {1}",
                    ConverterUtils.GetPercentageFloored(e.FilesProcessedCount, zipFileStatisticsModel.EstimatedFilesCount),
                    zipFileStatisticsModel.EstimatedFilesCount);
            }
        }

        private void OpenProjectFileForZipping()
        {
            SerializableTreeNode serializedTreeNode = null;
            
            if(applicationArgumentModel.IsFileOpenCase)
            {
                serializedTreeNode = projectSession.GetSerializableTreeNodeBaseOnProjectFile(applicationArgumentModel.FilePath);
            }
            else
            {
                serializedTreeNode = projectSession.GetSerializableTreeNodeBaseOnZipModel();
            }
            
            this.zipModel = projectSession.ZipFileModel;
            String newArchiveName = zipModel.GetFullPathFileAndNameOfNewZipArchive;
            this.Text = this.Text + " => " + Path.GetFileName(newArchiveName);
            zipArchiving.NewArchiveName = newArchiveName;
            zipArchiving.SerializableTreeNode = serializedTreeNode;
            zipArchiving.ZipFileModelSource = zipModel;
            zipArchiving.CompressionLevelArchiving = CompressionLevel.Optimal;
            zipArchiving.StartArchiving();
        }
        
        private void GetStatistic(ZipFileStatisticsModel statObj)
        {
            zipFileStatisticsModel = statObj;
            lblTotalFilesCount.Text = zipFileStatisticsModel.EstimatedFilesCount.ToString();
            lblTotalFoldersCount.Text = zipFileStatisticsModel.EstimatedFoldersCount.ToString();
            lblEstimatedSize.Text = ConverterUtils.HumanReadableFileSize(zipFileStatisticsModel.EstimatedFileSizeCount, 2);
        }
        
        private void timerElapseTime_Tick(object sender, EventArgs e)
        {
            elapseTime++;
            lblElapsedTime.Text = ConverterUtils.ConvertToHourMinuteSeconds(elapseTime);
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (isWindowCanBeClose)
            {
                BeforeClosingForm();
                this.Close();
            }
            else
            {
                btnStop_Click(null, null);
            }
        }
        
        private void btnStop_Click(object sender, EventArgs e)
        {
            zipArchiving.StopArchiving();
            btnStop.Enabled = false;
        }
        
        private void AddLogItems(String actionLabel="", String logMessage="")
        {
            listViewLogs.Items.Add(new ListViewItem(new String[]{
                DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"),
                actionLabel,
                logMessage
            }));

            listViewLogs.EnsureVisible(listViewLogs.Items.Count-1);
        }
        
        private void copySelectedLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder results = new StringBuilder();
            foreach (ListViewItem lvtm in listViewLogs.SelectedItems)
            {
                results.AppendLine(lvtm.SubItems[2].Text);
            }
            if (listViewLogs.SelectedItems.Count <= 0) return;
            Clipboard.SetText(results.ToString());
        }

        private void linkSaveLogs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = ResourcesUtil.GetFileLogFilterName();
            saveFileDialog.Title = "Save a log file";
            DialogResult dr = saveFileDialog.ShowDialog();

            if(dr == DialogResult.OK)
            {
                using (StreamWriter file = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach(ListViewItem lvItem in listViewLogs.Items)
                    {
                        file.WriteLine(lvItem.SubItems[0].Text + "\t" +
                                        lvItem.SubItems[1].Text + "\t" +
                                        lvItem.SubItems[2].Text + "\t");
                    }
                }
                MessageBox.Show("Log file has been successfully save...", "File saving...");
            }
        }

        private void OneClickProcessor_FormClosed(object sender, FormClosedEventArgs e)
        {
            BeforeClosingForm();
        }

        private void BeforeClosingForm()
        {
            if (zipArchiving.IsProcessingForceToStop && !zipArchiving.StopProcessingSuccessful)
            {
                DialogResult dr = MessageBox.Show(
                    "Are you sure you want to immediately exit the zip archiving?",
                    "Zip Archive Exit",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.No) return;
            }
            this.DialogResult = DialogResult.OK;
        }

    }
}
