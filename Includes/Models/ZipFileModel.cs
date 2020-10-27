using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OneClickZip.Includes.Classes;
using OneClickZip.Includes.Classes.Extensions;
using OneClickZip.Includes.Classes.TreeNodeSerialize;
using OneClickZip.Includes.Utilities;

namespace OneClickZip.Includes.Models
{
    [Serializable]
    public class ZipFileModel
    {
        private SerializableTreeNode treeViewZipFileStructure;
        private FileNameCreator fileNameCreator;
        private String filePath;
        private TargetOutputLocationModel targetOutputLocationModel;

        public ZipFileModel()
        {
            this.treeViewZipFileStructure = new SerializableTreeNode();
        }

        public ZipFileModel(TreeNodeExtended treeNodeExtended, FileNameCreator fileNameCreator)
        {
            this.fileNameCreator = fileNameCreator;
            this.treeViewZipFileStructure = new SerializableTreeNode();
            SetTreeViewZipFileStructureForFileWriting(treeNodeExtended);
        }

        public TreeNodeExtended GetTreeViewZipFileStructure() {
            return SerializableTreeViewOperation.fnPrepareToRead(treeViewZipFileStructure);
        }
        
        public SerializableTreeNode GetTreeViewZipFileSerializedStructure
        {
            get
            {
                return this.treeViewZipFileStructure;
            }
        }

        public void SetTreeViewZipFileStructureForFileWriting(TreeNodeExtended treeNodeExtended)
        {
            treeViewZipFileStructure = SerializableTreeViewOperation.fnPrepareToWrite(treeNodeExtended);
        }

        public FileNameCreator FileNameCreator { get => fileNameCreator; set => fileNameCreator = value; }
        
        public string FilePath { get => filePath; set => filePath = value; }
        
        public String GetFullPathFileAndNameOfNewZipArchive
        {
            get
            {
                String targetPath = TargetOutputLocationModel.MainTargetLocation.Trim();
                if(!TargetOutputLocationModel.MainTargetLocation.EndsWith(@"\")) targetPath += @"\";
                return String.Format(@"{0}{1}.zip", targetPath, fileNameCreator.GetDerivedFormula());
            }
        }

        public String GetFileName
        {
            get
            {
                if (filePath == null) return "";
                if (filePath == "") return "";
                if (FileSystemUtilities.IsFullPathIsDirectory(filePath))
                {
                    DirectoryInfo dInfo = new DirectoryInfo(filePath);
                    return dInfo.Name;
                }
                else
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    return fileInfo.Name;
                }
            }
        }

        public TargetOutputLocationModel TargetOutputLocationModel 
        {
            get
            {
                if (targetOutputLocationModel == null)
                    targetOutputLocationModel = new TargetOutputLocationModel(FileSystemUtilities.GetDefaultDirectory());
                if (!Directory.Exists(targetOutputLocationModel.MainTargetLocation))
                {
                    TargetOutputLocationModel tmp = new TargetOutputLocationModel(FileSystemUtilities.GetDefaultDirectory());
                    tmp.AddRange(targetOutputLocationModel.GetTargetLocations());
                    targetOutputLocationModel = (TargetOutputLocationModel) tmp.Clone();
                    return targetOutputLocationModel;
                }
                return targetOutputLocationModel;
            }
            set
            {
                targetOutputLocationModel = value;
            }
        }
    }
}
