using ExpTreeLib;
using OneClickZip.Includes.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneClickZip.Includes.Classes.Extensions
{
    public class TreeNodeExtended : TreeNode, ICloneable
    {
        private readonly ArrayList masterListFilesDir = new ArrayList();
        private bool isStructuredNode;
        private bool isCustomFolder;
        private bool isRootNode;
        private static String ROOT_NODE_NAME = "ROOT";

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
            isStructuredNode = true;
            isCustomFolder = false;
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

        public ArrayList MasterListFilesDir => this.masterListFilesDir;

        public bool IsStructuredNode { get => isStructuredNode; set => isStructuredNode = value; }
        
        public bool IsCustomFolder { get => isCustomFolder; set => isCustomFolder = value; }
        
        public bool IsRootNode { 
            get
            {
                if(isRootNode) return true;
                if (this.Name == ROOT_NODE_NAME && this.Text == ROOT_NODE_NAME) return true;
                return false;
            }
        }
    
        override
        public object Clone()
        {
            TreeNodeExtended tnx = (TreeNodeExtended) base.Clone();
            tnx.MasterListFilesDir.AddRange(this.MasterListFilesDir);
            tnx.IsStructuredNode = this.IsStructuredNode;
            tnx.IsCustomFolder = this.IsCustomFolder;
            return tnx;
        }
    
        public void SourceInExtendedDetails(TreeNodeExtended source)
        {
            this.MasterListFilesDir.AddRange(source.masterListFilesDir);
            this.IsStructuredNode = source.isStructuredNode;
            this.IsCustomFolder = source.isCustomFolder;
        }

        public bool IsAFolderGenerally
        {
            get
            {
                return (IsStructuredNode || IsCustomFolder);
            }
        }
    }
}
