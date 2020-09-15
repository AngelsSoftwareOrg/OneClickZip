using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Resources
{
    class ResourcesUtil : ResourceFilter
    {
        private static ResourceManager RESOURCE_MANAGER;
        private static String RESOURCE_NAME = "OneClickZip.Resources";
        private static String RESOURCE_PROPERTY_FILE_NAME = "CREATOR_DETAILS"; //CREATOR_DETAILS.properties

        static ResourcesUtil()
        {
            RESOURCE_MANAGER = new ResourceManager(RESOURCE_NAME, Assembly.GetExecutingAssembly());
        }


        public static void getDateFormulaProperties()
        {
            
        }
    }
}
