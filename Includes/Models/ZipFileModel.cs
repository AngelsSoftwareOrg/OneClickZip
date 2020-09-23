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
        private TreeNodeSerializable treeViewZipFileStructure;
        private FileNameCreator fileNameCreator;
        private String filePath;

        public ZipFileModel()
        {
        }
        public ZipFileModel(TreeView treeViewZipFileStructure)
        {
            this.treeViewZipFileStructure = new TreeNodeSerializable(treeViewZipFileStructure);
        }

        public ZipFileModel(TreeView treeViewZipFileStructure, FileNameCreator fileNameCreator)
        {
            this.treeViewZipFileStructure = new TreeNodeSerializable(treeViewZipFileStructure);
            this.fileNameCreator = fileNameCreator;
        }

        public string ZipFileName { get => fileNameCreator.FileFormulaName; }

        public TreeView TreeViewZipFileStructure {
            get 
            {
                return null;
                //return SerializableTreeViewOperation.fnPrepareToRead(treeViewZipFileStructure.SerializedTreeNodeStructure);
            }
            set {
                //treeViewZipFileStructure.SerializedTreeNodeStructure = new TreeNodeSerializable(value);
            }
        }
        public FileNameCreator FileNameCreator { get => fileNameCreator; set => fileNameCreator = value; }
        public string FilePath { get => filePath; set => filePath = value; }
    }
}
