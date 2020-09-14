using System;
using System.Collections;
using System.Windows.Forms;
using ExpTreeLib;
using OneClickZip;

public class ListViewInterpretor
{
    public static void generateListViewExplorerItems(ListView targetListView, CShItem cshItem)
    {
        ArrayList dirList = new ArrayList();
        ArrayList fileList = new ArrayList();

        try
        {
            if (cshItem.DisplayName.Equals(CShItem.strMyComputer))
            {
                dirList = cshItem.GetDirectories();
            }
            else
            {
                dirList = cshItem.GetDirectories();
                fileList = cshItem.GetFiles();
            }

            if((dirList.Count + fileList.Count) > 0)
            {
                dirList.Sort();
                fileList.Sort();

                targetListView.BeginUpdate();

                ArrayList combinationList = new ArrayList();
                combinationList.AddRange(dirList);
                combinationList.AddRange(fileList);

                foreach (CShItem fileObj in combinationList)
                {
                    ListViewItemExtended lvItem = new ListViewItemExtended(fileObj.GetFileName());
                    lvItem.ImageIndex = SystemImageListManager.GetIconIndex(fileObj, false);
                    //lvItem.Tag = fileObj;
                    lvItem.CshItem = fileObj;
                    targetListView.Items.Add(lvItem);
                }
                targetListView.EndUpdate();
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

    /**
     * encapsulated procedures to make icons appeared on the list view
     */
    public static void refreshToShowExplorerIcons(ListView targetListView)
    {
        SystemImageListManager.SetListViewImageList(targetListView, false, false);
        SystemImageListManager.SetListViewImageList(targetListView, true, false);
    }

}
