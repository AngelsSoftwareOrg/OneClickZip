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

namespace OneClickZip
{
    public partial class ZipDesigner : Form
    {
        public ZipDesigner()
        {
            InitializeComponent();
            ListViewSearchDirExpHandlersAndControlsActivation();
            ZipDesignerHandlersAndActivation();
        }


#region EXP Dir related functions

        private void ListViewSearchDirExpHandlersAndControlsActivation()
        {
            this.listViewSearchDirExp.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewSearchDirExp.ItemActivate += new System.EventHandler(this.ListViewSearchDirExp_ItemDoubleClicked);
        }
        private void ExpTreeSearchDir_StartUpDirectoryChanged(ExpTreeLib.ExpTree.StartDir startDir)
        {
            Console.WriteLine(startDir);
        }
        private void ExpTreeSearchDir_ExpTreeNodeSelectedEventHandler(String selectedPath, CShItem cshItem){
            Console.WriteLine(selectedPath);
            listViewSearchDirExp.Clear();
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

        #endregion


#region ZIP Designer Controls and related functions

        private void ZipDesignerHandlersAndActivation()
        {
            treeViewZipDesigner.Nodes.Add("file name of the zip file.zip");

            treeViewZipDesigner.Nodes[0].Nodes.Add("hello world");
        }
#endregion

    }
}
