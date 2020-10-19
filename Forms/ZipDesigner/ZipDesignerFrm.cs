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
using OneClickZip.Forms.Help;
using OneClickZip.Forms.Options;
using OneClickZip.Includes.Classes;
using OneClickZip.Includes.Classes.Extensions;
using OneClickZip.Includes.Models;
using OneClickZip.Includes.Resources;
using OneClickZip.Includes.Utilities;
using OneClickZip.Includes.Models.Types;
using static OneClickZip.Includes.Classes.FileSerialization;
using OneClickZip.Includes.Classes.Sorters;

namespace OneClickZip
{
    public partial class ZipDesigner : Form
    {
        private readonly ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
        private readonly ListViewColumnSorterForFileDir lvwColumnSorterFileDir = new ListViewColumnSorterForFileDir();
        private readonly TreeNodeSorters treeNodeSorters = new TreeNodeSorters();
        private ProjectSession PROJECT_SESSION = ProjectSession.Instance();
        private ApplicationArgumentModel APPLICATION_ARGUMENT_MODEL = null;
        private bool isTreeViewCollapseToggle = true;
        private AboutFrm aboutFrm = new AboutFrm();
        public ZipDesigner()
        {
            InitializeComponent();
            APPLICATION_ARGUMENT_MODEL = PROJECT_SESSION.ApplicationArgumentModel;
            ListViewSearchDirExpHandlersAndControlsActivation();
            ListViewZipDesignFilesHandlersAndControlsActivation();
            ZipDesignerHandlersAndActivation();
            TreeNodeInterpreter.RefreshToShowTreeViewIcons(treeViewZipDesigner);
        }

#region Setter Getter
        private ListviewExtended GetListViewZipDesignerFormObj { get => (ListviewExtended)listViewZipDesignFiles; }
        
        private TreeNodeExtended GetSelectedTreeNodeExtended
        {
            get
            {
                TreeNodeExtended selectedNode = (TreeNodeExtended) treeViewZipDesigner.SelectedNode;
                if (selectedNode != null) return selectedNode;
                if (GetListViewZipDesignerFormObj.ReferenceTreeNode != null) return GetListViewZipDesignerFormObj.ReferenceTreeNode;
                return (TreeNodeExtended)treeViewZipDesigner.Nodes[0];
            }
        }

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
                   TargetListView = (ListviewExtended) listViewSearchDirExp, 
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
            if (listViewSearchDirExp.SelectedItems.Count > 0)
            {
                if (IsSelectedNodeStructured())
                {
                    TreeNodeInterpreter.PutTheSelectedFilesAndDirOnSelectedTreeNode(
                        listViewZipDesignFiles, treeViewZipDesigner, listViewSearchDirExp.SelectedItems);
                }
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
            RefreshListViewAfterNodeSelection();
        }

        private void RefreshListViewAfterNodeSelection()
        {
            IsSelectedNodeStructured();
            TreeNodeExtended selectedNode = GetSelectedTreeNodeExtended;
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
                    SortTreeViewZipDesigner();
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

        private TreeNodeExtended AddFolderCommon(FolderType folderType)
        {
            TreeNodeExtended selNode = (TreeNodeExtended)treeViewZipDesigner.SelectedNode;
            if (!selNode.IsGenerallyAFolderType) return null;

            TreeNodeExtended newTreeNode = TreeNodeInterpreter.AddNewCustomFolderNode(treeViewZipDesigner, folderType);
            treeViewZipDesigner.SelectedNode = newTreeNode;
            return newTreeNode;
        }

        private void btnZipClear_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButtonAddExpItems_Click(object sender, EventArgs e)
        {
            if (IsSelectedNodeStructured())
            {
                TreeNodeInterpreter.PutTheSelectedFilesAndDirOnSelectedTreeNode(
                    listViewZipDesignFiles, treeViewZipDesigner, listViewSearchDirExp.SelectedItems);
                SortTreeViewZipDesigner();
            }
        }

        private void toolStripButtonRemSelected_Click(object sender, EventArgs e)
        {
            RemoveZipFileListViewItem();
        }

        private void RemoveZipFileListViewItem()
        {
            listViewZipDesignFiles.BeginUpdate();
            treeViewZipDesigner.BeginUpdate();
            foreach (ListViewItemExtended listViewItem in listViewZipDesignFiles.SelectedItems)
            {
                listViewItem.ReferenceTreeNode.RemoveItem(listViewItem.CustomFileItem);
                listViewItem.Remove();
            }
            listViewZipDesignFiles.EndUpdate();
            treeViewZipDesigner.EndUpdate();
        }

        private bool IsSelectedNodeStructured()
        {
            TreeNodeExtended selectedNode = GetSelectedTreeNodeExtended;

            if (selectedNode.IsFolderIsTreeViewNode)
            {
                listViewZipDesignFiles.BackColor = Color.Empty;
            }
            else
            {
                listViewZipDesignFiles.BackColor = Color.LightGray;
            }
            return selectedNode.IsFolderIsTreeViewNode;
        }

        private void treeViewZipDesigner_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null) return;
            
            if (e.Label.Trim().Length > 0)
            {
                String oldName = ((TreeNodeExtended)e.Node).Text.Trim();
                if (TreeNodeInterpreter.IsValidNodeName((TreeNodeExtended) GetSelectedTreeNodeExtended.Parent, e.Label))
                {
                    TreeNodeInterpreter.RenameNode((TreeNodeExtended)e.Node, e.Label);
                    e.Node.EndEdit(false); // Stop editing without canceling the label change.
                    ((TreeNodeExtended)e.Node).Text = e.Label.Trim(); //attempt to remove the extra space after editing
                }
                else
                {
                    if (oldName.Equals(e.Label.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        e.Node.EndEdit(true); //cancel and ignore changes
                        e.CancelEdit = true;
                    }
                    else
                    {
                        /* Cancel the label edit action, inform the user, and place the node in edit mode again. */
                        e.CancelEdit = true;
                        ShowValidationBox("Invalid tree node label.\n"
                            + "There are invalid characters in the name or an already existing name detected.");
                        e.Node.BeginEdit();
                    }
                }
            }
            else
            {
                /* Cancel the label edit action, inform the user, and place the node in edit mode again. */
                e.CancelEdit = true;
                ShowValidationBox("Invalid tree node label.\nThe label cannot be blank");
                e.Node.BeginEdit();
            }
        }

        private void listViewZipDesignFiles_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label == null) return;

            if (e.Label.Trim().Length > 0)
            {
                ListView listView = (ListView)sender;
                ListViewItemExtended listViewItmEx = (ListViewItemExtended)listView.SelectedItems[0];

                //get the affected equivalent node of the selected folder
                String targetText = listViewItmEx.Text.Trim();
                TreeNodeExtended affectedNode = listViewItmEx.ReferenceTreeNode.GetChildNodeByLabel(targetText);

                //because this folder is also the tree node
                if (affectedNode == null)
                {
                    e.CancelEdit = true;
                    ShowValidationBox("Error.\n Can't find the tree node.");
                }
                else if (TreeNodeInterpreter.IsValidNodeName(affectedNode, e.Label.Trim()))
                {
                    TreeNodeInterpreter.RenameNode(affectedNode, e.Label.Trim());
                    affectedNode.Text = e.Label.Trim();
                    listViewItmEx.SubItems[0].Text = e.Label.Trim();
                    affectedNode.TreeView.Refresh();
                    listViewItmEx.ListView.Refresh();
                    SortTreeViewZipDesigner();
                }
                else
                {
                    /* Cancel the label edit action, inform the user, and place the node in edit mode again. */
                    e.CancelEdit = true;
                    ShowValidationBox("Invalid label.\n"
                        + "There are invalid characters in the name or an already existing name detected.");
                }
            }
            else
            {
                /* Cancel the label edit action, inform the user, and place the node in edit mode again. */
                e.CancelEdit = true;
                ShowValidationBox("Invalid label.\nThe label cannot be blank");
            }
        }

        private void treeViewZipDesigner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                editTreeViewNodeLabel();
            }else if(e.KeyCode == Keys.Delete)
            {
                TreeNodeInterpreter.RemoveSelectedNode(treeViewZipDesigner, listViewZipDesignFiles);
            }
        }

        private void listViewZipDesignFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                EditListViewZipFileLabel();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                RemoveZipFileListViewItem();
            }
        }

        private void EditListViewZipFileLabel()
        {
            if (listViewZipDesignFiles.SelectedItems == null) return;
            if (listViewZipDesignFiles.SelectedItems.Count<=0) return;
            ListViewItemExtended listViewItmEx = (ListViewItemExtended) listViewZipDesignFiles.SelectedItems[0];
            listViewZipDesignFiles.LabelEdit = true;
            listViewItmEx.BeginEdit();
        }

        private void toolStripAddNode_Click(object sender, EventArgs e)
        {
            if (AddFolderCommon(FolderType.TreeView) == null) return;
            editTreeViewNodeLabel();
        }

        private void toolStripAddFilterRule_Click(object sender, EventArgs e)
        {
            AddFilterRuleCommon();
        }

        private void addFilterRuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFilterRuleCommon();
        }

        private void AddFilterRuleCommon()
        {
            TreeNodeExtended newTreeNode = AddFolderCommon(FolderType.FilterRule);
            if (newTreeNode == null) return;
            FilterRuleFrm filterFrm = new FilterRuleFrm();
            filterFrm.ShowDialog();
            newTreeNode.FolderFilterRuleObj = (FolderFilterRule)filterFrm.FolderFilterRule.Clone();
            editTreeViewNodeLabel();
        }

        private void toolStripClearList_Click(object sender, EventArgs e)
        {
            TreeNodeInterpreter.NewZipStructureProcedure(treeViewZipDesigner, listViewZipDesignFiles);
        }

        private void toolStripRemoveFolder_Click(object sender, EventArgs e)
        {
            TreeNodeInterpreter.RemoveSelectedNode(treeViewZipDesigner, listViewZipDesignFiles);
        }

        private void toolStripButtonExpandCollapse_Click(object sender, EventArgs e)
        {
            if (isTreeViewCollapseToggle)
            {
                isTreeViewCollapseToggle = false;
                GetSelectedTreeNodeExtended.ExpandAll();
            }
            else
            {
                isTreeViewCollapseToggle = true;
                GetSelectedTreeNodeExtended.Collapse();
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            SaveProjectAsCurrent();
        }

        private void toolStripButtonRename_Click(object sender, EventArgs e)
        {
            editTreeViewNodeLabel();
        }

        private void treeViewZipDesigner_DoubleClick(object sender, EventArgs e)
        {
            TreeNodeExtended targetNode = (TreeNodeExtended)treeViewZipDesigner.SelectedNode;
            if (targetNode == null) return;
            if (targetNode.IsFolderIsFilterRule) ModifyFilterRule();
        }

        private void listViewZipDesignFiles_DoubleClick(object sender, EventArgs e)
        {
            ListViewZipDesignFilesOpenOrModifyFoldeRule();
        }

        private void ListViewZipDesignFilesOpenOrModifyFoldeRule()
        {
            if (listViewZipDesignFiles.SelectedItems.Count == 1)
            {
                ListViewItemExtended listViewItmEx = (ListViewItemExtended)listViewZipDesignFiles.SelectedItems[0];

                //get the affected equivalent node of the selected folder
                TreeNodeExtended affectedNode = GetSelectedTreeNodeExtended.GetChildNodeByLabel(listViewItmEx.Text);
                if (affectedNode == null) return;
                if (affectedNode.IsFolderIsFilterRule)
                {
                    ModifyFilterRule(affectedNode);
                }
                else
                {
                    treeViewZipDesigner.SelectedNode = affectedNode;
                }
            }
        }

        private void SortTreeViewZipDesigner()
        {
            //after sorting, the selected node is missing and can be a various reason for a bug to other modules.
            TreeNodeExtended selectedNode = GetSelectedTreeNodeExtended;
            //treeViewZipDesigner.CollapseAll();
            treeViewZipDesigner.BeginUpdate();
            treeViewZipDesigner.Sort();
            treeViewZipDesigner.EndUpdate();
            treeViewZipDesigner.SelectedNode = selectedNode;
            treeViewZipDesigner.SelectedNode.EnsureVisible();
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

            FileNameCreator fileNameCreator = fileNameCreatorFrm.GetFileCreatorNameModel();
            PROJECT_SESSION.UpdateFileCreatorNameModel(fileNameCreator);
            txtFileName.Text = fileNameCreator.FileFormulaName;
        }

        private void lnkCopSaveLocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtZipFileLocation.Text == null) return;
            if (txtZipFileLocation.Text == "") return;
            Clipboard.SetText(txtZipFileLocation.Text);
        }

        private void btnRecalculateEstimations_Click(object sender, EventArgs e)
        {
            CalculateZipStructureStatistics();
        }

        private void CalculateZipStructureStatistics()
        {
            ClearStatisticForms();
            ZipFileStatisticsModel statistic = TreeNodeInterpreter.GetZipFileStatisticsModel(treeViewZipDesigner);
            PutStatisticFormValues(statistic.EstimatedFilesCount.ToString(),
                statistic.EstimatedFoldersCount.ToString(), statistic.EstimatedFileSizeCount);
        }

        private void ClearStatisticForms()
        {
            txtEstimatedAddedFiles.Text = "0";
            txtEstimatedAddedFolders.Text = "0";
            txtEstimatedZipFileSize.Text = "0";
        }

        private void PutStatisticFormValues(String fileCount, String foldersCount, long allFilesSize)
        {
            txtEstimatedAddedFiles.Text = fileCount;
            txtEstimatedAddedFolders.Text = foldersCount;
            txtEstimatedZipFileSize.Text = ConverterUtils.HumanReadableFileSize(allFilesSize, 2).ToString();
        }

        private bool IsProjectDataCompleted()
        {
            if(PROJECT_SESSION.FileNameCreatorModel == null)
            {
                ShowValidationBox("Please fill up a new Zip File Name.");
            }
            else if (PROJECT_SESSION.FileNameCreatorModel.FileFormulaName == null)
            {
                ShowValidationBox("Please fill up a new Zip File Name.");
            }
            else if (PROJECT_SESSION.FileNameCreatorModel.FileFormulaName.Trim().Length<=0)
            {
                ShowValidationBox("Please fill up a new Zip File Name.");
            }
            else if (((TreeNodeExtended) treeViewZipDesigner.Nodes[0]).MasterListFilesDir.Count <= 0)
            {
                ShowValidationBox("Please add at least a file or folder on the zip designer");
            }
            else
            {
                return true;
            }
            return false;
        }

        private void ShowInfoBox(String yourMessage)
        {
            MessageBox.Show(yourMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    
        private void ShowValidationBox(String yourMessage)
        {
            MessageBox.Show(yourMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void fileAssociationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileAssociationFrm fasscFrm = new FileAssociationFrm();
            fasscFrm.ShowDialog();
        }

        private void ZipDesigner_Load(object sender, EventArgs e)
        {
            if (APPLICATION_ARGUMENT_MODEL.IsOpenProjectDesignerFile)
            {
                this.OpenProjectDesignerFile(APPLICATION_ARGUMENT_MODEL.FilePath);
            }
            treeViewZipDesigner.TreeViewNodeSorter = this.treeNodeSorters;
        }

        private void lnlSetTargetLocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog browseFolder = new FolderBrowserDialog();
            browseFolder.SelectedPath = ApplicationSettings.GetLastOpenedDirectory();
            browseFolder.ShowNewFolderButton = true;
            DialogResult dr = browseFolder.ShowDialog();
            if(dr == DialogResult.OK)
            {
                if (String.IsNullOrWhiteSpace(browseFolder.SelectedPath)) return;
                txtTargetLocation.Text = browseFolder.SelectedPath;
                ApplicationSettings.SaveLastOpenedDirectory(browseFolder.SelectedPath);
            }
        }

        private void toolStripButtonGenOneClick_Click(object sender, EventArgs e)
        {
            GenerateBatchFile();
        }

        private void toolStripButtonRunZip_Click(object sender, EventArgs e)
        {
            StartArchiving();
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
            SaveProjectAsNew(ResourcesUtil.GetFileDesignerFilterName());
        }

        private void SaveProjectAsNew(String filterName)
        {
            if (!IsProjectDataCompleted()) return;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = filterName;
            saveFileDialog.Title = "Save File Designer project";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;

            // If the file name is not an empty string open it for saving.
            if (!String.IsNullOrWhiteSpace(saveFileDialog.FileName))
            {
                if (saveFileDialog.CheckPathExists)
                {
                    TreeNodeExtended rootNode = TreeNodeInterpreter.GetRootNode(treeViewZipDesigner);
                    ZipFileModel zipFileModel = new ZipFileModel(rootNode, PROJECT_SESSION.FileNameCreatorModel);
                    zipFileModel.FilePath = saveFileDialog.FileName;
                    zipFileModel.TargetDropFileLocationPath = txtTargetLocation.Text;
                    PROJECT_SESSION.ZipFileModel = zipFileModel;
                    PROJECT_SESSION.SaveProject(saveFileDialog.FileName);
                    txtZipFileLocation.Text = saveFileDialog.FileName;                    
                }
            }
        }

        private void SaveProjectAsCurrent()
        {
            if (!PROJECT_SESSION.IsSessionWasACurrentlyLoadedProject())
            {
                SaveProjectAsNew(ResourcesUtil.GetFileDesignerFilterName());
                return;
            }

            if (IsProjectDataCompleted())
            {
                SetUpToDateProjectSessionReferences();
                PROJECT_SESSION.SaveCurrentLoadedProject();
                ShowInfoBox("Successfully save at " + PROJECT_SESSION.ZipFileModel.FilePath);
            }
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenZipDesigner();
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            OpenZipDesigner();
        }

        private void OpenZipDesigner()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = ResourcesUtil.GetFileDesignerFilterName();
            openFileDialog.Title = "Open Zip Designer project";
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                if (openFileDialog.FileName == null) return;
                if (openFileDialog.FileName == "") return;
                OpenProjectDesignerFile(openFileDialog.FileName);
            }
        }

        private void OpenProjectDesignerFile(String filePath)
        {
            TreeNodeExtended treeNodeExtended = PROJECT_SESSION.GetTreeNodeZipDesignOnProjectFile(filePath);
            TreeNodeExtended rootNode = TreeNodeInterpreter.GetRootNode(treeViewZipDesigner);
            ZipFileModel zipFileModel = PROJECT_SESSION.ZipFileModel;

            listViewZipDesignFiles.BeginUpdate();
            treeViewZipDesigner.BeginUpdate();
            rootNode.ClearAndDisposeNodes();
            listViewZipDesignFiles.Items.Clear();
            ClearStatisticForms();
            TreeNodeInterpreter.SetTreeNodeFromOpeningAFile(treeNodeExtended, rootNode);
            treeViewZipDesigner.SelectedNode = rootNode;

            txtZipFileLocation.Text = filePath;
            txtTargetLocation.Text = zipFileModel.TargetDropFileLocationPath;
            txtFileName.Text = zipFileModel.FileNameCreator.FileFormulaName;
            RefreshListViewAfterNodeSelection();
            CalculateZipStructureStatistics();
            listViewZipDesignFiles.EndUpdate();
            treeViewZipDesigner.EndUpdate();
            PROJECT_SESSION.ApplicationArgumentModel = new ApplicationArgumentModel(new string[] { });
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProject();
        }

        private void toolStripButtonNewDesigner_Click(object sender, EventArgs e)
        {
            NewProject();
        }

        private void NewProject()
        {
            DialogResult dr = MessageBox.Show("Proceed to create blank zip designer?", "Confirmation...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            TreeNodeInterpreter.GetRootNode(treeViewZipDesigner).ClearAndDisposeNodes();
            listViewZipDesignFiles.Items.Clear();
            txtZipFileLocation.Text = "";
            txtFileName.Text = "";
            txtTargetLocation.Text = "";
            PROJECT_SESSION.ClearProjectSession();
            ClearStatisticForms();
        }

        private void toolStripMenuItemGenerateOneClickZip_Click(object sender, EventArgs e)
        {
            GenerateBatchFile();
        }

        private void GenerateBatchFile()
        {
            SaveProjectAsNew(ResourcesUtil.GetFileBatchFilterName());
        }
        
        private void btnRunZip_Click(object sender, EventArgs e)
        {
            StartArchiving();
        }

        private void StartArchiving()
        {
            if (!IsProjectDataCompleted()) return;
            SetUpToDateProjectSessionReferences();
            OneClickProcessorFrm oneClickForm = new OneClickProcessorFrm();
            oneClickForm.ShowDialog();
            oneClickForm.Dispose();
        }

        private void SetUpToDateProjectSessionReferences()
        {
            PROJECT_SESSION.ZipFileModel.TargetDropFileLocationPath = txtTargetLocation.Text;
            PROJECT_SESSION.UpdateZipDesignerModelStructure(TreeNodeInterpreter.GetRootNode(treeViewZipDesigner));
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            aboutFrm.ShowDialog();
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
                ShowInfoBox("No tree node selected or selected node is a root node.\n" +
                                  "Editing of root nodes is not allowed.");
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

        private void removeSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNodeInterpreter.RemoveSelectedNode(treeViewZipDesigner, listViewZipDesignFiles);
        }
        
        private void ctxMenuZipFileTree_Opening(object sender, CancelEventArgs e)
        {
            TreeNodeExtended treeNodeEx = (TreeNodeExtended)treeViewZipDesigner.SelectedNode;
            modifyFilterRuleToolStripMenuItem.Visible = treeNodeEx.IsFolderIsFilterRule;
        }

        private void modifyFilterRuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifyFilterRule();
        }

        private void ModifyFilterRule(TreeNodeExtended targetNode = null)
        {
            TreeNodeExtended treeNodeEx = (targetNode==null) ? (TreeNodeExtended)treeViewZipDesigner.SelectedNode : targetNode;
            FilterRuleFrm filterFrm = new FilterRuleFrm(treeNodeEx.FolderFilterRuleObj);
            filterFrm.ShowDialog();
            treeNodeEx.FolderFilterRuleObj = (FolderFilterRule)filterFrm.FolderFilterRule.Clone();
        }

#endregion

#region Context Strip for Zip File Designer List View

        private void contextMenuStripZipDesignerListView_Opening(object sender, CancelEventArgs e)
        {
            toolStripMenuItemOpenFolder.Visible = false;
            toolStripMenuItemModifyFolderFilterRule.Visible = false;
            toolStripMenuItemRemoveSelected.Visible = (listViewZipDesignFiles.SelectedItems.Count > 0);
            toolStripMenuItemRenameSelected.Visible = false;

            if (listViewZipDesignFiles.SelectedItems.Count == 1)
            {
                ListViewItemExtended lvie = (ListViewItemExtended)listViewZipDesignFiles.SelectedItems[0];
                toolStripMenuItemOpenFolder.Visible = lvie.CustomFileItem.IsFolderIsTreeViewNode;
                toolStripMenuItemModifyFolderFilterRule.Visible = lvie.CustomFileItem.IsFolderIsFilterRule;
                toolStripMenuItemRenameSelected.Visible = !lvie.ReferenceTreeNode.IsFolderIsFileViewNode;
                toolStripMenuItemRemoveSelected.Visible = !lvie.ReferenceTreeNode.IsFolderIsFileViewNode;
            }
        }

        private void toolStripMenuItemModifyFolderFilterRule_Click(object sender, EventArgs e)
        {
            ListViewZipDesignFilesOpenOrModifyFoldeRule();
        }

        private void toolStripMenuItemOpenFolder_Click(object sender, EventArgs e)
        {
            ListViewZipDesignFilesOpenOrModifyFoldeRule();
        }

        private void toolStripMenuItemRemoveSelected_Click(object sender, EventArgs e)
        {
            RemoveZipFileListViewItem();
        }

        private void toolStripMenuItemRefresh_Click(object sender, EventArgs e)
        {
            RefreshListViewAfterNodeSelection();
        }

        private void toolStripMenuItemRenameSelected_Click(object sender, EventArgs e)
        {
            EditListViewZipFileLabel();
        }




#endregion


    }

}
