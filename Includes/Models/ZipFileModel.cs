using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OneClickZip.Includes.Classes;

namespace OneClickZip.Includes.Models
{
    class ZipFileModel
    {
        private TreeView treeViewZipFileStructure;
        private FileNameCreator fileNameCreator;


        public ZipFileModel()
        {
        }
        public ZipFileModel(TreeView treeViewZipFileStructure)
        {
            this.treeViewZipFileStructure = treeViewZipFileStructure;
        }

        public ZipFileModel(TreeView treeViewZipFileStructure, FileNameCreator fileNameCreator)
        {
            this.treeViewZipFileStructure = treeViewZipFileStructure;
            this.fileNameCreator = fileNameCreator;
        }

        public string ZipFileName { get => fileNameCreator.FileFormulaName; }

        public TreeView TreeViewZipFileStructure { get => treeViewZipFileStructure; set => treeViewZipFileStructure = value; }

        public FileNameCreator FileNameCreator { get => fileNameCreator; set => fileNameCreator = value; }
    }
}
