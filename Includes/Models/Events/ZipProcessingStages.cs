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
        ZIP_CREATION,
        ADDING_FILE,
        ADDING_FOLDER,
        POST_PROCESSING,
        FINISH_SUCCESSFUL,
        STOP_PROCESSING
    };
}
