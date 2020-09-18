using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneClickZip.Includes.Resources;

namespace OneClickZip.Includes.Interface
{
    interface ICreatorExecutor
    {
        String Generate(string formulaValue);
        List<ResourcePropertiesModel> GetResourcePropertiesList(bool includeHeader);
    }
}
