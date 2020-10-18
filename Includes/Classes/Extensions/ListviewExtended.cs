using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneClickZip.Includes.Classes.Extensions
{
    public  class ListviewExtended: ListView
    {
        private TreeNodeExtended referenceTreeNode;

        public TreeNodeExtended ReferenceTreeNode { get => referenceTreeNode; set => referenceTreeNode = value; }
    }
}
