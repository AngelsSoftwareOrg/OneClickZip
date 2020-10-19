namespace OneClickZip.Forms.Options
{
    partial class FileAssociationFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileAssociationFrm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.listViewFileAssc = new System.Windows.Forms.ListView();
            this.columnHeaderExt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFileTypeDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAssociateNow = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listViewFileAssc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 219);
            this.panel1.TabIndex = 0;
            // 
            // listViewFileAssc
            // 
            this.listViewFileAssc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderExt,
            this.columnHeaderFileTypeDesc});
            this.listViewFileAssc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFileAssc.FullRowSelect = true;
            this.listViewFileAssc.GridLines = true;
            this.listViewFileAssc.HideSelection = false;
            this.listViewFileAssc.Location = new System.Drawing.Point(0, 0);
            this.listViewFileAssc.Name = "listViewFileAssc";
            this.listViewFileAssc.Size = new System.Drawing.Size(760, 219);
            this.listViewFileAssc.TabIndex = 0;
            this.listViewFileAssc.UseCompatibleStateImageBehavior = false;
            this.listViewFileAssc.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderExt
            // 
            this.columnHeaderExt.Text = "Extension Name";
            this.columnHeaderExt.Width = 138;
            // 
            // columnHeaderFileTypeDesc
            // 
            this.columnHeaderFileTypeDesc.Text = "Description";
            this.columnHeaderFileTypeDesc.Width = 600;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnAssociateNow);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 219);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(760, 66);
            this.panel2.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Image = global::OneClickZip.Properties.Resources.Exit_48;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(557, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(200, 56);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAssociateNow
            // 
            this.btnAssociateNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssociateNow.Image = global::OneClickZip.Properties.Resources.Download_Progress_48;
            this.btnAssociateNow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAssociateNow.Location = new System.Drawing.Point(181, 6);
            this.btnAssociateNow.Name = "btnAssociateNow";
            this.btnAssociateNow.Size = new System.Drawing.Size(370, 56);
            this.btnAssociateNow.TabIndex = 0;
            this.btnAssociateNow.Text = "Associate these extensions now on the system";
            this.btnAssociateNow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAssociateNow.UseVisualStyleBackColor = true;
            this.btnAssociateNow.Click += new System.EventHandler(this.btnAssociateNow_Click);
            // 
            // FileAssociationFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(760, 285);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileAssociationFrm";
            this.Text = "FileAssociation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileAssociationFrm_FormClosing);
            this.Load += new System.EventHandler(this.FileAssociationFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listViewFileAssc;
        private System.Windows.Forms.ColumnHeader columnHeaderExt;
        private System.Windows.Forms.ColumnHeader columnHeaderFileTypeDesc;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAssociateNow;
    }
}