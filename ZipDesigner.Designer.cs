﻿namespace OneClickZip
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
            this.splitContainerExplorers = new System.Windows.Forms.SplitContainer();
            this.splitContainerSearchDirExp = new System.Windows.Forms.SplitContainer();
            this.panel6 = new System.Windows.Forms.Panel();
            this.expTreeSearchDir = new ExpTreeLib.ExpTree();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.listViewSearchDirExp = new System.Windows.Forms.ListView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainerZipDesigner = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeViewZipDesigner = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnZipFileAddFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listViewZipDesignFiles = new System.Windows.Forms.ListView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnAddSelected = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFormMain)).BeginInit();
            this.splitContainerFormMain.Panel2.SuspendLayout();
            this.splitContainerFormMain.SuspendLayout();
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
            this.splitContainerFormMain.Name = "splitContainerFormMain";
            // 
            // splitContainerFormMain.Panel2
            // 
            this.splitContainerFormMain.Panel2.Controls.Add(this.splitContainerExplorers);
            this.splitContainerFormMain.Size = new System.Drawing.Size(1151, 614);
            this.splitContainerFormMain.SplitterDistance = 350;
            this.splitContainerFormMain.TabIndex = 0;
            // 
            // splitContainerExplorers
            // 
            this.splitContainerExplorers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerExplorers.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainerExplorers.Size = new System.Drawing.Size(797, 614);
            this.splitContainerExplorers.SplitterDistance = 239;
            this.splitContainerExplorers.TabIndex = 0;
            // 
            // splitContainerSearchDirExp
            // 
            this.splitContainerSearchDirExp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSearchDirExp.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainerSearchDirExp.Size = new System.Drawing.Size(797, 239);
            this.splitContainerSearchDirExp.SplitterDistance = 156;
            this.splitContainerSearchDirExp.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.expTreeSearchDir);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 36);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(156, 203);
            this.panel6.TabIndex = 3;
            // 
            // expTreeSearchDir
            // 
            this.expTreeSearchDir.AllowFolderRename = false;
            this.expTreeSearchDir.Cursor = System.Windows.Forms.Cursors.Default;
            this.expTreeSearchDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expTreeSearchDir.Location = new System.Drawing.Point(0, 0);
            this.expTreeSearchDir.Name = "expTreeSearchDir";
            this.expTreeSearchDir.ShowRootLines = false;
            this.expTreeSearchDir.Size = new System.Drawing.Size(156, 203);
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
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(637, 203);
            this.panel8.TabIndex = 2;
            // 
            // listViewSearchDirExp
            // 
            this.listViewSearchDirExp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSearchDirExp.HideSelection = false;
            this.listViewSearchDirExp.Location = new System.Drawing.Point(0, 0);
            this.listViewSearchDirExp.Name = "listViewSearchDirExp";
            this.listViewSearchDirExp.Size = new System.Drawing.Size(637, 203);
            this.listViewSearchDirExp.TabIndex = 1;
            this.listViewSearchDirExp.UseCompatibleStateImageBehavior = false;
            this.listViewSearchDirExp.View = System.Windows.Forms.View.List;
            this.listViewSearchDirExp.VisibleChanged += new System.EventHandler(this.ListViewSearchDirExp_VisibleChanged);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label4);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(637, 36);
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
            this.splitContainerZipDesigner.Size = new System.Drawing.Size(797, 371);
            this.splitContainerZipDesigner.SplitterDistance = 156;
            this.splitContainerZipDesigner.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.treeViewZipDesigner);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(156, 299);
            this.panel2.TabIndex = 1;
            // 
            // treeViewZipDesigner
            // 
            this.treeViewZipDesigner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewZipDesigner.Location = new System.Drawing.Point(0, 0);
            this.treeViewZipDesigner.Name = "treeViewZipDesigner";
            this.treeViewZipDesigner.Size = new System.Drawing.Size(156, 299);
            this.treeViewZipDesigner.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnZipFileAddFolder);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(156, 72);
            this.panel1.TabIndex = 0;
            // 
            // btnZipFileAddFolder
            // 
            this.btnZipFileAddFolder.Location = new System.Drawing.Point(7, 32);
            this.btnZipFileAddFolder.Name = "btnZipFileAddFolder";
            this.btnZipFileAddFolder.Size = new System.Drawing.Size(51, 30);
            this.btnZipFileAddFolder.TabIndex = 1;
            this.btnZipFileAddFolder.Text = "New";
            this.btnZipFileAddFolder.UseVisualStyleBackColor = true;
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
            this.panel3.Location = new System.Drawing.Point(0, 72);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(637, 299);
            this.panel3.TabIndex = 2;
            // 
            // listViewZipDesignFiles
            // 
            this.listViewZipDesignFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewZipDesignFiles.HideSelection = false;
            this.listViewZipDesignFiles.Location = new System.Drawing.Point(0, 0);
            this.listViewZipDesignFiles.Name = "listViewZipDesignFiles";
            this.listViewZipDesignFiles.Size = new System.Drawing.Size(637, 299);
            this.listViewZipDesignFiles.TabIndex = 1;
            this.listViewZipDesignFiles.UseCompatibleStateImageBehavior = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnAddSelected);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(637, 72);
            this.panel4.TabIndex = 1;
            // 
            // btnAddSelected
            // 
            this.btnAddSelected.Location = new System.Drawing.Point(7, 32);
            this.btnAddSelected.Name = "btnAddSelected";
            this.btnAddSelected.Size = new System.Drawing.Size(100, 29);
            this.btnAddSelected.TabIndex = 1;
            this.btnAddSelected.Text = "Add Selected";
            this.btnAddSelected.UseVisualStyleBackColor = true;
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
            this.Name = "ZipDesigner";
            this.Text = "ZipDesigner";
            this.splitContainerFormMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFormMain)).EndInit();
            this.splitContainerFormMain.ResumeLayout(false);
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
    }
}