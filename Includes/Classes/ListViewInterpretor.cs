using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using ExpTreeLib;
using OneClickZip;
using OneClickZip.Includes.Classes.Extensions;
using OneClickZip.Includes.Utilities;

namespace OneClickZip.Includes.Classes
{
    public class ListViewInterpretor
    {
        public static void generateListViewExplorerItems(ListView targetListView, CShItem cshItem)
        {
            ArrayList dirList = new ArrayList();
            ArrayList fileList = new ArrayList();
            if (cshItem.DisplayName.Equals(CShItem.strMyComputer))
            {
                dirList = cshItem.GetDirectories();
            }
            else
            {
                dirList = cshItem.GetDirectories();
                fileList = cshItem.GetFiles();
            }
            generateListViewCommonProcedure(targetListView, cshItem, dirList, fileList);
        }

        public static void generateListViewZipFileViewItems(ListView targetListView, CShItem cshItem)
        {
            ArrayList dirList = new ArrayList();
            ArrayList fileList = new ArrayList();

            if (cshItem.IsFolder)
            {
                dirList.Add(cshItem);
            }
            else
            {
                fileList.Add(cshItem);
            }

            generateListViewCommonProcedure(targetListView, cshItem, dirList, fileList);
        }

        public static void generateListViewZipFileChildrenViewItems(ListView targetListView, CShItem cshItem)
        {
            ArrayList dirList = new ArrayList();
            ArrayList fileList = new ArrayList();

            dirList = cshItem.GetDirectories();
            fileList = cshItem.GetFiles();

            generateListViewCommonProcedure(targetListView, cshItem, dirList, fileList);
        }

        private static void generateListViewCommonProcedure(ListView targetListView, CShItem cshItem, ArrayList dirList, ArrayList fileList)
        {
            try
            {
                if ((dirList.Count + fileList.Count) > 0)
                {
                    dirList.Sort();
                    fileList.Sort();

                    //targetListView.BeginUpdate();

                    ArrayList combinationList = new ArrayList();
                    combinationList.AddRange(dirList);
                    combinationList.AddRange(fileList);

                    foreach (CShItem fileObj in combinationList)
                    {
                        ListViewItemExtended lvItem=null;
                        if (targetListView.View == View.Details)
                        {
                            lvItem = new ListViewItemExtended(fileObj, getFileObjectDetails(fileObj));
                        }
                        else
                        {
                            lvItem = new ListViewItemExtended(fileObj);
                        }

                        lvItem.ImageIndex = SystemImageListManager.GetIconIndex(fileObj, false);
                        targetListView.Items.Add(lvItem);
                    }
                    //targetListView.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                dirList.Clear();
                fileList.Clear();
            }
        }

        private static String[] getFileObjectDetails(CShItem fileObj)
        {
            //DirectoryInfo di = new DirectoryInfo(fileObj.Path);
            //FileInfo fi = new FileInfo(fileObj.Path);

            return new string[] {
                fileObj.DisplayName, //file name
                fileObj.LastWriteTime.ToString(), //date modified
                (fileObj.IsFolder) ? "" : ConverterUtils.humanReadableFileSize(fileObj.Length, 2), //file size
                fileObj.CreationTime.ToString(), // created date time
                fileObj.TypeName //file type
            };
        }

        /**
         * encapsulated procedures to make icons appeared on the list view
         */
        public static void refreshToShowExplorerIcons(ListView targetListView)
        {
            SystemImageListManager.SetListViewImageList(targetListView, false, false);
            SystemImageListManager.SetListViewImageList(targetListView, true, false);
        }

    }

}