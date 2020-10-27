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
            String dir = LastOpenedDirectory;
            if (String.IsNullOrWhiteSpace(dir)) return FileSystemUtilities.GetDefaultDirectory();

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
            LastOpenedDirectory = lastOpenedPath;
            Properties.Settings.Default.Save();
        }

        private static String LastOpenedDirectory
        {
            get{
                return Properties.Settings.Default.LAST_OPENED_DIRECTORY;
            }
            set
            {
                Properties.Settings.Default["LAST_OPENED_DIRECTORY"] = (string)value;
            }
        }

    }
}
