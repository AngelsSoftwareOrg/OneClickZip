namespace OneClickZip.Forms.Options
{
    partial class FileNameCreatorFrm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileNameCreatorFrm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.listViewInstruction = new System.Windows.Forms.ListView();
            this.colVariable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.btnSimulateFormula = new System.Windows.Forms.Button();
            this.groupBoxSimulation = new System.Windows.Forms.GroupBox();
            this.lblCharCount = new System.Windows.Forms.Label();
            this.txtSimulatedFilename = new System.Windows.Forms.TextBox();
            this.groupNewFileName = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileNameFormula = new System.Windows.Forms.TextBox();
            this.btnClearFilename = new System.Windows.Forms.Button();
            this.groupBoxSelVar = new System.Windows.Forms.GroupBox();
            this.btnInsertVar = new System.Windows.Forms.Button();
            this.btnCopyVar = new System.Windows.Forms.Button();
            this.txtSelectedVariable = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.contextMenuStripListView.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBoxSimulation.SuspendLayout();
            this.groupNewFileName.SuspendLayout();
            this.groupBoxSelVar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listViewInstruction);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(961, 300);
            this.panel2.TabIndex = 7;
            // 
            // listViewInstruction
            // 
            this.listViewInstruction.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colVariable,
            this.colDesc});
            this.listViewInstruction.ContextMenuStrip = this.contextMenuStripListView;
            this.listViewInstruction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewInstruction.FullRowSelect = true;
            this.listViewInstruction.GridLines = true;
            this.listViewInstruction.HideSelection = false;
            this.listViewInstruction.Location = new System.Drawing.Point(0, 0);
            this.listViewInstruction.Name = "listViewInstruction";
            this.listViewInstruction.Size = new System.Drawing.Size(961, 300);
            this.listViewInstruction.TabIndex = 0;
            this.listViewInstruction.UseCompatibleStateImageBehavior = false;
            this.listViewInstruction.View = System.Windows.Forms.View.Details;
            this.listViewInstruction.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListViewInstruction_ItemSelectionChange);
            // 
            // colVariable
            // 
            this.colVariable.Text = "Variable";
            this.colVariable.Width = 120;
            // 
            // colDesc
            // 
            this.colDesc.Text = "Description";
            this.colDesc.Width = 807;
            // 
            // contextMenuStripListView
            // 
            this.contextMenuStripListView.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCopy,
            this.toolStripMenuItemInsert});
            this.contextMenuStripListView.Name = "contextMenuStripListView";
            this.contextMenuStripListView.Size = new System.Drawing.Size(115, 52);
            // 
            // toolStripMenuItemCopy
            // 
            this.toolStripMenuItemCopy.Name = "toolStripMenuItemCopy";
            this.toolStripMenuItemCopy.Size = new System.Drawing.Size(114, 24);
            this.toolStripMenuItemCopy.Text = "Copy";
            this.toolStripMenuItemCopy.ToolTipText = "Copy the formula into clipboard";
            this.toolStripMenuItemCopy.Click += new System.EventHandler(this.toolStripMenuItemCopy_Click);
            // 
            // toolStripMenuItemInsert
            // 
            this.toolStripMenuItemInsert.Name = "toolStripMenuItemInsert";
            this.toolStripMenuItemInsert.Size = new System.Drawing.Size(114, 24);
            this.toolStripMenuItemInsert.Text = "Insert";
            this.toolStripMenuItemInsert.ToolTipText = "Insert the formula on the file name";
            this.toolStripMenuItemInsert.Click += new System.EventHandler(this.toolStripMenuItemInsert_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSaveExit);
            this.panel3.Controls.Add(this.btnSimulateFormula);
            this.panel3.Controls.Add(this.groupBoxSimulation);
            this.panel3.Controls.Add(this.groupNewFileName);
            this.panel3.Controls.Add(this.groupBoxSelVar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 300);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(961, 219);
            this.panel3.TabIndex = 8;
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Image = global::OneClickZip.Properties.Resources.Exit_20;
            this.btnSaveExit.Location = new System.Drawing.Point(775, 180);
            this.btnSaveExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(182, 35);
            this.btnSaveExit.TabIndex = 6;
            this.btnSaveExit.Text = "Save and Exit";
            this.btnSaveExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // btnSimulateFormula
            // 
            this.btnSimulateFormula.Image = global::OneClickZip.Properties.Resources.no_connection_20;
            this.btnSimulateFormula.Location = new System.Drawing.Point(457, 180);
            this.btnSimulateFormula.Name = "btnSimulateFormula";
            this.btnSimulateFormula.Size = new System.Drawing.Size(311, 36);
            this.btnSimulateFormula.TabIndex = 14;
            this.btnSimulateFormula.Text = "Simulate now your file name formula";
            this.btnSimulateFormula.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSimulateFormula.UseVisualStyleBackColor = true;
            this.btnSimulateFormula.Click += new System.EventHandler(this.BtnSimulateFormula_Click);
            // 
            // groupBoxSimulation
            // 
            this.groupBoxSimulation.Controls.Add(this.lblCharCount);
            this.groupBoxSimulation.Controls.Add(this.txtSimulatedFilename);
            this.groupBoxSimulation.Location = new System.Drawing.Point(457, 7);
            this.groupBoxSimulation.Name = "groupBoxSimulation";
            this.groupBoxSimulation.Size = new System.Drawing.Size(500, 174);
            this.groupBoxSimulation.TabIndex = 21;
            this.groupBoxSimulation.TabStop = false;
            this.groupBoxSimulation.Text = "File Name Simulation";
            // 
            // lblCharCount
            // 
            this.lblCharCount.AutoSize = true;
            this.lblCharCount.Location = new System.Drawing.Point(6, 23);
            this.lblCharCount.Name = "lblCharCount";
            this.lblCharCount.Size = new System.Drawing.Size(137, 17);
            this.lblCharCount.TabIndex = 18;
            this.lblCharCount.Text = "(Character Count: 0)";
            // 
            // txtSimulatedFilename
            // 
            this.txtSimulatedFilename.BackColor = System.Drawing.SystemColors.Menu;
            this.txtSimulatedFilename.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtSimulatedFilename.Location = new System.Drawing.Point(3, 44);
            this.txtSimulatedFilename.Multiline = true;
            this.txtSimulatedFilename.Name = "txtSimulatedFilename";
            this.txtSimulatedFilename.ReadOnly = true;
            this.txtSimulatedFilename.Size = new System.Drawing.Size(494, 127);
            this.txtSimulatedFilename.TabIndex = 12;
            // 
            // groupNewFileName
            // 
            this.groupNewFileName.Controls.Add(this.label1);
            this.groupNewFileName.Controls.Add(this.txtFileNameFormula);
            this.groupNewFileName.Controls.Add(this.btnClearFilename);
            this.groupNewFileName.Location = new System.Drawing.Point(182, 7);
            this.groupNewFileName.Name = "groupNewFileName";
            this.groupNewFileName.Size = new System.Drawing.Size(269, 209);
            this.groupNewFileName.TabIndex = 20;
            this.groupNewFileName.TabStop = false;
            this.groupNewFileName.Text = "Formula Field";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Create your new File Name :";
            // 
            // txtFileNameFormula
            // 
            this.txtFileNameFormula.Location = new System.Drawing.Point(4, 44);
            this.txtFileNameFormula.Margin = new System.Windows.Forms.Padding(4);
            this.txtFileNameFormula.Multiline = true;
            this.txtFileNameFormula.Name = "txtFileNameFormula";
            this.txtFileNameFormula.Size = new System.Drawing.Size(259, 127);
            this.txtFileNameFormula.TabIndex = 11;
            // 
            // btnClearFilename
            // 
            this.btnClearFilename.Image = global::OneClickZip.Properties.Resources.broom_20;
            this.btnClearFilename.Location = new System.Drawing.Point(4, 173);
            this.btnClearFilename.Name = "btnClearFilename";
            this.btnClearFilename.Size = new System.Drawing.Size(259, 36);
            this.btnClearFilename.TabIndex = 17;
            this.btnClearFilename.Text = "Clear File Name";
            this.btnClearFilename.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearFilename.UseVisualStyleBackColor = true;
            this.btnClearFilename.Click += new System.EventHandler(this.btnClearFilename_Click);
            // 
            // groupBoxSelVar
            // 
            this.groupBoxSelVar.Controls.Add(this.btnInsertVar);
            this.groupBoxSelVar.Controls.Add(this.btnCopyVar);
            this.groupBoxSelVar.Controls.Add(this.txtSelectedVariable);
            this.groupBoxSelVar.Controls.Add(this.label2);
            this.groupBoxSelVar.Location = new System.Drawing.Point(3, 6);
            this.groupBoxSelVar.Name = "groupBoxSelVar";
            this.groupBoxSelVar.Size = new System.Drawing.Size(173, 210);
            this.groupBoxSelVar.TabIndex = 19;
            this.groupBoxSelVar.TabStop = false;
            this.groupBoxSelVar.Text = "Selected Variable";
            // 
            // btnInsertVar
            // 
            this.btnInsertVar.Image = global::OneClickZip.Properties.Resources.add_row_20;
            this.btnInsertVar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnInsertVar.Location = new System.Drawing.Point(95, 155);
            this.btnInsertVar.Name = "btnInsertVar";
            this.btnInsertVar.Size = new System.Drawing.Size(72, 54);
            this.btnInsertVar.TabIndex = 20;
            this.btnInsertVar.Text = "Insert it";
            this.btnInsertVar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInsertVar.UseVisualStyleBackColor = true;
            this.btnInsertVar.Click += new System.EventHandler(this.BtnInsertVar_Click);
            // 
            // btnCopyVar
            // 
            this.btnCopyVar.Image = global::OneClickZip.Properties.Resources.copy_to_clipboard_20;
            this.btnCopyVar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCopyVar.Location = new System.Drawing.Point(6, 155);
            this.btnCopyVar.Name = "btnCopyVar";
            this.btnCopyVar.Size = new System.Drawing.Size(73, 54);
            this.btnCopyVar.TabIndex = 19;
            this.btnCopyVar.Text = "Copy";
            this.btnCopyVar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCopyVar.UseVisualStyleBackColor = true;
            this.btnCopyVar.Click += new System.EventHandler(this.BtnCopyVar_Click);
            // 
            // txtSelectedVariable
            // 
            this.txtSelectedVariable.BackColor = System.Drawing.SystemColors.Menu;
            this.txtSelectedVariable.Location = new System.Drawing.Point(6, 81);
            this.txtSelectedVariable.Multiline = true;
            this.txtSelectedVariable.Name = "txtSelectedVariable";
            this.txtSelectedVariable.ReadOnly = true;
            this.txtSelectedVariable.Size = new System.Drawing.Size(161, 68);
            this.txtSelectedVariable.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 54);
            this.label2.TabIndex = 17;
            this.label2.Text = "Copy your variable here and paste on the file name formula.";
            // 
            // FileNameCreatorFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 519);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileNameCreatorFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File Name Creator";
            this.Load += new System.EventHandler(this.FileNameCreatorFrm_Load);
            this.panel2.ResumeLayout(false);
            this.contextMenuStripListView.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBoxSimulation.ResumeLayout(false);
            this.groupBoxSimulation.PerformLayout();
            this.groupNewFileName.ResumeLayout(false);
            this.groupNewFileName.PerformLayout();
            this.groupBoxSelVar.ResumeLayout(false);
            this.groupBoxSelVar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.ListView listViewInstruction;
        private System.Windows.Forms.ColumnHeader colVariable;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.TextBox txtFileNameFormula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSimulatedFilename;
        private System.Windows.Forms.Button btnSimulateFormula;
        private System.Windows.Forms.Button btnClearFilename;
        private System.Windows.Forms.Label lblCharCount;
        private System.Windows.Forms.GroupBox groupBoxSelVar;
        private System.Windows.Forms.Button btnInsertVar;
        private System.Windows.Forms.Button btnCopyVar;
        private System.Windows.Forms.TextBox txtSelectedVariable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupNewFileName;
        private System.Windows.Forms.GroupBox groupBoxSimulation;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripListView;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemInsert;
    }
}