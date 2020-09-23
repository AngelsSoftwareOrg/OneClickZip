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
    public class TreeNodeExtended : TreeNode
    {
        private readonly ArrayList masterListFilesDir = new ArrayList();
        private bool isStructuredNode;
        private bool isCustomFolder;
        private bool isRootNode;

        public TreeNodeExtended() : base(){
            CommonInitializers();
        }

        public TreeNodeExtended(bool isRootNode)
        {
            CommonInitializers();
            this.isRootNode = isRootNode;
            if (this.isRootNode)
            {
                this.Text = "ROOT";
                this.Name = "ROOT";
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

        public void ClearItem()
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
        
        public bool IsRootNode { get => isRootNode; }
    }
}
