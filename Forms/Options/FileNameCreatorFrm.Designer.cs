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
            this.panel2 = new System.Windows.Forms.Panel();
            this.listViewInstruction = new System.Windows.Forms.ListView();
            this.colVariable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClearFilename = new System.Windows.Forms.Button();
            this.btnInsertVar = new System.Windows.Forms.Button();
            this.btnCopyVar = new System.Windows.Forms.Button();
            this.btnSimulateFormula = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSimulatedFilename = new System.Windows.Forms.TextBox();
            this.txtFileNameFormula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSelectedVariable = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.lblCharCount = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listViewInstruction);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(782, 300);
            this.panel2.TabIndex = 7;
            // 
            // listViewInstruction
            // 
            this.listViewInstruction.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colVariable,
            this.colDesc});
            this.listViewInstruction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewInstruction.FullRowSelect = true;
            this.listViewInstruction.GridLines = true;
            this.listViewInstruction.HideSelection = false;
            this.listViewInstruction.Location = new System.Drawing.Point(0, 0);
            this.listViewInstruction.Name = "listViewInstruction";
            this.listViewInstruction.Size = new System.Drawing.Size(782, 300);
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
            this.colDesc.Width = 600;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblCharCount);
            this.panel3.Controls.Add(this.btnClearFilename);
            this.panel3.Controls.Add(this.btnInsertVar);
            this.panel3.Controls.Add(this.btnCopyVar);
            this.panel3.Controls.Add(this.btnSimulateFormula);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtSimulatedFilename);
            this.panel3.Controls.Add(this.txtFileNameFormula);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtSelectedVariable);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnSaveExit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 300);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(782, 219);
            this.panel3.TabIndex = 8;
            // 
            // btnClearFilename
            // 
            this.btnClearFilename.Location = new System.Drawing.Point(502, 37);
            this.btnClearFilename.Name = "btnClearFilename";
            this.btnClearFilename.Size = new System.Drawing.Size(125, 36);
            this.btnClearFilename.TabIndex = 17;
            this.btnClearFilename.Text = "Clear File Name";
            this.btnClearFilename.UseVisualStyleBackColor = true;
            this.btnClearFilename.Click += new System.EventHandler(this.btnClearFilename_Click);
            // 
            // btnInsertVar
            // 
            this.btnInsertVar.Location = new System.Drawing.Point(386, 37);
            this.btnInsertVar.Name = "btnInsertVar";
            this.btnInsertVar.Size = new System.Drawing.Size(110, 36);
            this.btnInsertVar.TabIndex = 16;
            this.btnInsertVar.Text = "Insert it";
            this.btnInsertVar.UseVisualStyleBackColor = true;
            this.btnInsertVar.Click += new System.EventHandler(this.BtnInsertVar_Click);
            // 
            // btnCopyVar
            // 
            this.btnCopyVar.Location = new System.Drawing.Point(303, 37);
            this.btnCopyVar.Name = "btnCopyVar";
            this.btnCopyVar.Size = new System.Drawing.Size(77, 36);
            this.btnCopyVar.TabIndex = 15;
            this.btnCopyVar.Text = "Copy";
            this.btnCopyVar.UseVisualStyleBackColor = true;
            this.btnCopyVar.Click += new System.EventHandler(this.BtnCopyVar_Click);
            // 
            // btnSimulateFormula
            // 
            this.btnSimulateFormula.Location = new System.Drawing.Point(502, 79);
            this.btnSimulateFormula.Name = "btnSimulateFormula";
            this.btnSimulateFormula.Size = new System.Drawing.Size(184, 63);
            this.btnSimulateFormula.TabIndex = 14;
            this.btnSimulateFormula.Text = "Simulate now your file name formula";
            this.btnSimulateFormula.UseVisualStyleBackColor = true;
            this.btnSimulateFormula.Click += new System.EventHandler(this.BtnSimulateFormula_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Simulated Filename: ";
            // 
            // txtSimulatedFilename
            // 
            this.txtSimulatedFilename.BackColor = System.Drawing.SystemColors.Menu;
            this.txtSimulatedFilename.Location = new System.Drawing.Point(3, 145);
            this.txtSimulatedFilename.Multiline = true;
            this.txtSimulatedFilename.Name = "txtSimulatedFilename";
            this.txtSimulatedFilename.ReadOnly = true;
            this.txtSimulatedFilename.Size = new System.Drawing.Size(774, 70);
            this.txtSimulatedFilename.TabIndex = 12;
            // 
            // txtFileNameFormula
            // 
            this.txtFileNameFormula.Location = new System.Drawing.Point(4, 90);
            this.txtFileNameFormula.Margin = new System.Windows.Forms.Padding(4);
            this.txtFileNameFormula.Name = "txtFileNameFormula";
            this.txtFileNameFormula.Size = new System.Drawing.Size(491, 22);
            this.txtFileNameFormula.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Create your new File Name / Formula:";
            // 
            // txtSelectedVariable
            // 
            this.txtSelectedVariable.BackColor = System.Drawing.SystemColors.Menu;
            this.txtSelectedVariable.Location = new System.Drawing.Point(6, 37);
            this.txtSelectedVariable.Name = "txtSelectedVariable";
            this.txtSelectedVariable.ReadOnly = true;
            this.txtSelectedVariable.Size = new System.Drawing.Size(291, 22);
            this.txtSelectedVariable.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(444, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Selected Variable. Copy your variable here and paste on the formula.";
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Location = new System.Drawing.Point(687, 79);
            this.btnSaveExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(90, 63);
            this.btnSaveExit.TabIndex = 6;
            this.btnSaveExit.Text = "Save and Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // lblCharCount
            // 
            this.lblCharCount.AutoSize = true;
            this.lblCharCount.Location = new System.Drawing.Point(134, 125);
            this.lblCharCount.Name = "lblCharCount";
            this.lblCharCount.Size = new System.Drawing.Size(137, 17);
            this.lblCharCount.TabIndex = 18;
            this.lblCharCount.Text = "(Character Count: 0)";
            // 
            // FileNameCreatorFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 519);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileNameCreatorFrm";
            this.Text = "File Name Creator";
            this.Load += new System.EventHandler(this.FileNameCreatorFrm_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.ListView listViewInstruction;
        private System.Windows.Forms.ColumnHeader colVariable;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSelectedVariable;
        private System.Windows.Forms.TextBox txtFileNameFormula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSimulatedFilename;
        private System.Windows.Forms.Button btnSimulateFormula;
        private System.Windows.Forms.Button btnInsertVar;
        private System.Windows.Forms.Button btnCopyVar;
        private System.Windows.Forms.Button btnClearFilename;
        private System.Windows.Forms.Label lblCharCount;
    }
}