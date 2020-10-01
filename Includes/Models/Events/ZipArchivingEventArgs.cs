using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Models.Events
{
    public class ZipArchivingEventArgs: EventArgs
    {
        public ZipArchivingEventArgs()
        {
            ProcessingStage = ZipProcessingStages.INITIALIZATION;
            ProgressStatusPercentage = 0;
            ZipFileToCreateFullPath = null;
            FileName = null;
            IsFolder = false;
            CustomFileItem = null;
            FolderProcessedCount = 0;
            FilesProcessedCount = 0;
        }
        public ZipProcessingStages ProcessingStage { get; set; }
        public int ProgressStatusPercentage { get; set; }
        public String ZipFileToCreateFullPath { get; set; }
        public String FileName { get; set; }
        public bool IsFolder { get; set; }
        public CustomFileItem CustomFileItem { get; set; }
        public long FolderProcessedCount { get; set; }
        public long FilesProcessedCount { get; set; }
    }
}
