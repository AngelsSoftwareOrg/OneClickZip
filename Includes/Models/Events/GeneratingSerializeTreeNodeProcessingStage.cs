using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Models.Events
{
    public enum GeneratingSerializeTreeNodeProcessingStage
    {
        INITIALIZATION,
        ENFORCING_RULE_TO_FILE,
        ENFORCING_RULE_TO_FOLDER,
        POST_PROCESSING,
        GENERATION_SUCCESSFUL,
        STOP_GENERATION
    }
}
