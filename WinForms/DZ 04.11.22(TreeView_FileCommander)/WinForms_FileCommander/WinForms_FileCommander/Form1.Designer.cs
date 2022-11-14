namespace WinForms_FileCommander
{
    partial class Form1
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.dirTree = new System.Windows.Forms.TreeView();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.fileView = new System.Windows.Forms.ListView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.fileView);
			this.splitContainer1.Size = new System.Drawing.Size(691, 534);
			this.splitContainer1.SplitterDistance = 297;
			this.splitContainer1.SplitterWidth = 5;
			this.splitContainer1.TabIndex = 0;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.dirTree);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.pictureBox1);
			this.splitContainer2.Size = new System.Drawing.Size(297, 534);
			this.splitContainer2.SplitterDistance = 304;
			this.splitContainer2.SplitterWidth = 2;
			this.splitContainer2.TabIndex = 0;
			// 
			// dirTree
			// 
			this.dirTree.AllowDrop = true;
			this.dirTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dirTree.Location = new System.Drawing.Point(0, 0);
			this.dirTree.Name = "dirTree";
			this.dirTree.Size = new System.Drawing.Size(297, 304);
			this.dirTree.TabIndex = 0;
			this.dirTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.dirTree_BeforeExpand);
			this.dirTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.dirTree_AfterSelect);
			this.dirTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.dirTree_DragDrop);
			this.dirTree.DragEnter += new System.Windows.Forms.DragEventHandler(this.dirTree_DragEnter);
			this.dirTree.DragOver += new System.Windows.Forms.DragEventHandler(this.dirTree_DragOver);
			this.dirTree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dirTree_MouseClick);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(297, 228);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// fileView
			// 
			this.fileView.AllowDrop = true;
			this.fileView.ContextMenuStrip = this.contextMenuStrip1;
			this.fileView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fileView.HideSelection = false;
			this.fileView.Location = new System.Drawing.Point(0, 0);
			this.fileView.Name = "fileView";
			this.fileView.Size = new System.Drawing.Size(389, 534);
			this.fileView.TabIndex = 0;
			this.fileView.UseCompatibleStateImageBehavior = false;
			this.fileView.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileView_DragDrop);
			this.fileView.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileView_DragEnter);
			this.fileView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fileView_MouseDown);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(114, 26);
			// 
			// refreshToolStripMenuItem
			// 
			this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
			this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
			this.refreshToolStripMenuItem.Text = "Refresh";
			this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 512);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(691, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(691, 534);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.splitContainer1);
			this.Name = "Form1";
			this.Text = "File commander";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView dirTree;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView fileView;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
	}
}

