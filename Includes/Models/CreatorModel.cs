using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OneClickZip.Includes.Resources;

namespace OneClickZip.Includes.Models
{
    [Serializable]
    partial class CreatorModel
    {
        private static String FORMULA_PATTERN_REGEX_START = "\\$";
        private static String FORMULA_PATTERN_REGEX = "{.*?\\}";
        public static string FORMULA_PATTER_REGEX_COMPLETE = "\\$.*?\\{.*?\\}";

        protected List<KeyValuePair<String, String>> GetFormulaValue(String formulaCode, String actualFormulaValue)
        {
            List<KeyValuePair<String, String>> arrKeyValuePair = new List<KeyValuePair<String, String>>();
            String completPattern = FORMULA_PATTERN_REGEX_START + formulaCode + FORMULA_PATTERN_REGEX;

            //DEBUG
            //Console.WriteLine("Complete Formula: " + completPattern);

            MatchCollection matchValueCol = Regex.Matches(actualFormulaValue, @completPattern);
            for (var i = 0; i < matchValueCol.Count; i++)
            {
                String formula = matchValueCol[i].Value;
                String value = ExtractFormulaValue(formulaCode, matchValueCol[i].Value);
                KeyValuePair<String, String> kvp = new KeyValuePair<String, String>(formula, value);
                arrKeyValuePair.Add(kvp);

                //default
                //Console.WriteLine(formula + " - " + value);
            }
            return arrKeyValuePair;
        }

        private String ExtractFormulaValue(String formulaCode, String formula)
        {
            int prefixLength = formulaCode.Length + 2;
            int lenToSub = formula.Length - prefixLength - 1; //the end point
            return formula.Substring(prefixLength, lenToSub);
        }

        protected List<ResourcePropertiesModel> GetConfigPropertiesList(List<ResourcePropertiesModel> listConfig, bool includeHeader)
        {
            List<ResourcePropertiesModel> results = new List<ResourcePropertiesModel>();
            foreach (ResourcePropertiesModel rpm in listConfig)
            {
                if (rpm.UniquePropertyId.Contains("_HEADER"))
                {
                    if (includeHeader) results.Add(rpm);
                }
                else
                {
                    results.Add(rpm);
                }
            }
            return results;
        }

        protected String GetDateNowInMillis()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
        }

        protected String GeneratePrintoutDescriptions(List<ResourcePropertiesModel> listRpm)
        {
            StringBuilder sb = new StringBuilder();

            //assess the longest property value
            int propertyValueLen = 0;
            foreach (ResourcePropertiesModel rpm in listRpm)
            {
                if (rpm.PropertyValue.Length >= propertyValueLen) propertyValueLen = rpm.PropertyValue.Length;
            }

            foreach (ResourcePropertiesModel rpm in listRpm)
            {
                if (rpm.UniquePropertyId.Contains("_HEADER"))
                {
                    sb.Insert(0, "\n");
                    sb.Insert(0, rpm.Description);
                    sb.Insert(0, ": ");
                    sb.Insert(0,rpm.PropertyValue);
                    sb.Insert(0, "***");
                }
                else
                {
                    //sb.Append(">  ");
                    sb.Append(rpm.PropertyValue);
                    sb.Append(AssesHowManyTabToInsert(rpm.PropertyValue, propertyValueLen) + "= ");
                    sb.AppendLine(rpm.Description);
                }
            }
            return sb.ToString();
        }

        private String AssesHowManyTabToInsert(String valueToAsses, int longestPropertyValueLen)
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("\t");

            int charPerTab = 8;
            int extraAdjustment = 8;

#pragma warning disable CS0219 // Variable is assigned but its value is never used
            int repeat = 0;
            int repeatLongest = 0;
#pragma warning restore CS0219 // Variable is assigned but its value is never used

            int inputTabCount = 0;
            int longestTabCount = 0;
            //use the difference between longest and current value. Use the remainder as basis
            //repeat = repeatLongest - repeat;

            //repeat = ((valueToAsses.Length + extraAdjustment) / charPerTab);
            longestTabCount = ((longestPropertyValueLen + extraAdjustment) / charPerTab);
            longestTabCount = (((longestPropertyValueLen + extraAdjustment) % charPerTab) > 0) ? longestTabCount + 1 : longestTabCount;

            if (valueToAsses.Length >= charPerTab)
            {
                inputTabCount = ((valueToAsses.Length + extraAdjustment) / charPerTab);
                inputTabCount = inputTabCount - 1; //because it already pass 8 characters
                inputTabCount = longestTabCount - inputTabCount;
            }
            else
            {
                inputTabCount = longestTabCount;
            }

            //repeat = charPerTab - ((longestPropertyValueLen - valueToAsses.Length) % charPerTab);
            //repeatLongest = charPerTab - (longestPropertyValueLen % charPerTab);

            //dividing has remainders?
            //repeat = ((repeat % charPerTab) > 0) ? repeat + 1 : 1;
            //repeat = repeat + (repeat % charPerTab)  + 1;
            //repeat = ((valueToAsses.Length % charPerTab) > 0) ? repeat + 1: repeat;
            //repeatLongest = ((charPerTab - (longestPropertyValueLen % charPerTab)) > 0) ? repeatLongest + 1 : repeatLongest;


            //repeat = repeatLongest - repeat;

            //how many tab had this property value
            //repeat = (repeat <= 0) ? 1 : repeat;

            //Console.WriteLine(valueToAsses 
            //                    + ", Length: " + valueToAsses.Length 
            //                    + ", Asses: " + (charPerTab - (valueToAsses.Length % charPerTab))
            //                    + ", inputTabCount : " + inputTabCount
            //                    + ", longestTabCount : " + longestTabCount
            //                    + ", tab : " + (new String(Char.Parse("t"), inputTabCount)));



            //align the tab of this to longest property value
            //repeat = repeatLongest - repeat;
            //repeat = (repeat > longestPropertyValueLen) ? longestPropertyValueLen : repeat; 

            sb.Append(new String(Char.Parse("\t"), inputTabCount));
            return sb.ToString();
        }

    }
}
