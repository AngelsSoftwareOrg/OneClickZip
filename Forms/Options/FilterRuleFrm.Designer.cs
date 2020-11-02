namespace OneClickZip.Forms.Options
{
    partial class FilterRuleFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterRuleFrm));
            this.tabPagePreview = new System.Windows.Forms.TabPage();
            this.panelListViewLog = new System.Windows.Forms.Panel();
            this.listViewLogs = new System.Windows.Forms.ListView();
            this.colHeadSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadAppliedRule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadActionTaken = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadEvalPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelProcessLabel = new System.Windows.Forms.Panel();
            this.txtBoxProcessLog = new System.Windows.Forms.TextBox();
            this.tabPageFilterRule = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBoxInclude = new System.Windows.Forms.GroupBox();
            this.txtBoxInclude = new System.Windows.Forms.TextBox();
            this.groupBoxExclude = new System.Windows.Forms.GroupBox();
            this.txtBoxExclude = new System.Windows.Forms.TextBox();
            this.groupBoxHelp = new System.Windows.Forms.GroupBox();
            this.txtBoxHelp = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownMaxFileSize = new System.Windows.Forms.NumericUpDown();
            this.lblFileMaxSizeReadable = new System.Windows.Forms.Label();
            this.checkBoxHasMaxFileSize = new System.Windows.Forms.CheckBox();
            this.numericUpDownMinFileSize = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLastXXDays = new System.Windows.Forms.NumericUpDown();
            this.comboBoxTimeSpanOption = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFileMinSizeReadable = new System.Windows.Forms.Label();
            this.checkBoxHasMinFileSize = new System.Windows.Forms.CheckBox();
            this.checkBoxIncludeEmptyFolder = new System.Windows.Forms.CheckBox();
            this.btnTargetDirBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxTargetDir = new System.Windows.Forms.TextBox();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.panelTab = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnSaveLog = new System.Windows.Forms.Button();
            this.btnStopPreview = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancelExit = new System.Windows.Forms.Button();
            this.btnSaveAndExit = new System.Windows.Forms.Button();
            this.btnStartPreview = new System.Windows.Forms.Button();
            this.tabPagePreview.SuspendLayout();
            this.panelListViewLog.SuspendLayout();
            this.panelProcessLabel.SuspendLayout();
            this.tabPageFilterRule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBoxInclude.SuspendLayout();
            this.groupBoxExclude.SuspendLayout();
            this.groupBoxHelp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxFileSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinFileSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLastXXDays)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.panelTab.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPagePreview
            // 
            this.tabPagePreview.Controls.Add(this.panelListViewLog);
            this.tabPagePreview.Controls.Add(this.panelProcessLabel);
            this.tabPagePreview.Location = new System.Drawing.Point(4, 29);
            this.tabPagePreview.Name = "tabPagePreview";
            this.tabPagePreview.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePreview.Size = new System.Drawing.Size(1156, 534);
            this.tabPagePreview.TabIndex = 1;
            this.tabPagePreview.Text = "Preview & Simulation";
            this.tabPagePreview.UseVisualStyleBackColor = true;
            this.tabPagePreview.Enter += new System.EventHandler(this.tabPagePreview_Enter);
            // 
            // panelListViewLog
            // 
            this.panelListViewLog.Controls.Add(this.listViewLogs);
            this.panelListViewLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelListViewLog.Location = new System.Drawing.Point(3, 64);
            this.panelListViewLog.Name = "panelListViewLog";
            this.panelListViewLog.Size = new System.Drawing.Size(1150, 467);
            this.panelListViewLog.TabIndex = 1;
            // 
            // listViewLogs
            // 
            this.listViewLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeadSeq,
            this.colHeadAppliedRule,
            this.colHeadActionTaken,
            this.colHeadEvalPath});
            this.listViewLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewLogs.FullRowSelect = true;
            this.listViewLogs.GridLines = true;
            this.listViewLogs.HideSelection = false;
            this.listViewLogs.Location = new System.Drawing.Point(0, 0);
            this.listViewLogs.Name = "listViewLogs";
            this.listViewLogs.Size = new System.Drawing.Size(1150, 467);
            this.listViewLogs.TabIndex = 0;
            this.listViewLogs.UseCompatibleStateImageBehavior = false;
            this.listViewLogs.View = System.Windows.Forms.View.Details;
            // 
            // colHeadSeq
            // 
            this.colHeadSeq.Text = "Sequence";
            this.colHeadSeq.Width = 80;
            // 
            // colHeadAppliedRule
            // 
            this.colHeadAppliedRule.Text = "Hit Filter / Rule";
            this.colHeadAppliedRule.Width = 200;
            // 
            // colHeadActionTaken
            // 
            this.colHeadActionTaken.Text = "Action Taken";
            this.colHeadActionTaken.Width = 120;
            // 
            // colHeadEvalPath
            // 
            this.colHeadEvalPath.Text = "Evaluated Path / File";
            this.colHeadEvalPath.Width = 700;
            // 
            // panelProcessLabel
            // 
            this.panelProcessLabel.Controls.Add(this.txtBoxProcessLog);
            this.panelProcessLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProcessLabel.Location = new System.Drawing.Point(3, 3);
            this.panelProcessLabel.Name = "panelProcessLabel";
            this.panelProcessLabel.Size = new System.Drawing.Size(1150, 61);
            this.panelProcessLabel.TabIndex = 0;
            // 
            // txtBoxProcessLog
            // 
            this.txtBoxProcessLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxProcessLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxProcessLog.Location = new System.Drawing.Point(0, 0);
            this.txtBoxProcessLog.Multiline = true;
            this.txtBoxProcessLog.Name = "txtBoxProcessLog";
            this.txtBoxProcessLog.ReadOnly = true;
            this.txtBoxProcessLog.Size = new System.Drawing.Size(1150, 61);
            this.txtBoxProcessLog.TabIndex = 0;
            // 
            // tabPageFilterRule
            // 
            this.tabPageFilterRule.Controls.Add(this.splitContainer1);
            this.tabPageFilterRule.Controls.Add(this.groupBox1);
            this.tabPageFilterRule.Location = new System.Drawing.Point(4, 29);
            this.tabPageFilterRule.Name = "tabPageFilterRule";
            this.tabPageFilterRule.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFilterRule.Size = new System.Drawing.Size(1156, 534);
            this.tabPageFilterRule.TabIndex = 0;
            this.tabPageFilterRule.Text = "Filter Rule";
            this.tabPageFilterRule.UseVisualStyleBackColor = true;
            this.tabPageFilterRule.Enter += new System.EventHandler(this.tabPageFilterRule_Enter);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 139);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxHelp);
            this.splitContainer1.Size = new System.Drawing.Size(1150, 392);
            this.splitContainer1.SplitterDistance = 600;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBoxInclude);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBoxExclude);
            this.splitContainer2.Size = new System.Drawing.Size(600, 392);
            this.splitContainer2.SplitterDistance = 250;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBoxInclude
            // 
            this.groupBoxInclude.Controls.Add(this.txtBoxInclude);
            this.groupBoxInclude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxInclude.Location = new System.Drawing.Point(0, 0);
            this.groupBoxInclude.Name = "groupBoxInclude";
            this.groupBoxInclude.Size = new System.Drawing.Size(250, 392);
            this.groupBoxInclude.TabIndex = 0;
            this.groupBoxInclude.TabStop = false;
            this.groupBoxInclude.Text = "Include Files and Folders";
            // 
            // txtBoxInclude
            // 
            this.txtBoxInclude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxInclude.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxInclude.Location = new System.Drawing.Point(3, 23);
            this.txtBoxInclude.Multiline = true;
            this.txtBoxInclude.Name = "txtBoxInclude";
            this.txtBoxInclude.Size = new System.Drawing.Size(244, 366);
            this.txtBoxInclude.TabIndex = 1;
            // 
            // groupBoxExclude
            // 
            this.groupBoxExclude.Controls.Add(this.txtBoxExclude);
            this.groupBoxExclude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxExclude.Location = new System.Drawing.Point(0, 0);
            this.groupBoxExclude.Name = "groupBoxExclude";
            this.groupBoxExclude.Size = new System.Drawing.Size(346, 392);
            this.groupBoxExclude.TabIndex = 0;
            this.groupBoxExclude.TabStop = false;
            this.groupBoxExclude.Text = "Exclude Files and Folders";
            // 
            // txtBoxExclude
            // 
            this.txtBoxExclude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxExclude.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxExclude.Location = new System.Drawing.Point(3, 23);
            this.txtBoxExclude.Multiline = true;
            this.txtBoxExclude.Name = "txtBoxExclude";
            this.txtBoxExclude.Size = new System.Drawing.Size(340, 366);
            this.txtBoxExclude.TabIndex = 0;
            // 
            // groupBoxHelp
            // 
            this.groupBoxHelp.Controls.Add(this.txtBoxHelp);
            this.groupBoxHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxHelp.Location = new System.Drawing.Point(0, 0);
            this.groupBoxHelp.Name = "groupBoxHelp";
            this.groupBoxHelp.Size = new System.Drawing.Size(546, 392);
            this.groupBoxHelp.TabIndex = 0;
            this.groupBoxHelp.TabStop = false;
            this.groupBoxHelp.Text = "Filter Help";
            // 
            // txtBoxHelp
            // 
            this.txtBoxHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxHelp.Location = new System.Drawing.Point(3, 23);
            this.txtBoxHelp.Multiline = true;
            this.txtBoxHelp.Name = "txtBoxHelp";
            this.txtBoxHelp.ReadOnly = true;
            this.txtBoxHelp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBoxHelp.Size = new System.Drawing.Size(540, 366);
            this.txtBoxHelp.TabIndex = 1;
            this.txtBoxHelp.WordWrap = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownMaxFileSize);
            this.groupBox1.Controls.Add(this.lblFileMaxSizeReadable);
            this.groupBox1.Controls.Add(this.checkBoxHasMaxFileSize);
            this.groupBox1.Controls.Add(this.numericUpDownMinFileSize);
            this.groupBox1.Controls.Add(this.numericUpDownLastXXDays);
            this.groupBox1.Controls.Add(this.comboBoxTimeSpanOption);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblFileMinSizeReadable);
            this.groupBox1.Controls.Add(this.checkBoxHasMinFileSize);
            this.groupBox1.Controls.Add(this.checkBoxIncludeEmptyFolder);
            this.groupBox1.Controls.Add(this.btnTargetDirBrowse);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtBoxTargetDir);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1150, 136);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // numericUpDownMaxFileSize
            // 
            this.numericUpDownMaxFileSize.Increment = new decimal(new int[] {
            5120,
            0,
            0,
            0});
            this.numericUpDownMaxFileSize.Location = new System.Drawing.Point(383, 106);
            this.numericUpDownMaxFileSize.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.numericUpDownMaxFileSize.Name = "numericUpDownMaxFileSize";
            this.numericUpDownMaxFileSize.Size = new System.Drawing.Size(313, 22);
            this.numericUpDownMaxFileSize.TabIndex = 17;
            this.numericUpDownMaxFileSize.ValueChanged += new System.EventHandler(this.numericUpDownMaxFileSize_ValueChanged);
            this.numericUpDownMaxFileSize.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownMaxFileSize_KeyUp);
            // 
            // lblFileMaxSizeReadable
            // 
            this.lblFileMaxSizeReadable.AutoSize = true;
            this.lblFileMaxSizeReadable.Location = new System.Drawing.Point(702, 109);
            this.lblFileMaxSizeReadable.Name = "lblFileMaxSizeReadable";
            this.lblFileMaxSizeReadable.Size = new System.Drawing.Size(74, 17);
            this.lblFileMaxSizeReadable.TabIndex = 16;
            this.lblFileMaxSizeReadable.Text = "0.00 bytes";
            // 
            // checkBoxHasMaxFileSize
            // 
            this.checkBoxHasMaxFileSize.AutoSize = true;
            this.checkBoxHasMaxFileSize.Location = new System.Drawing.Point(195, 106);
            this.checkBoxHasMaxFileSize.Name = "checkBoxHasMaxFileSize";
            this.checkBoxHasMaxFileSize.Size = new System.Drawing.Size(190, 21);
            this.checkBoxHasMaxFileSize.TabIndex = 15;
            this.checkBoxHasMaxFileSize.Text = "Maximum file size (In bits)";
            this.checkBoxHasMaxFileSize.UseVisualStyleBackColor = true;
            this.checkBoxHasMaxFileSize.CheckedChanged += new System.EventHandler(this.checkBoxHasMaxFileSize_CheckedChanged);
            // 
            // numericUpDownMinFileSize
            // 
            this.numericUpDownMinFileSize.Increment = new decimal(new int[] {
            5120,
            0,
            0,
            0});
            this.numericUpDownMinFileSize.Location = new System.Drawing.Point(383, 78);
            this.numericUpDownMinFileSize.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.numericUpDownMinFileSize.Name = "numericUpDownMinFileSize";
            this.numericUpDownMinFileSize.Size = new System.Drawing.Size(313, 22);
            this.numericUpDownMinFileSize.TabIndex = 14;
            this.numericUpDownMinFileSize.ValueChanged += new System.EventHandler(this.numericUpDownFileSize_ValueChanged);
            this.numericUpDownMinFileSize.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownFileSize_KeyUp);
            // 
            // numericUpDownLastXXDays
            // 
            this.numericUpDownLastXXDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownLastXXDays.Location = new System.Drawing.Point(1006, 105);
            this.numericUpDownLastXXDays.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownLastXXDays.Name = "numericUpDownLastXXDays";
            this.numericUpDownLastXXDays.Size = new System.Drawing.Size(141, 22);
            this.numericUpDownLastXXDays.TabIndex = 13;
            // 
            // comboBoxTimeSpanOption
            // 
            this.comboBoxTimeSpanOption.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxTimeSpanOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTimeSpanOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxTimeSpanOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTimeSpanOption.FormattingEnabled = true;
            this.comboBoxTimeSpanOption.Location = new System.Drawing.Point(1006, 78);
            this.comboBoxTimeSpanOption.Name = "comboBoxTimeSpanOption";
            this.comboBoxTimeSpanOption.Size = new System.Drawing.Size(138, 26);
            this.comboBoxTimeSpanOption.TabIndex = 12;
            this.comboBoxTimeSpanOption.SelectedValueChanged += new System.EventHandler(this.comboBoxTimeSpanOption_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(920, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Time Span:";
            // 
            // lblFileMinSizeReadable
            // 
            this.lblFileMinSizeReadable.AutoSize = true;
            this.lblFileMinSizeReadable.Location = new System.Drawing.Point(702, 81);
            this.lblFileMinSizeReadable.Name = "lblFileMinSizeReadable";
            this.lblFileMinSizeReadable.Size = new System.Drawing.Size(74, 17);
            this.lblFileMinSizeReadable.TabIndex = 9;
            this.lblFileMinSizeReadable.Text = "0.00 bytes";
            // 
            // checkBoxHasMinFileSize
            // 
            this.checkBoxHasMinFileSize.AutoSize = true;
            this.checkBoxHasMinFileSize.Location = new System.Drawing.Point(195, 78);
            this.checkBoxHasMinFileSize.Name = "checkBoxHasMinFileSize";
            this.checkBoxHasMinFileSize.Size = new System.Drawing.Size(187, 21);
            this.checkBoxHasMinFileSize.TabIndex = 7;
            this.checkBoxHasMinFileSize.Text = "Minimum file size (In bits)";
            this.checkBoxHasMinFileSize.UseVisualStyleBackColor = true;
            this.checkBoxHasMinFileSize.CheckedChanged += new System.EventHandler(this.checkBoxHasMinFileSize_CheckedChanged);
            // 
            // checkBoxIncludeEmptyFolder
            // 
            this.checkBoxIncludeEmptyFolder.AutoSize = true;
            this.checkBoxIncludeEmptyFolder.Checked = true;
            this.checkBoxIncludeEmptyFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIncludeEmptyFolder.Location = new System.Drawing.Point(9, 78);
            this.checkBoxIncludeEmptyFolder.Name = "checkBoxIncludeEmptyFolder";
            this.checkBoxIncludeEmptyFolder.Size = new System.Drawing.Size(176, 21);
            this.checkBoxIncludeEmptyFolder.TabIndex = 6;
            this.checkBoxIncludeEmptyFolder.Text = "Include empty Folders?";
            this.checkBoxIncludeEmptyFolder.UseVisualStyleBackColor = true;
            // 
            // btnTargetDirBrowse
            // 
            this.btnTargetDirBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTargetDirBrowse.Location = new System.Drawing.Point(1006, 38);
            this.btnTargetDirBrowse.Name = "btnTargetDirBrowse";
            this.btnTargetDirBrowse.Size = new System.Drawing.Size(143, 25);
            this.btnTargetDirBrowse.TabIndex = 5;
            this.btnTargetDirBrowse.Text = "Browse";
            this.btnTargetDirBrowse.UseVisualStyleBackColor = true;
            this.btnTargetDirBrowse.Click += new System.EventHandler(this.btnTargetDirBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Target Directory";
            // 
            // txtBoxTargetDir
            // 
            this.txtBoxTargetDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxTargetDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxTargetDir.Location = new System.Drawing.Point(9, 39);
            this.txtBoxTargetDir.Name = "txtBoxTargetDir";
            this.txtBoxTargetDir.Size = new System.Drawing.Size(991, 24);
            this.txtBoxTargetDir.TabIndex = 3;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageFilterRule);
            this.tabControlMain.Controls.Add(this.tabPagePreview);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1164, 567);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.Click += new System.EventHandler(this.tabControlMain_Click);
            // 
            // panelTab
            // 
            this.panelTab.Controls.Add(this.tabControlMain);
            this.panelTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTab.Location = new System.Drawing.Point(0, 0);
            this.panelTab.Name = "panelTab";
            this.panelTab.Size = new System.Drawing.Size(1164, 567);
            this.panelTab.TabIndex = 1;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnSaveLog);
            this.panelButtons.Controls.Add(this.btnStopPreview);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnCancelExit);
            this.panelButtons.Controls.Add(this.btnSaveAndExit);
            this.panelButtons.Controls.Add(this.btnStartPreview);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 567);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1164, 65);
            this.panelButtons.TabIndex = 2;
            // 
            // btnSaveLog
            // 
            this.btnSaveLog.Image = global::OneClickZip.Properties.Resources.Save_icon_24px;
            this.btnSaveLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveLog.Location = new System.Drawing.Point(180, 4);
            this.btnSaveLog.Name = "btnSaveLog";
            this.btnSaveLog.Size = new System.Drawing.Size(127, 56);
            this.btnSaveLog.TabIndex = 4;
            this.btnSaveLog.Text = "Save Logs";
            this.btnSaveLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveLog.UseVisualStyleBackColor = true;
            this.btnSaveLog.Visible = false;
            this.btnSaveLog.Click += new System.EventHandler(this.btnSaveLog_Click);
            // 
            // btnStopPreview
            // 
            this.btnStopPreview.Image = global::OneClickZip.Properties.Resources.Button_Stop_icon_24px;
            this.btnStopPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStopPreview.Location = new System.Drawing.Point(7, 4);
            this.btnStopPreview.Name = "btnStopPreview";
            this.btnStopPreview.Size = new System.Drawing.Size(167, 56);
            this.btnStopPreview.TabIndex = 3;
            this.btnStopPreview.Text = "Stop Preview / Simulation";
            this.btnStopPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStopPreview.UseVisualStyleBackColor = true;
            this.btnStopPreview.Visible = false;
            this.btnStopPreview.Click += new System.EventHandler(this.btnStopPreview_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::OneClickZip.Properties.Resources.save_v1_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(654, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(161, 56);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancelExit
            // 
            this.btnCancelExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelExit.Image = global::OneClickZip.Properties.Resources.Exit_32;
            this.btnCancelExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelExit.Location = new System.Drawing.Point(1013, 4);
            this.btnCancelExit.Name = "btnCancelExit";
            this.btnCancelExit.Size = new System.Drawing.Size(147, 56);
            this.btnCancelExit.TabIndex = 1;
            this.btnCancelExit.Text = "Exit";
            this.btnCancelExit.UseVisualStyleBackColor = true;
            this.btnCancelExit.Click += new System.EventHandler(this.btnCancelExit_Click);
            // 
            // btnSaveAndExit
            // 
            this.btnSaveAndExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndExit.Image = global::OneClickZip.Properties.Resources.save_and_exit_32;
            this.btnSaveAndExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveAndExit.Location = new System.Drawing.Point(821, 4);
            this.btnSaveAndExit.Name = "btnSaveAndExit";
            this.btnSaveAndExit.Size = new System.Drawing.Size(186, 56);
            this.btnSaveAndExit.TabIndex = 0;
            this.btnSaveAndExit.Text = "Save and Exit";
            this.btnSaveAndExit.UseVisualStyleBackColor = true;
            this.btnSaveAndExit.Click += new System.EventHandler(this.btnSaveAndExit_Click);
            // 
            // btnStartPreview
            // 
            this.btnStartPreview.Image = global::OneClickZip.Properties.Resources.Button_Play_icon_24px;
            this.btnStartPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartPreview.Location = new System.Drawing.Point(7, 4);
            this.btnStartPreview.Name = "btnStartPreview";
            this.btnStartPreview.Size = new System.Drawing.Size(167, 56);
            this.btnStartPreview.TabIndex = 5;
            this.btnStartPreview.Text = "Start Preview / Simulation";
            this.btnStartPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartPreview.UseVisualStyleBackColor = true;
            this.btnStartPreview.Visible = false;
            this.btnStartPreview.Click += new System.EventHandler(this.btnStartPreview_Click);
            // 
            // FilterRuleFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelExit;
            this.ClientSize = new System.Drawing.Size(1164, 632);
            this.Controls.Add(this.panelTab);
            this.Controls.Add(this.panelButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FilterRuleFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Files and Folders Filter Rule";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FilterRuleFrm_FormClosed);
            this.Load += new System.EventHandler(this.FilterRuleFrm_Load);
            this.Shown += new System.EventHandler(this.FilterRuleFrm_Shown);
            this.tabPagePreview.ResumeLayout(false);
            this.panelListViewLog.ResumeLayout(false);
            this.panelProcessLabel.ResumeLayout(false);
            this.panelProcessLabel.PerformLayout();
            this.tabPageFilterRule.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBoxInclude.ResumeLayout(false);
            this.groupBoxInclude.PerformLayout();
            this.groupBoxExclude.ResumeLayout(false);
            this.groupBoxExclude.PerformLayout();
            this.groupBoxHelp.ResumeLayout(false);
            this.groupBoxHelp.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxFileSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinFileSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLastXXDays)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.panelTab.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPagePreview;
        private System.Windows.Forms.TabPage tabPageFilterRule;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.Panel panelTab;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnCancelExit;
        private System.Windows.Forms.Button btnSaveAndExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTargetDirBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxTargetDir;
        private System.Windows.Forms.CheckBox checkBoxIncludeEmptyFolder;
        private System.Windows.Forms.CheckBox checkBoxHasMinFileSize;
        private System.Windows.Forms.Label lblFileMinSizeReadable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTimeSpanOption;
        private System.Windows.Forms.NumericUpDown numericUpDownLastXXDays;
        private System.Windows.Forms.NumericUpDown numericUpDownMinFileSize;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxFileSize;
        private System.Windows.Forms.Label lblFileMaxSizeReadable;
        private System.Windows.Forms.CheckBox checkBoxHasMaxFileSize;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBoxInclude;
        private System.Windows.Forms.GroupBox groupBoxExclude;
        private System.Windows.Forms.GroupBox groupBoxHelp;
        private System.Windows.Forms.TextBox txtBoxExclude;
        private System.Windows.Forms.TextBox txtBoxInclude;
        private System.Windows.Forms.TextBox txtBoxHelp;
        private System.Windows.Forms.Panel panelListViewLog;
        private System.Windows.Forms.Panel panelProcessLabel;
        private System.Windows.Forms.TextBox txtBoxProcessLog;
        private System.Windows.Forms.Button btnStopPreview;
        private System.Windows.Forms.ListView listViewLogs;
        private System.Windows.Forms.ColumnHeader colHeadSeq;
        private System.Windows.Forms.ColumnHeader colHeadAppliedRule;
        private System.Windows.Forms.ColumnHeader colHeadActionTaken;
        private System.Windows.Forms.ColumnHeader colHeadEvalPath;
        private System.Windows.Forms.Button btnSaveLog;
        private System.Windows.Forms.Button btnStartPreview;
    }
}