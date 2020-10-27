using ExpTreeLib;
using OneClickZip.Forms.Loading;
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
    public class TreeNodeInterpreter
    {
        private ListViewInterpretor listViewInterpretor = new ListViewInterpretor();
        private CrawlerProgressScreenFrm crawlerProgressScreen = new CrawlerProgressScreenFrm();
        private long showProgressDialogCtr = 0;
        private long showProgressDialogAtThisCount = 1000;
        private bool _cancelBulkAddFilesFolders = false;

        public TreeNodeInterpreter()
        {
            ResetCrawlerDialog();
            //Bind Events
            crawlerProgressScreen.CancelProgressEvent += CrawlerProgressScreen_CancelProgressEvent;
        }

        #region Crawler Progress Dialog Related Functions
        private void ShowProgressDialogForm()
        {
            if (crawlerProgressScreen.Visible) return;

            if (showProgressDialogCtr % showProgressDialogAtThisCount == 0) //show the progress dialog after this count
            {
                crawlerProgressScreen.Show();
            }
            showProgressDialogCtr++;
        }

        private void CrawlerProgressScreen_CancelProgressEvent(object sender, Models.Events.CrawlerProgressScreenEventArgs e)
        {
            CancelBulkAddFilesFolders = true;
        }

        private void AddingFolderCrawlerStatus(String fullPathName)
        {
            if (!crawlerProgressScreen.Visible) return;
            crawlerProgressScreen.StatusText = "Adding => " + fullPathName;
        }

        private void StartCrawlerDialog()
        {
            ResetCrawlerDialog();
        }

        private void ResetCrawlerDialog()
        {
            crawlerProgressScreen.ResetForms();
            crawlerProgressScreen.Title = "Adding files and folders...";
            showProgressDialogCtr = 0;
            CancelBulkAddFilesFolders = false;
            crawlerProgressScreen.Visible = false;
            crawlerProgressScreen.Hide();
        }

        public bool CancelBulkAddFilesFolders { get => _cancelBulkAddFilesFolders; set => _cancelBulkAddFilesFolders = value; }

        #endregion

        ///
        /// true = the node to add are already existing on the current selected tree node
        /// false = the node to add was not existing on the selected node of the tree
        ///
        public bool AddRecursiveNode(TreeNodeExtended targetTreeNode, CustomFileItem customFileItem)
        {
            bool isExistingParentNode = targetTreeNode.IsNodeExisting(customFileItem.GetCustomFileName);
            TreeNodeExtended selectedNode = AddParentDirectory(targetTreeNode, customFileItem);
            if (isExistingParentNode) return isExistingParentNode;
            if (customFileItem.DirectoriesCount <= 0) return false;
            AddingFolderCrawlerStatus(customFileItem.FilePathFull);
            AddSubDirectories(selectedNode, customFileItem);
            return isExistingParentNode;
        }

        private void AddSubDirectories(TreeNodeExtended targetTreeNode, CustomFileItem customFileItem)
        {
            if (CancelBulkAddFilesFolders) return;
            foreach (CustomFileItem itemDir in customFileItem.GetShellInfoDirectories())
            {
                Application.DoEvents();
                if (CancelBulkAddFilesFolders) return;
                ShowProgressDialogForm();
                if (!targetTreeNode.IsNodeExisting(customFileItem.GetCustomFileName))
                {
                    AddingFolderCrawlerStatus(customFileItem.FilePathFull);
                    TreeNodeExtended treeNode = new TreeNodeExtended();
                    treeNode.Name = itemDir.GetCustomFileName; //key of this node
                    treeNode.Text = itemDir.GetCustomFileName;
                    TagAllObjects(treeNode, itemDir);
                    treeNode.SetTreeNodeIcon(itemDir);
                    targetTreeNode.Nodes.Add(treeNode);
                    AddSubDirectories(treeNode, itemDir);
                }
                else
                {
                    AddingFolderCrawlerStatus(itemDir.FilePathFull);
                    if (targetTreeNode.Nodes.Count > 0)
                    {
                        AddSubDirectories((TreeNodeExtended)targetTreeNode.Nodes[0], itemDir);
                    }
                }
            }
        }

        public void AddRootItemFilesAsNode(TreeNodeExtended targetTreeNode, CustomFileItem customeFileItem)
        {
            TreeNodeExtended treeNode = new TreeNodeExtended();
            treeNode.Name = customeFileItem.KeyName; //key of this node
            treeNode.Text = customeFileItem.GetCustomFileName;
            treeNode.IsFolderIsFileViewNode = true;
            AddTagObject(treeNode, customeFileItem);
            treeNode.SetTreeNodeIcon(customeFileItem);
            targetTreeNode.Nodes.Add(treeNode);
        }

        public TreeNodeExtended AddNewCustomFolderNode(TreeView treeView, FolderType folderType = FolderType.TreeView)
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
        
        private String ValidateAndGenerateUniqueName(TreeNodeExtended selectedNode, String startingUniqueName)
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

        private TreeNodeExtended AddParentDirectory(TreeNodeExtended targetTreeNode, CustomFileItem customFileItem)
        {
            if (!customFileItem.IsFolder) return targetTreeNode;
            if (targetTreeNode.IsNodeExisting(customFileItem.GetCustomFileName)) return targetTreeNode;
            TreeNodeExtended treeNode = new TreeNodeExtended();
            treeNode.Name = customFileItem.GetCustomFileName; //key of this node
            treeNode.Text = customFileItem.GetCustomFileName;
            TagAllObjects(treeNode, customFileItem);
            treeNode.SetTreeNodeIcon(customFileItem);
            targetTreeNode.Nodes.Add(treeNode);
            return treeNode;
        }

        private void TagAllObjects(TreeNodeExtended treeNode, CustomFileItem customFileItem)
        {
            foreach (CustomFileItem cshFile in customFileItem.GetShellInfoFiles())
            {
                Application.DoEvents();
                AddingFolderCrawlerStatus(cshFile.FilePathFull);
                _ = AddTagObject(treeNode, cshFile);
            }
            foreach (CustomFileItem cshFile in customFileItem.GetShellInfoDirectories())
            {
                Application.DoEvents();
                _ = AddTagObject(treeNode, cshFile);
            }
        }
        
        public ArrayList AddTagObject(TreeNodeExtended treeNode, CustomFileItem customFileItem)
        {
            treeNode.AddItem(customFileItem);
            return treeNode.MasterListFilesDir;
        }

        public void NewZipStructureProcedure(TreeView targetTreeView, ListviewExtended targetListview)
        {
            targetTreeView.Nodes.Clear();
            targetListview.Items.Clear();
            TreeNodeExtended rootNode = new TreeNodeExtended(true);
            targetTreeView.Nodes.Add(rootNode);
            targetTreeView.SelectedNode = rootNode;
            targetListview.ReferenceTreeNode = rootNode;
            SelectSelectedNodeBgColor(targetTreeView);
        }

        public bool IsSelectedZipModelNodeRoot(TreeView targetTreeView)
        {
            return GetSelectedNode(targetTreeView).IsRootNode;
        }

        public void SelectSelectedNodeBgColor(TreeView targetTreeView)
        {
            if (targetTreeView.SelectedNode == null) return;
            targetTreeView.SelectedNode.BackColor = Color.Gray;
        }

        public void RemovePreviousSelectedNodeBgColor(TreeView targetTreeView)
        {
            if (targetTreeView.SelectedNode == null) return;
            targetTreeView.SelectedNode.BackColor = Color.Empty;
        }

        public bool AddZipFileNode(TreeView targetTreeView, CustomFileItem customeFileItem)
        {
            TreeNodeExtended selectedNode = GetSelectedNode(targetTreeView);
            bool isExistingNode = AddRecursiveNode(selectedNode, customeFileItem);

            if (IsSelectedZipModelNodeRoot(targetTreeView) && !customeFileItem.IsFolder && !isExistingNode)
            {
                AddRootItemFilesAsNode(selectedNode, customeFileItem);
            }
            return isExistingNode;
        }

        public void PutTheSelectedFilesAndDirOnSelectedTreeNode(ListviewExtended targetListView, TreeView targetTreeView, ListView.SelectedListViewItemCollection lstViewColl)
        {
            targetTreeView.BeginUpdate();
            targetListView.BeginUpdate();
            StartCrawlerDialog();
            foreach (ListViewItemExtended lvItem in lstViewColl)
            {
                //if node are not yet existed on the currently selected node of the tree
                if (!AddZipFileNode(targetTreeView, lvItem.CustomFileItem))
                {
                    TreeNodeExtended selectedNode = GetSelectedNode(targetTreeView);
                    AddTagObject(selectedNode, lvItem.CustomFileItem);
                    listViewInterpretor.GenerateListViewZipFileViewItems(new ListViewInterpretorViewingParamModel()
                    {
                        SelectedTreeNodeExtended = selectedNode,
                        TargetListView = (ListviewExtended) targetListView,
                        CustomFileItem = lvItem.CustomFileItem
                    });
                }
            }
            ResetCrawlerDialog();
            targetTreeView.EndUpdate();
            targetListView.EndUpdate();
        }

        public void RemoveSelectedNode(TreeView targetTreeView, ListviewExtended targetListView)
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
            if (selectedNode.PrevNode != null) nextSelectedNode = (TreeNodeExtended)selectedNode.PrevNode;
            if (selectedNode.NextNode != null) nextSelectedNode = (TreeNodeExtended)selectedNode.NextNode;

            parentNode.RemoveItemByNodeName(selectedNode.Text);
            selectedNode.ClearAndDisposeNodes();
            selectedNode.Remove();
            targetTreeView.SelectedNode = nextSelectedNode;
            SelectSelectedNodeBgColor(targetTreeView);
            listViewInterpretor.RefreshListViewItemsForZipFileDesigner(targetListView, nextSelectedNode);
        }

        public void RefreshToShowTreeViewIcons(TreeView targetTreeView)
        {
            targetTreeView.ImageList = DefaultIcons.SYSTEM_ICONS.SmallIconsImageList;
        }
    
        public ZipFileStatisticsModel GetZipFileStatisticsModel(TreeView targetTreeview)
        {
            ZipFileStatisticsModel statistic = new ZipFileStatisticsModel();
            if (targetTreeview.Nodes.Count <= 0) return statistic;
            statistic.SetStatistic((TreeNodeExtended)targetTreeview.Nodes[0]);
            return statistic;
        }

        public bool IsValidNodeName(TreeNodeExtended targetNode, String nodeName)
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

        public void RenameNode(TreeNodeExtended selectedNode, String newName)
        {
            TreeNodeExtended targetNode = (TreeNodeExtended)selectedNode.Parent;
            targetNode.UpdateCustomFileItemDisplayText(selectedNode.Text, newName);
            selectedNode.Text = (selectedNode.Text + " ").Trim();
        }
    
        public TreeNodeExtended GetRootNode(TreeView treeView)
        {
            return (TreeNodeExtended)treeView.Nodes[0];
        }

        public void SetTreeNodeFromOpeningAFile(TreeNodeExtended source, TreeNodeExtended destination)
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
    
        private TreeNodeExtended GetSelectedNode(TreeView targetTreeView)
        {
            return  (TreeNodeExtended)((targetTreeView.SelectedNode == null)
                            ? targetTreeView.Nodes[0] : targetTreeView.SelectedNode);
        }
    
    }
}
