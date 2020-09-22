using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Models
{
    public class ZipFileStatisticsModel
    {
        private long estimatedFoldersCount;
        private long estimatedFilesCount;
        private long estimatedFileSizeCount;

        public void IncrementEstimatedFileSizeCount(long value)
        {
            EstimatedFileSizeCount += value;
        }
        public void IncrementEstimatedFilesCount()
        {
            EstimatedFilesCount += 1;
        }
        public void IncrementEstimatedFoldersCount()
        {
            EstimatedFoldersCount += 1;
        }

        public long EstimatedFileSizeCount 
        { 
            get => estimatedFileSizeCount; 
            set  
            {
                if (value > long.MaxValue) value = long.MaxValue;
                estimatedFileSizeCount = value; 
            }
        }
        public long EstimatedFilesCount 
        { 
            get => estimatedFilesCount;
            set
            {
                if (value > long.MaxValue) value = long.MaxValue;
                estimatedFilesCount = value;
            }
        }
        public long EstimatedFoldersCount 
        { 
            get => estimatedFoldersCount;
            set
            {
                if (value > long.MaxValue) value = long.MaxValue;
                estimatedFoldersCount = value;
            }
        }
    }
}
