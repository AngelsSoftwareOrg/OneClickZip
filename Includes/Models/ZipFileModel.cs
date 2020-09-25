using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OneClickZip.Includes.Classes;
using OneClickZip.Includes.Classes.Extensions;
using OneClickZip.Includes.Classes.TreeNodeSerialize;

namespace OneClickZip.Includes.Models
{
    [Serializable]
    class ZipFileModel
    {
        private SerializableTreeNode treeViewZipFileStructure;
        private FileNameCreator fileNameCreator;
        private String filePath;

        public ZipFileModel()
        {
        }
        
        public ZipFileModel(TreeView treeViewZipFileStructure)
        {
            this.treeViewZipFileStructure = new SerializableTreeNode();
        }

        public ZipFileModel(TreeNodeExtended treeNodeExtended, FileNameCreator fileNameCreator)
        {
            this.fileNameCreator = fileNameCreator;
            this.treeViewZipFileStructure = new SerializableTreeNode();
            SetTreeViewZipFileStructureForFileWriting(treeNodeExtended);
        }

        public string ZipFileName { get => fileNameCreator.FileFormulaName; }

        public TreeNodeExtended GetTreeViewZipFileStructure() {
            return SerializableTreeViewOperation.fnPrepareToRead(treeViewZipFileStructure);
        }

        public void SetTreeViewZipFileStructureForFileWriting(TreeNodeExtended treeNodeExtended)
        {
            treeViewZipFileStructure = SerializableTreeViewOperation.fnPrepareToWrite(treeNodeExtended);
        }

        public FileNameCreator FileNameCreator { get => fileNameCreator; set => fileNameCreator = value; }
        
        public string FilePath { get => filePath; set => filePath = value; }
    }
}
