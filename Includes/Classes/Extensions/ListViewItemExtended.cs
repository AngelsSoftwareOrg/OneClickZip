using System;
using System.Windows.Forms;
using ExpTreeLib;

namespace OneClickZip.Includes.Classes.Extensions
{
    public class ListViewItemExtended : ListViewItem
    {
        private CShItem cshItem;
        
        public ListViewItemExtended(CShItem cshItem) : base(cshItem.GetFileName())
        {
            this.cshItem = cshItem;
        }
        public ListViewItemExtended(CShItem cshItem, string[] items) : base(items)
        {
            this.cshItem = cshItem;
        }

        public CShItem CshItem { get => cshItem; }
    }

}
