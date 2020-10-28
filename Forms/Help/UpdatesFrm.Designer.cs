namespace OneClickZip.Forms.Help
{
    partial class UpdatesFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdatesFrm));
            this.btnCheckForUpdate = new System.Windows.Forms.Button();
            this.panelRelease = new System.Windows.Forms.Panel();
            this.richTxtBoxMessage = new System.Windows.Forms.RichTextBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelRelease.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCheckForUpdate
            // 
            this.btnCheckForUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckForUpdate.Image = global::OneClickZip.Properties.Resources.Available_Updates_32px;
            this.btnCheckForUpdate.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCheckForUpdate.Location = new System.Drawing.Point(313, 17);
            this.btnCheckForUpdate.Name = "btnCheckForUpdate";
            this.btnCheckForUpdate.Size = new System.Drawing.Size(179, 71);
            this.btnCheckForUpdate.TabIndex = 0;
            this.btnCheckForUpdate.Text = "Check for Update";
            this.btnCheckForUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCheckForUpdate.UseVisualStyleBackColor = true;
            this.btnCheckForUpdate.Click += new System.EventHandler(this.btnCheckForUpdate_Click);
            // 
            // panelRelease
            // 
            this.panelRelease.Controls.Add(this.richTxtBoxMessage);
            this.panelRelease.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRelease.Location = new System.Drawing.Point(0, 0);
            this.panelRelease.Name = "panelRelease";
            this.panelRelease.Size = new System.Drawing.Size(678, 267);
            this.panelRelease.TabIndex = 1;
            // 
            // richTxtBoxMessage
            // 
            this.richTxtBoxMessage.BackColor = System.Drawing.Color.White;
            this.richTxtBoxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTxtBoxMessage.Location = new System.Drawing.Point(0, 0);
            this.richTxtBoxMessage.Name = "richTxtBoxMessage";
            this.richTxtBoxMessage.ReadOnly = true;
            this.richTxtBoxMessage.Size = new System.Drawing.Size(678, 267);
            this.richTxtBoxMessage.TabIndex = 0;
            this.richTxtBoxMessage.Text = "";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnExit);
            this.panelButtons.Controls.Add(this.btnCheckForUpdate);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 267);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(678, 100);
            this.panelButtons.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Image = global::OneClickZip.Properties.Resources.Exit_32;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(498, 17);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(168, 71);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // UpdatesFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(678, 367);
            this.Controls.Add(this.panelRelease);
            this.Controls.Add(this.panelButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "UpdatesFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Check for Updates";
            this.panelRelease.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCheckForUpdate;
        private System.Windows.Forms.Panel panelRelease;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RichTextBox richTxtBoxMessage;
    }
}