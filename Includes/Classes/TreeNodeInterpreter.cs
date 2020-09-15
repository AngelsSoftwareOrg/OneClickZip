using ExpTreeLib;
using OneClickZip.Includes.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneClickZip.Includes.Classes
{
    class TreeNodeInterpreter
    {
        //
        // true = the node to add are already existing on the current selected tree node
        // false = the node to add was not existing on the selected node of the tree
        //
        public static bool addRecursiveNode(TreeNodeExtended targetTreeNode, CShItem cshItem){
            bool isExistingParentNode = isNodeExisting(targetTreeNode, cshItem);
            TreeNodeExtended selectedNode = addParentDirectory(targetTreeNode, cshItem);
            if (isExistingParentNode) return isExistingParentNode;
            if (cshItem.Directories.Count() <= 0) return false;
            addSubDirectories(selectedNode, cshItem);
            return isExistingParentNode;
        }

        private static void addSubDirectories(TreeNodeExtended targetTreeNode, CShItem cshItem)
        {
            foreach (CShItem itemDir in cshItem.Directories)
            {
                if (!isNodeExisting(targetTreeNode, cshItem))
                {
                    TreeNodeExtended treeNode = new TreeNodeExtended();
                    treeNode.Name = itemDir.DisplayName; //key of this node
                    treeNode.Text = itemDir.DisplayName;
                    addTagObject(treeNode, itemDir);
                    targetTreeNode.Nodes.Add(treeNode);
                    TreeNodeInterpreter.addSubDirectories(treeNode, itemDir);
                }
                else
                {
                    TreeNodeInterpreter.addSubDirectories((TreeNodeExtended) targetTreeNode.Nodes[0], itemDir);
                }
            }
        }

        public static void addRootItemFilesAsNode(TreeNodeExtended targetTreeNode, CShItem cshItem)
        {
            TreeNodeExtended treeNode = new TreeNodeExtended();
            treeNode.Name = cshItem.DisplayName; //key of this node
            treeNode.Text = cshItem.DisplayName;
            addTagObject(treeNode, cshItem);
            targetTreeNode.Nodes.Add(treeNode);
        }

        private static TreeNodeExtended addParentDirectory(TreeNodeExtended targetTreeNode, CShItem cshItem)
        {
            if (!cshItem.IsFolder) return targetTreeNode;
            if (isNodeExisting(targetTreeNode, cshItem)) return targetTreeNode;
            TreeNodeExtended treeNode = new TreeNodeExtended();
            treeNode.Name = cshItem.DisplayName; //key of this node
            treeNode.Text = cshItem.DisplayName;
            addTagObject(treeNode, cshItem);
            targetTreeNode.Nodes.Add(treeNode);
            return treeNode;
        }

        public static ArrayList addTagObject(TreeNodeExtended treeNode, CShItem cshItem)
        {
            treeNode.addItem(cshItem);
            return treeNode.MasterListFilesDir;
        }

        private static Boolean isNodeExisting(TreeNodeExtended targetTreeNode, CShItem cshItem)
        {
            //Console.WriteLine("isNodeExisting ~~~~~~~~~~~~");
            //Console.WriteLine(targetTreeNode.Nodes.IndexOfKey(cshItem.DisplayName) + " / " + targetTreeNode.Nodes.ContainsKey(cshItem.DisplayName));
            //Console.WriteLine();
            foreach(TreeNode currNode in targetTreeNode.Nodes)
            {
                if(currNode.Text.Equals(cshItem.DisplayName, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }





}
