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
            timerElapseTime.Enabled = true;
            timerElapseTime.Start();
            elapseTime = 0;
            this.Show();
            zipArchiving.ProcessingStatus += ZipArchiving_ProcessingStatus;
            zipArchiving.ProgressStatus += ZipArchiving_ProgressStatus;
            zipArchiving.FinishedArchiving += ZipArchiving_FinishedArchiving;
            OpenProjectFileForZipping();
        }

        private void ZipArchiving_FinishedArchiving(object sender, ZipArchivingEventArgs e)
        {
            txtBoxCurrentAction.Text = "Finished....";
        }

        private void ZipArchiving_ProgressStatus(object sender, ZipArchivingEventArgs e)
        {
            this.progressBarStatus.Value = e.ProgressStatusPercentage;

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
            if (e.ProcessingStage == ZipProcessingStages.ADDING_FILE)
            {
                txtBoxCurrentAction.Text = "Adding File " + e.FileFullPath;
            }
            else if (e.ProcessingStage == ZipProcessingStages.ADDING_FOLDER)
            {
                txtBoxCurrentAction.Text = "Creating Folder " + e.FileName;
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
            this.Close();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timerElapseTime.Stop();
        }
    }
}
