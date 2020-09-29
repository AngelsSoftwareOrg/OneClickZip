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
            timerElapseTime.Enabled = true;
            timerElapseTime.Start();
            elapseTime = 0;
            OpenProjectFileForZipping();
        }

        private void OpenProjectFileForZipping()
        {
            TreeNodeExtended treeNodeExtended = projectSession.GetTreeNodeZipDesignOnProjectFile(applicationArgumentModel.FilePath);
            zipModel = projectSession.ZipFileModel;
            GetStatistic(treeNodeExtended);

            //DEBUG
            Console.WriteLine(zipModel.GetFullPathFileAndNameOfNewZipArchive);

            //CrawlTreeStructure(treeNodeExtended, null, null);
            //if (true) return;

            using (FileStream zipToCreate = new FileStream(zipModel.GetFullPathFileAndNameOfNewZipArchive, FileMode.Create))
            {
                using (ZipArchive archiveFile = new ZipArchive(zipToCreate, ZipArchiveMode.Update))
                {
                    CrawlTreeStructure(treeNodeExtended, archiveFile, null);
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
                    byte[] buffer = new byte[2048];
                    int bytesRead;
                    while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        zipStream.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }

        private void CrawlTreeStructure(TreeNodeExtended treeNodeExtended, ZipArchive archiveFile, String zipFileFolderName)
        {
            if (zipFileFolderName == null) zipFileFolderName = "";
            foreach (CustomFileItem customFile in treeNodeExtended.MasterListFilesDir)
            {
                if (!customFile.IsFolder && !customFile.IsCustomFolder)
                {
                    AddFileIntoZipArchive(archiveFile, customFile.FilePathFull, zipFileFolderName);
                    
                    //debug
                    Console.WriteLine("[" + treeNodeExtended.Text + "] -> " + customFile.GetCustomFileName);
                }
            }

            //create the directory even if its empty
            if (treeNodeExtended.MasterListFilesDir.Count <= 0)
            {
                archiveFile.CreateEntry(zipFileFolderName);
            }

            foreach (TreeNodeExtended treeNodeEx in treeNodeExtended.Nodes)
            {
                if(treeNodeEx.IsAFolderGenerally)
                {
                    String newPath = "";
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

        private void GetStatistic(TreeNodeExtended treeNodeExtended)
        {
            zipFileStatisticsModel = new ZipFileStatisticsModel();
            TreeNodeInterpreter.TraverseTreeViewForStatistic((TreeNodeExtended)treeNodeExtended, zipFileStatisticsModel);
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
            this.Close();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timerElapseTime.Stop();
        }
    }
}
