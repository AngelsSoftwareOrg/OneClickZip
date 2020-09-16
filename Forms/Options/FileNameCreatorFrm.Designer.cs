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
            this.txtFileNameFormula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSelectedVariable = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSimulateFormula = new System.Windows.Forms.Button();
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
            this.panel2.Size = new System.Drawing.Size(789, 300);
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
            this.listViewInstruction.Size = new System.Drawing.Size(789, 300);
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
            this.panel3.Controls.Add(this.btnSimulateFormula);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.txtFileNameFormula);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtSelectedVariable);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnSaveExit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 300);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(789, 219);
            this.panel3.TabIndex = 8;
            // 
            // txtFileNameFormula
            // 
            this.txtFileNameFormula.Location = new System.Drawing.Point(12, 90);
            this.txtFileNameFormula.Margin = new System.Windows.Forms.Padding(4);
            this.txtFileNameFormula.Name = "txtFileNameFormula";
            this.txtFileNameFormula.Size = new System.Drawing.Size(485, 22);
            this.txtFileNameFormula.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Create your new File Name / Formula:";
            // 
            // txtSelectedVariable
            // 
            this.txtSelectedVariable.BackColor = System.Drawing.SystemColors.Menu;
            this.txtSelectedVariable.Location = new System.Drawing.Point(12, 37);
            this.txtSelectedVariable.Name = "txtSelectedVariable";
            this.txtSelectedVariable.ReadOnly = true;
            this.txtSelectedVariable.Size = new System.Drawing.Size(485, 22);
            this.txtSelectedVariable.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(444, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Selected Variable. Copy your variable here and paste on the formula.";
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Location = new System.Drawing.Point(678, 145);
            this.btnSaveExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(107, 70);
            this.btnSaveExit.TabIndex = 6;
            this.btnSaveExit.Text = "Save and Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox1.Location = new System.Drawing.Point(11, 145);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(485, 70);
            this.textBox1.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Simulate your new Filename Here";
            // 
            // btnSimulateFormula
            // 
            this.btnSimulateFormula.Location = new System.Drawing.Point(502, 145);
            this.btnSimulateFormula.Name = "btnSimulateFormula";
            this.btnSimulateFormula.Size = new System.Drawing.Size(169, 70);
            this.btnSimulateFormula.TabIndex = 14;
            this.btnSimulateFormula.Text = "Simulate now your file name formula";
            this.btnSimulateFormula.UseVisualStyleBackColor = true;
            this.btnSimulateFormula.Click += new System.EventHandler(this.btnSimulateFormula_Click);
            // 
            // FileNameCreatorFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 519);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileNameCreatorFrm";
            this.Text = "FileNameCreator";
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSimulateFormula;
    }
}