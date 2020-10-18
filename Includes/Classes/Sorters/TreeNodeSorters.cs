using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneClickZip.Includes.Classes.Extensions;

namespace OneClickZip.Includes.Classes.Sorters
{

    public class TreeNodeSorters : System.Collections.IComparer
    {
        public TreeNodeSorters() { }
        
        public int Compare(object x, object y)
        {
            TreeNodeExtended tx = x as TreeNodeExtended;
            TreeNodeExtended ty = y as TreeNodeExtended;

            if(tx.IsGenerallyAFolderType && ty.IsGenerallyAFolderType) return string.Compare(tx.Text, ty.Text);
            if (tx.IsGenerallyAFolderType) return -1;
            if (ty.IsGenerallyAFolderType) return 1;
            return string.Compare(tx.Text, ty.Text);
        }
    }
}
