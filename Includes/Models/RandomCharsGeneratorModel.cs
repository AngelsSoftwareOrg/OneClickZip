using OneClickZip.Includes.Interface;
using OneClickZip.Includes.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace OneClickZip.Includes.Models
{
    class RandomCharsGeneratorModel : CreatorModel, ICreatorExecutor
    {
        private List<ResourcePropertiesModel> randomCharsGenerator = ResourcesUtil.GetRandomCharsFormulaProperties();
        private static readonly String FORMULA_CODE = "RC";
        private readonly Dictionary<String, String> FORMULA_FUNCTION;

        public RandomCharsGeneratorModel(){
            FORMULA_FUNCTION = new Dictionary<String, String>
            {
                { "SHA1",  "HashSha1" },
                { "SHA256", "HashSha256" },
                { "SHA512", "HashSha512" }
            };
        }

        public List<ResourcePropertiesModel> GetResourcePropertiesList(bool includeHeader)
        {
            return this.GetConfigPropertiesList(randomCharsGenerator, includeHeader);
        }

        public String GetCreatorDescription()
        {
            return this.GeneratePrintoutDescriptions(this.randomCharsGenerator);
        }

        public String Generate(string formulaValue)
        {
            foreach(KeyValuePair<String, String> kvp in this.GetFormulaValue(FORMULA_CODE, formulaValue))
            {
                if (FORMULA_FUNCTION.ContainsKey(kvp.Value))
                {
                    String result = (String)this.GetType().GetMethod(FORMULA_FUNCTION[kvp.Value], 
                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy).Invoke(this, null);
                    formulaValue = formulaValue.Replace(kvp.Key, result);
                }
            }
            return formulaValue;
        }

        private string HashSha1()
        {
            using (var sha1 = new SHA1Managed())
            {
                return BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(this.GetDateNowInMillis()))).Replace("-","");
            }
        }

        private string HashSha256()
        {
            using (var sha256 = new SHA256Managed())
            {
                return BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(this.GetDateNowInMillis()))).Replace("-", "");
            }
        }
        private string HashSha512()
        {
            using (var sha512 = new SHA512Managed())
            {
                return BitConverter.ToString(sha512.ComputeHash(Encoding.UTF8.GetBytes(this.GetDateNowInMillis()))).Replace("-", "");
            }
        }
    }
}
