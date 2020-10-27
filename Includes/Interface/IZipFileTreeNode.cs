using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneClickZip.Includes.Classes;
using OneClickZip.Includes.Classes.TreeNodeSerialize;
using OneClickZip.Includes.Models;
using OneClickZip.Includes.Models.Types;

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
        List<CustomFileItem> MasterListFilesDir { get; set; }
        bool IsFolderIsTreeViewNode { get; set; }
        bool IsFolderIsFileViewNode { get; set; }
        bool IsRootNode { get; set; }
        bool IsGenerallyAFolderType { get; }
        FolderType FolderType { get; set; }
        FolderFilterRule FolderFilterRuleObj { get; set; }
    }
}
