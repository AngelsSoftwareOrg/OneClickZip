using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using OneClickZip.Includes.Classes.TreeNodeSerialize;
using OneClickZip.Includes.Models;
using OneClickZip.Includes.Models.Events;
using OneClickZip.Includes.Utilities;

namespace OneClickZip.Includes.Classes
{
    public class ZipArchiving
    {
        // declaring an event using built-in EventHandler
        public event EventHandler<ZipArchivingEventArgs> ProcessingStatus;
        public event EventHandler<ZipArchivingEventArgs> ProgressStatus;
        public event EventHandler<ZipArchivingEventArgs> FinishedArchiving;
        public event EventHandler<ZipArchivingEventArgs> StopProcess;
        public event EventHandler<ZipArchivingEventArgs> SerializedTreeNodeGeneratedComplete;

        private ZipArchivingEventArgs processingStatusEventArgs;

        private String newArchiveName;
        private ZipFileModel zipFileModel;
        private SerializableTreeNode serializableTreeNode;
        private ZipFileStatisticsModel zipFileStatisticsModel;
        private bool stopProcessing;
        private bool stopProcessingSuccessfull;
        private GenerateSerializableTreeNode generateSerializableTreeNode;
        private CompressionLevel compressionLevelArchiving = CompressionLevel.Optimal;

        public ZipArchiving() 
        {
            PrepareEventsVariablesArgs();
            StopProcessing = false;
            StopProcessingSuccessful = false;
        }

        public ZipArchiving(String newArchiveName, ZipFileModel zipFileModel, SerializableTreeNode serializableTreeNode)
        {
            this.NewArchiveName = newArchiveName;
            this.ZipFileModelSource = zipFileModel;
            this.SerializableTreeNode = serializableTreeNode;
            PrepareEventsVariablesArgs();
        }
        private void PrepareEventsVariablesArgs()
        {
            processingStatusEventArgs = new ZipArchivingEventArgs();
            generateSerializableTreeNode = new GenerateSerializableTreeNode();
        }
        public String NewArchiveName
        {
            get => this.newArchiveName;
            set
            {
                this.newArchiveName = value;
            }
        }
        public ZipFileModel ZipFileModelSource
        {
            get => this.zipFileModel;
            set
            {
                this.zipFileModel = value;
            }
        }
        public SerializableTreeNode SerializableTreeNode
        {
            get => this.serializableTreeNode;
            set
            {
                this.serializableTreeNode = value;
            }
        }
        public void StopArchiving()
        {
            StopProcessing = true;
            Application.DoEvents();
        }
        public void StartArchiving()
        {
            Application.DoEvents();
            ResetProgressAndStats();
            ValidateAndFillupDynamicZipTreeDetails();
            StartCrawling();
        }
        private void ValidateAndFillupDynamicZipTreeDetails()
        {
            UpdateStatusAndRaiseEventProcessingStatus(ZipProcessingStages.INITIALIZATION);
            CompleteFolderFilterRuleCrawler(serializableTreeNode);
            SerializedTreeNodeCompletionStatus();
            ComputeStatistic();
        }
        private void CompleteFolderFilterRuleCrawler(SerializableTreeNode serializableTreeNode)
        {
            foreach (SerializableTreeNode streeNodeEx in serializableTreeNode.Nodes)
            {
                if (streeNodeEx.IsFolderIsFilterRule)
                {
                    generateSerializableTreeNode.FolderFilterRuleObj = (FolderFilterRule)streeNodeEx.FolderFilterRuleObj.Clone();
                    generateSerializableTreeNode.StartGeneration();
                    SerializableTreeViewOperation.SerializeTreeNodeShallowCopy(
                        generateSerializableTreeNode.SerializableTreeNodeObj, streeNodeEx);
                }
                else
                {
                    CompleteFolderFilterRuleCrawler(streeNodeEx);
                }
            }
        }
        private void StartCrawling()
        {
            using (FileStream zipToCreate = new FileStream(NewArchiveName, FileMode.Create))
            {
                using (ZipArchive archiveFile = new ZipArchive(zipToCreate, ZipArchiveMode.Update))
                {
                    UpdateStatusAndRaiseEventProcessingStatus(ZipProcessingStages.ZIP_CREATION);
                    CrawlTreeStructure(serializableTreeNode, archiveFile, null);
                    if (StopProcessing && StopProcessingSuccessful)
                    {
                        StopProcessingRaiseEvent();
                    }
                    else
                    {
                        FinishedArchivingRaiseEvent();
                    }
                }
            }
        }
        private bool AddFileIntoZipArchive(ZipArchive archiveFile, String fullPathOfaFile, String zipFileFolderName)
        {
            FileInfo fileInfo = new FileInfo(fullPathOfaFile);
            if (!fileInfo.Exists) return false;
            ZipArchiveEntry zipArchiveEntry = archiveFile.CreateEntry(zipFileFolderName + fileInfo.Name, CompressionLevelArchiving);
            using (var zipStream = zipArchiveEntry.Open())
            {
                using (Stream source = File.OpenRead(fullPathOfaFile))
                {
                    Application.DoEvents();
                    byte[] buffer = new byte[2048];
                    int bytesRead;
                    while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        zipStream.Write(buffer, 0, bytesRead);
                    }
                }
            }
            return true;
        }
        private void CrawlTreeStructure(SerializableTreeNode serializableTreeNode, ZipArchive archiveFile, String zipFileFolderName)
        {
            if (IsStopProcessing()) return;
            if (zipFileFolderName == null) zipFileFolderName = "";

            foreach (CustomFileItem customFile in serializableTreeNode.MasterListFilesDir)
            {
                if (customFile.IsFolderIsFileViewNode)
                {
                    IncrementFilesProcessedCountArgs();
                    if(AddFileIntoZipArchive(archiveFile, customFile.FilePathFull, zipFileFolderName))
                    {
                        UpdateStatusAndRaiseEventProgressStatus(ZipProcessingStages.ADDING_FILE, customFile);
                    }
                    else
                    {
                        UpdateStatusAndRaiseEventProgressStatus(ZipProcessingStages.ADDING_FILE_FAILED, customFile);
                    }
                }
                else
                {
                    IncrementFolderProcessedCountArgs();
                    String newFolderName = String.Format("{0}{1}/", zipFileFolderName, customFile.GetCustomFileName);
                    archiveFile.CreateEntry(newFolderName);
                    UpdateStatusAndRaiseEventProgressStatus(ZipProcessingStages.ADDING_FOLDER, customFile, newFolderName);
                }
                Application.DoEvents();
                if (IsStopProcessing()) return;
            }

            foreach (SerializableTreeNode treeNodeEx in serializableTreeNode.Nodes)
            {
                if (treeNodeEx.IsGenerallyAFolderType)
                {
                    String newPath;
                    if (zipFileFolderName == null)
                    {
                        newPath = treeNodeEx.Text + @"/";
                    }
                    else
                    {
                        newPath = zipFileFolderName + treeNodeEx.Text + @"/";
                    }
                    if (IsStopProcessing()) return;
                    CrawlTreeStructure(treeNodeEx, archiveFile, newPath);
                }
            }
        }
        public ZipFileStatisticsModel GetStatistic()
        {
            if (zipFileStatisticsModel == null) ComputeStatistic();
            return zipFileStatisticsModel;
        }
        private void ComputeStatistic()
        {
            if (SerializableTreeNode == null) throw new NullReferenceException("SerializableTreeNode property has no value to get statistic at.");
            zipFileStatisticsModel = new ZipFileStatisticsModel();
            zipFileStatisticsModel.SetStatistic(SerializableTreeNode);
        }
        private ZipArchivingEventArgs GetProcessingStatusEventArgs(ZipProcessingStages setStage, CustomFileItem customFile = null, String folderName = "") 
        {
            processingStatusEventArgs.CustomFileItem = customFile;
            processingStatusEventArgs.ProcessingStage = setStage;

            if (customFile == null)
            {
                processingStatusEventArgs.ZipFileToCreateFullPath = this.zipFileModel.FilePath;
                processingStatusEventArgs.FileName = (folderName == "") ? zipFileModel.GetFileName : folderName; 
                processingStatusEventArgs.IsFolder = FileSystemUtilities.IsFullPathIsDirectory(this.zipFileModel.FilePath);
            }
            else
            {
                processingStatusEventArgs.ZipFileToCreateFullPath = customFile.FilePathFull;
                processingStatusEventArgs.FileName = (folderName=="") ? customFile.GetCustomFileName : folderName;
                processingStatusEventArgs.IsFolder = customFile.IsFolder;
            }

            ProgressStatusPercentageArgs();
            return processingStatusEventArgs;
        }
        private void ResetProgressAndStats()
        {
            processingStatusEventArgs.FilesProcessedCount = 0;
            processingStatusEventArgs.FolderProcessedCount = 0;
            processingStatusEventArgs.ProgressStatusPercentage = 0;
        }
        private void IncrementFilesProcessedCountArgs()
        {
            processingStatusEventArgs.FilesProcessedCount += 1;
        }
        private void IncrementFolderProcessedCountArgs()
        {
            processingStatusEventArgs.FolderProcessedCount += 1;
        }
        private void ProgressStatusPercentageArgs()
        {
            long processed = processingStatusEventArgs.FilesProcessedCount + processingStatusEventArgs.FolderProcessedCount;
            processingStatusEventArgs.ProgressStatusPercentage = 
                (zipFileStatisticsModel == null) ? 0 : 
                ConverterUtils.GetPercentageFloored(processed, zipFileStatisticsModel.TotalFilesAndFolders);
        }
        private void UpdateStatusAndRaiseEventProcessingStatus(ZipProcessingStages setStage, CustomFileItem customFile = null)
        {
            GetProcessingStatusEventArgs(setStage, customFile);
            ProcessingStatus.Invoke(this, processingStatusEventArgs);
        }
        private void UpdateStatusAndRaiseEventProgressStatus(ZipProcessingStages setStage, CustomFileItem customFile = null, String folderName="")
        {
            GetProcessingStatusEventArgs(setStage, customFile, folderName);
            ProgressStatus.Invoke(this, processingStatusEventArgs);
        }
        private void SerializedTreeNodeCompletionStatus()
        {
            processingStatusEventArgs.ProcessingStage = ZipProcessingStages.GENERATE_SERIALIZED_TREE_NODE_BASE_FILTER_RULE;
            SerializedTreeNodeGeneratedComplete.Invoke(this, processingStatusEventArgs);
        }
        private void FinishedArchivingRaiseEvent()
        {
            GetProcessingStatusEventArgs(ZipProcessingStages.FINISH_SUCCESSFUL);
            FinishedArchiving.Invoke(this, processingStatusEventArgs);
        }
        private void StopProcessingRaiseEvent()
        {
            GetProcessingStatusEventArgs(ZipProcessingStages.STOP_PROCESSING);
            StopProcess.Invoke(this, processingStatusEventArgs);
        }
        private bool StopProcessing { get => stopProcessing; set => stopProcessing = value; }
        public bool IsProcessingForceToStop
        {
            get
            {
                return StopProcessing;
            }
        }
        public bool StopProcessingSuccessful { get => stopProcessingSuccessfull; set => stopProcessingSuccessfull = value; }
        public CompressionLevel CompressionLevelArchiving 
        {
            get 
            {
                return compressionLevelArchiving;
            } set {
                compressionLevelArchiving = value;
            } 
        }
        private bool IsStopProcessing()
        {
            if (StopProcessing)
            {
                StopProcessingSuccessful = true;
                return true;
            }
            return false;
        }
    }
}
