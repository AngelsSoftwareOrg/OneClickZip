using ExpTreeLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneClickZip.Includes.Models
{
    public class TreeNodeExtended : TreeNode
    {
        private readonly ArrayList masterListFilesDir = new ArrayList();

        public TreeNodeExtended() : base(){}

        public void AddItem(CShItem cshItem)
        {
            this.masterListFilesDir.Add(cshItem);
        }

        public void ClearItem()
        {
            this.masterListFilesDir.Clear();
        }

        public void RemoveItem(CShItem cshItem)
        {
            this.masterListFilesDir.Remove(cshItem);
        }

        public void RemoveItemByNodeName(String nodeName)
        {
            List<CShItem> listForRemoval = new List<CShItem>();
            foreach (CShItem cshItem in this.masterListFilesDir)
            {

                Console.WriteLine(cshItem.Text);

                if (cshItem.Name == nodeName || cshItem.Text == nodeName)
                {
                    listForRemoval.Add(cshItem);
                }
            }

            foreach (CShItem cshItem in listForRemoval)
            {
                this.masterListFilesDir. Remove(cshItem);
            }
        }

        public void removeSubNode(String nodeName)
        {
            foreach (CShItem cshItem in this.masterListFilesDir)
            {
                ArrayList combinationList = new ArrayList();
                combinationList.AddRange(cshItem.Directories);
                combinationList.AddRange(cshItem.Files);

                List<CShItem> listForRemoval = new List<CShItem>();
                foreach (CShItem cshSubItem in combinationList)
                {
                    
                }
            }
        }



        public ArrayList MasterListFilesDir => this.masterListFilesDir;

    }
}
