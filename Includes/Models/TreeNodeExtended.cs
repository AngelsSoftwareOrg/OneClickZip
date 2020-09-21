using ExpTreeLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneClickZip.Includes.Models
{
    public class TreeNodeExtended : TreeNode
    {
        private readonly ArrayList masterListFilesDir = new ArrayList();
        private bool isStructuredNode;

        public TreeNodeExtended() : base(){
            isStructuredNode = true;
        }

        public void AddItem(CShItem cshItem)
        {
            this.masterListFilesDir.Add(cshItem);
        }

        public void ClearItem()
        {
            this.masterListFilesDir.Clear();
        }

        public void RemoveItem(CShItem cshItem)
        {
            this.masterListFilesDir.Remove(cshItem);
            this.RemoveSubNode(cshItem.DisplayName);
        }

        public void RemoveItemByNodeName(String nodeName)
        {
            List<CShItem> listForRemoval = new List<CShItem>();
            foreach (CShItem cshItem in this.masterListFilesDir)
            {
                if (cshItem.Name == nodeName || cshItem.Text == nodeName)
                {
                    listForRemoval.Add(cshItem);
                }
            }

            foreach (CShItem cshItem in listForRemoval)
            {
                this.masterListFilesDir.Remove(cshItem);
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
    }
}
