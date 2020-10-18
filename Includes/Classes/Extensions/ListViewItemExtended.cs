using System;
using System.Windows.Forms;
using ExpTreeLib;
using OneClickZip.Includes.Models;

namespace OneClickZip.Includes.Classes.Extensions
{
    public class ListViewItemExtended : ListViewItem
    {
        private CustomFileItem customFileItem;
        private TreeNodeExtended referenceTreeNode;


        public ListViewItemExtended(CustomFileItem customFileItem) : base(customFileItem.GetCustomFileName)
        {
            this.customFileItem = customFileItem;
            SetDefaultIcon();
        }
        public ListViewItemExtended(CustomFileItem customFileItem, string[] items) : base(items)
        {
            this.customFileItem = customFileItem;
            SetDefaultIcon();
        }
        public CustomFileItem CustomFileItem { get => customFileItem; }
        public TreeNodeExtended ReferenceTreeNode { get => referenceTreeNode; set => referenceTreeNode = value; }
        private void SetDefaultIcon()
        {
            switch (CustomFileItem.FolderType)
            {
                case Models.Types.FolderType.File:
                    this.ImageIndex = DefaultIcons.SYSTEM_ICONS.GetIconIndex(CustomFileItem.FilePathFull);
                    break;
                case Models.Types.FolderType.TreeView:
                    this.ImageIndex = DefaultIcons.SYSTEM_ICONS.GetIconIndexForDirectories();
                    break;
                case Models.Types.FolderType.FilterRule:
                    this.ImageIndex = DefaultIcons.SYSTEM_ICONS.GetIconIndexForFolderFilterRule();
                    this.ForeColor = System.Drawing.Color.Blue;
                    break;
                default:
                    this.ImageIndex = DefaultIcons.SYSTEM_ICONS.GetIconIndexForDirectories();
                    break;
            }
        }
    }

}
