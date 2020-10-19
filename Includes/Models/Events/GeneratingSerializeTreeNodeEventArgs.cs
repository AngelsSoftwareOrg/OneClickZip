using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneClickZip.Includes.Classes;

namespace OneClickZip.Includes.Models.Events
{
    public class GeneratingSerializeTreeNodeEventArgs : EventArgs
    {
        public FolderFilterRule FolderFilterRuleObj { get; set; }
        public GeneratingSerializeTreeNodeProcessingStage ProcessingStage { get; set; }
        public long SequenceNumber { get; set; }
        public long ActualFilesProcessedCount { get; set; }
        public String ActionTaken { get; set; }
        public String HitFilterRule { get; set; }
        public String EvaluatedPath { get; set; }
        public String RelativeEvaluatedPath { get; set; }
    }
}
