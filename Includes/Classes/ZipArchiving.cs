using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OneClickZip.Includes.Classes.Extensions;
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

        private ZipArchivingEventArgs processingStatusEventArgs;

        private String newArchiveName;
        private ZipFileModel zipFileModel;
        private SerializableTreeNode serializableTreeNode;
        private ZipFileStatisticsModel zipFileStatisticsModel;

        public ZipArchiving() 
        {
            PrepareEventsVariablesArgs();
        }

        public ZipArchiving(String newArchiveName, ZipFileModel zipFileModel, SerializableTreeNode serializableTreeNode)
        {
            this.NewArchiveName = newArchiveName;
            this.ZipFileModelSource = zipFileModel;
            this.SerializableTreeNode = serializableTreeNode;
            PrepareEventsVariablesArgs();
            ComputeStatistic();
        }
        
        private void PrepareEventsVariablesArgs()
        {
            processingStatusEventArgs = new ZipArchivingEventArgs();
            //progressStatusEventArgs = new ZipArchivingEventArgs();
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
        public void StopArchieving()
        {
            Application.DoEvents();
        }
        public void StartArchieving()
        {
            Application.DoEvents();
            ResetProgressAndStats();
            ValidateAndFillupDynamicZipTreeDetails();
            StartCrawling();
        }

        private void ValidateAndFillupDynamicZipTreeDetails()
        {

            UpdateStatusAndRaiseEventProcessingStatus(ZipProcessingStages.INITIALIZATION);
        }

        private void StartCrawling()
        {
            using (FileStream zipToCreate = new FileStream(NewArchiveName, FileMode.Create))
            {
                using (ZipArchive archiveFile = new ZipArchive(zipToCreate, ZipArchiveMode.Update))
                {
                    UpdateStatusAndRaiseEventProcessingStatus(ZipProcessingStages.ZIP_CREATION);
                    CrawlTreeStructure(serializableTreeNode, archiveFile, null);
                    FinishedArchivingRaiseEvent();
                }
            }
        }

        private void AddFileIntoZipArchive(ZipArchive archiveFile, String fullPathOfaFile, String zipFileFolderName)
        {
            FileInfo fileInfo = new FileInfo(fullPathOfaFile);
            ZipArchiveEntry zipArchiveEntry = archiveFile.CreateEntry(zipFileFolderName + fileInfo.Name, CompressionLevel.Optimal);
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
        }

        private void CrawlTreeStructure(SerializableTreeNode serializableTreeNode, ZipArchive archiveFile, String zipFileFolderName)
        {
            if (zipFileFolderName == null) zipFileFolderName = "";
            foreach (CustomFileItem customFile in serializableTreeNode.MasterListFilesDir)
            {
                if (!customFile.IsFolder && !customFile.IsCustomFolder)
                {
                    IncrementFilesProcessedCountArgs();
                    UpdateStatusAndRaiseEventProgressStatus(ZipProcessingStages.ADDING_FILE, customFile);
                    AddFileIntoZipArchive(archiveFile, customFile.FilePathFull, zipFileFolderName);

                    //DEBUG
                    Console.WriteLine(zipFileFolderName + "\\[" + serializableTreeNode.Text + "] -> " + customFile.GetCustomFileName);
                    
                    //END DEBUG
                }
                else
                {
                    IncrementFolderProcessedCountArgs();
                    UpdateStatusAndRaiseEventProgressStatus(ZipProcessingStages.ADDING_FOLDER, customFile);
                }
                Application.DoEvents();

                //DEBUG
                Thread.Sleep(500);
            }

            //DEBUG
            //Thread.Sleep(500);
            //END DEBUG

            //create the directory even if its empty
            if (serializableTreeNode.MasterListFilesDir.Count <= 0)
            {
                //IncrementFolderProcessedCountArgs();
                UpdateStatusAndRaiseEventProgressStatus(ZipProcessingStages.ADDING_FOLDER);
                processingStatusEventArgs.FileName = zipFileFolderName;
                archiveFile.CreateEntry(zipFileFolderName);
                Application.DoEvents();
            }
            
            foreach (SerializableTreeNode treeNodeEx in serializableTreeNode.Nodes)
            {
                if (treeNodeEx.IsAFolderGenerally)
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
            if (SerializableTreeNode == null) throw new NullReferenceException("SerializableTreeNode has no value to get statistic at.");
            zipFileStatisticsModel = new ZipFileStatisticsModel();
            zipFileStatisticsModel.SetStatistic(SerializableTreeNode);
        }
        private ZipArchivingEventArgs GetProcessingStatusEventArgs(ZipProcessingStages setStage, CustomFileItem customFile = null) 
        {
            processingStatusEventArgs.CustomFileItem = customFile;
            processingStatusEventArgs.ProcessingStage = setStage;

            if (customFile == null)
            {
                processingStatusEventArgs.FileFullPath = this.zipFileModel.FilePath;
                processingStatusEventArgs.FileName = zipFileModel.GetFileName;
                processingStatusEventArgs.IsFolder = FileSystemUtilities.IsFullPathIsDirectory(this.zipFileModel.FilePath);
            }
            else
            {
                processingStatusEventArgs.FileFullPath = customFile.FilePathFull;
                processingStatusEventArgs.FileName = customFile.GetCustomFileName;
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

            //DEBUG
            Console.WriteLine("ProgressStatusPercentageArgs: " + processed + ", " + zipFileStatisticsModel.TotalFilesAndFolders);

            processingStatusEventArgs.ProgressStatusPercentage = 
                ConverterUtils.GetPercentageFloored(processed, zipFileStatisticsModel.TotalFilesAndFolders);
        }
        private void UpdateStatusAndRaiseEventProcessingStatus(ZipProcessingStages setStage, CustomFileItem customFile = null)
        {
            GetProcessingStatusEventArgs(setStage, customFile);
            ProcessingStatus.Invoke(this, processingStatusEventArgs);
        }
        private void UpdateStatusAndRaiseEventProgressStatus(ZipProcessingStages setStage, CustomFileItem customFile = null)
        {
            GetProcessingStatusEventArgs(setStage, customFile);
            ProgressStatus.Invoke(this, processingStatusEventArgs);
        }

        private void FinishedArchivingRaiseEvent()
        {
            GetProcessingStatusEventArgs(ZipProcessingStages.FINISH_SUCCESSFULL);
            FinishedArchiving.Invoke(this, processingStatusEventArgs);
        }
    }
}
