using System;
using System.Windows.Forms;
using ExpTreeLib;

namespace OneClickZip
{
    public class ListViewItemExtended : ListViewItem
    {
        private CShItem cshItem;
        
        public ListViewItemExtended(string text) : base(text)
        {
            
        }

        public CShItem CshItem { get => cshItem; set => cshItem = value; }
    }

}
