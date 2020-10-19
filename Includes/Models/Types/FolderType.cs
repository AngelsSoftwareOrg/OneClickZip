using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Models.Types
{
    public enum FolderType
    {
        TreeView, //folder which shown as a folder like those in the windows explorer
        File, //an actual file, but added on the root folder so that it will shows in the tree view as node
        FilterRule //a folder which specifically contains rules and informations about the files to extract on its target folder
    }
}
