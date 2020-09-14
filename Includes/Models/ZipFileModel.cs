using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneClickZip.Includes.Models
{
    class ZipFileModel
    {
        private readonly TreeView zipStructureData;

        public ZipFileModel(TreeView zipStructureData)
        {
            this.zipStructureData = zipStructureData;
        }

        public TreeView ZipStructureData => zipStructureData;
    }
}
