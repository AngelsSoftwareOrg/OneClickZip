using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneClickZip.Includes.Classes;
using OneClickZip.Includes.Utilities;

namespace OneClickZip.Includes.Resources
{
    public class ApplicationSettings
    {
        public static String GetLastOpenedDirectory()
        {
            String dir = Properties.Settings.Default.LAST_OPENED_DIRECTORY;
            if (dir == null) return FileSystemUtilities.GetDefaultDirectory();
            if (dir.Trim() == "") return FileSystemUtilities.GetDefaultDirectory();

            if (FileSystemUtilities.IsFullPathIsDirectory(dir.Trim()))
            {
                return dir.Trim();
            }
            else
            {
                return FileSystemUtilities.GetDefaultDirectory();
            }
        }
        public static void SaveLastOpenedDirectory(String lastOpenedPath)
        {
            Properties.Settings.Default.LAST_OPENED_DIRECTORY = lastOpenedPath;
            Properties.Settings.Default.Save();
        }
    }
}
