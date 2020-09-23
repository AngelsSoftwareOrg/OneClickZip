using System;
using System.Windows.Forms;
using ExpTreeLib;
using OneClickZip.Includes.Models;

namespace OneClickZip.Includes.Classes.Extensions
{
    public class ListViewItemExtended : ListViewItem
    {
        private CustomFileItem customFileItem;
        
        public ListViewItemExtended(CustomFileItem customFileItem) : base(customFileItem.GetCustomFileName)
        {
            this.customFileItem = customFileItem;
        }
        public ListViewItemExtended(CustomFileItem customFileItem, string[] items) : base(items)
        {
            this.customFileItem = customFileItem;
        }

        public CustomFileItem CustomFileItem { get => customFileItem; }
    }

}
