using OneClickZip.Includes.Interface;
using OneClickZip.Includes.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Models
{
    class RandomCharsGeneratorModel : CreatorModel, ICreatorExecutor
    {
        private List<ResourcePropertiesModel> randomCharsGenerator = ResourcesUtil.GetRandomCharsFormulaProperties();

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

            Console.WriteLine("Sha1: " + HashSha1());
            Console.WriteLine("Sha256: " + HashSha256());
            Console.WriteLine("Sha512: " + HashSha512());
            return null;
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
