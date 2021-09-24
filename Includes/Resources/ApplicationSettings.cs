using System;
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
        public static String ApplicationVersionDisplay
        {
            get
            {
                return String.Format("v{0}.{1}.{2} {3}",
                            Properties.Settings.Default.app_version_major,
                            Properties.Settings.Default.app_version_minor,
                            Properties.Settings.Default.app_version_patch,
                            Properties.Settings.Default.app_version_revision);
            }
        }
        public static String[] ApplicationVersionSplitted
        {
            get
            {
                return String.Format("{0}.{1}.{2}.{3}",
                            Properties.Settings.Default.app_version_major,
                            Properties.Settings.Default.app_version_minor,
                            Properties.Settings.Default.app_version_patch,
                            Properties.Settings.Default.app_version_revision).Split(Char.Parse("."));
            }
        }
        public static String ApplicationVersion
        {
            get
            {
                return String.Format("{0}.{1}.{2}.{3}",
                            Properties.Settings.Default.app_version_major,
                            Properties.Settings.Default.app_version_minor,
                            Properties.Settings.Default.app_version_patch,
                            Properties.Settings.Default.app_version_revision);
            }
        }
        public static String ApplicationWebsiteLink
        {
            get
            {
                return String.Format(Properties.Settings.Default.about_website_link,
                    ApplicationOrganizationName,
                    ApplicationName);
            }
        }
        public static String ApplicationOrganizationName
        {
            get
            {
                return Properties.Settings.Default.app_organization;
            }
        }
        public static String ApplicationName
        {
            get
            {
                return Properties.Settings.Default.app_name;
            }
        }
    }
}
