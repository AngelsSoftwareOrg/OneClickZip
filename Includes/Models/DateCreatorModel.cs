using OneClickZip.Includes.Interface;
using OneClickZip.Includes.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Models
{
    class DateCreatorModel : CreatorModel, ICreatorExecutor
    {
        private List<ResourcePropertiesModel> dateGenerator = ResourcesUtil.GetDateFormulaProperties();
        private static String FORMULA_CODE = "DT";
        private readonly Dictionary<String, String> FORMULA_FUNCTION;

        public DateCreatorModel()
        {
            FORMULA_FUNCTION = new Dictionary<String, String>
            {
                { "DateNowMillis",  "GenerateSystemTimeInMillis" },
                { "Standard", "generateFormattedDate" }
            };
        }


        public List<ResourcePropertiesModel> GetResourcePropertiesList(bool includeHeader)
        {
            return this.GetConfigPropertiesList(dateGenerator, includeHeader);
        }

        public String GetCreatorDescription()
        {
            return this.GeneratePrintoutDescriptions(this.dateGenerator);
        }

        public String Generate(string formulaValue)
        {
            foreach (KeyValuePair<String, String> kvp in this.GetFormulaValue(FORMULA_CODE, formulaValue))
            {
                String result = "";
                if (FORMULA_FUNCTION.ContainsKey(kvp.Value))
                {
                    result = (String)this.GetType().GetMethod(FORMULA_FUNCTION[kvp.Value],
                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy).Invoke(this, null);
                    formulaValue = formulaValue.Replace(kvp.Key, result);
                }
                else
                {
                    result = this.GenerateFormattedDate(kvp.Value);
                }
                formulaValue = formulaValue.Replace(kvp.Key, result);
            }
            return formulaValue;
        }


        private String GenerateSystemTimeInMillis()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
        }

        private String GenerateFormattedDate(String format)
        {
            try
            {
                DateTime.Now.ToString(@format);
            }
            catch (Exception)
            {
                return "Try to add a space before or after for [" + format + "]";
            }

            return DateTime.Now.ToString(@format);
        }

    }
}

