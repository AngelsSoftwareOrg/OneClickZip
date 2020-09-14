using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpTreeLib;
using OneClickZip.Includes.Classes;
using OneClickZip.Includes.Classes.Extensions;
using OneClickZip.Includes.Models;

namespace OneClickZip
{
    public partial class ZipDesigner : Form
    {
        public ZipDesigner()
        {
            InitializeComponent();
            ListViewSearchDirExpHandlersAndControlsActivation();
            ListViewZipDesignFilesHandlersAndControlsActivation();
            ZipDesignerHandlersAndActivation();
        }


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
                ListViewItemExtended lvItemEx = (ListViewItemExtended)listViewSearchDirExp.SelectedItems[0];
                CShItem cshItem = lvItemEx.CshItem;

                Console.WriteLine("\nItem Name: " + cshItem.Text);
                Console.WriteLine("Is Folder: " + cshItem.IsFolder);
                Console.WriteLine("Path: " + cshItem.Path + "\n");
                //Console.WriteLine(listViewSearchDirExp.SelectedItems[0].Text);
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

        private void ListViewZipDesignFiles_ItemDoubleClicked(object sender, EventArgs e)
        {
            Console.WriteLine("ListViewZipDesignFiles_ItemDoubleClicked");
            if (listViewZipDesignFiles.SelectedItems.Count > 0)
            {
                ListViewItemExtended lvItemEx = (ListViewItemExtended)listViewZipDesignFiles.SelectedItems[0];
                CShItem cshItem = lvItemEx.CshItem;

                Console.WriteLine("\nItem Name: " + cshItem.Text);
                Console.WriteLine("Is Folder: " + cshItem.IsFolder);
                Console.WriteLine("Path: " + cshItem.Path + "\n");
            }
        }

        private void ListViewZipDesignFiles_DragDropHandler(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection).ToString(), false))
            {
                ListView.SelectedListViewItemCollection lstViewColl = (ListView.SelectedListViewItemCollection)
                                                                      e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));
                treeViewZipDesigner.BeginUpdate();
                listViewZipDesignFiles.BeginUpdate();
                foreach (ListViewItemExtended lvItem in lstViewColl)
                {
                    addZipFileNode(lvItem.CshItem);
                    //CShItem cshItem = lvItem.CshItem;
                    ListViewInterpretor.generateListViewZipFileViewItems(listViewZipDesignFiles, lvItem.CshItem);
                    //Console.WriteLine("----------------");
                    //Console.WriteLine("\nItem Name: " + cshItem.Text);
                    //Console.WriteLine("Is Folder: " + cshItem.IsFolder);
                    //Console.WriteLine("Path: " + cshItem.Path + "\n");
                }
                treeViewZipDesigner.EndUpdate();
                listViewZipDesignFiles.EndUpdate();
            }

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
            treeViewZipDesigner.Nodes.Add("ROOT");
            //treeViewZipDesigner.SelectedNode = treeViewZipDesigner.Nodes[0];
        }


        private void addZipFileNode(CShItem cshItem)
        {
            TreeNode selectedNode = (treeViewZipDesigner.SelectedNode == null) ? treeViewZipDesigner.Nodes[0] : treeViewZipDesigner.SelectedNode;
            TreeNodeInterpreter.addRecursiveNode(selectedNode, cshItem);
            //treeViewZipDesigner.SelectedNode = treeViewZipDesigner.Nodes[0];
        }


        #endregion

    }
}
