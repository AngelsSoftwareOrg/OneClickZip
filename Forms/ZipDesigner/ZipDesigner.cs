using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

namespace OneClickZip
{
    public partial class ZipDesigner : Form
    {
        private readonly ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
        private readonly ListViewColumnSorterForFileDir lvwColumnSorterFileDir = new ListViewColumnSorterForFileDir();
        private ZipFileModel zipFileModel;



        public ZipDesigner()
        {
            InitializeComponent();
            ListViewSearchDirExpHandlersAndControlsActivation();
            ListViewZipDesignFilesHandlersAndControlsActivation();
            ZipDesignerHandlersAndActivation();


            //debug
            //ResourcesUtil.GetDateFormulaProperties();

            
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

            //DEBUG
            Console.WriteLine(selectedPath);
            listViewSearchDirExp.Items.Clear();
            ListViewInterpretor.generateListViewExplorerItems(listViewSearchDirExp, cshItem);
        }

        /**
         * Need this event viewer to show the icon on the explorer
         */
        private void ListViewSearchDirExp_VisibleChanged(object sender, EventArgs e)
        {
            ListViewInterpretor.refreshToShowExplorerIcons(listViewSearchDirExp);
        }

        private void ListViewSearchDirExp_ItemDoubleClicked(object sender, EventArgs e)
        {
            Console.WriteLine("listViewSearchDirExp_ItemDoubleClicked");
            if (listViewSearchDirExp.SelectedItems.Count > 0)
            {
                addSelectedItemsOnZipFileModelListView(listViewSearchDirExp.SelectedItems);

                //DEBUG
                ListViewItemExtended lvItemEx = (ListViewItemExtended)listViewSearchDirExp.SelectedItems[0];
                CShItem cshItem = lvItemEx.CshItem;
                Console.WriteLine("\nItem Name: " + cshItem.Text);
                Console.WriteLine("Is Folder: " + cshItem.IsFolder);
                Console.WriteLine("Path: " + cshItem.Path + "\n");
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
            newZipStructureProcedure();
        }

        private void ListViewZipDesignFilesHandlersAndControlsActivation()
        {
            this.listViewZipDesignFiles.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewZipDesignFiles.ItemActivate += new System.EventHandler(this.ListViewZipDesignFiles_ItemDoubleClicked);
        }

        private void treeViewZipDesigner_AfterSelectHandler(object sender, TreeViewEventArgs e)
        {
            ArrayList arrCshItem = (ArrayList) ((TreeNodeExtended) treeViewZipDesigner.SelectedNode).MasterListFilesDir;
            listViewZipDesignFiles.Tag = treeViewZipDesigner.SelectedNode;
            refreshTreeViewZipDesignerListViewItems(arrCshItem);
            selectSelectedNodeBgColor();
        }

        private void treeViewZipDesigner_BeforeSelectHandler(object sender, TreeViewCancelEventArgs e)
        {
            removePreviousSelectedNodeBgColor();
        }

        private void refreshTreeViewZipDesignerListViewItems(ArrayList arrCshItem)
        {
            listViewZipDesignFiles.BeginUpdate();
            listViewZipDesignFiles.Items.Clear();
            bool isRootNode = isSelectedZipModelNodeRoot();
            foreach(CShItem cshItem in arrCshItem)
            {
                if (isRootNode)
                {
                    ListViewInterpretor.generateListViewZipFileViewItems(listViewZipDesignFiles, cshItem);
                }
                else
                {
                    ListViewInterpretor.generateListViewZipFileChildrenViewItems(listViewZipDesignFiles, cshItem);
                }
            }
            listViewZipDesignFiles.EndUpdate();
        }

        private void ListViewZipDesignFiles_ItemDoubleClicked(object sender, EventArgs e)
        {
            Console.WriteLine("ListViewZipDesignFiles_ItemDoubleClicked");
            if (listViewZipDesignFiles.SelectedItems.Count > 0)
            {
                ListViewItemExtended lvItemEx = (ListViewItemExtended)listViewZipDesignFiles.SelectedItems[0];
                CShItem cshItem = lvItemEx.CshItem;

                //DEBUG
                Console.WriteLine("\nItem Name: " + cshItem.Text);
                Console.WriteLine("Is Folder: " + cshItem.IsFolder);
                Console.WriteLine("Path: " + cshItem.Path + "\n");
                //DEBUG END
            }

        }

        private void ListViewZipDesignFiles_DragDropHandler(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection).ToString(), false))
            {
                ListView.SelectedListViewItemCollection lstViewColl = (ListView.SelectedListViewItemCollection)
                                                                      e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));
                addSelectedItemsOnZipFileModelListView(lstViewColl);
            }
        }

        private void addSelectedItemsOnZipFileModelListView(ListView.SelectedListViewItemCollection lstViewColl)
        {
            treeViewZipDesigner.BeginUpdate();
            listViewZipDesignFiles.BeginUpdate();
            foreach (ListViewItemExtended lvItem in lstViewColl)
            {
                //if node are not yet existed on the currently selected node of the tree
                if (!addZipFileNode(lvItem.CshItem))
                {
                    ListViewInterpretor.generateListViewZipFileViewItems(listViewZipDesignFiles, lvItem.CshItem);
                    TreeNodeInterpreter.addTagObject((TreeNodeExtended) treeViewZipDesigner.SelectedNode, lvItem.CshItem);
                } 

                //CShItem cshItem = lvItem.CshItem;
                
                //Console.WriteLine("----------------");
                //Console.WriteLine("\nItem Name: " + cshItem.Text);
                //Console.WriteLine("Is Folder: " + cshItem.IsFolder);
                //Console.WriteLine("Path: " + cshItem.Path + "\n");
            }
            treeViewZipDesigner.EndUpdate();
            listViewZipDesignFiles.EndUpdate();
        }

        private void ListViewZipDesignFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
                e.Effect = DragDropEffects.Move;
        }
        
        private void listViewZipDesignFiles_VisibleChanged(object sender, EventArgs e)
        {
            ListViewInterpretor.refreshToShowExplorerIcons(listViewZipDesignFiles);
        }

        private void btnZipFileAddFolder_Click(object sender, EventArgs e)
        {
            
        }

        private void btnZipClear_Click(object sender, EventArgs e)
        {
            newZipStructureProcedure();
        }

        private void btnAddSelected_Click(object sender, EventArgs e)
        {

        }

        private void newZipStructureProcedure()
        {
            treeViewZipDesigner.Nodes.Clear();
            listViewZipDesignFiles.Items.Clear();
            TreeNodeExtended rootNode = new TreeNodeExtended();
            rootNode.Text = "ROOT";
            rootNode.Name = "ROOT";
            treeViewZipDesigner.Nodes.Add(rootNode);
            treeViewZipDesigner.SelectedNode = rootNode;
            listViewZipDesignFiles.Tag = rootNode;
            selectSelectedNodeBgColor();
        }

        private bool addZipFileNode(CShItem cshItem)
        {
            TreeNodeExtended selectedNode = (TreeNodeExtended) ((treeViewZipDesigner.SelectedNode == null) ? treeViewZipDesigner.Nodes[0] : treeViewZipDesigner.SelectedNode);
            bool isExistingNode = TreeNodeInterpreter.addRecursiveNode(selectedNode, cshItem);

            if (isSelectedZipModelNodeRoot() && !cshItem.IsFolder && !isExistingNode)
            {
                TreeNodeInterpreter.addRootItemFilesAsNode(selectedNode, cshItem);
            }
            return isExistingNode;
        }
        
        private bool isSelectedZipModelNodeRoot()
        {
            return (treeViewZipDesigner.SelectedNode.Name == "ROOT");
        }

        private void btnRemoveSelectedNode_Click(object sender, EventArgs e)
        {
            if (treeViewZipDesigner.SelectedNode == null) return;
            if (isSelectedZipModelNodeRoot())
            {
                newZipStructureProcedure();
                return;
            }
            TreeNode parentNode = treeViewZipDesigner.SelectedNode.Parent;
            treeViewZipDesigner.SelectedNode.Remove();
            treeViewZipDesigner.SelectedNode = parentNode;
            selectSelectedNodeBgColor();
            refreshTreeViewZipDesignerListViewItems(((TreeNodeExtended)treeViewZipDesigner.SelectedNode).MasterListFilesDir);
        }

        private void selectSelectedNodeBgColor()
        {
            if (treeViewZipDesigner.SelectedNode == null) return;
            treeViewZipDesigner.SelectedNode.BackColor = Color.Gray;
        }
        
        private void removePreviousSelectedNodeBgColor()
        {
            if (treeViewZipDesigner.SelectedNode == null) return;
            treeViewZipDesigner.SelectedNode.BackColor = Color.Empty;
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

        private void btnCreateFileName_Click(object sender, EventArgs e)
        {
            FileNameCreatorFrm fileNameCreator = new FileNameCreatorFrm();
            fileNameCreator.ShowDialog();
        }
    }
}
