using ExpTreeLib;
using OneClickZip.Includes.Classes.Extensions;
using OneClickZip.Includes.Models;
using OneClickZip.Includes.Models.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneClickZip.Includes.Classes
{
    class TreeNodeInterpreter
    {
        private static readonly char[] INVALID_NODE_NAME_CHARS = new char[] { '@', ',' }; //ORIGINAL{ '@', '.', ',', '!' };

        ///
        /// true = the node to add are already existing on the current selected tree node
        /// false = the node to add was not existing on the selected node of the tree
        ///
        public static bool AddRecursiveNode(TreeNodeExtended targetTreeNode, CustomFileItem customFileItem)
        {
            bool isExistingParentNode = IsNodeExisting(targetTreeNode, customFileItem);
            TreeNodeExtended selectedNode = AddParentDirectory(targetTreeNode, customFileItem);
            if (isExistingParentNode) return isExistingParentNode;
            if (customFileItem.DirectoriesCount <= 0) return false;
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
                    treeNode.Name = itemDir.GetCustomFileName; //key of this node
                    treeNode.Text = itemDir.GetCustomFileName;
                    TagAllObjects(treeNode, itemDir);
                    treeNode.SetTreeNodeIcon(itemDir);
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
            treeNode.Name = customeFileItem.KeyName; //key of this node
            treeNode.Text = customeFileItem.GetCustomFileName;
            treeNode.IsFolderIsFileViewNode = true;
            AddTagObject(treeNode, customeFileItem);
            treeNode.SetTreeNodeIcon(customeFileItem);
            targetTreeNode.Nodes.Add(treeNode);
        }

        public static TreeNodeExtended AddNewCustomFolderNode(TreeView treeView, FolderType folderType = FolderType.TreeView)
        {
            TreeNodeExtended selectedNode = (TreeNodeExtended)treeView.SelectedNode;
            CustomFileItem customFileItem = new CustomFileItem(ValidateAndGenerateUniqueName(selectedNode, "New folder"))
            {
                FolderType = folderType,
            };

            TreeNodeExtended treeNode = new TreeNodeExtended();
            treeNode.FolderType = folderType;
            treeNode.Name = customFileItem.GetCustomFileName; //key of this node
            treeNode.Text = customFileItem.GetCustomFileName;
            AddTagObject(selectedNode, customFileItem);
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
                    customFileName = startingUniqueName + " " + fileNameUniqueCtr++;
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
            if (!customFileItem.IsFolder) return targetTreeNode;
            if (IsNodeExisting(targetTreeNode, customFileItem)) return targetTreeNode;
            TreeNodeExtended treeNode = new TreeNodeExtended();
            treeNode.Name = customFileItem.GetCustomFileName; //key of this node
            treeNode.Text = customFileItem.GetCustomFileName;
            TagAllObjects(treeNode, customFileItem);
            treeNode.SetTreeNodeIcon(customFileItem);
            targetTreeNode.Nodes.Add(treeNode);
            return treeNode;
        }

        private static void TagAllObjects(TreeNodeExtended treeNode, CustomFileItem customFileItem)
        {
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
                if(currNode.Text.Equals(customFileItem.GetCustomFileName, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public static void NewZipStructureProcedure(TreeView targetTreeView, ListviewExtended targetListview)
        {
            targetTreeView.Nodes.Clear();
            targetListview.Items.Clear();
            TreeNodeExtended rootNode = new TreeNodeExtended(true);
            targetTreeView.Nodes.Add(rootNode);
            targetTreeView.SelectedNode = rootNode;
            targetListview.ReferenceTreeNode = rootNode;
            SelectSelectedNodeBgColor(targetTreeView);
        }

        public static bool IsSelectedZipModelNodeRoot(TreeView targetTreeView)
        {
            return GetSelectedNode(targetTreeView).IsRootNode;
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
            TreeNodeExtended selectedNode = GetSelectedNode(targetTreeView);
            bool isExistingNode = AddRecursiveNode(selectedNode, customeFileItem);

            if (IsSelectedZipModelNodeRoot(targetTreeView) && !customeFileItem.IsFolder && !isExistingNode)
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
                        TargetListView = (ListviewExtended) targetListView,
                        CustomFileItem = lvItem.CustomFileItem
                    });
                }
            }
            targetTreeView.EndUpdate();
            targetListView.EndUpdate();
        }

        public static void RemoveSelectedNode(TreeView targetTreeView, ListviewExtended targetListView)
        {
            if (targetTreeView.SelectedNode == null) return;
            if (IsSelectedZipModelNodeRoot(targetTreeView))
            {
                NewZipStructureProcedure(targetTreeView, targetListView);
                return;
            }

            TreeNodeExtended parentNode = (TreeNodeExtended)targetTreeView.SelectedNode.Parent;
            TreeNodeExtended selectedNode = (TreeNodeExtended)targetTreeView.SelectedNode;
            TreeNodeExtended nextSelectedNode = parentNode;
            if (selectedNode.PrevNode != null) nextSelectedNode = (TreeNodeExtended) selectedNode.PrevNode;
            if (selectedNode.NextNode != null) nextSelectedNode = (TreeNodeExtended)selectedNode.NextNode;

            parentNode.RemoveItemByNodeName(selectedNode.Text);
            selectedNode.ClearAndDisposeNodes();
            selectedNode.Remove();
            targetTreeView.SelectedNode = nextSelectedNode;
            SelectSelectedNodeBgColor(targetTreeView);
            ListViewInterpretor.RefreshListViewItemsForZipFileDesigner(targetListView, nextSelectedNode);
        }

        public static void RefreshToShowTreeViewIcons(TreeView targetTreeView)
        {
            targetTreeView.ImageList = DefaultIcons.SYSTEM_ICONS.SmallIconsImageList;
        }
    
        public static ZipFileStatisticsModel GetZipFileStatisticsModel(TreeView targetTreeview)
        {
            ZipFileStatisticsModel statistic = new ZipFileStatisticsModel();
            if (targetTreeview.Nodes.Count <= 0) return statistic;
            statistic.SetStatistic((TreeNodeExtended)targetTreeview.Nodes[0]);
            return statistic;
        }

        public static bool IsValidNodeName(TreeNodeExtended targetNode, String nodeName)
        {
            nodeName = nodeName.Trim();
            if (nodeName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0) return false;

            //The duplicate name count should be one, one means the file itself
            foreach(CustomFileItem item in targetNode.MasterListFilesDir)
            {
                if (item.GetCustomFileName.Trim().Equals(nodeName, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }
            return true;
        }

        public static void RenameNode(TreeNodeExtended selectedNode, String newName)
        {
            TreeNodeExtended targetNode = (TreeNodeExtended)selectedNode.Parent;
            targetNode.UpdateCustomFileItemDisplayText(selectedNode.Text, newName);
            selectedNode.Text = (selectedNode.Text + " ").Trim();
        }
    
        public static TreeNodeExtended GetRootNode(TreeView treeView)
        {
            return (TreeNodeExtended)treeView.Nodes[0];
        }

        public static void SetTreeNodeFromOpeningAFile(TreeNodeExtended source, TreeNodeExtended destination)
        {
            //must keep the ROOT node by having this function, so that seeking the root node was only
            //confined within this class.
            //any other class dont know whos's the root node is...

            destination.SourceInExtendedDetails(source);
            foreach (TreeNodeExtended trx in source.Nodes)
            {
                destination.Nodes.Add(trx);
            }
        }
    
        private static TreeNodeExtended GetSelectedNode(TreeView targetTreeView)
        {
            return  (TreeNodeExtended)((targetTreeView.SelectedNode == null)
                            ? targetTreeView.Nodes[0] : targetTreeView.SelectedNode);
        }
    
    }
}
