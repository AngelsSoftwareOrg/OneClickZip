using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OneClickZip.Includes.Classes;

namespace OneClickZip
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            PopulateTreeViewImageIndex();
        }



        private void PopulateTreeViewImageIndex()
        {
            ImageList smallImageList = DefaultIcons.SYSTEM_ICONS.SmallIconsImageList;
            treeViewImageIndex.ImageList = smallImageList;
            ImageList.ImageCollection collection = smallImageList.Images;
            foreach(String imageKey in collection.Keys)
            {
                int index = smallImageList.Images.IndexOfKey(imageKey);

                TreeNode treeNode = new TreeNode(imageKey);
                treeNode.Name = imageKey;
                treeNode.Text = index + "-" + imageKey;
                treeNode.ImageIndex = index;
                treeNode.SelectedImageIndex = index;
                treeViewImageIndex.Nodes.Add(treeNode);
            }
        }

    }
}
