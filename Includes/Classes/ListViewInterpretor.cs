using System;
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
            if (lvParamModel.CshItem.DisplayName.Equals(CShItem.strMyComputer))
            {
                lvParamModel.DirList = lvParamModel.CshItem.GetDirectories();
            }
            else
            {
                lvParamModel.DirList = lvParamModel.CshItem.GetDirectories();
                lvParamModel.FileList = lvParamModel.CshItem.GetFiles();
            }
            GenerateListViewCommonProcedureForExplorer(lvParamModel);
        }

        public static void GenerateListViewZipFileViewItems(ListViewInterpretorViewingParamModel lvParamModel) 
        {
            if (lvParamModel.CustomFileItem.IsFolder)
            {
                lvParamModel.DirList.Add(lvParamModel.CustomFileItem);
            }
            else
            {
                lvParamModel.FileList.Add(lvParamModel.CustomFileItem);
            }

            GenerateListViewCommonProcedureForDesigner(lvParamModel);
        }

        public static void GenerateListViewZipFileChildrenViewItems(ListViewInterpretorViewingParamModel lvParamModel)
        {
            TreeNodeExtended selectedNode = lvParamModel.SelectedTreeNodeExtended;

            List<String> subNodeName = new List<String>();
            foreach(TreeNodeExtended subNode in selectedNode.Nodes)
            {
                subNodeName.Add(subNode.Text);
            }
            lvParamModel.DirList = lvParamModel.CustomFileItem.GetShellInfoDirectories();
            lvParamModel.FileList = lvParamModel.CustomFileItem.GetShellInfoFiles();
            GenerateListViewCommonProcedureForDesigner(lvParamModel);
        }

        private static void GenerateListViewCommonProcedureForDesigner(ListViewInterpretorViewingParamModel lvParamModel)
        {
            ArrayList dirList = lvParamModel.DirList;
            ArrayList fileList = lvParamModel.FileList;
            ListviewExtended targetListView = lvParamModel.TargetListView;
            targetListView.ReferenceTreeNode = lvParamModel.SelectedTreeNodeExtended;

            try
            {
                if ((dirList.Count + fileList.Count) > 0)
                {
                    dirList.Sort();
                    fileList.Sort();

                    ArrayList combinationList = new ArrayList();
                    combinationList.AddRange(dirList);
                    combinationList.AddRange(fileList);

                    foreach (CustomFileItem fileObj in combinationList)
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

                        if (lvParamModel.SelectedTreeNodeExtended != null)
                        {
                            lvItem.ReferenceTreeNode = lvParamModel.SelectedTreeNodeExtended;
                        }

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

        private static void GenerateListViewCommonProcedureForExplorer(ListViewInterpretorViewingParamModel lvParamModel)
        {
            ArrayList dirList = lvParamModel.DirList;
            ArrayList fileList = lvParamModel.FileList;
            ListviewExtended targetListView = lvParamModel.TargetListView;

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
                        if(!FileSystemUtilities.IsSpecialFolder(fileObj.Path, fileObj.DisplayName)){
                            ListViewItemExtended lvItem = new ListViewItemExtended(fileObj, new string[] {
                                            fileObj.DisplayName, //file name
                                            fileObj.LastWriteTime.ToString(), //date modified
                                            (fileObj.IsFolder) ? "" : ConverterUtils.HumanReadableFileSize(fileObj.Length, 2), //file size
                                            fileObj.CreationTime.ToString(), // created date time
                                            fileObj.TypeName //file type
                                        });
                            lvItem.ImageIndex = fileObj.IconIndexNormal;
                            targetListView.Items.Add(lvItem);
                        }
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

        private static String[] GetFileObjectDetails(CustomFileItem fileObj)
        {
            return new string[] {
                fileObj.GetCustomFileName, //file name
                fileObj.LastWriteTime.ToString(), //date modified
                (fileObj.IsFolder) ? "" : ConverterUtils.HumanReadableFileSize(fileObj.FileLength, 2), //file size
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

        public static void RefreshToShowZipDesignerIcons(ListView targetListView)
        {
            targetListView.SmallImageList = DefaultIcons.SYSTEM_ICONS.SmallIconsImageList;
            targetListView.LargeImageList = DefaultIcons.SYSTEM_ICONS.LargeIconsImageList;
        }

        public static void RefreshListViewItemsForZipFileDesigner(ListviewExtended targetListView,  TreeNodeExtended selectedTreeNodeExtended)
        {
            targetListView.BeginUpdate();
            targetListView.Items.Clear();
            foreach (CustomFileItem customeFileItem in selectedTreeNodeExtended.MasterListFilesDir)
            {
                ListViewInterpretorViewingParamModel commonParam = new ListViewInterpretorViewingParamModel()
                {
                    SelectedTreeNodeExtended = selectedTreeNodeExtended,
                    TargetListView = targetListView,
                    CustomFileItem = customeFileItem
                };

                ListViewInterpretor.GenerateListViewZipFileViewItems(commonParam);
            }
            targetListView.EndUpdate();
        }

    }

}