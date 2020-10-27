using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;
using Ionic.Zip;
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
        private FileStream zipToCreate;
        private String newArchiveName;
        private ZipFileModel zipFileModel;
        private SerializableTreeNode serializableTreeNode;
        private ZipFileStatisticsModel zipFileStatisticsModel;
        private bool stopProcessing;
        private bool stopProcessingSuccessfull;
        private GenerateSerializableTreeNode generateSerializableTreeNode;
        private CompressionLevel compressionLevelArchiving = CompressionLevel.Optimal;
        private long processedZipFileSize;
        private long processedFilesSizeFlusherThreshold = 52428800; //50 * 1024 * 1024; //50MB,just howmany mega bytes would it take before we flush it to storage, just to avoid low memory
        private long processedFilesSizeFlusherCtr = 0;

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
            generateSerializableTreeNode.RuleEnforcementStatus += GenerateSerializableTreeNode_RuleEnforcementStatus;
        }
        private void GenerateSerializableTreeNode_RuleEnforcementStatus(object sender, GeneratingSerializeTreeNodeEventArgs e)
        {
            UpdateStatusAndRaiseEventProcessingStatusForDynamicGeneration(e.EvaluatedPath);
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
            using (ZipFile archiveFile = new ZipFile(NewArchiveName))
            {
                archiveFile.AlternateEncodingUsage = ZipOption.AsNecessary;

                UpdateStatusAndRaiseEventProcessingStatus(ZipProcessingStages.ZIP_CREATION);
                CrawlTreeStructure(serializableTreeNode, archiveFile, null);
                UpdateStatusAndRaiseEventProcessingStatus(ZipProcessingStages.POST_PROCESSING);
                archiveFile.Save();
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
        private bool AddFileIntoZipArchive(ZipFile archiveFile, CustomFileItem customFileItem, String zipFileFolderName)
        {
            FileInfo fileInfo = new FileInfo(customFileItem.FilePathFull);
            if (!fileInfo.Exists) return false;
            processedZipFileSize += fileInfo.Length;

            String customFileName = (zipFileFolderName + 
                                    FileSystemUtilities.SanitizeFileName(customFileItem.GetCustomFileName));

            archiveFile.AddEntry(customFileName, File.OpenRead(customFileItem.FilePathFull));
            try
            {
                //if there's a difference of, e.g. 50MB processed file size, then flush
                if((processedZipFileSize - processedFilesSizeFlusherCtr) >= processedFilesSizeFlusherThreshold)
                {
                    processedFilesSizeFlusherCtr = processedZipFileSize;
                    archiveFile.Save();
                }
            }
            catch (Exception)
            {
                //just ignore if cannot accessed the file
            }
            return true;
        }
        private void CrawlTreeStructure(SerializableTreeNode serializableTreeNode, ZipFile archiveFile, String zipFileFolderName)
        {
            if (IsStopProcessing()) return;
            if (zipFileFolderName == null) zipFileFolderName = "";

            foreach (CustomFileItem customFile in serializableTreeNode.MasterListFilesDir)
            {
                if (!customFile.IsGenerallyAFolderType)
                {
                    IncrementFilesProcessedCountArgs();
                    if(AddFileIntoZipArchive(archiveFile, customFile, zipFileFolderName))
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
                    archiveFile.AddDirectoryByName(newFolderName);
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
            processingStatusEventArgs.ArchiveSize = processedZipFileSize;
            if (customFile == null)
            {
                processingStatusEventArgs.ZipFileToCreateFullPath = this.zipFileModel.FilePath;
                processingStatusEventArgs.FileName = (String.IsNullOrWhiteSpace(folderName)) ? zipFileModel.GetFileName : folderName;

                if (String.IsNullOrWhiteSpace(this.zipFileModel.FilePath))
                {
                    processingStatusEventArgs.IsFolder = false;
                }
                else
                {
                    processingStatusEventArgs.IsFolder = FileSystemUtilities.IsFullPathIsDirectory(this.zipFileModel.FilePath);
                }
            }
            else
            {
                processingStatusEventArgs.ZipFileToCreateFullPath = customFile.FilePathFull;
                processingStatusEventArgs.FileName = (String.IsNullOrWhiteSpace(folderName)) ? customFile.GetCustomFileName : folderName;
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
            processedZipFileSize = 0;
            processedFilesSizeFlusherCtr = 0;
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
        private void UpdateStatusAndRaiseEventProcessingStatusForDynamicGeneration(String evaluatedPathPath)
        {
            processingStatusEventArgs.CustomFileItem = null;
            processingStatusEventArgs.ProcessingStage = ZipProcessingStages.GENERATE_SERIALIZED_TREE_NODE_BASE_FILTER_RULE;
            processingStatusEventArgs.ZipFileToCreateFullPath = evaluatedPathPath;
            processingStatusEventArgs.FileName = null;
            processingStatusEventArgs.IsFolder = false;
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
        private FileStream ZipToCreate { get => zipToCreate; set => zipToCreate = value; }
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
