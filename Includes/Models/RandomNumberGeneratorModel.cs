using OneClickZip.Includes.Interface;
using OneClickZip.Includes.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace OneClickZip.Includes.Models
{
    [Serializable]
    class RandomNumberGeneratorModel : CreatorModel, ICreatorExecutor
    {
        private List<ResourcePropertiesModel> randomNumberGenerator = ResourcesUtil.GetRandomNumberFormulaProperties();
        private static String FORMULA_CODE = "RN";

        public List<ResourcePropertiesModel> GetResourcePropertiesList(bool includeHeader)
        {
            return this.GetConfigPropertiesList(randomNumberGenerator, includeHeader);
        }

        public String GetCreatorDescription()
        {
            return this.GeneratePrintoutDescriptions(this.randomNumberGenerator);
        }

        public String Generate(string formulaValue)
        {
            foreach (KeyValuePair<String, String> kvp in this.GetFormulaValue(FORMULA_CODE, formulaValue))
            {
                String result = "";
                if (kvp.Value.Contains(","))
                {
                    result = this.GenerateInBetweenRandomNumber(kvp.Value);
                }
                else
                {
                    result = this.GenerateSimpleRandomNumber(kvp.Value);
                }
                formulaValue = formulaValue.Replace(kvp.Key, result);
            }
            return formulaValue;
        }

        private String GenerateSimpleRandomNumber(String plainValue)
        {
            if (plainValue == null) return "";
            if (plainValue.Length <= 0) return "";
            int value = 0;
            if (!int.TryParse(plainValue, out value)) return plainValue;
            if (value >= int.MaxValue) return "Input value was too high.";
            if (value < 0) return "Please put a number higher than 0.";
            Random rnd = new Random();
            int result = 0;
            int maxTry = 0;
            while (result <= 0)
            {
                result = rnd.Next(value+1);
                if (maxTry++ > 10000) result = 1;
            }
            return result.ToString();
        }

        private String GenerateInBetweenRandomNumber(String minMax)
        {
            if (minMax == null) return "";
            if (minMax.Length <= 0) return "";
            if (!minMax.Contains(",")) return minMax;
            String[] splitted = minMax.Split(char.Parse(","));
            
            if (splitted.Length < 1) return minMax;

            int min = 0;  
            int max = 0;
            if (!int.TryParse(splitted[0], out min)) return minMax;
            if (!int.TryParse(splitted[1], out max)) return minMax;

            if (min >= int.MaxValue) return "Min input value was too high.";
            if (max >= int.MaxValue) return "Max input value was too high.";
            if (min < 0) return "Please put a min number higher than 0.";
            if (max < 0) return "Please put a max number higher than 0.";
            Random rnd = new Random();
            int result = 0;
            int maxTry = 0;
            while(result <= 0)
            {
                result = rnd.Next(min, max);
                if (maxTry++ > 10000) result = 1;
            }
            return result.ToString();
        }
    }
}
