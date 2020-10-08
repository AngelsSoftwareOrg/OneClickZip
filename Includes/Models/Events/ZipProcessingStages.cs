using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Models.Events
{
    public enum ZipProcessingStages
    {
        INITIALIZATION,
        GENERATE_SERIALIZED_TREE_NODE_BASE_FILTER_RULE,
        ZIP_CREATION,
        ADDING_FILE,
        ADDING_FILE_FAILED,
        ADDING_FOLDER,
        POST_PROCESSING,
        FINISH_SUCCESSFUL,
        STOP_PROCESSING
    };
}
