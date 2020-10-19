using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using OneClickZip.Includes.Resources;

namespace OneClickZip.Includes.Utilities
{
    public class FileSystemUtilities
    {
        private static List<String> SPECIAL_FOLDERS;
        private static readonly String SPECIAL_FOLDER_PATTERN = @".*?\{.*?\}";
        private static List<KeyValuePair<String, Environment.SpecialFolder>> SPECIAL_FOLDERS_MANUAL_MATCHMAKING;



        static FileSystemUtilities() {
            SPECIAL_FOLDERS = new List<string>();
            SPECIAL_FOLDERS_MANUAL_MATCHMAKING = new List<KeyValuePair<string, Environment.SpecialFolder>>();
            SPECIAL_FOLDERS.AddRange(ClassReflectionUtilities.GetEnumerableOptions(typeof(Environment.SpecialFolder)));
            SPECIAL_FOLDERS_MANUAL_MATCHMAKING.Add(new KeyValuePair<string, Environment.SpecialFolder>("This PC", Environment.SpecialFolder.MyComputer));
        }

        public static bool IsFullPathIsDirectory(String fullPath)
        {
            try
            {
                DirectoryInfo dInfo = new DirectoryInfo(fullPath);
                if ((dInfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    return true;
                }
            }
            catch (Exception )
            {
                return false;
            }
            return false;
        }
        public static bool IsDirectoryExistInTheSystem(String fullPathDir)
        {
            try
            {
                DirectoryInfo dInfo = new DirectoryInfo(fullPathDir);
                if ((dInfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    return dInfo.Exists;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
        public static bool IsDirectoryAttribute(DirectoryInfo dirInfo)
        {
            if ((dirInfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                return true;
            }
            return false;
        }
        public static DirectoryInfo[] GetDirectories(String pathName)
        {
            DirectoryInfo[] result = null;
            DirectoryInfo dInfo = new DirectoryInfo(pathName);
            if (!dInfo.Exists) return result;
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
        public static FileInfo[] GetFiles(String pathName)
        {
            DirectoryInfo dInfo = new DirectoryInfo(pathName);
            FileInfo[] result=null;
            if (!dInfo.Exists) return result;
            try
            {
                if(FileSystemUtilities.IsDirectoryAttribute(dInfo)) result = dInfo.GetFiles();
            }
            catch (UnauthorizedAccessException) { }
            return result;
        }
        public static String GetDefaultDirectory()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
        public static void SaveListViewItemsToLogFile(ListView targetListview)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = ResourcesUtil.GetFileLogFilterName();
            saveFileDialog.Title = "Save a log file";
            DialogResult dr = saveFileDialog.ShowDialog();

            if (dr == DialogResult.OK)
            {
                using (StreamWriter file = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (ListViewItem lvItem in targetListview.Items)
                    {
                        foreach (ListViewItem.ListViewSubItem si in lvItem.SubItems)
                        {
                            file.Write(si.Text + "\t");
                        }
                        file.WriteLine();
                    }
                }
                MessageBox.Show("Log file has been successfully save...", "File saving...");
            }
        }
        public static bool IsSpecialFolder(String fullPath, String fileName)
        {
            fileName = fileName.Replace(" ", "");
            MatchCollection matchValueCol = Regex.Matches(fullPath, SPECIAL_FOLDER_PATTERN);
            bool isPatternMatch = matchValueCol.Count > 0;
            bool isNameOnSpecialFolderList = false;//SPECIAL_FOLDERS.Contains(fileName.Replace(" ", ""), StringComparer.OrdinalIgnoreCase);

            //foreach (KeyValuePair<string, Environment.SpecialFolder> kvp in SPECIAL_FOLDERS_MANUAL_MATCHMAKING)
            //{
            //    if(kvp.Key.Replace(" ", "").Equals(fileName, StringComparison.OrdinalIgnoreCase)){
            //        isNameOnSpecialFolderList = true;
            //        break;
            //    }
            //}

            //debug
            //Console.WriteLine(String.Format("IsSpecialFolder: {0} / {1} / {2}", (isPatternMatch || isNameOnSpecialFolderList), fileName, fullPath));

            return isPatternMatch || isNameOnSpecialFolderList;
        }
    
        public static String GetSpecialFolderFullPath(String fileName)
        {
            fileName = fileName.Replace(" ", "").Trim();
            Enum targetEnum = ClassReflectionUtilities.GetEnumerableTypeByDescription(typeof(Environment.SpecialFolder), fileName);

            if (targetEnum == null)
            {
                foreach (KeyValuePair<string, Environment.SpecialFolder> kvp in SPECIAL_FOLDERS_MANUAL_MATCHMAKING)
                {
                    if (kvp.Key.Replace(" ", "").Equals(fileName, StringComparison.OrdinalIgnoreCase))
                    {
                        targetEnum = kvp.Value;
                        break;
                    }
                }
            }
            if (targetEnum == null) return null;

            return System.Environment.GetFolderPath((Environment.SpecialFolder) targetEnum);
        }
    
    }
}
