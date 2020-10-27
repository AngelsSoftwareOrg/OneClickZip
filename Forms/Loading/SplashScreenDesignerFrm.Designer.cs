namespace OneClickZip.Forms.Loading
{
    partial class SplashScreenDesignerFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreenDesignerFrm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelImage = new System.Windows.Forms.Panel();
            this.panelLoadingMsg = new System.Windows.Forms.Panel();
            this.txtBoxStatMsg = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelImage.SuspendLayout();
            this.panelLoadingMsg.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(515, 348);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelImage
            // 
            this.panelImage.Controls.Add(this.pictureBox1);
            this.panelImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelImage.Location = new System.Drawing.Point(0, 0);
            this.panelImage.Name = "panelImage";
            this.panelImage.Size = new System.Drawing.Size(515, 348);
            this.panelImage.TabIndex = 1;
            // 
            // panelLoadingMsg
            // 
            this.panelLoadingMsg.Controls.Add(this.txtBoxStatMsg);
            this.panelLoadingMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLoadingMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelLoadingMsg.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.panelLoadingMsg.Location = new System.Drawing.Point(0, 354);
            this.panelLoadingMsg.Name = "panelLoadingMsg";
            this.panelLoadingMsg.Size = new System.Drawing.Size(515, 33);
            this.panelLoadingMsg.TabIndex = 2;
            // 
            // txtBoxStatMsg
            // 
            this.txtBoxStatMsg.BackColor = System.Drawing.SystemColors.Window;
            this.txtBoxStatMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxStatMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxStatMsg.Enabled = false;
            this.txtBoxStatMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxStatMsg.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtBoxStatMsg.Location = new System.Drawing.Point(0, 0);
            this.txtBoxStatMsg.Multiline = true;
            this.txtBoxStatMsg.Name = "txtBoxStatMsg";
            this.txtBoxStatMsg.ReadOnly = true;
            this.txtBoxStatMsg.Size = new System.Drawing.Size(515, 33);
            this.txtBoxStatMsg.TabIndex = 1;
            this.txtBoxStatMsg.Text = "Loading...";
            this.txtBoxStatMsg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SplashScreenDesignerFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(515, 387);
            this.ControlBox = false;
            this.Controls.Add(this.panelLoadingMsg);
            this.Controls.Add(this.panelImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SplashScreenDesignerFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreenDesigner";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.SplashScreenDesignerFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelImage.ResumeLayout(false);
            this.panelLoadingMsg.ResumeLayout(false);
            this.panelLoadingMsg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.Panel panelLoadingMsg;
        private System.Windows.Forms.TextBox txtBoxStatMsg;
    }
}