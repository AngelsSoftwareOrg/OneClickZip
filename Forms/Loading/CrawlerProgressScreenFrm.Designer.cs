namespace OneClickZip.Forms.Loading
{
    partial class CrawlerProgressScreenFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrawlerProgressScreenFrm));
            this.txtBoxStatusLabel = new System.Windows.Forms.TextBox();
            this.progressBarStatus = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtBoxInfo = new System.Windows.Forms.TextBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxStatusLabel
            // 
            this.txtBoxStatusLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtBoxStatusLabel.Location = new System.Drawing.Point(0, 0);
            this.txtBoxStatusLabel.Multiline = true;
            this.txtBoxStatusLabel.Name = "txtBoxStatusLabel";
            this.txtBoxStatusLabel.ReadOnly = true;
            this.txtBoxStatusLabel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxStatusLabel.Size = new System.Drawing.Size(801, 148);
            this.txtBoxStatusLabel.TabIndex = 0;
            // 
            // progressBarStatus
            // 
            this.progressBarStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBarStatus.Location = new System.Drawing.Point(0, 148);
            this.progressBarStatus.Name = "progressBarStatus";
            this.progressBarStatus.Size = new System.Drawing.Size(801, 42);
            this.progressBarStatus.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::OneClickZip.Properties.Resources.stop_32;
            this.btnCancel.Location = new System.Drawing.Point(659, 206);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 61);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtBoxInfo
            // 
            this.txtBoxInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxInfo.Location = new System.Drawing.Point(3, 196);
            this.txtBoxInfo.Multiline = true;
            this.txtBoxInfo.Name = "txtBoxInfo";
            this.txtBoxInfo.ReadOnly = true;
            this.txtBoxInfo.Size = new System.Drawing.Size(620, 71);
            this.txtBoxInfo.TabIndex = 3;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.progressBarStatus);
            this.panelMain.Controls.Add(this.txtBoxStatusLabel);
            this.panelMain.Controls.Add(this.btnCancel);
            this.panelMain.Controls.Add(this.txtBoxInfo);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(801, 306);
            this.panelMain.TabIndex = 4;
            // 
            // CrawlerProgressScreenFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(801, 306);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CrawlerProgressScreenFrm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CrawlerProgressScreen_FormClosing);
            this.Load += new System.EventHandler(this.CrawlerProgressScreen_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxStatusLabel;
        private System.Windows.Forms.ProgressBar progressBarStatus;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtBoxInfo;
        private System.Windows.Forms.Panel panelMain;
    }
}