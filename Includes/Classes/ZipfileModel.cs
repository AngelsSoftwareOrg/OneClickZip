using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneClickZip.Includes.Classes
{
    class ZipfileModel
    {
        private readonly TreeView treeViewZipFileStructure;
        private String zipFileName;

        public ZipfileModel(TreeView treeViewZipFileStructure)
        {
            this.treeViewZipFileStructure = treeViewZipFileStructure;
        }

        public TreeView TreeViewZipFileStructure => treeViewZipFileStructure;

        public string ZipFileName { get => zipFileName; set => zipFileName = value; }
    }
}
