using OneClickZip.Includes.Interface;
using OneClickZip.Includes.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Models
{
    class DateCreatorModel : CreatorModel, ICreatorExecutor
    {
        private List<ResourcePropertiesModel> dateGenerator = ResourcesUtil.GetDateFormulaProperties();

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
            throw new NotImplementedException();
        }
    }
}

