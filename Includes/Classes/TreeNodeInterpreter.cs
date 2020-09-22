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
        private static readonly char[] INVALID_NODE_NAME_CHARS = new char[] { '@', '.', ',', '!' };

        //
        // true = the node to add are already existing on the current selected tree node
        // false = the node to add was not existing on the selected node of the tree
        //
        public static bool AddRecursiveNode(TreeNodeExtended targetTreeNode, CustomFileItem customFileItem)
        {
            bool isExistingParentNode = IsNodeExisting(targetTreeNode, customFileItem);
            TreeNodeExtended selectedNode = AddParentDirectory(targetTreeNode, customFileItem);
            if (isExistingParentNode) return isExistingParentNode;
            if (customFileItem.CshItem.Directories.Count() <= 0) return false;
            AddSubDirectories(selectedNode, customFileItem);
            return isExistingParentNode;
        }

        private static void AddSubDirectories(TreeNodeExtended targetTreeNode, CustomFileItem customFileItem)
        {
            foreach (CustomFileItem itemDir in customFileItem.GetShellInfoDirectories())
            {
                if (!IsNodeExisting(targetTreeNode, customFileItem))
                {
                    TreeNodeExtended treeNode = new TreeNodeExtended();
                    treeNode.Name = itemDir.GetCustomFileName(); //key of this node
                    treeNode.Text = itemDir.GetCustomFileName();
                    TagAllObjects(treeNode, itemDir);
                    SetTreeNodeIcon(treeNode, itemDir);
                    targetTreeNode.Nodes.Add(treeNode);
                    TreeNodeInterpreter.AddSubDirectories(treeNode, itemDir);
                }
                else
                {
                    TreeNodeInterpreter.AddSubDirectories((TreeNodeExtended) targetTreeNode.Nodes[0], customFileItem);
                }
            }
        }

        public static void AddRootItemFilesAsNode(TreeNodeExtended targetTreeNode, CustomFileItem customeFileItem)
        {
            TreeNodeExtended treeNode = new TreeNodeExtended();
            treeNode.Name = customeFileItem.CshItem.DisplayName; //key of this node
            treeNode.Text = customeFileItem.CshItem.DisplayName;
            treeNode.IsStructuredNode = false;
            AddTagObject(treeNode, customeFileItem);
            SetTreeNodeIcon(treeNode, customeFileItem);
            targetTreeNode.Nodes.Add(treeNode);
        }

        public static TreeNodeExtended AddNewCustomFolderNode(TreeView treeView)
        {

            TreeNodeExtended selectedNode = (TreeNodeExtended)treeView.SelectedNode;

            CustomFileItem customFileItem = new CustomFileItem(ValidateAndGenerateUniqueName(selectedNode, "New folder"))
            {
                IsCustomFolder = true,
            };

            TreeNodeExtended treeNode = new TreeNodeExtended();
            treeNode.Name = customFileItem.GetCustomFileName(); //key of this node
            treeNode.Text = customFileItem.GetCustomFileName();
            treeNode.IsCustomFolder = true;
            selectedNode.Nodes.Add(treeNode);
            return treeNode;
        }
        
        private static String ValidateAndGenerateUniqueName(TreeNodeExtended selectedNode, String startingUniqueName)
        {
            String customFileName = startingUniqueName.ToString() ;
            bool notYetUniqueName = true;
            long fileNameUniqueCtr = 1;
            long breakCtr = 0;

            while (notYetUniqueName)
            {
                if (selectedNode.Nodes.ContainsKey(customFileName))
                {
                    notYetUniqueName = true;
                    customFileName = startingUniqueName + " (" + fileNameUniqueCtr++ + ")";
                }
                else
                {
                    notYetUniqueName = false;
                }
                breakCtr++;
                if (breakCtr > 10000000) throw new Exception("Failed to derive a new unique name");
            }
            return customFileName;
        }

        private static TreeNodeExtended AddParentDirectory(TreeNodeExtended targetTreeNode, CustomFileItem customFileItem)
        {
            if (!customFileItem.CshItem.IsFolder) return targetTreeNode;
            if (IsNodeExisting(targetTreeNode, customFileItem)) return targetTreeNode;
            TreeNodeExtended treeNode = new TreeNodeExtended();
            treeNode.Name = customFileItem.GetCustomFileName(); //key of this node
            treeNode.Text = customFileItem.GetCustomFileName();
            TagAllObjects(treeNode, customFileItem);
            SetTreeNodeIcon(treeNode, customFileItem);
            targetTreeNode.Nodes.Add(treeNode);
            return treeNode;
        }

        private static void SetTreeNodeIcon(TreeNodeExtended targetTreeNode, CustomFileItem customFileItem)
        {
            targetTreeNode.ImageIndex = customFileItem.CshItem.IconIndexNormal;
            targetTreeNode.SelectedImageIndex = customFileItem.CshItem.IconIndexNormal;
        }

        private static void TagAllObjects(TreeNodeExtended treeNode, CustomFileItem customFileItem)
        {
            //_ = AddTagObject(treeNode, cshItem);
            foreach (CustomFileItem cshFile in customFileItem.GetShellInfoFiles())
            {
                _ = AddTagObject(treeNode, cshFile);
            }
            foreach (CustomFileItem cshFile in customFileItem.GetShellInfoDirectories())
            {
                _ = AddTagObject(treeNode, cshFile);
            }
        }
        
        public static ArrayList AddTagObject(TreeNodeExtended treeNode, CustomFileItem customFileItem)
        {
            treeNode.AddItem(customFileItem);
            return treeNode.MasterListFilesDir;
        }

        private static Boolean IsNodeExisting(TreeNodeExtended targetTreeNode, CustomFileItem customFileItem)
        {
            foreach(TreeNode currNode in targetTreeNode.Nodes)
            {
                if(currNode.Text.Equals(customFileItem.GetCustomFileName(), StringComparison.CurrentCultureIgnoreCase))
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
            TreeNodeExtended rootNode = new TreeNodeExtended(true);
            targetTreeView.Nodes.Add(rootNode);
            targetTreeView.SelectedNode = rootNode;
            targetListview.Tag = rootNode;
            SelectSelectedNodeBgColor(targetTreeView);
        }

        public static bool IsSelectedZipModelNodeRoot(TreeView targetTreeView)
        {
            return (((TreeNodeExtended)targetTreeView.SelectedNode).IsRootNode);
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

        public static bool AddZipFileNode(TreeView targetTreeView, CustomFileItem customeFileItem)
        {
            TreeNodeExtended selectedNode = (TreeNodeExtended)((targetTreeView.SelectedNode == null) 
                                                        ? targetTreeView.Nodes[0] : targetTreeView.SelectedNode);
            bool isExistingNode = AddRecursiveNode(selectedNode, customeFileItem);

            if (IsSelectedZipModelNodeRoot(targetTreeView) && !customeFileItem.CshItem.IsFolder && !isExistingNode)
            {
                AddRootItemFilesAsNode(selectedNode, customeFileItem);
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
                if (!AddZipFileNode(targetTreeView, lvItem.CustomFileItem))
                {
                    TreeNodeExtended selectedNode = (TreeNodeExtended)targetTreeView.SelectedNode;
                    AddTagObject(selectedNode, lvItem.CustomFileItem);
                    ListViewInterpretor.GenerateListViewZipFileViewItems(new ListViewInterpretorViewingParamModel()
                    {
                        SelectedTreeNodeExtended = selectedNode,
                        TargetListView = targetListView,
                        CustomFileItem = lvItem.CustomFileItem
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
            foreach (CustomFileItem customFileItem in currentNode.MasterListFilesDir)
            {
                if (!customFileItem.CshItem.IsFolder) {
                    statistic.IncrementEstimatedFilesCount();
                    statistic.IncrementEstimatedFileSizeCount(customFileItem.CshItem.Length);
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

        public static bool IsValidNodeName(String nodeName)
        {
            if (nodeName.IndexOfAny(INVALID_NODE_NAME_CHARS) == -1)
            {
                return true;
            }
            return false;
        }

        public static void RenameNode(TreeNodeExtended selectedNode, String newName)
        {
            TreeNodeExtended parentNode = (TreeNodeExtended) selectedNode.Parent;
            parentNode.UpdateCustomFileItemDisplayText(selectedNode.Text, newName);
        }
    
    }





}
