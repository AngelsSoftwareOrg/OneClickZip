using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OneClickZip.Includes.Resources;

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
        public static bool IsDirectoryExistInTheSystem(String fullPathDir)
        {
            DirectoryInfo dInfo = new DirectoryInfo(fullPathDir);
            if ((dInfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                return dInfo.Exists;
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
    }
}
