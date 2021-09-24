namespace OneClickZip.Forms.Options
{
    partial class OneClickProcessorFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OneClickProcessorFrm));
            this.btnStop = new System.Windows.Forms.Button();
            this.panelStatistic = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblArchivedSize = new System.Windows.Forms.Label();
            this.lblArchiveSize = new System.Windows.Forms.Label();
            this.lblFoldersCreated = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblFilesAdded = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalFoldersCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblEstimatedSize = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalFilesCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblElapsedTime = new System.Windows.Forms.Label();
            this.panelLogs = new System.Windows.Forms.Panel();
            this.listViewLogs = new System.Windows.Forms.ListView();
            this.columnTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLogs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.conMenuLogs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copySelectedLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.linkSaveLogs = new System.Windows.Forms.LinkLabel();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelProgress = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBoxCurrentAction = new System.Windows.Forms.TextBox();
            this.progressBarStatus = new System.Windows.Forms.ProgressBar();
            this.timerElapseTime = new System.Windows.Forms.Timer(this.components);
            this.panelStatistic.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelLogs.SuspendLayout();
            this.conMenuLogs.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelProgress.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Image = global::OneClickZip.Properties.Resources.stop_32;
            this.btnStop.Location = new System.Drawing.Point(741, 6);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(103, 69);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // panelStatistic
            // 
            this.panelStatistic.Controls.Add(this.groupBox1);
            this.panelStatistic.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStatistic.Location = new System.Drawing.Point(0, 0);
            this.panelStatistic.Name = "panelStatistic";
            this.panelStatistic.Size = new System.Drawing.Size(955, 96);
            this.panelStatistic.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblArchivedSize);
            this.groupBox1.Controls.Add(this.lblArchiveSize);
            this.groupBox1.Controls.Add(this.lblFoldersCreated);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.lblFilesAdded);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblTotalFoldersCount);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblEstimatedSize);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblTotalFilesCount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.lblElapsedTime);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(955, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Processing Details";
            // 
            // lblArchivedSize
            // 
            this.lblArchivedSize.AutoSize = true;
            this.lblArchivedSize.Location = new System.Drawing.Point(824, 25);
            this.lblArchivedSize.Name = "lblArchivedSize";
            this.lblArchivedSize.Size = new System.Drawing.Size(74, 17);
            this.lblArchivedSize.TabIndex = 12;
            this.lblArchivedSize.Text = "0.00 bytes";
            // 
            // lblArchiveSize
            // 
            this.lblArchiveSize.AutoSize = true;
            this.lblArchiveSize.Location = new System.Drawing.Point(658, 25);
            this.lblArchiveSize.Name = "lblArchiveSize";
            this.lblArchiveSize.Size = new System.Drawing.Size(169, 17);
            this.lblArchiveSize.TabIndex = 11;
            this.lblArchiveSize.Text = "Processed Archived Size:";
            // 
            // lblFoldersCreated
            // 
            this.lblFoldersCreated.AutoSize = true;
            this.lblFoldersCreated.Location = new System.Drawing.Point(525, 47);
            this.lblFoldersCreated.Name = "lblFoldersCreated";
            this.lblFoldersCreated.Size = new System.Drawing.Size(80, 17);
            this.lblFoldersCreated.TabIndex = 10;
            this.lblFoldersCreated.Text = "99% > 345 ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(402, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 17);
            this.label13.TabIndex = 9;
            this.label13.Text = "Folders Created: ";
            // 
            // lblFilesAdded
            // 
            this.lblFilesAdded.AutoSize = true;
            this.lblFilesAdded.Location = new System.Drawing.Point(525, 25);
            this.lblFilesAdded.Name = "lblFilesAdded";
            this.lblFilesAdded.Size = new System.Drawing.Size(76, 17);
            this.lblFilesAdded.TabIndex = 8;
            this.lblFilesAdded.Text = "18% > 567";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(402, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "Files Added: ";
            // 
            // lblTotalFoldersCount
            // 
            this.lblTotalFoldersCount.AutoSize = true;
            this.lblTotalFoldersCount.Location = new System.Drawing.Point(217, 47);
            this.lblTotalFoldersCount.Name = "lblTotalFoldersCount";
            this.lblTotalFoldersCount.Size = new System.Drawing.Size(52, 17);
            this.lblTotalFoldersCount.TabIndex = 6;
            this.lblTotalFoldersCount.Text = "56,789";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(208, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Estimated Uncompressed Size: ";
            // 
            // lblEstimatedSize
            // 
            this.lblEstimatedSize.AutoSize = true;
            this.lblEstimatedSize.Location = new System.Drawing.Point(217, 69);
            this.lblEstimatedSize.Name = "lblEstimatedSize";
            this.lblEstimatedSize.Size = new System.Drawing.Size(52, 17);
            this.lblEstimatedSize.TabIndex = 4;
            this.lblEstimatedSize.Text = "1.4 GB";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Total Folders Count: ";
            // 
            // lblTotalFilesCount
            // 
            this.lblTotalFilesCount.AutoSize = true;
            this.lblTotalFilesCount.Location = new System.Drawing.Point(217, 25);
            this.lblTotalFilesCount.Name = "lblTotalFilesCount";
            this.lblTotalFilesCount.Size = new System.Drawing.Size(52, 17);
            this.lblTotalFilesCount.TabIndex = 2;
            this.lblTotalFilesCount.Text = "12,345";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Total Files Count: ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(402, 69);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 17);
            this.label15.TabIndex = 0;
            this.label15.Text = "Elapsed Time: ";
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.AutoSize = true;
            this.lblElapsedTime.Location = new System.Drawing.Point(525, 69);
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(64, 17);
            this.lblElapsedTime.TabIndex = 0;
            this.lblElapsedTime.Text = "12:13:14";
            // 
            // panelLogs
            // 
            this.panelLogs.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelLogs.Controls.Add(this.listViewLogs);
            this.panelLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogs.Location = new System.Drawing.Point(0, 205);
            this.panelLogs.Name = "panelLogs";
            this.panelLogs.Size = new System.Drawing.Size(955, 256);
            this.panelLogs.TabIndex = 1;
            // 
            // listViewLogs
            // 
            this.listViewLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnTime,
            this.columnAction,
            this.columnLogs});
            this.listViewLogs.ContextMenuStrip = this.conMenuLogs;
            this.listViewLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLogs.FullRowSelect = true;
            this.listViewLogs.GridLines = true;
            this.listViewLogs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewLogs.HideSelection = false;
            this.listViewLogs.Location = new System.Drawing.Point(0, 0);
            this.listViewLogs.Name = "listViewLogs";
            this.listViewLogs.Size = new System.Drawing.Size(955, 256);
            this.listViewLogs.TabIndex = 0;
            this.listViewLogs.UseCompatibleStateImageBehavior = false;
            this.listViewLogs.View = System.Windows.Forms.View.Details;
            // 
            // columnTime
            // 
            this.columnTime.Text = "Date Time";
            this.columnTime.Width = 130;
            // 
            // columnAction
            // 
            this.columnAction.Text = "Action Taken";
            this.columnAction.Width = 100;
            // 
            // columnLogs
            // 
            this.columnLogs.Text = "Logs";
            this.columnLogs.Width = 1343;
            // 
            // conMenuLogs
            // 
            this.conMenuLogs.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.conMenuLogs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copySelectedLogToolStripMenuItem});
            this.conMenuLogs.Name = "conMenuLogs";
            this.conMenuLogs.Size = new System.Drawing.Size(203, 28);
            // 
            // copySelectedLogToolStripMenuItem
            // 
            this.copySelectedLogToolStripMenuItem.Name = "copySelectedLogToolStripMenuItem";
            this.copySelectedLogToolStripMenuItem.Size = new System.Drawing.Size(202, 24);
            this.copySelectedLogToolStripMenuItem.Text = "Copy Selected Log";
            this.copySelectedLogToolStripMenuItem.Click += new System.EventHandler(this.copySelectedLogToolStripMenuItem_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.linkSaveLogs);
            this.panelButtons.Controls.Add(this.btnStop);
            this.panelButtons.Controls.Add(this.btnExit);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 461);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(955, 78);
            this.panelButtons.TabIndex = 2;
            // 
            // linkSaveLogs
            // 
            this.linkSaveLogs.AutoSize = true;
            this.linkSaveLogs.Location = new System.Drawing.Point(3, 3);
            this.linkSaveLogs.Name = "linkSaveLogs";
            this.linkSaveLogs.Size = new System.Drawing.Size(75, 17);
            this.linkSaveLogs.TabIndex = 2;
            this.linkSaveLogs.TabStop = true;
            this.linkSaveLogs.Text = "Save Logs";
            this.linkSaveLogs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSaveLogs_LinkClicked);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = global::OneClickZip.Properties.Resources.Exit_32;
            this.btnExit.Location = new System.Drawing.Point(859, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 69);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelProgress
            // 
            this.panelProgress.Controls.Add(this.groupBox2);
            this.panelProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProgress.Location = new System.Drawing.Point(0, 96);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.Size = new System.Drawing.Size(955, 109);
            this.panelProgress.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBoxCurrentAction);
            this.groupBox2.Controls.Add(this.progressBarStatus);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(955, 109);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Processing Progress";
            // 
            // txtBoxCurrentAction
            // 
            this.txtBoxCurrentAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxCurrentAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxCurrentAction.Location = new System.Drawing.Point(12, 21);
            this.txtBoxCurrentAction.Multiline = true;
            this.txtBoxCurrentAction.Name = "txtBoxCurrentAction";
            this.txtBoxCurrentAction.ReadOnly = true;
            this.txtBoxCurrentAction.Size = new System.Drawing.Size(937, 45);
            this.txtBoxCurrentAction.TabIndex = 2;
            // 
            // progressBarStatus
            // 
            this.progressBarStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarStatus.Location = new System.Drawing.Point(9, 72);
            this.progressBarStatus.Name = "progressBarStatus";
            this.progressBarStatus.Size = new System.Drawing.Size(940, 29);
            this.progressBarStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarStatus.TabIndex = 1;
            // 
            // timerElapseTime
            // 
            this.timerElapseTime.Interval = 1000;
            this.timerElapseTime.Tick += new System.EventHandler(this.timerElapseTime_Tick);
            // 
            // OneClickProcessorFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 539);
            this.Controls.Add(this.panelLogs);
            this.Controls.Add(this.panelProgress);
            this.Controls.Add(this.panelStatistic);
            this.Controls.Add(this.panelButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OneClickProcessorFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "One Click Zip Creator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OneClickProcessor_FormClosed);
            this.Load += new System.EventHandler(this.OneClickProcessor_Load);
            this.panelStatistic.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelLogs.ResumeLayout(false);
            this.conMenuLogs.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.panelProgress.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelStatistic;
        private System.Windows.Forms.Panel panelLogs;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblFoldersCreated;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblFilesAdded;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotalFoldersCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblEstimatedSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalFilesCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblElapsedTime;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panelProgress;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar progressBarStatus;
        private System.Windows.Forms.TextBox txtBoxCurrentAction;
        private System.Windows.Forms.Timer timerElapseTime;
        private System.Windows.Forms.ListView listViewLogs;
        private System.Windows.Forms.ColumnHeader columnTime;
        private System.Windows.Forms.ColumnHeader columnLogs;
        private System.Windows.Forms.ContextMenuStrip conMenuLogs;
        private System.Windows.Forms.ToolStripMenuItem copySelectedLogToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnAction;
        private System.Windows.Forms.LinkLabel linkSaveLogs;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblArchivedSize;
        private System.Windows.Forms.Label lblArchiveSize;
    }
}