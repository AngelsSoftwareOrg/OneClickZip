using ExpTreeLib;
using OneClickZip.Includes.Classes.Extensions;
using OneClickZip.Includes.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
                    SetTreeNodeIcon(treeNode, itemDir);
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
            treeNode.IsStructuredNode = false;
            AddTagObject(treeNode, cshItem);
            SetTreeNodeIcon(treeNode, cshItem);
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
            SetTreeNodeIcon(treeNode, cshItem);
            targetTreeNode.Nodes.Add(treeNode);
            return treeNode;
        }

        private static void SetTreeNodeIcon(TreeNodeExtended targetTreeNode, CShItem cshItem)
        {
            targetTreeNode.ImageIndex = cshItem.IconIndexNormal;
            targetTreeNode.SelectedImageIndex = cshItem.IconIndexNormal;
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

        public static void NewZipStructureProcedure(TreeView targetTreeView, ListView targetListview)
        {
            targetTreeView.Nodes.Clear();
            targetListview.Items.Clear();
            TreeNodeExtended rootNode = new TreeNodeExtended();
            rootNode.Text = "ROOT";
            rootNode.Name = "ROOT";
            targetTreeView.Nodes.Add(rootNode);
            targetTreeView.SelectedNode = rootNode;
            targetListview.Tag = rootNode;
            SelectSelectedNodeBgColor(targetTreeView);
        }

        public static bool IsSelectedZipModelNodeRoot(TreeView targetTreeView)
        {
            return (targetTreeView.SelectedNode.Name == "ROOT");
        }

        public static void SelectSelectedNodeBgColor(TreeView targetTreeView)
        {
            if (targetTreeView.SelectedNode == null) return;
            targetTreeView.SelectedNode.BackColor = Color.Gray;
        }

        public static void RemovePreviousSelectedNodeBgColor(TreeView targetTreeView)
        {
            if (targetTreeView.SelectedNode == null) return;
            targetTreeView.SelectedNode.BackColor = Color.Empty;
        }

        public static bool AddZipFileNode(TreeView targetTreeView, CShItem cshItem)
        {
            TreeNodeExtended selectedNode = (TreeNodeExtended)((targetTreeView.SelectedNode == null) 
                                                        ? targetTreeView.Nodes[0] : targetTreeView.SelectedNode);
            bool isExistingNode = AddRecursiveNode(selectedNode, cshItem);

            if (IsSelectedZipModelNodeRoot(targetTreeView) && !cshItem.IsFolder && !isExistingNode)
            {
                AddRootItemFilesAsNode(selectedNode, cshItem);
            }
            return isExistingNode;
        }

        public static void PutTheSelectedFilesAndDirOnSelectedTreeNode(ListView targetListView, TreeView targetTreeView, ListView.SelectedListViewItemCollection lstViewColl)
        {
            targetTreeView.BeginUpdate();
            targetListView.BeginUpdate();
            foreach (ListViewItemExtended lvItem in lstViewColl)
            {
                //if node are not yet existed on the currently selected node of the tree
                if (!AddZipFileNode(targetTreeView, lvItem.CshItem))
                {
                    TreeNodeExtended selectedNode = (TreeNodeExtended)targetTreeView.SelectedNode;
                    AddTagObject(selectedNode, lvItem.CshItem);
                    ListViewInterpretor.GenerateListViewZipFileViewItems(new ListViewInterpretorViewingParamModel()
                    {
                        SelectedTreeNodeExtended = selectedNode,
                        TargetListView = targetListView,
                        CshItem = lvItem.CshItem
                    });
                }
            }
            targetTreeView.EndUpdate();
            targetListView.EndUpdate();
        }

        public static void RemoveSelectedNode(TreeView targetTreeView, ListView targetListView)
        {
            if (targetTreeView.SelectedNode == null) return;
            if (IsSelectedZipModelNodeRoot(targetTreeView))
            {
                NewZipStructureProcedure(targetTreeView, targetListView);
                return;
            }

            TreeNodeExtended parentNode = (TreeNodeExtended)targetTreeView.SelectedNode.Parent;
            TreeNodeExtended selectedNode = (TreeNodeExtended)targetTreeView.SelectedNode;
            parentNode.RemoveItemByNodeName(selectedNode.Text);
            selectedNode.Remove();
            targetTreeView.SelectedNode = parentNode;
            SelectSelectedNodeBgColor(targetTreeView);
            ListViewInterpretor.RefreshListViewItemsForZipFileDesigner(targetListView, parentNode);
        }

        public static void RefreshToShowTreeViewIcons(TreeView targetTreeView)
        {
            SystemImageListManager.SetTreeViewImageList(targetTreeView, false);
            SystemImageListManager.SetTreeViewImageList(targetTreeView, true);
        }
    
        public static ZipFileStatisticsModel GetZipFileStatisticsModel(TreeView targetTreeview)
        {
            ZipFileStatisticsModel statistic = new ZipFileStatisticsModel();
            if (targetTreeview.Nodes.Count <= 0) return statistic;
            TraverseTreeViewForStatistic((TreeNodeExtended) targetTreeview.Nodes[0], statistic);
            return statistic;
        }
        private static void TraverseTreeViewForStatistic(TreeNodeExtended currentNode, ZipFileStatisticsModel statistic)
        {
            foreach (CShItem cShItem in currentNode.MasterListFilesDir)
            {
                if (!cShItem.IsFolder) {
                    statistic.IncrementEstimatedFilesCount();
                    statistic.IncrementEstimatedFileSizeCount(cShItem.Length);
                }
            }
            foreach (TreeNodeExtended node in currentNode.Nodes)
            {
                if (node.IsStructuredNode)
                {
                    statistic.IncrementEstimatedFoldersCount();
                    TraverseTreeViewForStatistic(node, statistic);
                }
            }
        }
    }





}
