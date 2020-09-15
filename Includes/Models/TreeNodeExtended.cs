using ExpTreeLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneClickZip.Includes.Models
{
    class TreeNodeExtended : TreeNode
    {
        private ArrayList masterListFilesDir = new ArrayList();

        public TreeNodeExtended() : base(){}

        public void addItem(CShItem cshItem)
        {
            this.masterListFilesDir.Add(cshItem);
        }

        public void clearItem()
        {
            this.masterListFilesDir.Clear();
        }

        public void removeItem(CShItem cshItem)
        {
            this.masterListFilesDir.Remove(cshItem);
        }

        public ArrayList MasterListFilesDir => this.masterListFilesDir;

    }
}
