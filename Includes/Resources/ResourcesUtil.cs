using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Resources
{
    public class ResourcesUtil : IDisposable 
    {
        private static ResourceManager RESOURCE_MANAGER;
        private static readonly String RESOURCE_NAME = "OneClickZip.Properties.Resources";
        private static readonly String RESOURCE_PROPERTY_FILE_NAME = "CREATOR_DETAILS"; //CREATOR_DETAILS.properties

        private static readonly String RESOURCE_PROPERTY_NAME_DATE = "DATE_FORMULA_FUNCTION_";
        private static readonly String RESOURCE_PROPERTY_NAME_RANDOM_GEN = "RANDOM_NUMBER_GENERATOR_";
        private static readonly String RESOURCE_PROPERTY_NAME_RANDOM_CHARS = "RANDOM_CHAR_GENERATOR_";
        private static List<ResourcePropertiesModel> getDateFormulaProperties = new List<ResourcePropertiesModel>();
        private static List<ResourcePropertiesModel> getRandomNumberFormulaProperties = new List<ResourcePropertiesModel>();
        private static List<ResourcePropertiesModel> getRandomCharsFormulaProperties = new List<ResourcePropertiesModel>();

        private static readonly String FILE_DESIGNER_FILTER_NAME = "FILE_DESIGNER_FILTER_NAME";
        private static readonly String FILE_BATCH_ONE_CLICK_FILTER_NAME = "FILE_BATCH_ONE_CLICK_FILTER_NAME";
        private static readonly String FILE_DESIGNER_EXTENSION_NAME = "FILE_DESIGNER_EXTENSION_NAME";
        private static readonly String FILE_BATCH_ONE_CLICK_EXTENSION_NAME = "FILE_BATCH_ONE_CLICK_EXTENSION_NAME";


        static ResourcesUtil()
        {
            RESOURCE_MANAGER = new ResourceManager(RESOURCE_NAME, typeof(ResourcesUtil).Assembly);
        }
        private static string getSetting(String settingName)
        {
            return RESOURCE_MANAGER.GetString(settingName);
        }

        public static List<ResourcePropertiesModel> GetDateFormulaProperties()
        {
            if (getDateFormulaProperties.Count <= 0) 
                getDateFormulaProperties = GetFormulaConfigProperties(RESOURCE_PROPERTY_NAME_DATE);
            return getDateFormulaProperties.ToList<ResourcePropertiesModel>();
        }

        public static List<ResourcePropertiesModel> GetRandomNumberFormulaProperties()
        {
            if (getRandomNumberFormulaProperties.Count <= 0)
                getRandomNumberFormulaProperties = GetFormulaConfigProperties(RESOURCE_PROPERTY_NAME_RANDOM_GEN);
            return getRandomNumberFormulaProperties.ToList<ResourcePropertiesModel>();
        }

        public static List<ResourcePropertiesModel> GetRandomCharsFormulaProperties()
        {
            if (getRandomCharsFormulaProperties.Count <= 0)
                getRandomCharsFormulaProperties = GetFormulaConfigProperties(RESOURCE_PROPERTY_NAME_RANDOM_CHARS);
            return getRandomCharsFormulaProperties.ToList<ResourcePropertiesModel>();
        }

        private static List<ResourcePropertiesModel> GetFormulaConfigProperties(String configPropertyName)
        {
            List<String> propertyList = GetResourcePropertiesModel().FindAll(
                                            delegate (String configValue)
                                            {
                                                return (configValue.StartsWith(configPropertyName));
                                            }).ToList<String>();
            return ConvertToResourcePropertiesModelList(propertyList);
        }

        private static List<ResourcePropertiesModel> ConvertToResourcePropertiesModelList(List<String> propertyList)
        {
            List<ResourcePropertiesModel> rpmResults = new List<ResourcePropertiesModel>();
            foreach (String value in propertyList)
            {
                String[] configValue = value.Split(Char.Parse("\t"));
                ResourcePropertiesModel rpm = new ResourcePropertiesModel
                {
                    UniquePropertyId = configValue[0],
                    PropertyValue = configValue[1],
                    Description = configValue[2]
                };
                rpmResults.Add(rpm);
            }
            return rpmResults;
        }

        private static List<String> GetResourcePropertiesModel()
        {
            String fileObject = Encoding.UTF8.GetString((Byte[])RESOURCE_MANAGER.GetObject(RESOURCE_PROPERTY_FILE_NAME));
            return fileObject.Split(Char.Parse("\n")).ToList<string>();
        }

        public static String GetFileDesignerFilterName()
        {
            return getSetting(FILE_DESIGNER_FILTER_NAME);
        }
        public static String GetFileBatchFilterName()
        {
            return getSetting(FILE_BATCH_ONE_CLICK_FILTER_NAME);
        }
        public static String GetFileDesignerExtensionName()
        {
            return getSetting(FILE_DESIGNER_EXTENSION_NAME);
        }
        public static String GetFileBatchExtensionName()
        {
            return getSetting(FILE_BATCH_ONE_CLICK_EXTENSION_NAME);
        }

        public void Dispose()
        {
            RESOURCE_MANAGER = null;
        }
    }
}
