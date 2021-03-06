﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneClickZip.Includes.Interface;
using OneClickZip.Includes.Models;
using OneClickZip.Includes.Resources;

namespace OneClickZip.Includes.Classes
{
    [Serializable]
    public class FileNameCreator: ICloneable
    {
        private String fileFormulaName;
        private List<ICreatorExecutor> formulaDerivatorGenerator = new List<ICreatorExecutor>
        {
            new DateCreatorModel(),
            new RandomNumberGeneratorModel(),
            new RandomCharsGeneratorModel()
        };
        public FileNameCreator()
        {
        }
        public FileNameCreator(String fileFormulaName)
        {
            this.FileFormulaName = fileFormulaName;
        }
        public String GetDerivedFormula()
        {
            String result = this.FileFormulaName;
            if (result == null) return "";
            if (result.Trim().Length<=0) return "";

            foreach (ICreatorExecutor iec in formulaDerivatorGenerator)
            {
                result = iec.Generate(result);
            }
            return result.Trim();
        }
        public List<ResourcePropertiesModel> GetResourcePropertiesList(bool includeHeader = false)
        {
            List<ResourcePropertiesModel> resource = new List<ResourcePropertiesModel>();

            foreach (ICreatorExecutor iec in formulaDerivatorGenerator)
            {
                resource.AddRange(iec.GetResourcePropertiesList(includeHeader));
            }
            return resource;
        }
        public string FileFormulaName { get => fileFormulaName; set => fileFormulaName = value; }
        public object Clone()
        {
            FileNameCreator fnc = new FileNameCreator();
            fnc.FileFormulaName = String.Copy(this.FileFormulaName);
            return fnc;
        }
    }
}
