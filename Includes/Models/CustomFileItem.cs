using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpTreeLib;

namespace OneClickZip.Includes.Models
{
    public class CustomFileItem : IDisposable, IComparable
    {
        private CShItem cshItem;
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
            this.cshItem = cshItem;
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

        public String GetCustomFileName()
        {
            if (customFileName != null) return customFileName;
            if (cshItem != null) return cshItem.DisplayName;
            throw new Exception("couldnt locate file item name");
        }

        public String SetCustomFileName
        {
            set{
                this.customFileName = value;
            }
        }


        public CShItem CshItem { get => cshItem; }
        
        public ArrayList GetShellInfoDirectories()
        {
            ArrayList result = new ArrayList();
            foreach (CShItem obj in this.cshItem.GetDirectories())
            {
                result.Add(new CustomFileItem(obj.DisplayName, obj)
                {
                    isFolder = true
                });
            }
            return result;
        }

        public ArrayList GetShellInfoFiles()
        {
            ArrayList result = new ArrayList();
            foreach (CShItem obj in this.cshItem.GetFiles())
            {
                result.Add(new CustomFileItem(obj.DisplayName, obj)
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
            return this.customFileName.CompareTo(cft.GetCustomFileName());
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
                if (isCustomFolder)
                {
                    return lastWriteTime;
                }
                return this.cshItem.LastWriteTime;
            }
        }

        public DateTime CreationTime
        {
            get
            {
                if (isCustomFolder)
                {
                    return creationTime;
                }
                return this.cshItem.CreationTime;
            }
        }
        public string TypeName
        {
            get
            {
                if (isCustomFolder)
                {
                    return typeName;
                }
                return this.cshItem.TypeName;
            }
        }

        public long FileLength
        {
            get
            {
                if (isCustomFolder)
                {
                    return fileLength;
                }
                return this.cshItem.Length;
            }
        }
        

    }
}
