using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OneClickZip.Includes.Interface;

namespace OneClickZip.Includes.Classes.TreeNodeSerialize
{
    #region  DISCLAIMER
    /* THE CLASS IS PROVIDED "AS IS". ANY ECONOMIC (OR OTHERWISE) 
    /* LOSS/DAMAGE INCURRED DIRECTLY OR INDIRECTLY BECAUSE OF THIS 
    /* CLASS IS TO BE BEARED BY THE USER. THE AUTHOR IS IN NO WAY 
    /* RESPONSIBLE FOR ANY SUCH LOSS/DAMAGE.*/
    #endregion
    [Serializable]
    public class SerializableTreeNode : IZipFileTreeNode
    {
        #region USER DEFINED VARIABLES
        private string name=String.Empty;
        private int imageIndex =-1;
        private int selectedImageIndex = -1;
        private object tag =null;
        private string text = String.Empty;
        private string toolTipText = String.Empty;

        private ArrayList masterListFilesDir = new ArrayList();
        private bool isStructuredNode;
        private bool isCustomFolder;
        private bool isRootNode;

        List<SerializableTreeNode> nodes=new List<SerializableTreeNode>();

        #endregion
        #region PROPERTIES
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int ImageIndex
        {
            get { return imageIndex; }
            set { imageIndex=value; }
        }
        public int SelectedImageIndex
        {
            get { return selectedImageIndex; }
            set { selectedImageIndex = value; }
        }
        public object Tag
        {
            get { return tag; }
            set { tag=value; }
        }
        public string ToolTipText
        {
            get { return toolTipText; }
            set { toolTipText=value; }
        }
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        public List<SerializableTreeNode> Nodes
        {
            get { return nodes; }
            set { nodes=value; }
        }
        public ArrayList MasterListFilesDir { get => masterListFilesDir; set => masterListFilesDir = value; }
        public bool IsStructuredNode { get => isStructuredNode; set => isStructuredNode = value; }
        public bool IsCustomFolder { get => isCustomFolder; set => isCustomFolder = value; }
        public bool IsRootNode { get => isRootNode; set => isRootNode = value; }
        #endregion
        public SerializableTreeNode()
		{
		}
        public bool IsAFolderGenerally
        {
            get
            {
                return (IsStructuredNode || IsCustomFolder);
            }
        }
        List<SerializableTreeNode> IZipFileTreeNode.Nodes 
        { 
            get => this.nodes; 
            set => this.nodes = value; 
        }
    }
}
