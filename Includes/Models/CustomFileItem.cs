using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpTreeLib;
using OneClickZip.Includes.Classes;
using OneClickZip.Includes.Models.Types;
using OneClickZip.Includes.Utilities;

namespace OneClickZip.Includes.Models
{
    [Serializable]
    public class CustomFileItem : IDisposable, IComparable
    {
        private string keyName = String.Empty;
        private int iconIndexNormal = -1;
        private int iconIndexOpen = -1;
        private Object tag;
        private String filePathFull;
        private FolderType folderType;
        private bool isFolder;
        private bool isSpecialFolder;
        private String specialFolderFullPath;
        private String customFileName;
        private DateTime lastWriteTime;
        private DateTime creationTime;
        private String typeName;
        private long fileLength;

        public CustomFileItem()
        {
            CommonInitialization();
        }

        public CustomFileItem(String fileName)
        {
            CommonInitialization();
            this.customFileName = fileName.Trim();
        }

        public CustomFileItem(String fileName, CShItem cshItem)
        {
            CommonInitialization();
            String targetPath = cshItem.Path;
            DealWithSpecialFolders(cshItem.Path, cshItem.DisplayName, ref targetPath);
            this.customFileName = fileName.Trim();
            this.KeyName = cshItem.Name.Trim();
            this.Tag = cshItem.Tag;
            this.lastWriteTime = cshItem.LastWriteTime;
            this.creationTime = cshItem.CreationTime;
            this.typeName = SystemFilesDirInfo.GetFileTypeDescription(targetPath);
            this.fileLength = cshItem.Length;
            this.filePathFull = @targetPath;
            this.isFolder = FileSystemUtilities.IsFullPathIsDirectory(targetPath);
            this.FolderType = (this.isFolder) ? FolderType.TreeView : FolderType.File;
            SetIconsIndex(targetPath);
        }

        public CustomFileItem(String fileName, FileInfo fileInfo)
        {
            CommonInitialization();
            String targetPath = fileInfo.FullName;
            DealWithSpecialFolders(fileInfo.FullName, fileInfo.Name, ref targetPath);
            this.customFileName = fileName.Trim();
            this.KeyName = fileInfo.Name.Trim();
            this.lastWriteTime = fileInfo.LastWriteTime;
            this.creationTime = fileInfo.CreationTime;
            this.typeName = SystemFilesDirInfo.GetFileTypeDescription(targetPath);
            this.fileLength = fileInfo.Length;
            this.filePathFull = @targetPath;
            this.isFolder = false;
            this.FolderType = FolderType.File;
            SetIconsIndex(targetPath);
        }

        public CustomFileItem(String fileName, DirectoryInfo directoryInfor)
        {
            CommonInitialization();
            String targetPath = directoryInfor.FullName;
            DealWithSpecialFolders(directoryInfor.FullName, directoryInfor.Name, ref targetPath);
            this.customFileName = fileName.Trim();
            this.KeyName = directoryInfor.Name.Trim();
            this.lastWriteTime = directoryInfor.LastWriteTime;
            this.creationTime = directoryInfor.CreationTime;
            this.typeName = SystemFilesDirInfo.FOLDER_TYPE_DESCRIPTION;
            this.fileLength = 0;
            this.filePathFull = @targetPath;
            this.isFolder = true;
            this.FolderType = FolderType.TreeView;
            SetIconsIndex(targetPath);
        }

        private void SetIconsIndex(String fullPath)
        {
            if (FileSystemUtilities.IsFullPathIsDirectory(fullPath))
            {
                this.IconIndexOpen = DefaultIcons.SYSTEM_ICONS.GetIconIndexForDirectories();
                this.IconIndexNormal = this.IconIndexOpen;
            }else if (this.isSpecialFolder)
            {
                this.IconIndexOpen = 0;
                this.IconIndexNormal = 0;
            }
            else
            {
                this.IconIndexOpen = DefaultIcons.SYSTEM_ICONS.GetIconIndex(fullPath);
                this.IconIndexNormal = this.IconIndexOpen;
            }
        }

        private void CommonInitialization()
        {
            this.FolderType = FolderType.TreeView;
            this.isFolder = false;
            this.isSpecialFolder = false;
            this.lastWriteTime = DateTime.Now;
            this.creationTime = DateTime.Now;
            this.typeName = "File Folder";
            this.fileLength = 0;
        }
        private void DealWithSpecialFolders(String fullPath, String fileName, ref String targetFilePath)
        {
            targetFilePath = fullPath;

            this.isSpecialFolder = FileSystemUtilities.IsSpecialFolder(fullPath, fileName);
            if (this.isSpecialFolder)
            {
                this.specialFolderFullPath = FileSystemUtilities.GetSpecialFolderFullPath(fileName);

                if (!String.IsNullOrWhiteSpace(this.specialFolderFullPath))
                {
                    targetFilePath = this.specialFolderFullPath;
                }
                else
                {
                    throw new Exception("Invalid Path");
                }
            }
        }


        public String GetCustomFileName
        {
            get
            {
                if (customFileName != null) return customFileName;
                return KeyName;
            }
        }

        public String SetCustomFileName
        {
            set{
                this.customFileName = (value == null) ? null : value.Trim();
            }
        }

        public ArrayList GetShellInfoDirectories()
        {
            ArrayList result = new ArrayList();
            DirectoryInfo[] dInfo = FileSystemUtilities.GetDirectories(FilePathFull);
            if (dInfo == null) return result;

            foreach (DirectoryInfo obj in dInfo)
            {
                if (!FileSystemUtilities.IsSpecialFolder(obj.FullName, obj.Name))
                {
                    result.Add(new CustomFileItem(obj.Name, obj)
                    {
                        isFolder = true
                    });
                }
            }
            return result;
        }

        public ArrayList GetShellInfoFiles()
        {
            ArrayList result = new ArrayList();
            DirectoryInfo dInfo = new DirectoryInfo(FilePathFull);
            try
            {
                foreach (FileInfo obj in dInfo.GetFiles())
                {
                    if(!FileSystemUtilities.IsSpecialFolder(obj.FullName, obj.Name))
                    {
                        result.Add(new CustomFileItem(obj.Name, obj)
                        {
                            isFolder = false
                        });
                    }

                }
            }
            catch (UnauthorizedAccessException) {}

            return result;
        }

        public int CompareTo(Object obj)
        {
            if (obj == null) return 1;
            CustomFileItem cft = (CustomFileItem)obj;
            return this.customFileName.CompareTo(cft.GetCustomFileName);
        }

        public void Dispose()
        {
            this.Dispose();
        }

        public bool IsFolderIsFileViewNode
        {
            get
            {
                return (FolderType == FolderType.File);
            }
        }

        public bool IsFolderIsTreeViewNode
        {
            get
            {
                return (FolderType == FolderType.TreeView);
            }
        }
        public bool IsFolderIsFilterRule
        {
            get
            {
                return (FolderType == FolderType.FilterRule);
            }
        }
        public bool IsGenerallyAFolderType
        {
            get
            {
                return !(this.FolderType == FolderType.File);
            }
        }
        public FolderType FolderType
        {
            get => folderType;
            set
            {
                folderType = value;
                if (this.FolderType != FolderType.File) this.isFolder = true;
            }
        }

        public bool IsFolder { get => isFolder;}

        public DateTime LastWriteTime
        {
            get 
            {
                return lastWriteTime;
            }
        }

        public DateTime CreationTime
        {
            get
            {
                return creationTime;
            }
        }
        
        public string TypeName
        {
            get
            {
                return typeName;
            }
        }

        public long FileLength
        {
            get
            {
                return fileLength;
            }
        }

        public string KeyName { get => keyName; set => keyName = value; }
        
        public int IconIndexNormal { get => iconIndexNormal; set => iconIndexNormal = value; }
        
        public int IconIndexOpen { get => iconIndexOpen; set => iconIndexOpen = value; }
        
        public object Tag { get => tag; set => tag = value; }
        
        public long DirectoriesCount { 
            get 
            {
                if (FileSystemUtilities.IsFullPathIsDirectory(FilePathFull))
                {
                    DirectoryInfo[] dinfo = FileSystemUtilities.GetDirectories(filePathFull);
                    if (dinfo == null) return 0;
                    return FileSystemUtilities.GetDirectories(FilePathFull).Length;
                }
                return 0;
            }
         }
        
        public long FilesCount {
            get
            {
                DirectoryInfo dInfo = new DirectoryInfo(FilePathFull);
                return (FileSystemUtilities.IsFullPathIsDirectory(FilePathFull) ? dInfo.GetFiles().Length : 0);
            }
        }

        public string FilePathFull { get => @filePathFull; }
    }
}
