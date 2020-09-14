using ExpTreeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneClickZip.Includes.Classes
{
    class TreeNodeInterpreter
    {
        public static void addRecursiveNode(TreeNode targetTreeNode, CShItem cshItem){
            TreeNode selectedNode = addParentDirectory(targetTreeNode, cshItem);
            if (cshItem.Directories.Count() <= 0) return;

            foreach (CShItem itemDir in cshItem.Directories){
                TreeNode treeNode = new TreeNode();
                treeNode.Text = itemDir.DisplayName;
                treeNode.Tag = itemDir;
                TreeNodeInterpreter.addRecursiveNode(treeNode, itemDir);
                selectedNode.Nodes.Add(treeNode);
            }
        }

        private static TreeNode addParentDirectory(TreeNode targetTreeNode, CShItem cshItem)
        {
            if (!cshItem.IsFolder) return targetTreeNode;
            TreeNode treeNode = new TreeNode();
            treeNode.Text = cshItem.DisplayName;
            treeNode.Tag = cshItem;
            targetTreeNode.Nodes.Add(treeNode);
            return treeNode;
        }
    }





}
