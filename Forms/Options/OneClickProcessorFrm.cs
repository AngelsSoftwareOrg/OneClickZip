using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Text;
using System.Windows.Forms;
using Ionic.Zlib;
using OneClickZip.Includes.Classes;
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
        private bool isStopProcessing;
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
            lblArchivedSize.Text = ConverterUtils.HumanReadableFileSize(e.ArchiveSize, 2);
            AddLogItems("Archiving Ended", "Successfully stop further zip archiving");
            AddLogItems("Project File", @"Project file that has been processed is ");
            AddLogItems("Project File", (String.IsNullOrWhiteSpace(e.ZipFileToCreateFullPath) ? "(Project is not yet save...)" : e.ZipFileToCreateFullPath));
            AddLogItems("Zip Archive Location", @"Partial zip file has been save into....");
            AddLogItems("Zip Archive Location", zipArchiving.NewArchiveName);
            linkSaveLogs.Enabled = true;
            btnStop.Enabled = false;
            isWindowCanBeClose = true;
            isStopProcessing = false;
            listViewLogs.EndUpdate();
        }
        private void ZipArchiving_FinishedArchiving(object sender, ZipArchivingEventArgs e)
        {
            timerElapseTime.Stop();
            lblArchivedSize.Text = ConverterUtils.HumanReadableFileSize(e.ArchiveSize, 2);
            AddLogItems("Wrapping up", txtBoxCurrentAction.Text);
            AddLogItems("Project File", @"Project file that has been processed is ");
            AddLogItems("Project File", (String.IsNullOrWhiteSpace(e.ZipFileToCreateFullPath) ? "(Project is not yet save...)" : e.ZipFileToCreateFullPath));
            AddLogItems("Zip Archive Location", @"Zip file has been save into....");
            AddLogItems("Zip Archive Location", zipArchiving.NewArchiveName);
            listViewLogs.EndUpdate();
            CopyOutputToOtherTargetFolders(e);
            txtBoxCurrentAction.Text = "Finished Zip Archiving...";
            isStopProcessing = false;
            linkSaveLogs.Enabled = true;
            btnStop.Enabled = false;
            isWindowCanBeClose = true;
            SystemSounds.Exclamation.Play();
        }
        private void CopyOutputToOtherTargetFolders(ZipArchivingEventArgs e)
        {
            TargetOutputLocationModel targetOutputLoc = zipModel.TargetOutputLocationModel;
            List<string> targetLocationsArr = targetOutputLoc.GetTargetLocations();
            if (targetLocationsArr.Count <= 0)
            {
                progressBarStatus.Value = progressBarStatus.Maximum;
                return;
            }

            FileInfo zipOutputFile = new FileInfo(zipArchiving.NewArchiveName);
            String zipOutputFileName = zipOutputFile.Name;
            String zipOutputFullFilePathName = zipOutputFile.FullName;
            long totalFileOutputSize = zipOutputFile.Length * targetLocationsArr.Count;
            long totalTransferredByte = 0;
            long totalTransferredByteUpdateProgress = 10485760; //10 * 1024 * 1024, every 10MB
            long totalTransferredByteUpdateProgressCtr = 0;
            progressBarStatus.Value = 0;

            foreach (String targetOutputFolder in targetLocationsArr)
            {
                String outputFileFullPath = targetOutputFolder + @"\" + zipOutputFileName;
                if (isStopProcessing) break;
                try
                {
                    if (!IsDirectoryValidAndAccessible(targetOutputFolder))
                    {
                        AddLogItems("Copy file failed", String.Format(@"Failed to place the file [{1}] in [{0}] due to folder is not accessible" +
                                        @" or no read and write permission", targetOutputFolder, zipOutputFile.Name));
                        continue;
                    }

                    int bufferSize = 8 * 1024;
                    using (FileStream sourceStream = new FileStream(zipOutputFullFilePathName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        using (FileStream fileStream = new FileStream(outputFileFullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                        {
                            fileStream.SetLength(sourceStream.Length);
                            int bytesRead = -1;
                            byte[] bytes = new byte[bufferSize];

                            if (isStopProcessing) break;
                            while ((bytesRead = sourceStream.Read(bytes, 0, bufferSize)) > 0)
                            {
                                fileStream.Write(bytes, 0, bytesRead);
                                totalTransferredByte += bytesRead;

                                //update progress bar not that much, e.g. every 10MB
                                if ((totalTransferredByte - totalTransferredByteUpdateProgressCtr) >= totalTransferredByteUpdateProgress)
                                {
                                    totalTransferredByteUpdateProgressCtr = totalTransferredByte;
                                    Application.DoEvents();
                                    progressBarStatus.Value = ConverterUtils.GetPercentageFloored(totalTransferredByte, totalFileOutputSize);
                                }
                            }
                            fileStream.Flush();
                            txtBoxCurrentAction.Text = "Copying output Zip Archive to => " + targetOutputFolder;
                            AddLogItems("Copy file success", outputFileFullPath);
                        }
                    }
                    progressBarStatus.Value = ConverterUtils.GetPercentageFloored(totalTransferredByte, totalFileOutputSize);
                }
                catch (Exception ex)
                {
                    AddLogItems("Copy file failed", String.Format(@"Failed: {0}\{1}. / Error message: {2}", targetOutputFolder, zipOutputFile.Name, ex.Message));
                }
            }
            //In case some locations are not valid anymore
            progressBarStatus.Value = progressBarStatus.Maximum;
            if (isStopProcessing)
            {
                txtBoxCurrentAction.Text = "Copying has been halted...";
                AddLogItems("Copy Output File", "Copying has been halted...");
                progressBarStatus.Value = progressBarStatus.Maximum;
            }
        }
        private void ZipArchiving_ProgressStatus(object sender, ZipArchivingEventArgs e)
        {
            if(this.progressBarStatus.Value != e.ProgressStatusPercentage)
            {

                if (e.ProgressStatusPercentage > 100)
                {
                    this.progressBarStatus.Value = 100;
                }
                else
                {
                    this.progressBarStatus.Value = e.ProgressStatusPercentage;
                }              
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
                String addingStatus = (e.ProcessingStage == ZipProcessingStages.ADDING_FILE) ? "" : "Failed";
                txtBoxCurrentAction.Text = String.Format("Adding File {0} => {1}", addingStatus, e.ZipFileToCreateFullPath);
                AddLogItems(String.Format("Adding File {0}", addingStatus), e.ZipFileToCreateFullPath);
                lblFilesAdded.Text = String.Format("{0}% > {1}",
                    ConverterUtils.GetPercentageFloored(e.FilesProcessedCount, zipFileStatisticsModel.EstimatedFilesCount),
                    zipFileStatisticsModel.EstimatedFilesCount);
                lblArchivedSize.Text = ConverterUtils.HumanReadableFileSize(e.ArchiveSize, 2);
            }
            else if (e.ProcessingStage == ZipProcessingStages.GENERATE_SERIALIZED_TREE_NODE_BASE_FILTER_RULE)
            {
                txtBoxCurrentAction.Text = String.Format("Constructing dynamic filter folder => {0}", e.ZipFileToCreateFullPath);
            }
            else if (e.ProcessingStage == ZipProcessingStages.POST_PROCESSING)
            {
                txtBoxCurrentAction.Text = "Writing the Zip file into the target folder...";
            }
        }
        private void OpenProjectFileForZipping()
        {
            SerializableTreeNode serializedTreeNode;
            if (applicationArgumentModel.IsFileOpenCase)
            {
                serializedTreeNode = projectSession.GetSerializableTreeNodeBaseOnProjectFile(applicationArgumentModel.FilePath);
            }
            else
            {
                serializedTreeNode = projectSession.GetSerializableTreeNodeBaseOnZipModel();
            }
            this.zipModel = projectSession.ZipFileModel;
            if (IsDirectoryValidAndAccessible(this.zipModel.MainTargetLocationDirectory))
            {
                String newArchiveName = zipModel.GetFullPathFileAndNameOfNewZipArchive;
                this.Text = this.Text + " => " + Path.GetFileName(newArchiveName);
                zipArchiving.NewArchiveName = newArchiveName;
                zipArchiving.SerializableTreeNode = serializedTreeNode;
                zipArchiving.ZipFileModelSource = zipModel;
                zipArchiving.CompressionLevelArchiving = CompressionLevel.BestCompression;
                zipArchiving.StartArchiving();
            }
            else
            {
                MessageBox.Show(String.Format("The target location for archiving '{0}' is not accessible!", 
                    this.zipModel.MainTargetLocationDirectory), 
                    "Access Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isWindowCanBeClose = true;
                btnStop.Enabled = false;
            }
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
            isStopProcessing = true;
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
            FileSystemUtilities.SaveListViewItemsToLogFile(listViewLogs);
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
        private bool IsDirectoryValidAndAccessible(String dirPath)
        {
            if (!FileSystemUtilities.IsDirectoryExistInTheSystem(dirPath))
            {
                if (!FileSystemUtilities.MakeDirectory(dirPath)) return false;
            }
            if (!FileSystemUtilities.IsDirectoryHasReadAndWritePermission(dirPath)) return false;
            return true;
        }
    
    }
}
