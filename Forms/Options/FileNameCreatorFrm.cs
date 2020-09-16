using OneClickZip.Includes.Models;
using OneClickZip.Includes.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneClickZip.Forms.Options
{
    public partial class FileNameCreatorFrm : Form
    {
        DateCreatorModel dateCreatorModel = new DateCreatorModel();
        RandomNumberGeneratorModel randomNumberGenerator = new RandomNumberGeneratorModel();
        RandomCharsGeneratorModel randomCharGenerator = new RandomCharsGeneratorModel();

        public FileNameCreatorFrm()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            listViewInstruction.Items.Clear();
            listViewInstruction.BeginUpdate();
            AddListViewInstructionItems(dateCreatorModel.GetResourcePropertiesList(false));
            AddListViewInstructionItems(randomNumberGenerator.GetResourcePropertiesList(false));
            AddListViewInstructionItems(randomCharGenerator.GetResourcePropertiesList(false));
            listViewInstruction.EndUpdate();
        }

        private void AddListViewInstructionItems(List<ResourcePropertiesModel> arrayRpm)
        {
            foreach (ResourcePropertiesModel rpm in arrayRpm)
            {
                ListViewItem lvItem = new ListViewItem(new string[] { rpm.PropertyValue, rpm.Description });
                lvItem.Tag = rpm;
                listViewInstruction.Items.Add(lvItem);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FileNameCreatorFrm_Load(object sender, EventArgs e)
        {
            //DEBUG
            txtFileNameFormula.Text = "Sample File Name - $RC{SHA1} - $RC{SHA2} - $RC{SHA256}";
            //DEBUG END
        }

        private void ListViewInstruction_ItemSelectionChange(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewInstruction.SelectedItems == null) return;
            if (listViewInstruction.SelectedItems.Count <= 0) return;
            if (listViewInstruction.SelectedItems[0] == null) return;
            ResourcePropertiesModel rpm = (ResourcePropertiesModel) listViewInstruction.SelectedItems[0].Tag;
            txtSelectedVariable.Text = rpm.PropertyValue;
        }

        private void btnSimulateFormula_Click(object sender, EventArgs e)
        {
            //dateCreatorModel.Generate(txtFileNameFormula.Text);
            randomNumberGenerator.Generate(txtFileNameFormula.Text);
            randomCharGenerator.Generate(txtFileNameFormula.Text);
        }
    }
}
