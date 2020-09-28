namespace OneClickZip.Forms.Options
{
    partial class OneClickProcessor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OneClickProcessor));
            this.panelStatistic = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelStatistic
            // 
            this.panelStatistic.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStatistic.Location = new System.Drawing.Point(0, 0);
            this.panelStatistic.Name = "panelStatistic";
            this.panelStatistic.Size = new System.Drawing.Size(955, 196);
            this.panelStatistic.TabIndex = 0;
            this.panelStatistic.Paint += new System.Windows.Forms.PaintEventHandler(this.panelStatistic_Paint);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(92, 160);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(38, 329);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 100);
            this.panel3.TabIndex = 2;
            // 
            // OneClickProcessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 539);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelStatistic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OneClickProcessor";
            this.Text = "One Click Zip Creator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelStatistic;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}