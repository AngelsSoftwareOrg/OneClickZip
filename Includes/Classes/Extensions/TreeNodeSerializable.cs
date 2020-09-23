using OneClickZip.Includes.Classes.TreeNodeSerialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneClickZip.Includes.Classes.Extensions
{
    [Serializable]
    public class TreeNodeSerializable
    {
        private SerializableTreeNode serializedTreeNodeStructure;

        public TreeNodeSerializable()
        {
        }
        public TreeNodeSerializable(TreeView treeView)
        {

        }

        public SerializableTreeNode SerializedTreeNodeStructure { get => serializedTreeNodeStructure; set => serializedTreeNodeStructure = value; }

        //public TreeView TreeViewObject { get => treeViewObject; set => treeViewObject = value; }
    }
}
