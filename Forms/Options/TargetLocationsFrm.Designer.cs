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
            this.panelSetLocations = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnAddOtherFolder1 = new System.Windows.Forms.Button();
            this.tableLayoutPanelSetLocations = new System.Windows.Forms.TableLayoutPanel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelMainLocations = new System.Windows.Forms.Panel();
            this.btnAddMain = new System.Windows.Forms.Button();
            this.txtTargetLocationMain = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSelectedPath = new System.Windows.Forms.Panel();
            this.txtSelectedPath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelSetLocations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelMainLocations.SuspendLayout();
            this.panelSelectedPath.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 53);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.expTreeExplorer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelSetLocations);
            this.splitContainer1.Panel2.Controls.Add(this.panelButtons);
            this.splitContainer1.Panel2.Controls.Add(this.panelMainLocations);
            this.splitContainer1.Size = new System.Drawing.Size(1092, 506);
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
            this.expTreeExplorer.Size = new System.Drawing.Size(362, 504);
            this.expTreeExplorer.StartUpDirectory = ExpTreeLib.ExpTree.StartDir.Desktop;
            this.expTreeExplorer.TabIndex = 0;
            this.expTreeExplorer.ExpTreeNodeSelected += new ExpTreeLib.ExpTree.ExpTreeNodeSelectedEventHandler(this.expTreeExplorer_ExpTreeNodeSelected);
            // 
            // panelSetLocations
            // 
            this.panelSetLocations.AutoScroll = true;
            this.panelSetLocations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSetLocations.Controls.Add(this.splitContainer2);
            this.panelSetLocations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSetLocations.Location = new System.Drawing.Point(0, 89);
            this.panelSetLocations.Name = "panelSetLocations";
            this.panelSetLocations.Size = new System.Drawing.Size(722, 328);
            this.panelSetLocations.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnAddOtherFolder1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanelSetLocations);
            this.splitContainer2.Size = new System.Drawing.Size(720, 326);
            this.splitContainer2.SplitterDistance = 60;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnAddOtherFolder1
            // 
            this.btnAddOtherFolder1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddOtherFolder1.Image = global::OneClickZip.Properties.Resources.folder_Plus_24px;
            this.btnAddOtherFolder1.Location = new System.Drawing.Point(0, 0);
            this.btnAddOtherFolder1.Name = "btnAddOtherFolder1";
            this.btnAddOtherFolder1.Size = new System.Drawing.Size(60, 326);
            this.btnAddOtherFolder1.TabIndex = 0;
            this.btnAddOtherFolder1.Text = "Add other target folder >>>";
            this.btnAddOtherFolder1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddOtherFolder1.UseVisualStyleBackColor = true;
            this.btnAddOtherFolder1.Click += new System.EventHandler(this.btnAddOtherFolder1_Click);
            // 
            // tableLayoutPanelSetLocations
            // 
            this.tableLayoutPanelSetLocations.AutoScroll = true;
            this.tableLayoutPanelSetLocations.ColumnCount = 1;
            this.tableLayoutPanelSetLocations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSetLocations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSetLocations.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelSetLocations.Name = "tableLayoutPanelSetLocations";
            this.tableLayoutPanelSetLocations.RowCount = 1;
            this.tableLayoutPanelSetLocations.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 355F));
            this.tableLayoutPanelSetLocations.Size = new System.Drawing.Size(656, 326);
            this.tableLayoutPanelSetLocations.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelButtons.Controls.Add(this.btnDefault);
            this.panelButtons.Controls.Add(this.btnSaveExit);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 417);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(722, 87);
            this.panelButtons.TabIndex = 2;
            // 
            // btnDefault
            // 
            this.btnDefault.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDefault.Image = global::OneClickZip.Properties.Resources.folder_rule_32px;
            this.btnDefault.Location = new System.Drawing.Point(7, 9);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(124, 72);
            this.btnDefault.TabIndex = 4;
            this.btnDefault.Text = "Restore Default";
            this.btnDefault.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDefault.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveExit.Image = global::OneClickZip.Properties.Resources.save_v1_32;
            this.btnSaveExit.Location = new System.Drawing.Point(474, 9);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(115, 72);
            this.btnSaveExit.TabIndex = 1;
            this.btnSaveExit.Text = "Save and Exit";
            this.btnSaveExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::OneClickZip.Properties.Resources.Exit_32;
            this.btnCancel.Location = new System.Drawing.Point(595, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 72);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.panelMainLocations.Size = new System.Drawing.Size(722, 89);
            this.panelMainLocations.TabIndex = 0;
            // 
            // btnAddMain
            // 
            this.btnAddMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMain.Image = global::OneClickZip.Properties.Resources.folder_Plus_24px;
            this.btnAddMain.Location = new System.Drawing.Point(546, 26);
            this.btnAddMain.Name = "btnAddMain";
            this.btnAddMain.Size = new System.Drawing.Size(171, 55);
            this.btnAddMain.TabIndex = 2;
            this.btnAddMain.Text = "Set as Main Folder";
            this.btnAddMain.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddMain.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            this.txtTargetLocationMain.Size = new System.Drawing.Size(533, 55);
            this.txtTargetLocationMain.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Main target directory location (where the zip file to put into):";
            // 
            // panelSelectedPath
            // 
            this.panelSelectedPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSelectedPath.Controls.Add(this.groupBox1);
            this.panelSelectedPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSelectedPath.Location = new System.Drawing.Point(0, 0);
            this.panelSelectedPath.Name = "panelSelectedPath";
            this.panelSelectedPath.Size = new System.Drawing.Size(1092, 53);
            this.panelSelectedPath.TabIndex = 1;
            // 
            // txtSelectedPath
            // 
            this.txtSelectedPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSelectedPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSelectedPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelectedPath.Location = new System.Drawing.Point(3, 18);
            this.txtSelectedPath.Name = "txtSelectedPath";
            this.txtSelectedPath.Size = new System.Drawing.Size(1084, 24);
            this.txtSelectedPath.TabIndex = 0;
            this.txtSelectedPath.WordWrap = false;
            this.txtSelectedPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSelectedPath_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSelectedPath);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1090, 51);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Directory: ";
            // 
            // TargetLocationsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 559);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelSelectedPath);
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
            this.panelSetLocations.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelMainLocations.ResumeLayout(false);
            this.panelMainLocations.PerformLayout();
            this.panelSelectedPath.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Panel panelSelectedPath;
        private System.Windows.Forms.TextBox txtSelectedPath;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSetLocations;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnAddOtherFolder1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}