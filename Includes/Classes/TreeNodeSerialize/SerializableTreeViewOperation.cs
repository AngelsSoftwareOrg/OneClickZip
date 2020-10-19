using OneClickZip.Includes.Classes.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OneClickZip.Includes.Classes.TreeNodeSerialize
{
    #region  DISCLAIMER
    /* THE CLASS IS PROVIDED "AS IS". ANY ECONOMIC (OR OTHERWISE) 
    /* LOSS/DAMAGE INCURRED DIRECTLY OR INDIRECTLY BECAUSE OF THIS 
    /* CLASS IS TO BE BEARED BY THE USER. THE AUTHOR IS IN NO WAY 
    /* RESPONSIBLE FOR ANY SUCH LOSS/DAMAGE.*/
    #endregion
    public class SerializableTreeViewOperation
    {
        /// <summary>
        /// This function prepares an StreeNode Similar to the treeView
        /// </summary>
        public static SerializableTreeNode fnPrepareToWrite(TreeNodeExtended treeNodeExtended)
        {
            try
            {
                TreeNodeExtended treeNodeDestination = (TreeNodeExtended) treeNodeExtended.Clone();
                treeNodeDestination.Nodes.Clear();
                foreach (TreeNodeExtended treeNodeItr in treeNodeExtended.Nodes)
                {
                    treeNodeDestination.Nodes.Add((TreeNodeExtended)treeNodeItr.Clone());
                }
                SerializableTreeNode FinalStr = fnPrepareTreeNode(treeNodeDestination);
                return FinalStr;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #region Allied functions for writing purpose
        /// <summary>
        /// One of the two recursives.
        /// </summary>
        /// <param name="tr"></param>
        /// <returns></returns>
        private static List<SerializableTreeNode> fnPrepareChildNode(TreeNodeExtended tr)
        {
            List<SerializableTreeNode> retSTreeNode = new List<SerializableTreeNode>();
            SerializableTreeNode stc;
            foreach (TreeNodeExtended trc in tr.Nodes)
            {
                stc = fnPrepareTreeNode(trc);
                retSTreeNode.Add(stc);
            }
            return retSTreeNode;
        }
        /// <summary>
        /// One of the two recursives
        /// </summary>
        /// <param name="tr"></param>
        /// <returns></returns>
        private static SerializableTreeNode fnPrepareTreeNode(TreeNodeExtended tr)
        {
            SerializableTreeNode strRet = new SerializableTreeNode();
            SerializeTreeNode(tr, strRet);
            strRet.Nodes = fnPrepareChildNode(tr);
            return strRet;
        }
        #endregion
        /// <summary>
        /// This functions returns the treeView for which it has been written
        /// </summary>
        /// <returns></returns>
        public static TreeNodeExtended fnPrepareToRead(SerializableTreeNode sTreeNode)
        {
            try
            {
                TreeNodeExtended FinalTreeNode = RfnPrepareTreeNode(sTreeNode);
                return FinalTreeNode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #region Allied functions for Writing Purpose
        private static List<TreeNodeExtended> RfnPrepareChildNodes(SerializableTreeNode str)
        {
            List<TreeNodeExtended> retTreeNode = new List<TreeNodeExtended>();
            TreeNodeExtended tnc;
            foreach(SerializableTreeNode strc in str.Nodes)
            {
                tnc = RfnPrepareTreeNode(strc);
                retTreeNode.Add(tnc);
            }
            return retTreeNode;
        }
        private static TreeNodeExtended RfnPrepareTreeNode(SerializableTreeNode str)
        {
            TreeNodeExtended trnRet = new TreeNodeExtended();
            UnserializeTreeNode(str, trnRet);
            #region Building NodeCollection
            List<TreeNodeExtended> retTempTreeNodeList = RfnPrepareChildNodes(str);
            foreach (TreeNodeExtended tempTr in retTempTreeNodeList)
            {
                trnRet.Nodes.Add(tempTr);
            }
            #endregion
            return trnRet;
        }

        private static void UnserializeTreeNode(SerializableTreeNode source, TreeNodeExtended destination)
        {
            destination.Name = source.Name;
            destination.Tag = source.Tag;
            destination.ToolTipText = source.ToolTipText;
            destination.ImageIndex = source.ImageIndex;
            destination.Text = source.Text;
            destination.SelectedImageIndex = source.SelectedImageIndex;
            destination.MasterListFilesDir.AddRange(source.MasterListFilesDir.ToArray());
            destination.FolderType = source.FolderType;
            destination.FolderFilterRuleObj = source.FolderFilterRuleObj;
            //destination.IsRootNode = source.IsRootNode; //no need
        }

        private static void SerializeTreeNode(TreeNodeExtended source, SerializableTreeNode destination)
        {
            destination.Name = source.Name;
            destination.ToolTipText = source.ToolTipText;
            destination.ImageIndex = source.ImageIndex;
            destination.Text = source.Text.ToString();
            destination.SelectedImageIndex = source.SelectedImageIndex;
            destination.MasterListFilesDir.AddRange(source.MasterListFilesDir.ToArray());
            destination.FolderType = source.FolderType;
            destination.IsRootNode = source.IsRootNode;
            destination.FolderFilterRuleObj = source.FolderFilterRuleObj;
            destination.Tag = (source.Tag == null) ? null : source.Tag.ToString();
        }

        public static void SerializeTreeNodeShallowCopy(SerializableTreeNode source, SerializableTreeNode destination)
        {
            if (!String.IsNullOrEmpty(source.Name)) destination.Name = source.Name;
            if (!String.IsNullOrEmpty(source.ToolTipText)) destination.ToolTipText = source.ToolTipText;
            destination.ImageIndex = source.ImageIndex;
            if(!String.IsNullOrEmpty(source.Text)) destination.Text = source.Text.ToString();
            destination.SelectedImageIndex = source.SelectedImageIndex;
            destination.MasterListFilesDir.AddRange(source.MasterListFilesDir.ToArray());
            destination.FolderType = source.FolderType;
            destination.IsRootNode = source.IsRootNode;
            destination.FolderFilterRuleObj = source.FolderFilterRuleObj;
            destination.Tag = (source.Tag == null) ? null : source.Tag.ToString();
            destination.Nodes.AddRange(source.Nodes);
        }


        #endregion


    }
}
