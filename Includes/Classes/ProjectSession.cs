using OneClickZip.Includes.Classes.Extensions;
using OneClickZip.Includes.Classes.TreeNodeSerialize;
using OneClickZip.Includes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static OneClickZip.Includes.Classes.FileSerialization;

namespace OneClickZip.Includes.Classes
{
    public class ProjectSession
    {
        private ZipFileModel zipFileModelCurrentlyWorkingTo = new ZipFileModel();
        private static ProjectSession projectSession;
        private static ApplicationArgumentModel applicationArgumentModel;

        public static ProjectSession Instance()
        {
            if (projectSession == null) projectSession = new ProjectSession();
            return projectSession;
        }

        public ZipFileModel ZipFileModel
        {
            get
            {
                return zipFileModelCurrentlyWorkingTo;
            }
            set
            {
                zipFileModelCurrentlyWorkingTo = value;
            }
        }

        public ZipFileModel OpenProjectSession(String fileFullPath)
        {
            ZipFileModel = FileSerialization.LoadObjectToFile<ZipFileModel>(Serialization.BinarySerialization, fileFullPath);
            return ZipFileModel;
        }

        public TreeNodeExtended GetTreeNodeZipDesignOnProjectFile(String fileFullPath)
        {
            ZipFileModel zipFileModel = OpenProjectSession(fileFullPath);
            return zipFileModel.GetTreeViewZipFileStructure();
        }
        
        public SerializableTreeNode GetSerializableTreeNodeBaseOnProjectFile(String fileFullPath)
        {
            ZipFileModel zipFileModel = OpenProjectSession(fileFullPath);
            return zipFileModel.GetTreeViewZipFileSerializedStructure;
        }
        
        public SerializableTreeNode GetSerializableTreeNodeBaseOnZipModel()
        {
            return ZipFileModel.GetTreeViewZipFileSerializedStructure;
        }

        public void SaveProject(String fullFilePath)
        {
            FileSerialization.SaveObjectToFile(Serialization.BinarySerialization, fullFilePath, ZipFileModel);
        }

        public void SaveCurrentLoadedProject()
        {
            FileSerialization.SaveObjectToFile(Serialization.BinarySerialization, ZipFileModel.FilePath, ZipFileModel);
        }

        public void UpdateZipDesignerModelStructure(TreeNodeExtended rootNode)
        {
            ZipFileModel.SetTreeViewZipFileStructureForFileWriting(rootNode);
        }
    
        public bool IsSessionWasACurrentlyLoadedProject()
        {
            if (ZipFileModel == null) return false;
            if (ZipFileModel.FilePath == null) return false;
            if (ZipFileModel.FilePath.Length <= 0) return false;
            return true;
        }
    
        public void ClearProjectSession()
        {
            ZipFileModel = new ZipFileModel();
            ApplicationArgumentModel = new ApplicationArgumentModel(new string[] { });
        }
    
        public void UpdateFileCreatorNameModel(FileNameCreator fileNameCreator)
        {
            ZipFileModel.FileNameCreator = fileNameCreator;
        }

        public FileNameCreator FileNameCreatorModel => ZipFileModel.FileNameCreator;

        public ApplicationArgumentModel ApplicationArgumentModel { get => applicationArgumentModel; set => applicationArgumentModel = value; }
    }
}
