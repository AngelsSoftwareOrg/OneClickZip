namespace OneClickZip
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.treeViewImageIndex = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeViewImageIndex
            // 
            this.treeViewImageIndex.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeViewImageIndex.Location = new System.Drawing.Point(0, 0);
            this.treeViewImageIndex.Name = "treeViewImageIndex";
            this.treeViewImageIndex.Size = new System.Drawing.Size(417, 545);
            this.treeViewImageIndex.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 545);
            this.Controls.Add(this.treeViewImageIndex);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "One Click Zip";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewImageIndex;
    }
}

