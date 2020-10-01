using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneClickZip.Includes.Classes.TreeNodeSerialize;

namespace OneClickZip.Includes.Interface
{
    public interface IZipFileTreeNode
    {
        string Name { get; set; }
        int ImageIndex { get; set; }
        int SelectedImageIndex { get; set; }
        object Tag { get; set; }
        string ToolTipText { get; set; }
        string Text { get; set; }
        List<SerializableTreeNode> Nodes { get; set; }
        ArrayList MasterListFilesDir { get; set; }
        bool IsStructuredNode { get; set; }
        bool IsCustomFolder { get; set; }
        bool IsRootNode { get; set; }
        bool IsAFolderGenerally { get; }
    }
}
