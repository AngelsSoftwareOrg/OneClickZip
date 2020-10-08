﻿using ExpTreeLib;
using OneClickZip.Includes.Classes.TreeNodeSerialize;
using OneClickZip.Includes.Interface;
using OneClickZip.Includes.Models;
using OneClickZip.Includes.Models.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneClickZip.Includes.Classes.Extensions
{
    public class TreeNodeExtended : TreeNode, ICloneable, IZipFileTreeNode
    {
        private ArrayList masterListFilesDir = new ArrayList();
        private FolderType folderType;
        private bool isRootNode;
        private readonly String ROOT_NODE_NAME = "ROOT";
        private FolderFilterRule folderFilterRuleObj;

        public TreeNodeExtended() : base(){
            CommonInitializers();
        }
        public TreeNodeExtended(bool isRootNode)
        {
            CommonInitializers();
            this.isRootNode = isRootNode;
            if (this.isRootNode)
            {
                this.Text = ROOT_NODE_NAME;
                this.Name = ROOT_NODE_NAME;
            }
        }
        private void CommonInitializers()
        {
            folderType = FolderType.TreeView;
        }
        public void AddItem(CustomFileItem customFileItem)
        {
            this.masterListFilesDir.Add(customFileItem);
        }
        public void ClearAndDisposeNodes()
        {
            this.Nodes.Clear();
            ClearItems();
        }
        public void ClearItems()
        {
            this.masterListFilesDir.Clear();
        }
        public void RemoveItem(CustomFileItem customFileItem)
        {
            this.masterListFilesDir.Remove(customFileItem);
            this.RemoveSubNode(customFileItem.GetCustomFileName);
        }
        public void RemoveItemByNodeName(String nodeName)
        {
            List<CustomFileItem> listForRemoval = new List<CustomFileItem>();
            foreach (CustomFileItem customeFileName in this.masterListFilesDir)
            {
                if (customeFileName.GetCustomFileName == nodeName)
                {
                    listForRemoval.Add(customeFileName);
                }
            }

            foreach (CustomFileItem customeFileName in listForRemoval)
            {
                this.masterListFilesDir.Remove(customeFileName);
            }
        }
        public void UpdateCustomFileItemDisplayText(String oldName, String newDisplayText)
        {
            foreach (CustomFileItem customeFileName in this.masterListFilesDir)
            {
                if (customeFileName.GetCustomFileName == oldName)
                {
                    customeFileName.SetCustomFileName = newDisplayText;
                }
            }
        }
        private void RemoveSubNode(String nodeName)
        {
            List<TreeNode> listNodesForRemoval = new List<TreeNode>();
            foreach(TreeNode node in this.Nodes)
            {
                if (nodeName == node.Text) listNodesForRemoval.Add(node);
            }
            foreach (TreeNode node in listNodesForRemoval)
            {
                node.Remove();
            }
        }
        public ArrayList MasterListFilesDir { get => this.masterListFilesDir; set => this.masterListFilesDir = value; }
        public bool IsFolderIsTreeViewNode { 
            get 
            {
                return (FolderType == FolderType.TreeView);
            } 
            set 
            {
                FolderType = (value) ? FolderType.TreeView : FolderType.File;
            }
        }
        public bool IsFolderIsFileViewNode
        {
            get
            {
                return (FolderType == FolderType.File);
            }
            set
            {
                FolderType = (value) ? FolderType.File : FolderType.TreeView;
            }
        }
        public bool IsFolderIsFilterRule
        {
            get
            {
                return (FolderType == FolderType.FilterRule);
            }
            set
            {
                if (value)
                {
                    FolderType = FolderType.FilterRule;
                    SetFilterRuleFolderFontColor();
                }
                else
                {
                    FolderType = FolderType.TreeView;
                }
            }
        }
        private void SetFilterRuleFolderFontColor()
        {
            if (FolderType != FolderType.FilterRule) return;
            //this.BackColor = Color.Blue;
            this.ForeColor = Color.Blue;
        }
        public bool IsRootNode { 
            get
            {
                if(isRootNode) return true;
                if (this.Name == ROOT_NODE_NAME && this.Text == ROOT_NODE_NAME) return true;
                return false;
            }
            set
            {
                this.IsRootNode = value;
            }
        }
        override
        public object Clone()
        {
            TreeNodeExtended tnx = (TreeNodeExtended) base.Clone();
            tnx.MasterListFilesDir.AddRange(this.MasterListFilesDir);
            tnx.FolderType = this.FolderType;
            if (FolderFilterRuleObj == null)
            {
                tnx.FolderFilterRuleObj = FolderFilterRuleObj;
            }
            else
            {
                tnx.FolderFilterRuleObj = (FolderFilterRule)FolderFilterRuleObj.Clone();
            }
            return tnx;
        }
        public void SourceInExtendedDetails(TreeNodeExtended source)
        {
            this.MasterListFilesDir.AddRange(source.masterListFilesDir);
            this.FolderType = source.FolderType;
            this.FolderFilterRuleObj = source.FolderFilterRuleObj;
        }
        public bool IsGenerallyAFolderType
        {
            get
            {
                return !(this.FolderType==FolderType.File);
            }
        }
        public new object Tag 
        { 
            get
            {
                return base.Tag;
            }
            set
            {
                base.Tag = value;
            }
        }
        List<SerializableTreeNode> IZipFileTreeNode.Nodes 
        {
            get
            {
                SerializableTreeNode serial = SerializableTreeViewOperation.fnPrepareToWrite((TreeNodeExtended) this);
                return serial.Nodes.ToList<SerializableTreeNode>();
            }
            set
            {
                throw new ArgumentException("Not applicable. Make control of TreeNodeExtended.Nodes instead.");
            }
        }
        public FolderType FolderType
        {
            get => folderType;
            set
            {
                folderType = value;
                SetFilterRuleFolderFontColor();
            }
        }
        public FolderFilterRule FolderFilterRuleObj { get => folderFilterRuleObj; set => folderFilterRuleObj = value; }
    }
}
