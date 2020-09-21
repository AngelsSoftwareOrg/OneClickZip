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
        public static bool AddRecursiveNode(TreeNodeExtended targetTreeNode, CShItem cshItem){
            bool isExistingParentNode = IsNodeExisting(targetTreeNode, cshItem);
            TreeNodeExtended selectedNode = AddParentDirectory(targetTreeNode, cshItem);
            if (isExistingParentNode) return isExistingParentNode;
            if (cshItem.Directories.Count() <= 0) return false;
            AddSubDirectories(selectedNode, cshItem);
            return isExistingParentNode;
        }

        private static void AddSubDirectories(TreeNodeExtended targetTreeNode, CShItem cshItem)
        {
            foreach (CShItem itemDir in cshItem.Directories)
            {
                if (!IsNodeExisting(targetTreeNode, cshItem))
                {
                    TreeNodeExtended treeNode = new TreeNodeExtended();
                    treeNode.Name = itemDir.DisplayName; //key of this node
                    treeNode.Text = itemDir.DisplayName;
                    TagAllObjects(treeNode, itemDir);
                    targetTreeNode.Nodes.Add(treeNode);
                    TreeNodeInterpreter.AddSubDirectories(treeNode, itemDir);
                }
                else
                {
                    TreeNodeInterpreter.AddSubDirectories((TreeNodeExtended) targetTreeNode.Nodes[0], itemDir);
                }
            }
        }

        public static void AddRootItemFilesAsNode(TreeNodeExtended targetTreeNode, CShItem cshItem)
        {
            TreeNodeExtended treeNode = new TreeNodeExtended();
            treeNode.Name = cshItem.DisplayName; //key of this node
            treeNode.Text = cshItem.DisplayName;
            AddTagObject(treeNode, cshItem);
            targetTreeNode.Nodes.Add(treeNode);
        }

        private static TreeNodeExtended AddParentDirectory(TreeNodeExtended targetTreeNode, CShItem cshItem)
        {
            if (!cshItem.IsFolder) return targetTreeNode;
            if (IsNodeExisting(targetTreeNode, cshItem)) return targetTreeNode;
            TreeNodeExtended treeNode = new TreeNodeExtended();
            treeNode.Name = cshItem.DisplayName; //key of this node
            treeNode.Text = cshItem.DisplayName;
            TagAllObjects(treeNode, cshItem);
            targetTreeNode.Nodes.Add(treeNode);
            return treeNode;
        }

        
        private static void TagAllObjects(TreeNodeExtended treeNode, CShItem cshItem)
        {
            //_ = AddTagObject(treeNode, cshItem);
            foreach (CShItem cshFile in cshItem.GetFiles())
            {
                _ = AddTagObject(treeNode, cshFile);
            }
            foreach (CShItem cshFile in cshItem.GetDirectories())
            {
                _ = AddTagObject(treeNode, cshFile);
            }
        }
        
        public static ArrayList AddTagObject(TreeNodeExtended treeNode, CShItem cshItem)
        {
            treeNode.AddItem(cshItem);
            return treeNode.MasterListFilesDir;
        }

        private static Boolean IsNodeExisting(TreeNodeExtended targetTreeNode, CShItem cshItem)
        {
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
