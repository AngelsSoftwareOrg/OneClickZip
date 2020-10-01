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
    public partial class OneClickProcessor : Form
    {
        private ProjectSession projectSession;
        private ApplicationArgumentModel applicationArgumentModel;
        private ZipFileModel zipModel;
        private ZipFileStatisticsModel zipFileStatisticsModel;
        private long elapseTime = 0;
        private ZipArchiving zipArchiving = new ZipArchiving();

        public OneClickProcessor()
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
            timerElapseTime.Enabled = true;
            timerElapseTime.Start();
            linkSaveLogs.Enabled = false;
            elapseTime = 0;
            this.Show();
            zipArchiving.ProcessingStatus += ZipArchiving_ProcessingStatus;
            zipArchiving.ProgressStatus += ZipArchiving_ProgressStatus;
            zipArchiving.FinishedArchiving += ZipArchiving_FinishedArchiving;
            zipArchiving.StopProcess += ZipArchiving_StopProcess;
            OpenProjectFileForZipping();
        }

        private void ZipArchiving_StopProcess(object sender, ZipArchivingEventArgs e)
        {
            timerElapseTime.Stop();
            progressBarStatus.Value = progressBarStatus.Maximum;
            txtBoxCurrentAction.Text = "Zip Archiving Stopped...";
            AddLogItems("Archiving Ended", "Successfully stop further zip archiving");
            AddLogItems("Zip Location", @"Partial zip file has been save into....");
            AddLogItems("Zip Location", e.ZipFileToCreateFullPath);
            linkSaveLogs.Enabled = true;
        }

        private void ZipArchiving_FinishedArchiving(object sender, ZipArchivingEventArgs e)
        {
            timerElapseTime.Stop();
            txtBoxCurrentAction.Text = "Finished Zip Archiving...";
            AddLogItems("Wrapping up", txtBoxCurrentAction.Text);
            AddLogItems("Zip Location", @"Zip file has been save into....");
            AddLogItems("Zip Location", e.ZipFileToCreateFullPath);
            linkSaveLogs.Enabled = true;
        }

        private void ZipArchiving_ProgressStatus(object sender, ZipArchivingEventArgs e)
        {
            if(this.progressBarStatus.Value != e.ProgressStatusPercentage)
            {
                this.progressBarStatus.Value = e.ProgressStatusPercentage;
            }
            //DEBUG
            Console.WriteLine("ZipArchiving_ProgressStatus: " + e.ProgressStatusPercentage);

            DisplayProcessedFile(e);
        }

        private void ZipArchiving_ProcessingStatus(object sender, ZipArchivingEventArgs e)
        {
            DisplayProcessedFile(e);
        }

        private void DisplayProcessedFile(ZipArchivingEventArgs e)
        {
            Application.DoEvents();
            if (e.ProcessingStage == ZipProcessingStages.ADDING_FILE)
            {
                txtBoxCurrentAction.Text = "Adding File => " + e.ZipFileToCreateFullPath;
                AddLogItems("Adding File", e.ZipFileToCreateFullPath);
                lblFilesAdded.Text = String.Format("{0}% > {1}",
                    ConverterUtils.GetPercentageFloored(e.FilesProcessedCount, zipFileStatisticsModel.EstimatedFilesCount),
                    zipFileStatisticsModel.EstimatedFilesCount);
            }
            else if (e.ProcessingStage == ZipProcessingStages.ADDING_FOLDER)
            {
                txtBoxCurrentAction.Text = "Creating Folder => " + e.FileName;
                AddLogItems("Adding Folder", e.FileName);
                lblFoldersCreated.Text = String.Format("{0}% > {1}",
                    ConverterUtils.GetPercentageFloored(e.FolderProcessedCount, zipFileStatisticsModel.EstimatedFoldersCount),
                    zipFileStatisticsModel.EstimatedFoldersCount);
            }
        }

        private void OpenProjectFileForZipping()
        {
            SerializableTreeNode serializedTreeNode = projectSession.GetSerializableTreeNodeOnProjectFile(applicationArgumentModel.FilePath);
            this.zipModel = projectSession.ZipFileModel;

            //DEBUG
            Console.WriteLine(zipModel.GetFullPathFileAndNameOfNewZipArchive);

            zipArchiving.NewArchiveName = zipModel.GetFullPathFileAndNameOfNewZipArchive;
            zipArchiving.SerializableTreeNode = serializedTreeNode;
            zipArchiving.ZipFileModelSource = zipModel;
            GetStatistic(zipArchiving.GetStatistic());
            zipArchiving.StartArchieving();
        }
        
        private void GetStatistic(ZipFileStatisticsModel statObj)
        {
            zipFileStatisticsModel = statObj;
            lblTotalFilesCount.Text = zipFileStatisticsModel.EstimatedFilesCount.ToString();
            lblTotalFoldersCount.Text = zipFileStatisticsModel.EstimatedFoldersCount.ToString();
            lblEstimatedSize.Text = ConverterUtils.humanReadableFileSize(zipFileStatisticsModel.EstimatedFileSizeCount, 2);
        }
        
        private void timerElapseTime_Tick(object sender, EventArgs e)
        {
            elapseTime++;
            lblElapsedTime.Text = ConverterUtils.ConvertToHourMinuteSeconds(elapseTime);
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (zipArchiving.IsProcessingForceToStop && !zipArchiving.StopProcessingSuccessful)
            {
                DialogResult dr = MessageBox.Show(
                    "Are you sure you want to immediately exit the zip archiving?",
                    "Zip Archive Exit",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.No) return;
            }

            this.Close();
        }
        
        private void btnStop_Click(object sender, EventArgs e)
        {
            zipArchiving.StopArchieving();
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
    }
}
