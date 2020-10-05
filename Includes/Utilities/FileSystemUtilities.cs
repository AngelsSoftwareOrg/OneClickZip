using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Utilities
{
    public class FileSystemUtilities
    {
        public static bool IsFullPathIsDirectory(String fullPath)
        {
            DirectoryInfo dInfo = new DirectoryInfo(fullPath);
            if ((dInfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                return true;
            }
            return false;
        }
        public static DirectoryInfo[] GetDirectories(String pathName)
        {
            DirectoryInfo[] result = null;
            DirectoryInfo dInfo = new DirectoryInfo(pathName);
            if ((File.GetAttributes(pathName) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
            {
                try
                {
                    result = dInfo.GetDirectories();
                }
                catch (UnauthorizedAccessException) { }
            }
            return result;
        }

        public static String GetDefaultDirectory()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }
}
