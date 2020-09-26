using OneClickZip.Includes.Classes.Extensions;
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
        private static ZipFileModel zipFileModelCurrentlyWorkingTo = new ZipFileModel();

        public static ZipFileModel ZipFileModel
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

        public static ZipFileModel OpenProjectSession(String fileFullPath)
        {
            ZipFileModel = FileSerialization.LoadObjectToFile<ZipFileModel>(Serialization.BinarySerialization, fileFullPath);
            return ZipFileModel;
        }

        public static TreeNodeExtended GetTreeNodeZipDesignOnProjectFile(String fileFullPath)
        {
            ZipFileModel zipFileModel = ProjectSession.OpenProjectSession(fileFullPath);
            TreeNodeExtended treeNodeExtended = zipFileModel.GetTreeViewZipFileStructure();
            return treeNodeExtended;
        }

        public static void SaveProject(String fullFilePath)
        {
            FileSerialization.SaveObjectToFile(Serialization.BinarySerialization, fullFilePath, ZipFileModel);
        }

        public static void SaveCurrentLoadedProject()
        {
            FileSerialization.SaveObjectToFile(Serialization.BinarySerialization, ZipFileModel.FilePath, ZipFileModel);
        }

        public static void UpdateZipDesignerModelStructure(TreeNodeExtended rootNode)
        {
            ZipFileModel.SetTreeViewZipFileStructureForFileWriting(rootNode);
        }
    
        public static bool IsSessionWasACurrentlyLoadedProject()
        {
            if (ProjectSession.ZipFileModel == null) return false;
            if (ZipFileModel.FilePath == null) return false;
            if (ProjectSession.ZipFileModel.FilePath.Length <= 0) return false;
            return true;
        }
    
        public static void ClearProjectSession()
        {
            ZipFileModel = new ZipFileModel();
        }
    
        public static void UpdateFileCreatorNameModel(FileNameCreator fileNameCreator)
        {
            ZipFileModel.FileNameCreator = fileNameCreator;
        }

        public static FileNameCreator FileNameCreatorModel => ZipFileModel.FileNameCreator;

    }
}
