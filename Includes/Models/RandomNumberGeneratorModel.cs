using OneClickZip.Includes.Interface;
using OneClickZip.Includes.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Models
{
    class RandomNumberGeneratorModel : CreatorModel, ICreatorExecutor
    {
        private List<ResourcePropertiesModel> randomNumberGenerator = ResourcesUtil.GetRandomNumberFormulaProperties();

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
            Console.WriteLine(GenerateSimpleRandomNumber(24));
            Console.WriteLine(GenerateInBetweenRandomNumber(900, 100000));
            return "";
        }


        private String GenerateSimpleRandomNumber(int value)
        {
            if (value >= int.MaxValue) return "Input value was too high.";
            if (value < 0) return "Please put a number higher than 0.";
            Random rnd = new Random();
            int result = rnd.Next(value);
            return result.ToString();
        }

        private String GenerateInBetweenRandomNumber(int min, int max)
        {
            if (min >= int.MaxValue) return "Min input value was too high.";
            if (max >= int.MaxValue) return "Max input value was too high.";
            if (min < 0) return "Please put a min number higher than 0.";
            if (max < 0) return "Please put a max number higher than 0.";
            Random rnd = new Random();
            int result = rnd.Next(min, max);
            return result.ToString();
        }
    }
}
