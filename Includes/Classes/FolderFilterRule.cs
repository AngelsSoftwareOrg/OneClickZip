using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using OneClickZip.Includes.Resources;
using OneClickZip.Includes.Utilities;

namespace OneClickZip.Includes.Classes
{
    [Serializable]
    public class FolderFilterRule: ICloneable
    {
        public enum TimeSpanOption
        {
            [EnumMember(Value = "(None)")]
            NONE,
            [EnumMember(Value = "Today")]
            TODAY,
            [EnumMember(Value = "This Month")]
            THIS_MONTH,
            [EnumMember(Value = "This Year")]
            THIS_YEAR,
            [EnumMember(Value = "Last xx days: ")]
            LAST_XX_DAYS
        };

        private long minimumFileSize;
        private long maximumFileSize;
        private bool hasMinimumFileSize;
        private bool hasMaximumFileSize;
        private bool includeEmptyFolder;
        private bool hasTimeSpan;
        private int lastNumberOfDaysValue;
        private TimeSpanOption timeSpanOption;
        private String targetFolderPath;
        private List<String> includeFilterRules;
        private List<String> excludeFilterRules;


        public FolderFilterRule()
        {
            IncludeEmptyFolder = true;
            HasMinimumFileSize = false;
            HasMaximumFileSize = false;
            MinimumFileSize = 0;
            MaximumFileSize = 0;
            HasTimeSpan = false;
            TimeSpanOptionValue = TimeSpanOption.NONE;
            TargetFolderPath = String.Empty;
            IncludeFilterRules = new List<string>();
            ExcludeFilterRules = new List<string>();
            IncludeFilterRules.Add("*");
            ExcludeFilterRules.AddRange(ResourcesUtil.GetResourceFolderFilterExcludeModel());

            //DEBUGGING
            //IncludeFilterRules.Clear();
            //IncludeFilterRules.Add(@"Add-in Express\");
            //IncludeFilterRules.Add(@"\Add-in Express\");
            //IncludeFilterRules.Add(@"\Add-in Express");
            //IncludeFilterRules.Add("Adobe");
            //IncludeFilterRules.Add(@"\Animotica\Projects\Media\*");
            //IncludeFilterRules.Add(@"*.docx");
            //IncludeFilterRules.Add(@"\*\*.txt");
            //IncludeFilterRules.Add(@"*.json");
            //IncludeFilterRules.Add(@"\*");
            //IncludeFilterRules.Add(@"\Adobe\?udition\");
            //IncludeFilterRules.Add(@"\Adobe\**");
            ExcludeFilterRules.Add(@"\Adobe\**");
            HasMinimumFileSize = true;
            HasMaximumFileSize = true;
            MinimumFileSize = 15360;
            MaximumFileSize = 819200;
            TimeSpanOptionValue = TimeSpanOption.THIS_YEAR;

        }

        public long MinimumFileSize { get => minimumFileSize; set => minimumFileSize = value; }
        public bool HasMinimumFileSize { get => hasMinimumFileSize; set => hasMinimumFileSize = value; }
        public bool IncludeEmptyFolder { get => includeEmptyFolder; set => includeEmptyFolder = value; }
        public bool HasTimeSpan { get => hasTimeSpan; set => hasTimeSpan = value; }
        public TimeSpanOption TimeSpanOptionValue { get => timeSpanOption; set => timeSpanOption = value; }
        public string TargetFolderPath
        {
            get
            {
                if (String.IsNullOrWhiteSpace(targetFolderPath)) return FileSystemUtilities.GetDefaultDirectory();
                return targetFolderPath;
            }
            set
            {
                targetFolderPath = value;
            }
        }
        public List<string> IncludeFilterRules { get => includeFilterRules; set => includeFilterRules = value; }
        public List<string> ExcludeFilterRules { get => excludeFilterRules; set => excludeFilterRules = value; }
        public long MaximumFileSize { get => maximumFileSize; set => maximumFileSize = value; }
        public bool HasMaximumFileSize { get => hasMaximumFileSize; set => hasMaximumFileSize = value; }
        public int LastNumberOfDaysValue { get => lastNumberOfDaysValue; set => lastNumberOfDaysValue = value; }
        public string GetTimeSpanOptionDescription(TimeSpanOption value)
        {
            return ClassReflectionUtilities.GetEnumDescription(value);
        }
        public String[] GetAllTimeSpanOptions()
        {
            return ClassReflectionUtilities.GetEnumerableOptions(typeof(TimeSpanOption));
        }
        public TimeSpanOption GetTypeBaseOnValue(String value)
        {
            foreach (TimeSpanOption timeSpan in Enum.GetValues(typeof(TimeSpanOption)))
            {
                if (GetTimeSpanOptionDescription(timeSpan).Equals(value, StringComparison.CurrentCultureIgnoreCase))
                {
                    return timeSpan;
                }
            }
            return TimeSpanOption.NONE;
        }
        public String GetAggregatedExcludedList()
        {
            if (ExcludeFilterRules == null) return "";
            if (ExcludeFilterRules.Count<=0) return "";
            return ExcludeFilterRules.Aggregate((x, y) => x + Environment.NewLine + y);
        }
        public String GetAggregatedIncludedList()
        {
            if (IncludeFilterRules == null) return "";
            if (IncludeFilterRules.Count <= 0) return "";
            return IncludeFilterRules.Aggregate((x, y) => x + Environment.NewLine + y);
        }
        public void ConsumeAggregatedIncludedList(String aggregatedList)
        {
            IncludeFilterRules.Clear();
            IncludeFilterRules.AddRange(aggregatedList.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
        }
        public void ConsumeAggregatedExcludedList(String aggregatedList)
        {
            ExcludeFilterRules.Clear();
            ExcludeFilterRules.AddRange(aggregatedList.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
        }
        public object Clone()
        {
            FolderFilterRule clone = (FolderFilterRule) base.MemberwiseClone();
            clone.IncludeFilterRules = new List<string>(this.IncludeFilterRules);
            clone.ExcludeFilterRules = new List<string>(this.ExcludeFilterRules);
            clone.TargetFolderPath = String.Copy(this.TargetFolderPath);
            return clone;
        }
    }
}
