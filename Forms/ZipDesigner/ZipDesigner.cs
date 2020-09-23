using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpTreeLib;
using OneClickZip.Forms.Options;
using OneClickZip.Includes.Classes;
using OneClickZip.Includes.Classes.Extensions;
using OneClickZip.Includes.Models;
using OneClickZip.Includes.Resources;
using OneClickZip.Includes.Utilities;
using static OneClickZip.Includes.Classes.FileSerialization;

namespace OneClickZip
{
    public partial class ZipDesigner : Form
    {
        private readonly ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
        private readonly ListViewColumnSorterForFileDir lvwColumnSorterFileDir = new ListViewColumnSorterForFileDir();
        private ZipFileModel zipFileModel;
        private FileNameCreator fileNameCreator;
        private bool isTreeViewCollapseToggle = true;
        public ZipDesigner()
        {
            InitializeComponent();
            ListViewSearchDirExpHandlersAndControlsActivation();
            ListViewZipDesignFilesHandlersAndControlsActivation();
            ZipDesignerHandlersAndActivation();
            TreeNodeInterpreter.RefreshToShowTreeViewIcons(treeViewZipDesigner);
        }

#region Setter Getter
        ZipFileModel ZipFileModel { get => zipFileModel; set => zipFileModel = value; }
#endregion

#region EXP Dir related functions

        private void ListViewSearchDirExpHandlersAndControlsActivation()
        {
            this.listViewSearchDirExp.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewSearchDirExp.ItemActivate += new System.EventHandler(this.ListViewSearchDirExp_ItemDoubleClicked);
            expTreeSearchDir.StartUpDirectory = ExpTree.StartDir.MyDocuments;
        }
       
        private void ExpTreeSearchDir_StartUpDirectoryChanged(ExpTreeLib.ExpTree.StartDir startDir)
        {
            //TODO: DEBUGGING
            Console.WriteLine(startDir);
        }
       
        private void ExpTreeSearchDir_ExpTreeNodeSelectedEventHandler(String selectedPath, CShItem cshItem){
            listViewSearchDirExp.Items.Clear();
            ListViewInterpretor.GenerateListViewExplorerItems(
                new ListViewInterpretorViewingParamModel(){
                   TargetListView = listViewSearchDirExp, 
                   CustomFileItem = new CustomFileItem(cshItem.DisplayName, cshItem),
                   IsEnlistAllDirAndFiles = true,
                   CshItem = cshItem
                });
        }

        /**
         * Need this event viewer to show the icon on the explorer
         */
        private void ListViewSearchDirExp_VisibleChanged(object sender, EventArgs e)
        {
            ListViewInterpretor.RefreshToShowExplorerIcons(listViewSearchDirExp);
        }

        private void ListViewSearchDirExp_ItemDoubleClicked(object sender, EventArgs e)
        {
            //DEBUG
            Console.WriteLine("listViewSearchDirExp_ItemDoubleClicked");
            //DEBUG END
            
            if (listViewSearchDirExp.SelectedItems.Count > 0)
            {
                if (IsSelectedNodeStructured())
                {
                    TreeNodeInterpreter.PutTheSelectedFilesAndDirOnSelectedTreeNode(
                        listViewZipDesignFiles, treeViewZipDesigner, listViewSearchDirExp.SelectedItems);
                }

                //DEBUG
                ListViewItemExtended lvItemEx = (ListViewItemExtended)listViewSearchDirExp.SelectedItems[0];
                //CShItem cshItem = lvItemEx.CshItem;
                //Console.WriteLine("\nItem Name: " + cshItem.Text);
                //Console.WriteLine("Is Folder: " + cshItem.IsFolder);
                //Console.WriteLine("Path: " + cshItem.Path + "\n");
                //Console.WriteLine(listViewSearchDirExp.SelectedItems[0].Text);
                //DEBUG END
            }
        }

        private void listViewSearchDirExp_ItemDragHandler(object sender, ItemDragEventArgs e)
        {
            listViewSearchDirExp.DoDragDrop(listViewSearchDirExp.SelectedItems, DragDropEffects.Move);
        }

#endregion


#region ZIP Designer Controls and related functions

        private void ZipDesignerHandlersAndActivation()
        {
            TreeNodeInterpreter.NewZipStructureProcedure(treeViewZipDesigner, listViewZipDesignFiles);
        }

        private void ListViewZipDesignFilesHandlersAndControlsActivation()
        {
            this.listViewZipDesignFiles.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewZipDesignFiles.ItemActivate += new System.EventHandler(this.ListViewZipDesignFiles_ItemDoubleClicked);
        }

        private void TreeViewZipDesigner_AfterSelectHandler(object sender, TreeViewEventArgs e)
        {
            IsSelectedNodeStructured();
            TreeNodeExtended selectedNode = (TreeNodeExtended)treeViewZipDesigner.SelectedNode;
            listViewZipDesignFiles.Tag = selectedNode;
            ListViewInterpretor.RefreshListViewItemsForZipFileDesigner(listViewZipDesignFiles, selectedNode);
            TreeNodeInterpreter.SelectSelectedNodeBgColor(treeViewZipDesigner);
        }

        private void TreeViewZipDesigner_BeforeSelectHandler(object sender, TreeViewCancelEventArgs e)
        {
            TreeNodeInterpreter.RemovePreviousSelectedNodeBgColor(treeViewZipDesigner);
        }

        private void ListViewZipDesignFiles_ItemDoubleClicked(object sender, EventArgs e)
        {
            if (listViewZipDesignFiles.SelectedItems.Count > 0)
            {
                ListViewItemExtended lvItemEx = (ListViewItemExtended)listViewZipDesignFiles.SelectedItems[0];
            }
        }

        private void ListViewZipDesignFiles_DragDropHandler(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection).ToString(), false))
            {
                ListView.SelectedListViewItemCollection lstViewColl = (ListView.SelectedListViewItemCollection)
                                                                      e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));
                if (IsSelectedNodeStructured())
                {
                    TreeNodeInterpreter.PutTheSelectedFilesAndDirOnSelectedTreeNode(
                        listViewZipDesignFiles, treeViewZipDesigner, lstViewColl);
                }
            }
        }

        private void ListViewZipDesignFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
                e.Effect = DragDropEffects.Move;
        }
        
        private void listViewZipDesignFiles_VisibleChanged(object sender, EventArgs e)
        {
            ListViewInterpretor.RefreshToShowExplorerIcons(listViewZipDesignFiles);
        }

        private void btnZipFileAddFolder_Click(object sender, EventArgs e)
        {
            TreeNodeExtended newTreeNode = TreeNodeInterpreter.AddNewCustomFolderNode(treeViewZipDesigner);
            treeViewZipDesigner.SelectedNode = newTreeNode;
            editTreeViewNodeLabel();
        }

        private void btnZipClear_Click(object sender, EventArgs e)
        {
            TreeNodeInterpreter.NewZipStructureProcedure(treeViewZipDesigner, listViewZipDesignFiles);
        }

        private void btnAddSelected_Click(object sender, EventArgs e)
        {
            if (IsSelectedNodeStructured())
            {
                TreeNodeInterpreter.PutTheSelectedFilesAndDirOnSelectedTreeNode(
                    listViewZipDesignFiles, treeViewZipDesigner, listViewSearchDirExp.SelectedItems);
            }
        }

        private void BtnRemoveSelectedNode_Click(object sender, EventArgs e)
        {
            TreeNodeInterpreter.RemoveSelectedNode(treeViewZipDesigner, listViewZipDesignFiles);
        }

        private void btnRemoveSelectedZipFiles_Click(object sender, EventArgs e)
        {
            TreeNodeExtended treeNodeExtended = (TreeNodeExtended) treeViewZipDesigner.SelectedNode;
            foreach(ListViewItemExtended listViewItem in listViewZipDesignFiles.SelectedItems)
            {
                treeNodeExtended.RemoveItem(listViewItem.CustomFileItem);
            }
            ListViewInterpretor.RefreshListViewItemsForZipFileDesigner(listViewZipDesignFiles, treeNodeExtended);
        }

        private bool IsSelectedNodeStructured()
        {
            TreeNodeExtended selectedNode = (TreeNodeExtended)treeViewZipDesigner.SelectedNode;
            if (selectedNode.IsStructuredNode)
            {
                listViewZipDesignFiles.BackColor = Color.Empty;
            }
            else
            {
                listViewZipDesignFiles.BackColor = Color.LightGray;
            }
            return selectedNode.IsStructuredNode;
        }

        private void treeViewZipDesigner_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null) return;
            
            if (e.Label.Length > 0)
            {
                if (TreeNodeInterpreter.IsValidNodeName(e.Label))
                {
                    TreeNodeInterpreter.RenameNode((TreeNodeExtended)e.Node, e.Label);
                    e.Node.EndEdit(false); // Stop editing without canceling the label change.
                }
                else
                {
                    /* Cancel the label edit action, inform the user, and place the node in edit mode again. */
                    e.CancelEdit = true;
                    MessageBox.Show("Invalid tree node label.\n" + "The invalid characters are: '@','.', ',', '!'",
                        "Node Label Edit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Node.BeginEdit();
                }
            }
            else
            {
                /* Cancel the label edit action, inform the user, and place the node in edit mode again. */
                e.CancelEdit = true;
                MessageBox.Show("Invalid tree node label.\nThe label cannot be blank", 
                    "Node Label Edit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Node.BeginEdit();
            }
        }

        private void treeViewZipDesigner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                editTreeViewNodeLabel();
            }
        }
#endregion


#region List View Sorter
        private void listViewSearchDirExp_ColumnClickHandler(object sender, ColumnClickEventArgs e)
        {
            listviewSorter(sender, e);
        }
        
        private void listViewZipDesignFiles_ColumnClickHandler(object sender, ColumnClickEventArgs e)
        {
            listviewSorter(sender, e);
        }

        private void listviewSorter(object sender, ColumnClickEventArgs e)
        {
            ListView lvObj = (ListView)sender;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            lvObj.ListViewItemSorter = lvwColumnSorter;
            // Perform the sort with these new sort options.
            lvObj.Sort();

            //if the first column was being sorted, then distinguised again file and folder
            if(e.Column <= 0)
            {
                lvwColumnSorterFileDir.Order = lvwColumnSorter.Order; //just inherit above
                lvObj.ListViewItemSorter = lvwColumnSorterFileDir;
                // Perform the sort with these new sort options.
                lvObj.Sort();
            }
        }

#endregion

#region "Main GUI Controls"
        private void btnCreateFileName_Click(object sender, EventArgs e)
        {
            FileNameCreatorFrm fileNameCreatorFrm = new FileNameCreatorFrm(txtFileName.Text);
            fileNameCreatorFrm.ShowDialog();
            fileNameCreator = fileNameCreatorFrm.GetFileCreatorName();
            txtFileName.Text = fileNameCreator.FileFormulaName;
        }

        private void lnkCopSaveLocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtZipFileLocation.Text == null) return;
            if (txtZipFileLocation.Text == "") return;
            Clipboard.SetText(txtZipFileLocation.Text);
        }
       
        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            if (isTreeViewCollapseToggle)
            {
                isTreeViewCollapseToggle = false;
                treeViewZipDesigner.SelectedNode.ExpandAll();
            }
            else
            {
                isTreeViewCollapseToggle = true;
                treeViewZipDesigner.SelectedNode.Collapse();
            }
        }

        private void btnRecalculateEstimations_Click(object sender, EventArgs e)
        {
            ZipFileStatisticsModel statistic = TreeNodeInterpreter.GetZipFileStatisticsModel(treeViewZipDesigner);
            txtEstimatedAddedFiles.Text = statistic.EstimatedFilesCount.ToString();
            txtEstimatedAddedFolders.Text = statistic.EstimatedFoldersCount.ToString();
            txtEstimatedZipFileSize.Text = ConverterUtils.humanReadableFileSize(statistic.EstimatedFileSizeCount).ToString();
        }


        private void btnSaveZipDesign_Click(object sender, EventArgs e)
        {
            SaveProjectAsCurrent();
        }

        private bool IsProjectDataCompleted()
        {
            String message;

            if(fileNameCreator == null)
            {
                message = "Please fill up a new Zip File Name.";
            }
            else if (fileNameCreator.FileFormulaName == null)
            {
                message = "Please fill up a new Zip File Name.";
            }
            else if (fileNameCreator.FileFormulaName.Trim().Length<=0)
            {
                message = "Please fill up a new Zip File Name.";
            }
            else if (((TreeNodeExtended) treeViewZipDesigner.Nodes[0]).MasterListFilesDir.Count <= 0)
            {
                message = "Please add at least a file or folder on the zip designer";
            }
            else
            {
                return true;
            }

            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return false;
        }

#endregion

        #region Main Menu Strip
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProjectAsCurrent();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProjectAsNew();
        }

        private void SaveProjectAsNew()
        {
            if (!IsProjectDataCompleted()) return;
            ZipFileModel zipFileModel = new ZipFileModel(treeViewZipDesigner, fileNameCreator);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = ResourcesUtil.GetFileDesignerFilterName();
            saveFileDialog.Title = "Save a File Designer project";
            saveFileDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog.FileName != "")
            {
                if (saveFileDialog.CheckPathExists)
                {
                    //FileSerialization.SaveObjectToFile(Serialization.BinarySerialization, saveFileDialog.FileName, zipFileModel);

                    //FileSerialization.SaveObjectToFile(Serialization.BinarySerialization, saveFileDialog.FileName, 
                    //    ( ((CustomFileItem) ((TreeNodeExtended) treeViewZipDesigner.Nodes[0]).MasterListFilesDir[0])).CshItem);






                    //txtZipFileLocation.Text = saveFileDialog.FileName;
                    //zipFileModel.FilePath = saveFileDialog.FileName;
                    //this.zipFileModel = zipFileModel;
                }
            }
        }

        private void SaveProjectAsCurrent()
        {
            if (zipFileModel == null)
            {
                SaveProjectAsNew();
                return;
            }
            else if (zipFileModel.FilePath == null)
            {
                SaveProjectAsNew();
                return;
            }
            else if (zipFileModel.FilePath.Length <= 0)
            {
                SaveProjectAsNew();
                return;
            }

            if (IsProjectDataCompleted())
            {
                zipFileModel.TreeViewZipFileStructure = treeViewZipDesigner;
                zipFileModel.FileNameCreator = fileNameCreator;
                FileSerialization.SaveObjectToFile(Serialization.BinarySerialization, zipFileModel.FilePath, zipFileModel);
            }
        }
#endregion

        #region Context Strip for Zip File Tree View

        private void expandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewZipDesigner.SelectedNode == null) return;
            treeViewZipDesigner.SelectedNode.Expand();
        }

        private void expandAllToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (treeViewZipDesigner.SelectedNode == null) return;
            treeViewZipDesigner.SelectedNode.ExpandAll();
        }

        private void collapseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewZipDesigner.SelectedNode == null) return;
            treeViewZipDesigner.SelectedNode.Collapse();
        }

        private void tsmTvdEditLabel_Click(object sender, EventArgs e)
        {
            editTreeViewNodeLabel();
        }

        private void editTreeViewNodeLabel()
        {
            if (treeViewZipDesigner.SelectedNode == null) return;
            TreeNodeExtended selectedNode = (TreeNodeExtended)treeViewZipDesigner.SelectedNode;
            if (selectedNode.IsRootNode)
            {
                MessageBox.Show("No tree node selected or selected node is a root node.\n" +
                                  "Editing of root nodes is not allowed.", "Invalid selection");
            }
            else
            {
                treeViewZipDesigner.LabelEdit = true;
                if (!selectedNode.IsEditing)
                {
                    selectedNode.BeginEdit();
                }
            }
        }







        #endregion

    }


}
