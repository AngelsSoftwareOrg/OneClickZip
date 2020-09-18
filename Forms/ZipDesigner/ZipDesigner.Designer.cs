namespace OneClickZip
{
    partial class ZipDesigner
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
            this.splitContainerFormMain = new System.Windows.Forms.SplitContainer();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnCreateFileName = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.splitContainerExplorers = new System.Windows.Forms.SplitContainer();
            this.splitContainerSearchDirExp = new System.Windows.Forms.SplitContainer();
            this.panel6 = new System.Windows.Forms.Panel();
            this.expTreeSearchDir = new ExpTreeLib.ExpTree();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.listViewSearchDirExp = new System.Windows.Forms.ListView();
            this.columnExpFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnExpDateModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnExpSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnExpType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnExpDateCreated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel7 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainerZipDesigner = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeViewZipDesigner = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRemoveSelectedNode = new System.Windows.Forms.Button();
            this.btnZipClear = new System.Windows.Forms.Button();
            this.btnZipFileAddFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listViewZipDesignFiles = new System.Windows.Forms.ListView();
            this.columnZipMdlFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnZipMdlDateModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnZipMdlSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnZipMdlDateCreated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnZipMdlType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnAddSelected = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFormMain)).BeginInit();
            this.splitContainerFormMain.Panel1.SuspendLayout();
            this.splitContainerFormMain.Panel2.SuspendLayout();
            this.splitContainerFormMain.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerExplorers)).BeginInit();
            this.splitContainerExplorers.Panel1.SuspendLayout();
            this.splitContainerExplorers.Panel2.SuspendLayout();
            this.splitContainerExplorers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSearchDirExp)).BeginInit();
            this.splitContainerSearchDirExp.Panel1.SuspendLayout();
            this.splitContainerSearchDirExp.Panel2.SuspendLayout();
            this.splitContainerSearchDirExp.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerZipDesigner)).BeginInit();
            this.splitContainerZipDesigner.Panel1.SuspendLayout();
            this.splitContainerZipDesigner.Panel2.SuspendLayout();
            this.splitContainerZipDesigner.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerFormMain
            // 
            this.splitContainerFormMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFormMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerFormMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerFormMain.Name = "splitContainerFormMain";
            // 
            // splitContainerFormMain.Panel1
            // 
            this.splitContainerFormMain.Panel1.Controls.Add(this.panel9);
            // 
            // splitContainerFormMain.Panel2
            // 
            this.splitContainerFormMain.Panel2.Controls.Add(this.splitContainerExplorers);
            this.splitContainerFormMain.Size = new System.Drawing.Size(1151, 614);
            this.splitContainerFormMain.SplitterDistance = 349;
            this.splitContainerFormMain.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnCreateFileName);
            this.panel9.Controls.Add(this.txtFileName);
            this.panel9.Controls.Add(this.label5);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(349, 219);
            this.panel9.TabIndex = 0;
            // 
            // btnCreateFileName
            // 
            this.btnCreateFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateFileName.Location = new System.Drawing.Point(196, 70);
            this.btnCreateFileName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateFileName.Name = "btnCreateFileName";
            this.btnCreateFileName.Size = new System.Drawing.Size(149, 28);
            this.btnCreateFileName.TabIndex = 4;
            this.btnCreateFileName.Text = "Create a File Name";
            this.btnCreateFileName.UseVisualStyleBackColor = true;
            this.btnCreateFileName.Click += new System.EventHandler(this.btnCreateFileName_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtFileName.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtFileName.Enabled = false;
            this.txtFileName.Location = new System.Drawing.Point(5, 38);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(339, 22);
            this.txtFileName.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Zip File Name : ";
            // 
            // splitContainerExplorers
            // 
            this.splitContainerExplorers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerExplorers.Location = new System.Drawing.Point(0, 0);
            this.splitContainerExplorers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerExplorers.Name = "splitContainerExplorers";
            this.splitContainerExplorers.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerExplorers.Panel1
            // 
            this.splitContainerExplorers.Panel1.Controls.Add(this.splitContainerSearchDirExp);
            // 
            // splitContainerExplorers.Panel2
            // 
            this.splitContainerExplorers.Panel2.Controls.Add(this.splitContainerZipDesigner);
            this.splitContainerExplorers.Size = new System.Drawing.Size(798, 614);
            this.splitContainerExplorers.SplitterDistance = 238;
            this.splitContainerExplorers.TabIndex = 0;
            // 
            // splitContainerSearchDirExp
            // 
            this.splitContainerSearchDirExp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSearchDirExp.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSearchDirExp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerSearchDirExp.Name = "splitContainerSearchDirExp";
            // 
            // splitContainerSearchDirExp.Panel1
            // 
            this.splitContainerSearchDirExp.Panel1.Controls.Add(this.panel6);
            this.splitContainerSearchDirExp.Panel1.Controls.Add(this.panel5);
            // 
            // splitContainerSearchDirExp.Panel2
            // 
            this.splitContainerSearchDirExp.Panel2.Controls.Add(this.panel8);
            this.splitContainerSearchDirExp.Panel2.Controls.Add(this.panel7);
            this.splitContainerSearchDirExp.Size = new System.Drawing.Size(798, 238);
            this.splitContainerSearchDirExp.SplitterDistance = 156;
            this.splitContainerSearchDirExp.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.expTreeSearchDir);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 36);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(156, 202);
            this.panel6.TabIndex = 3;
            // 
            // expTreeSearchDir
            // 
            this.expTreeSearchDir.AllowFolderRename = false;
            this.expTreeSearchDir.Cursor = System.Windows.Forms.Cursors.Default;
            this.expTreeSearchDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expTreeSearchDir.Location = new System.Drawing.Point(0, 0);
            this.expTreeSearchDir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.expTreeSearchDir.Name = "expTreeSearchDir";
            this.expTreeSearchDir.ShowRootLines = false;
            this.expTreeSearchDir.Size = new System.Drawing.Size(156, 202);
            this.expTreeSearchDir.StartUpDirectory = ExpTreeLib.ExpTree.StartDir.Desktop;
            this.expTreeSearchDir.TabIndex = 2;
            this.expTreeSearchDir.StartUpDirectoryChanged += new ExpTreeLib.ExpTree.StartUpDirectoryChangedEventHandler(this.ExpTreeSearchDir_StartUpDirectoryChanged);
            this.expTreeSearchDir.ExpTreeNodeSelected += new ExpTreeLib.ExpTree.ExpTreeNodeSelectedEventHandler(this.ExpTreeSearchDir_ExpTreeNodeSelectedEventHandler);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(156, 36);
            this.panel5.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Explorer View :";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.listViewSearchDirExp);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 36);
            this.panel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(638, 202);
            this.panel8.TabIndex = 2;
            // 
            // listViewSearchDirExp
            // 
            this.listViewSearchDirExp.AllowDrop = true;
            this.listViewSearchDirExp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnExpFileName,
            this.columnExpDateModified,
            this.columnExpSize,
            this.columnExpType,
            this.columnExpDateCreated});
            this.listViewSearchDirExp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSearchDirExp.HideSelection = false;
            this.listViewSearchDirExp.Location = new System.Drawing.Point(0, 0);
            this.listViewSearchDirExp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewSearchDirExp.Name = "listViewSearchDirExp";
            this.listViewSearchDirExp.Size = new System.Drawing.Size(638, 202);
            this.listViewSearchDirExp.TabIndex = 1;
            this.listViewSearchDirExp.UseCompatibleStateImageBehavior = false;
            this.listViewSearchDirExp.View = System.Windows.Forms.View.Details;
            this.listViewSearchDirExp.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewSearchDirExp_ColumnClickHandler);
            this.listViewSearchDirExp.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listViewSearchDirExp_ItemDragHandler);
            this.listViewSearchDirExp.VisibleChanged += new System.EventHandler(this.ListViewSearchDirExp_VisibleChanged);
            // 
            // columnExpFileName
            // 
            this.columnExpFileName.Text = "File Name";
            this.columnExpFileName.Width = 194;
            // 
            // columnExpDateModified
            // 
            this.columnExpDateModified.Text = "Date Modified";
            this.columnExpDateModified.Width = 86;
            // 
            // columnExpSize
            // 
            this.columnExpSize.Text = "Size";
            this.columnExpSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnExpType
            // 
            this.columnExpType.DisplayIndex = 4;
            this.columnExpType.Text = "Type";
            // 
            // columnExpDateCreated
            // 
            this.columnExpDateCreated.DisplayIndex = 3;
            this.columnExpDateCreated.Text = "Date Created";
            this.columnExpDateCreated.Width = 115;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label4);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(638, 36);
            this.panel7.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Explorer Actions: ";
            // 
            // splitContainerZipDesigner
            // 
            this.splitContainerZipDesigner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerZipDesigner.Location = new System.Drawing.Point(0, 0);
            this.splitContainerZipDesigner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerZipDesigner.Name = "splitContainerZipDesigner";
            // 
            // splitContainerZipDesigner.Panel1
            // 
            this.splitContainerZipDesigner.Panel1.Controls.Add(this.panel2);
            this.splitContainerZipDesigner.Panel1.Controls.Add(this.panel1);
            this.splitContainerZipDesigner.Panel1MinSize = 20;
            // 
            // splitContainerZipDesigner.Panel2
            // 
            this.splitContainerZipDesigner.Panel2.Controls.Add(this.panel3);
            this.splitContainerZipDesigner.Panel2.Controls.Add(this.panel4);
            this.splitContainerZipDesigner.Size = new System.Drawing.Size(798, 372);
            this.splitContainerZipDesigner.SplitterDistance = 333;
            this.splitContainerZipDesigner.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.treeViewZipDesigner);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 71);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(333, 301);
            this.panel2.TabIndex = 1;
            // 
            // treeViewZipDesigner
            // 
            this.treeViewZipDesigner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewZipDesigner.Location = new System.Drawing.Point(0, 0);
            this.treeViewZipDesigner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeViewZipDesigner.Name = "treeViewZipDesigner";
            this.treeViewZipDesigner.Size = new System.Drawing.Size(333, 301);
            this.treeViewZipDesigner.TabIndex = 0;
            this.treeViewZipDesigner.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewZipDesigner_BeforeSelectHandler);
            this.treeViewZipDesigner.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewZipDesigner_AfterSelectHandler);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRemoveSelectedNode);
            this.panel1.Controls.Add(this.btnZipClear);
            this.panel1.Controls.Add(this.btnZipFileAddFolder);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 71);
            this.panel1.TabIndex = 0;
            // 
            // btnRemoveSelectedNode
            // 
            this.btnRemoveSelectedNode.Location = new System.Drawing.Point(76, 33);
            this.btnRemoveSelectedNode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemoveSelectedNode.Name = "btnRemoveSelectedNode";
            this.btnRemoveSelectedNode.Size = new System.Drawing.Size(31, 28);
            this.btnRemoveSelectedNode.TabIndex = 3;
            this.btnRemoveSelectedNode.Text = "-";
            this.btnRemoveSelectedNode.UseVisualStyleBackColor = true;
            this.btnRemoveSelectedNode.Click += new System.EventHandler(this.btnRemoveSelectedNode_Click);
            // 
            // btnZipClear
            // 
            this.btnZipClear.Location = new System.Drawing.Point(43, 33);
            this.btnZipClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnZipClear.Name = "btnZipClear";
            this.btnZipClear.Size = new System.Drawing.Size(28, 28);
            this.btnZipClear.TabIndex = 2;
            this.btnZipClear.Text = "c";
            this.btnZipClear.UseVisualStyleBackColor = true;
            this.btnZipClear.Click += new System.EventHandler(this.btnZipClear_Click);
            // 
            // btnZipFileAddFolder
            // 
            this.btnZipFileAddFolder.Location = new System.Drawing.Point(7, 32);
            this.btnZipFileAddFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnZipFileAddFolder.Name = "btnZipFileAddFolder";
            this.btnZipFileAddFolder.Size = new System.Drawing.Size(29, 30);
            this.btnZipFileAddFolder.TabIndex = 1;
            this.btnZipFileAddFolder.Text = "+";
            this.btnZipFileAddFolder.UseVisualStyleBackColor = true;
            this.btnZipFileAddFolder.Click += new System.EventHandler(this.btnZipFileAddFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zip File Tree View : ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.listViewZipDesignFiles);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 71);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(461, 301);
            this.panel3.TabIndex = 2;
            // 
            // listViewZipDesignFiles
            // 
            this.listViewZipDesignFiles.AllowDrop = true;
            this.listViewZipDesignFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnZipMdlFileName,
            this.columnZipMdlDateModified,
            this.columnZipMdlSize,
            this.columnZipMdlDateCreated,
            this.columnZipMdlType});
            this.listViewZipDesignFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewZipDesignFiles.HideSelection = false;
            this.listViewZipDesignFiles.Location = new System.Drawing.Point(0, 0);
            this.listViewZipDesignFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewZipDesignFiles.Name = "listViewZipDesignFiles";
            this.listViewZipDesignFiles.Size = new System.Drawing.Size(461, 301);
            this.listViewZipDesignFiles.TabIndex = 1;
            this.listViewZipDesignFiles.UseCompatibleStateImageBehavior = false;
            this.listViewZipDesignFiles.View = System.Windows.Forms.View.Details;
            this.listViewZipDesignFiles.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewZipDesignFiles_ColumnClickHandler);
            this.listViewZipDesignFiles.VisibleChanged += new System.EventHandler(this.listViewZipDesignFiles_VisibleChanged);
            this.listViewZipDesignFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListViewZipDesignFiles_DragDropHandler);
            this.listViewZipDesignFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListViewZipDesignFiles_DragEnter);
            // 
            // columnZipMdlFileName
            // 
            this.columnZipMdlFileName.Text = "File Name";
            this.columnZipMdlFileName.Width = 122;
            // 
            // columnZipMdlDateModified
            // 
            this.columnZipMdlDateModified.Text = "Date Modified";
            // 
            // columnZipMdlSize
            // 
            this.columnZipMdlSize.Text = "Size";
            this.columnZipMdlSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnZipMdlDateCreated
            // 
            this.columnZipMdlDateCreated.Text = "Date Created";
            // 
            // columnZipMdlType
            // 
            this.columnZipMdlType.Text = "Type";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnAddSelected);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(461, 71);
            this.panel4.TabIndex = 1;
            // 
            // btnAddSelected
            // 
            this.btnAddSelected.Location = new System.Drawing.Point(7, 32);
            this.btnAddSelected.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddSelected.Name = "btnAddSelected";
            this.btnAddSelected.Size = new System.Drawing.Size(100, 30);
            this.btnAddSelected.TabIndex = 1;
            this.btnAddSelected.Text = "Add Selected";
            this.btnAddSelected.UseVisualStyleBackColor = true;
            this.btnAddSelected.Click += new System.EventHandler(this.btnAddSelected_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Zip Files Designer Actions: ";
            // 
            // ZipDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 614);
            this.Controls.Add(this.splitContainerFormMain);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ZipDesigner";
            this.Text = "Zip File Designer";
            this.splitContainerFormMain.Panel1.ResumeLayout(false);
            this.splitContainerFormMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFormMain)).EndInit();
            this.splitContainerFormMain.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.splitContainerExplorers.Panel1.ResumeLayout(false);
            this.splitContainerExplorers.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerExplorers)).EndInit();
            this.splitContainerExplorers.ResumeLayout(false);
            this.splitContainerSearchDirExp.Panel1.ResumeLayout(false);
            this.splitContainerSearchDirExp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSearchDirExp)).EndInit();
            this.splitContainerSearchDirExp.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.splitContainerZipDesigner.Panel1.ResumeLayout(false);
            this.splitContainerZipDesigner.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerZipDesigner)).EndInit();
            this.splitContainerZipDesigner.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerFormMain;
        private System.Windows.Forms.SplitContainer splitContainerExplorers;
        private System.Windows.Forms.SplitContainer splitContainerSearchDirExp;
        private System.Windows.Forms.SplitContainer splitContainerZipDesigner;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeViewZipDesigner;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView listViewZipDesignFiles;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnZipFileAddFolder;
        private System.Windows.Forms.Button btnAddSelected;
        private System.Windows.Forms.Panel panel6;
        private ExpTreeLib.ExpTree expTreeSearchDir;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ListView listViewSearchDirExp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader columnZipMdlFileName;
        private System.Windows.Forms.ColumnHeader columnExpFileName;
        private System.Windows.Forms.ColumnHeader columnExpDateModified;
        private System.Windows.Forms.ColumnHeader columnExpSize;
        private System.Windows.Forms.ColumnHeader columnExpDateCreated;
        private System.Windows.Forms.ColumnHeader columnExpType;
        private System.Windows.Forms.ColumnHeader columnZipMdlDateModified;
        private System.Windows.Forms.ColumnHeader columnZipMdlSize;
        private System.Windows.Forms.ColumnHeader columnZipMdlDateCreated;
        private System.Windows.Forms.ColumnHeader columnZipMdlType;
        private System.Windows.Forms.Button btnZipClear;
        private System.Windows.Forms.Button btnRemoveSelectedNode;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCreateFileName;
    }
}