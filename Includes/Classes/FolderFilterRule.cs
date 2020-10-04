using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Classes
{
    [Serializable]
    public class FolderFilterRule
    {
        private long minimumFileSize;
        private bool includeEmptyFolder;
        private String targetFolderPath;
        private List<String> includeFilterRules;
        private List<String> excludeFilterRules;

    }
}
