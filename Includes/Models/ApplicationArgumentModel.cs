using OneClickZip.Includes.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Models
{
    public class ApplicationArgumentModel
    {
        private List<String> listArguments = new List<String>();
        private String filePath;
        private String fileExtension;
        private readonly String FILE_EXTENSION_FOR_PROJECT_DESIGNER = ResourcesUtil.GetFileDesignerExtensionName().Trim().ToUpper();
        private readonly String FILE_EXTENSION_FOR_PROJECT_BATCH_FILE = ResourcesUtil.GetFileBatchExtensionName().Trim().ToUpper();
        private StringBuilder allArguments;

        public ApplicationArgumentModel(String[] applicationRunArgs)
        {
            allArguments = new StringBuilder();
            if (applicationRunArgs == null) return;
            if (applicationRunArgs.Length <= 0) return;
            listArguments.AddRange(applicationRunArgs.ToArray<String>());
            
            foreach (String args in applicationRunArgs)
            {
                allArguments.AppendLine(args);
            }
            
            this.filePath = applicationRunArgs[0];
            SetFileDetails();
        }

        private void SetFileDetails()
        {
            FileInfo fInfo = new FileInfo(this.filePath);
            this.fileExtension = fInfo.Extension.Trim().ToUpper();
        }

        public String FilePath => this.filePath;
        
        public String FileExtension => this.fileExtension;

        public bool IsOpenProjectDesignerFile
        {
            get
            {
                if (FileExtension == null) return false;
                return FileExtension.Contains(FILE_EXTENSION_FOR_PROJECT_DESIGNER);
            }
        }

        public bool IsOpenProjectBatchFile
        {
            get
            {
                if (FileExtension == null) return false;
                return FileExtension.Contains(FILE_EXTENSION_FOR_PROJECT_BATCH_FILE);
            }
        }

        public String GetAllArgs => this.allArguments.ToString();

    }
}
