﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ExpTreeLib;
using OneClickZip;
using OneClickZip.Includes.Classes.Extensions;
using OneClickZip.Includes.Models;
using OneClickZip.Includes.Utilities;

namespace OneClickZip.Includes.Classes
{
    public class ListViewInterpretor
    {
        public static void GenerateListViewExplorerItems(ListViewInterpretorViewingParamModel lvParamModel)
        {
            ArrayList dirList = new ArrayList();
            ArrayList fileList = new ArrayList();
            CShItem cshItem = lvParamModel.CshItem;
            if (cshItem.DisplayName.Equals(CShItem.strMyComputer))
            {
                lvParamModel.DirList = lvParamModel.CshItem.GetDirectories();
            }
            else
            {
                lvParamModel.DirList = lvParamModel.CshItem.GetDirectories();
                lvParamModel.FileList = lvParamModel.CshItem.GetFiles();
            }
            GenerateListViewCommonProcedure(lvParamModel);
        }

        public static void GenerateListViewZipFileViewItems(ListViewInterpretorViewingParamModel lvParamModel) 
        {
            if (lvParamModel.CshItem.IsFolder)
            {
                lvParamModel.DirList.Add(lvParamModel.CshItem);
            }
            else
            {
                lvParamModel.FileList.Add(lvParamModel.CshItem);
            }

            GenerateListViewCommonProcedure(lvParamModel);
        }

        public static void GenerateListViewZipFileChildrenViewItems(ListViewInterpretorViewingParamModel lvParamModel)
        {
            TreeNodeExtended selectedNode = lvParamModel.SelectedTreeNodeExtended;

            List<String> subNodeName = new List<String>();
            foreach(TreeNodeExtended subNode in selectedNode.Nodes)
            {
                subNodeName.Add(subNode.Text);
            }
            lvParamModel.DirList = lvParamModel.CshItem.GetDirectories();
            lvParamModel.FileList = lvParamModel.CshItem.GetFiles();
            GenerateListViewCommonProcedure(lvParamModel);
        }

        private static void GenerateListViewCommonProcedure(ListViewInterpretorViewingParamModel lvParamModel)
        {
            ArrayList dirList = lvParamModel.DirList;
            ArrayList fileList = lvParamModel.FileList;
            ListView targetListView = lvParamModel.TargetListView;

            try
            {
                if ((dirList.Count + fileList.Count) > 0)
                {
                    dirList.Sort();
                    fileList.Sort();

                    ArrayList combinationList = new ArrayList();
                    combinationList.AddRange(dirList);
                    combinationList.AddRange(fileList);

                    foreach (CShItem fileObj in combinationList)
                    {
                        ListViewItemExtended lvItem=null;
                        if (targetListView.View == View.Details)
                        {
                            lvItem = new ListViewItemExtended(fileObj, GetFileObjectDetails(fileObj));
                        }
                        else
                        {
                            lvItem = new ListViewItemExtended(fileObj);
                        }

                        lvItem.ImageIndex = SystemImageListManager.GetIconIndex(fileObj, false);
                        targetListView.Items.Add(lvItem);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dirList.Clear();
                fileList.Clear();
            }
        }

        private static String[] GetFileObjectDetails(CShItem fileObj)
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
        public static void RefreshToShowExplorerIcons(ListView targetListView)
        {
            SystemImageListManager.SetListViewImageList(targetListView, false, false);
            SystemImageListManager.SetListViewImageList(targetListView, true, false);
        }

        public static void RefreshListViewItemsForZipFileDesigner(ListView targetListView,  TreeNodeExtended selectedTreeNodeExtended)
        {
            targetListView.BeginUpdate();
            targetListView.Items.Clear();
            //bool isRootNode = TreeNodeInterpreter.IsSelectedZipModelNodeRoot(selectedTreeNodeExtended.TreeView);
            foreach (CShItem cshItem in selectedTreeNodeExtended.MasterListFilesDir)
            {
                ListViewInterpretorViewingParamModel commonParam = new ListViewInterpretorViewingParamModel()
                {
                    SelectedTreeNodeExtended = selectedTreeNodeExtended,
                    TargetListView = targetListView,
                    CshItem = cshItem
                };

                ListViewInterpretor.GenerateListViewZipFileViewItems(commonParam);
            }
            targetListView.EndUpdate();
        }

    }

}