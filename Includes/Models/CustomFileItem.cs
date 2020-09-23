using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpTreeLib;
using OneClickZip.Includes.Classes;

namespace OneClickZip.Includes.Models
{
    [Serializable]
    public class CustomFileItem : IDisposable, IComparable
    {
        //private CShItem cshItem;

        private string keyName = String.Empty;
        private int iconIndexNormal = -1;
        private int iconIndexOpen = -1;
        private Object tag;
        private String filePathFull;
        private bool isCustomFolder;
        private bool isFolder;
        private String customFileName;
        private DateTime lastWriteTime;
        private DateTime creationTime;
        private String typeName;
        private long fileLength;


        public CustomFileItem()
        {
            commonInitialization();
        }

        public CustomFileItem(String fileName)
        {
            commonInitialization();
            this.customFileName = fileName;
        }

        public CustomFileItem(String fileName, CShItem cshItem)
        {
            commonInitialization();
            this.customFileName = fileName;
            //this.cshItem = cshItem;

            this.KeyName = cshItem.Name;
            this.Tag = cshItem.Tag;
           
            this.lastWriteTime = cshItem.LastWriteTime;
            this.creationTime = cshItem.CreationTime;
            this.typeName = cshItem.TypeName;
            this.fileLength = cshItem.Length;
            this.filePathFull = cshItem.Path;
            //this.IconIndexOpen = DefaultIcons.SYSTEM_ICONS.GetIconIndex(cshItem.Path);
            //this.IconIndexNormal = this.IconIndexOpen;
            SetIconsIndex(cshItem.Path);
        }

        public CustomFileItem(String fileName, FileInfo fileInfo)
        {
            commonInitialization();
            this.customFileName = fileName;
            this.KeyName = fileInfo.Name;
            this.lastWriteTime = fileInfo.LastWriteTime;
            this.creationTime = fileInfo.CreationTime;
            this.typeName = fileInfo.GetType().ToString();
            this.fileLength = fileInfo.Length;
            this.filePathFull = fileInfo.FullName;
            //this.IconIndexOpen = DefaultIcons.SYSTEM_ICONS.GetIconIndex(fileInfo.FullName);
            //this.IconIndexNormal = this.IconIndexOpen;
            SetIconsIndex(fileInfo.FullName);
        }

        public CustomFileItem(String fileName, DirectoryInfo directoryInfor)
        {
            commonInitialization();
            this.customFileName = fileName;
            this.KeyName = directoryInfor.Name;
            this.lastWriteTime = directoryInfor.LastWriteTime;
            this.creationTime = directoryInfor.CreationTime;
            this.typeName = directoryInfor.GetType().ToString();
            this.fileLength = 0;
            this.filePathFull = directoryInfor.FullName;
            SetIconsIndex(directoryInfor.FullName);
        }

        private void SetIconsIndex(String fullPath)
        {
            if (IsFullPathIsDirectory(fullPath))
            {
                this.IconIndexOpen = DefaultIcons.SYSTEM_ICONS.GetIconIndexForDirectories();
                this.IconIndexNormal = this.IconIndexOpen;
            }
            else
            {
                this.IconIndexOpen = DefaultIcons.SYSTEM_ICONS.GetIconIndex(fullPath);
                this.IconIndexNormal = this.IconIndexOpen;
            }
        }


        private void commonInitialization()
        {
            this.isCustomFolder = false;
            this.isFolder = false;
            this.lastWriteTime = DateTime.Now;
            this.creationTime = DateTime.Now;
            this.typeName = "Folder";
            this.fileLength = 0;
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
                this.customFileName = value;
            }
        }

        //public CShItem CshItem { get => cshItem; }
        
        public ArrayList GetShellInfoDirectories()
        {
            ArrayList result = new ArrayList();
            DirectoryInfo dInfo = new DirectoryInfo(this.filePathFull);
            foreach (DirectoryInfo obj in dInfo.GetDirectories())
            {
                result.Add(new CustomFileItem(obj.Name, obj)
                {
                    isFolder = true
                });
            }
            return result;
        }

        public ArrayList GetShellInfoFiles()
        {
            ArrayList result = new ArrayList();
            DirectoryInfo dInfo = new DirectoryInfo(this.filePathFull);

            foreach (FileInfo obj in dInfo.GetFiles())
            {
                result.Add(new CustomFileItem(obj.Name, obj)
                {
                    isFolder = false
                });
            }
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

        public bool IsCustomFolder
        {
            get => isCustomFolder;
            set
            {
                isCustomFolder = value;
                isFolder = true;
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
                DirectoryInfo dInfo = new DirectoryInfo(this.filePathFull);
                return (IsFullPathIsDirectory(this.filePathFull) ? dInfo.GetDirectories().Length : 0);
            }
         }
        public long FilesCount {
            get
            {
                DirectoryInfo dInfo = new DirectoryInfo(this.filePathFull);
                return (IsFullPathIsDirectory(this.filePathFull) ? dInfo.GetFiles().Length : 0);
            }
        }
        public string FilePathFull { get => filePathFull; }
        private bool IsFullPathIsDirectory(String fullPath)
        {
            DirectoryInfo dInfo = new DirectoryInfo(this.filePathFull);
            if ((dInfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                return true;
            }
            return false;
        }
    }
}
