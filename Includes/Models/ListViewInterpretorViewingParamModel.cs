using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpTreeLib;

namespace OneClickZip.Includes.Models
{
    public class ListViewInterpretorViewingParamModel
    {
        private TreeNodeExtended selectedTreeNodeExtended;
        private ListView targetListView;
        private CShItem cshItem;
        private ArrayList dirList;
        private ArrayList fileList;
        private bool isEnlistAllDirAndFiles;

        public ListViewInterpretorViewingParamModel()
        {
            this.dirList = new ArrayList();
            this.fileList = new ArrayList();
            this.isEnlistAllDirAndFiles = false;
        }

        public TreeNodeExtended SelectedTreeNodeExtended { get => selectedTreeNodeExtended; set => selectedTreeNodeExtended = value; }
        public ListView TargetListView { get => targetListView; set => targetListView = value; }
        public CShItem CshItem { get => cshItem; set => cshItem = value; }
        public ArrayList DirList { get => dirList; set => dirList = value; }
        public ArrayList FileList { get => fileList; set => fileList = value; }
        public bool IsEnlistAllDirAndFiles { get => isEnlistAllDirAndFiles; set => isEnlistAllDirAndFiles = value; }
    }
}
