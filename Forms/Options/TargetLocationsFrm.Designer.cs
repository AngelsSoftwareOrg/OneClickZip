namespace OneClickZip.Forms.Options
{
    partial class TargetLocationsFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TargetLocationsFrm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.expTreeExplorer = new ExpTreeLib.ExpTree();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnAddOtherFolder = new System.Windows.Forms.Button();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelSetLocations = new System.Windows.Forms.Panel();
            this.panelMainLocations = new System.Windows.Forms.Panel();
            this.btnAddMain = new System.Windows.Forms.Button();
            this.txtTargetLocationMain = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelMainLocations.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.expTreeExplorer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelButtons);
            this.splitContainer1.Panel2.Controls.Add(this.panelSetLocations);
            this.splitContainer1.Panel2.Controls.Add(this.panelMainLocations);
            this.splitContainer1.Size = new System.Drawing.Size(1092, 559);
            this.splitContainer1.SplitterDistance = 364;
            this.splitContainer1.TabIndex = 0;
            // 
            // expTreeExplorer
            // 
            this.expTreeExplorer.AllowFolderRename = false;
            this.expTreeExplorer.Cursor = System.Windows.Forms.Cursors.Default;
            this.expTreeExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expTreeExplorer.Location = new System.Drawing.Point(0, 0);
            this.expTreeExplorer.Name = "expTreeExplorer";
            this.expTreeExplorer.ShowHiddenFolders = false;
            this.expTreeExplorer.ShowRootLines = false;
            this.expTreeExplorer.Size = new System.Drawing.Size(364, 559);
            this.expTreeExplorer.StartUpDirectory = ExpTreeLib.ExpTree.StartDir.Desktop;
            this.expTreeExplorer.TabIndex = 0;
            this.expTreeExplorer.ExpTreeNodeSelected += new ExpTreeLib.ExpTree.ExpTreeNodeSelectedEventHandler(this.expTreeExplorer_ExpTreeNodeSelected);
            // 
            // panelButtons
            // 
            this.panelButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelButtons.Controls.Add(this.btnAddOtherFolder);
            this.panelButtons.Controls.Add(this.btnSaveExit);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 472);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(724, 87);
            this.panelButtons.TabIndex = 2;
            // 
            // btnAddOtherFolder
            // 
            this.btnAddOtherFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddOtherFolder.Image = global::OneClickZip.Properties.Resources.folder_Plus_32px;
            this.btnAddOtherFolder.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddOtherFolder.Location = new System.Drawing.Point(321, 9);
            this.btnAddOtherFolder.Name = "btnAddOtherFolder";
            this.btnAddOtherFolder.Size = new System.Drawing.Size(149, 72);
            this.btnAddOtherFolder.TabIndex = 3;
            this.btnAddOtherFolder.Text = "Add Other Folder";
            this.btnAddOtherFolder.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddOtherFolder.UseVisualStyleBackColor = true;
            this.btnAddOtherFolder.Click += new System.EventHandler(this.btnAddOtherFolder_Click);
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveExit.Image = global::OneClickZip.Properties.Resources.save_v1_32;
            this.btnSaveExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveExit.Location = new System.Drawing.Point(476, 9);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(115, 72);
            this.btnSaveExit.TabIndex = 1;
            this.btnSaveExit.Text = "Save and Exit";
            this.btnSaveExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::OneClickZip.Properties.Resources.Exit_32;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.Location = new System.Drawing.Point(597, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 72);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelSetLocations
            // 
            this.panelSetLocations.AutoScroll = true;
            this.panelSetLocations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSetLocations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSetLocations.Location = new System.Drawing.Point(0, 89);
            this.panelSetLocations.Name = "panelSetLocations";
            this.panelSetLocations.Size = new System.Drawing.Size(724, 470);
            this.panelSetLocations.TabIndex = 1;
            // 
            // panelMainLocations
            // 
            this.panelMainLocations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMainLocations.Controls.Add(this.btnAddMain);
            this.panelMainLocations.Controls.Add(this.txtTargetLocationMain);
            this.panelMainLocations.Controls.Add(this.label1);
            this.panelMainLocations.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMainLocations.Location = new System.Drawing.Point(0, 0);
            this.panelMainLocations.Name = "panelMainLocations";
            this.panelMainLocations.Size = new System.Drawing.Size(724, 89);
            this.panelMainLocations.TabIndex = 0;
            // 
            // btnAddMain
            // 
            this.btnAddMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMain.Image = global::OneClickZip.Properties.Resources.folder_Plus_24px;
            this.btnAddMain.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddMain.Location = new System.Drawing.Point(603, 26);
            this.btnAddMain.Name = "btnAddMain";
            this.btnAddMain.Size = new System.Drawing.Size(107, 55);
            this.btnAddMain.TabIndex = 2;
            this.btnAddMain.Text = "Add Folder";
            this.btnAddMain.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddMain.UseVisualStyleBackColor = true;
            this.btnAddMain.Click += new System.EventHandler(this.btnAddMain_Click);
            // 
            // txtTargetLocationMain
            // 
            this.txtTargetLocationMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetLocationMain.Location = new System.Drawing.Point(7, 26);
            this.txtTargetLocationMain.Multiline = true;
            this.txtTargetLocationMain.Name = "txtTargetLocationMain";
            this.txtTargetLocationMain.ReadOnly = true;
            this.txtTargetLocationMain.Size = new System.Drawing.Size(590, 55);
            this.txtTargetLocationMain.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Main Target Location:";
            // 
            // TargetLocationsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 559);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "TargetLocationsFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Target Locations Settings";
            this.Load += new System.EventHandler(this.TargetLocationsFrm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelMainLocations.ResumeLayout(false);
            this.panelMainLocations.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ExpTreeLib.ExpTree expTreeExplorer;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Panel panelSetLocations;
        private System.Windows.Forms.Panel panelMainLocations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTargetLocationMain;
        private System.Windows.Forms.Button btnAddMain;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.Button btnAddOtherFolder;
    }
}