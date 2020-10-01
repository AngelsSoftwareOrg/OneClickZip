using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneClickZip.Includes.Classes.Extensions;
using OneClickZip.Includes.Classes.TreeNodeSerialize;
using OneClickZip.Includes.Interface;

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
        public void SetStatistic(IZipFileTreeNode zipFileTreeNodeObj)
        {
            TraverseTreeViewForStatistic(zipFileTreeNodeObj, this);
        }
        private void TraverseTreeViewForStatistic(IZipFileTreeNode currentNode, ZipFileStatisticsModel statistic)
        {
            foreach (CustomFileItem customFileItem in currentNode.MasterListFilesDir)
            {
                if (!customFileItem.IsFolder)
                {
                    statistic.IncrementEstimatedFilesCount();
                    statistic.IncrementEstimatedFileSizeCount(customFileItem.FileLength);
                }
            }
            foreach (IZipFileTreeNode node in currentNode.Nodes)
            {
                if (node.IsStructuredNode)
                {
                    statistic.IncrementEstimatedFoldersCount();
                    TraverseTreeViewForStatistic(node, statistic);
                }
            }
        }
        public long TotalFilesAndFolders
        {
            get
            {
                return EstimatedFilesCount + EstimatedFoldersCount;
            }
        }
    }
}
