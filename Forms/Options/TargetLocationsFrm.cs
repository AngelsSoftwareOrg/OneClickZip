using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ExpTreeLib;
using OneClickZip.Includes.Models;
using OneClickZip.Includes.Resources;
using OneClickZip.Includes.Utilities;

namespace OneClickZip.Forms.Options
{
    public partial class TargetLocationsFrm : Form
    {
        private int dynamicControlCtr = 0;
        private String selectedPath;
        private TargetOutputLocationModel targetOutputLocationModel;
        public TargetLocationsFrm(TargetOutputLocationModel targetOutput=null)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.None;
            if(targetOutput != null)
            {
                targetOutputLocationModel = (TargetOutputLocationModel)targetOutput.Clone();
            }
        }
        private void TargetLocationsFrm_Load(object sender, EventArgs e)
        {
            expTreeExplorer.StartUpDirectory = ExpTree.StartDir.Desktop;
            SetUpDefault();
            expTreeExplorer.ExpandANode(ApplicationSettings.GetLastOpenedDirectory(), true);
        }
        private void SetUpDefault()
        {
            if (targetOutputLocationModel != null)
            {
                txtTargetLocationMain.Text = targetOutputLocationModel.MainTargetLocation;
                tableLayoutPanelSetLocations.Controls.Clear();
                foreach (String str in targetOutputLocationModel.GetTargetLocations())
                {
                    AddNewTargetLocationControls(str);
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void btnAddOtherFolder_Click(object sender, EventArgs e)
        {
            AddNewTargetLocationControls(
                (FileSystemUtilities.IsDirectoryExistInTheSystem(SelectedPath) 
                        ? SelectedPath : ""));
        }
        private void AddNewTargetLocationControls(String targetLocation="")
        {
            dynamicControlCtr++;
            int tabIndex = -1;
            Label labelAddedFolder = new Label();
            labelAddedFolder.AutoSize = true;
            labelAddedFolder.Location = new System.Drawing.Point(9, 9);
            labelAddedFolder.Name = "labelAddedFolder" + dynamicControlCtr;
            labelAddedFolder.Size = new System.Drawing.Size(97, 17);
            labelAddedFolder.TabIndex = ++tabIndex;
            labelAddedFolder.Text = "Added Folder: " + dynamicControlCtr;

            TextBox txtAddedLocation = new TextBox();
            txtAddedLocation.Anchor = ((AnchorStyles) (((AnchorStyles.Top | AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            txtAddedLocation.Location = new System.Drawing.Point(11, 34);
            txtAddedLocation.Name = "txtAddedLocation" + dynamicControlCtr;
            txtAddedLocation.Size = new System.Drawing.Size(128, 22);
            txtAddedLocation.TabIndex = ++tabIndex;
            txtAddedLocation.Text = targetLocation;
            txtAddedLocation.ReadOnly = false;

            LinkLabel linkLabelRemove = new LinkLabel();
            linkLabelRemove.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            linkLabelRemove.Location = new System.Drawing.Point(45, 55);
            linkLabelRemove.Name = "linLblRemoveAddedLoc" + dynamicControlCtr;
            linkLabelRemove.Size = new System.Drawing.Size(120, 17);
            linkLabelRemove.TabIndex = ++tabIndex;
            linkLabelRemove.Text = "Remove Folder " + dynamicControlCtr;
            linkLabelRemove.Click += LinkLabelRemove_Click;

            Button btnAddFolder = new Button();
            btnAddFolder.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            btnAddFolder.Location = new System.Drawing.Point(145, 26);
            btnAddFolder.Name = "btnAddFolder" + dynamicControlCtr;
            btnAddFolder.Size = new System.Drawing.Size(40, 30);
            btnAddFolder.TabIndex = ++tabIndex;
            btnAddFolder.Text = "+";
            btnAddFolder.UseVisualStyleBackColor = true;
            btnAddFolder.Click += BtnAddFolder_Click;

            Panel panelDynamic = new Panel();
            panelDynamic.Controls.Add(btnAddFolder);
            panelDynamic.Controls.Add(txtAddedLocation);
            panelDynamic.Controls.Add(labelAddedFolder);
            panelDynamic.Controls.Add(linkLabelRemove);
            panelDynamic.Dock = System.Windows.Forms.DockStyle.Top;
            panelDynamic.Location = new System.Drawing.Point(0, 0);
            panelDynamic.Name = "panelDynamic" + dynamicControlCtr;
            panelDynamic.Size = new System.Drawing.Size(400, 75);
            panelDynamic.TabIndex = ++tabIndex;

            int tgtRowIdx = this.tableLayoutPanelSetLocations.RowCount - 1;
            this.tableLayoutPanelSetLocations.Controls.Add(panelDynamic, 0, tgtRowIdx + 1);
            this.tableLayoutPanelSetLocations.RowStyles[tgtRowIdx].SizeType = SizeType.AutoSize;
            this.tableLayoutPanelSetLocations.RowCount += 1;
            this.tableLayoutPanelSetLocations.RowStyles.Add(new RowStyle(SizeType.AutoSize, 20F));
            this.tableLayoutPanelSetLocations.ScrollControlIntoView(panelDynamic);
        }
        private void BtnAddFolder_Click(object sender, EventArgs e)
        {
            if (!FileSystemUtilities.IsDirectoryExistInTheSystem(SelectedPath)) return;

            Button genericButton = (Button)sender;
            Panel panelContainer = (Panel)genericButton.Parent;
            TextBox addOtherLocation = AddedLocationTextBoxControl(panelContainer);
            if (!IsUniqueTargetLocation(addOtherLocation))
            {
                MessageBox.Show("Duplicate target folder found. Please choose a unique folder...", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool IsUniqueTargetLocation(TextBox sourceLocation)
        {
            if (IsUniqueTargetFolder(sourceLocation, SelectedPath))
            {
                sourceLocation.Text = SelectedPath;
                ColorControlBaseOnValidation(sourceLocation, true);
                return true;
            }
            else
            {
                ColorControlBaseOnValidation(sourceLocation, false);
            }
            return false;
        }
        private void LinkLabelRemove_Click(object sender, EventArgs e)
        {
            LinkLabel linkLabelRemove = (LinkLabel)sender;
            Panel panelContainer = (Panel)linkLabelRemove.Parent;

            Panel mainContainer = (Panel)panelContainer.Parent;
            mainContainer.Controls.Remove(panelContainer);
        }
        private TextBox AddedLocationTextBoxControl(Panel panelContainer)
        {
            foreach (Control control in panelContainer.Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    return ((TextBox)control);
                }
            }
            return null;
        }
        private void expTreeExplorer_ExpTreeNodeSelected(string SelPath, CShItem Item)
        {
            SelectedPath = SelPath;
            txtSelectedPath.Text = SelPath;
            ColorControlBaseOnValidation(txtSelectedPath, true);
        }
        private string SelectedPath { get => selectedPath; set => selectedPath = value; }
        private void btnAddMain_Click(object sender, EventArgs e)
        {
            if (FileSystemUtilities.IsDirectoryExistInTheSystem(SelectedPath)) 
            {
                txtTargetLocationMain.Text = SelectedPath;
            };
        }
        private bool IsUniqueTargetFolder(TextBox sourceControl, String targetFolderPath)
        {
            if (targetFolderPath.Equals(txtTargetLocationMain.Text, StringComparison.InvariantCultureIgnoreCase)) return false;
            //Other Controls
            foreach (Control control in tableLayoutPanelSetLocations.Controls)
            {
                TextBox txtBoxControl = AddedLocationTextBoxControl((Panel)control);
                if (txtBoxControl != sourceControl)
                {
                    if (targetFolderPath.Equals(txtBoxControl.Text, StringComparison.InvariantCultureIgnoreCase)) return false;
                }
            }
            return true;
        }
        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            if (!AreTargetLocationsValid())
            {
                MessageBox.Show("Please put a valid folder", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            };

            targetOutputLocationModel = new TargetOutputLocationModel(txtTargetLocationMain.Text);
            foreach (Control control in tableLayoutPanelSetLocations.Controls)
            {
                TextBox txtBoxControl = AddedLocationTextBoxControl((Panel)control);
                targetOutputLocationModel.AddLocation(txtBoxControl.Text);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private bool AreTargetLocationsValid()
        {
            int invalidFormCtr = 0;
            if (!IsTextboxValueValid(txtTargetLocationMain)) invalidFormCtr++;

            List<String> targets = new List<string>();
            targets.Add(txtTargetLocationMain.Text);

            //Other Controls
            foreach (Control control in tableLayoutPanelSetLocations.Controls)
            {
                TextBox txtBoxControl = AddedLocationTextBoxControl((Panel)control);
                if (!IsTextboxValueValid(txtBoxControl)) invalidFormCtr++;
                if (targets.Contains(txtBoxControl.Text))
                {
                    invalidFormCtr++;
                    _ = IsUniqueTargetLocation(txtBoxControl);
                }
                else
                {
                    targets.Add(txtBoxControl.Text);
                }
            }

            return (invalidFormCtr<=0);
        }
        private bool IsTextboxValueValid(TextBox textBoxControl)
        {
            if (String.IsNullOrWhiteSpace(textBoxControl.Text))
            {
                ColorControlBaseOnValidation(textBoxControl, false);
                return false;
            }
            else if (!FileSystemUtilities.IsDirectoryExistInTheSystem(textBoxControl.Text))
            {
                ColorControlBaseOnValidation(textBoxControl, false);
                return false;
            }
            else
            {
                ColorControlBaseOnValidation(textBoxControl, true);
            }
            return true;
        }
        private void ColorControlBaseOnValidation(Control control, bool isValid)
        {
            if (isValid)
            {
                control.BackColor = Color.White; //Color.FromArgb(255, 240, 240, 240); //gray
            }
            else
            {
                control.BackColor = Color.Orange;
            }
        }
        public TargetOutputLocationModel TargetOutputLocationModel 
        {
            get
            {
                return targetOutputLocationModel;
            }
            set
            {
                targetOutputLocationModel = (TargetOutputLocationModel) value.Clone();
            }
        }
        private void btnDefault_Click(object sender, EventArgs e)
        {
            dynamicControlCtr = 0;
            ColorControlBaseOnValidation(txtTargetLocationMain,true);
            tableLayoutPanelSetLocations.Controls.Clear();
            SetUpDefault();
        }
        private void txtSelectedPath_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (FileSystemUtilities.IsDirectoryExistInTheSystem(txtSelectedPath.Text))
                {
                    ColorControlBaseOnValidation(txtSelectedPath, true);
                    expTreeExplorer.ExpandANode(SelectedPath, true);
                    expTreeExplorer.Refresh();
                    SelectedPath = txtSelectedPath.Text;
                }
                else
                {
                    ColorControlBaseOnValidation(txtSelectedPath, false);
                }
            }
        }

    }
}
