using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Resources
{
    [Serializable]
    public class ResourcePropertiesModel
    {
        private String uniquePropertyId;
        private String propertyValue;
        private String description;
        public string UniquePropertyId { get => uniquePropertyId; set => uniquePropertyId = value; }
        public string PropertyValue { get => propertyValue; set => propertyValue = value; }
        public string Description { get => description; set => description = value; }
    }
}
