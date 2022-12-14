namespace WinForms_Drawing
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.PrimitivesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ellipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linearGradientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pathGradientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.контурыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flattenPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setClipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setClip2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createBrushToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphicsFromImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageFragmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageAttributesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockBitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setPixelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createRegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.isVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrimitivesToolStripMenuItem,
            this.colorToolStripMenuItem,
            this.контурыToolStripMenuItem,
            this.imagesToolStripMenuItem,
            this.regionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(837, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // PrimitivesToolStripMenuItem
            // 
            this.PrimitivesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rectangleToolStripMenuItem,
            this.pieToolStripMenuItem,
            this.ellipseToolStripMenuItem,
            this.linearGradientToolStripMenuItem,
            this.pathGradientToolStripMenuItem});
            this.PrimitivesToolStripMenuItem.Name = "PrimitivesToolStripMenuItem";
            this.PrimitivesToolStripMenuItem.Size = new System.Drawing.Size(159, 20);
            this.PrimitivesToolStripMenuItem.Text = "Графические примитивы";
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.rectangleToolStripMenuItem.Text = "Rectangles";
            this.rectangleToolStripMenuItem.Click += new System.EventHandler(this.rectangleToolStripMenuItem_Click);
            // 
            // pieToolStripMenuItem
            // 
            this.pieToolStripMenuItem.Name = "pieToolStripMenuItem";
            this.pieToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.pieToolStripMenuItem.Text = "Pie";
            this.pieToolStripMenuItem.Click += new System.EventHandler(this.pieToolStripMenuItem_Click);
            // 
            // ellipseToolStripMenuItem
            // 
            this.ellipseToolStripMenuItem.Name = "ellipseToolStripMenuItem";
            this.ellipseToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.ellipseToolStripMenuItem.Text = "Ellipse";
            this.ellipseToolStripMenuItem.Click += new System.EventHandler(this.ellipseToolStripMenuItem_Click);
            // 
            // linearGradientToolStripMenuItem
            // 
            this.linearGradientToolStripMenuItem.Name = "linearGradientToolStripMenuItem";
            this.linearGradientToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.linearGradientToolStripMenuItem.Text = "Linear gradient";
            this.linearGradientToolStripMenuItem.Click += new System.EventHandler(this.linearGradientToolStripMenuItem_Click);
            // 
            // pathGradientToolStripMenuItem
            // 
            this.pathGradientToolStripMenuItem.Name = "pathGradientToolStripMenuItem";
            this.pathGradientToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.pathGradientToolStripMenuItem.Text = "Path gradient";
            this.pathGradientToolStripMenuItem.Click += new System.EventHandler(this.pathGradientToolStripMenuItem_Click);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.colorToolStripMenuItem.Text = "Color";
            this.colorToolStripMenuItem.Click += new System.EventHandler(this.colorToolStripMenuItem_Click);
            // 
            // контурыToolStripMenuItem
            // 
            this.контурыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createPathToolStripMenuItem,
            this.addStringToolStripMenuItem,
            this.flattenPathToolStripMenuItem,
            this.setClipToolStripMenuItem,
            this.setClip2ToolStripMenuItem,
            this.createBrushToolStripMenuItem});
            this.контурыToolStripMenuItem.Name = "контурыToolStripMenuItem";
            this.контурыToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.контурыToolStripMenuItem.Text = "Контуры";
            // 
            // createPathToolStripMenuItem
            // 
            this.createPathToolStripMenuItem.Name = "createPathToolStripMenuItem";
            this.createPathToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.createPathToolStripMenuItem.Text = "CreatePath";
            this.createPathToolStripMenuItem.Click += new System.EventHandler(this.createPathToolStripMenuItem_Click);
            // 
            // addStringToolStripMenuItem
            // 
            this.addStringToolStripMenuItem.Name = "addStringToolStripMenuItem";
            this.addStringToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.addStringToolStripMenuItem.Text = "AddString";
            this.addStringToolStripMenuItem.Click += new System.EventHandler(this.addStringToolStripMenuItem_Click);
            // 
            // flattenPathToolStripMenuItem
            // 
            this.flattenPathToolStripMenuItem.Name = "flattenPathToolStripMenuItem";
            this.flattenPathToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.flattenPathToolStripMenuItem.Text = "Flatten Path";
            this.flattenPathToolStripMenuItem.Click += new System.EventHandler(this.flattenPathToolStripMenuItem_Click);
            // 
            // setClipToolStripMenuItem
            // 
            this.setClipToolStripMenuItem.Name = "setClipToolStripMenuItem";
            this.setClipToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.setClipToolStripMenuItem.Text = "SetClip";
            this.setClipToolStripMenuItem.Click += new System.EventHandler(this.setClipToolStripMenuItem_Click);
            // 
            // setClip2ToolStripMenuItem
            // 
            this.setClip2ToolStripMenuItem.Name = "setClip2ToolStripMenuItem";
            this.setClip2ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.setClip2ToolStripMenuItem.Text = "SetClip2";
            this.setClip2ToolStripMenuItem.Click += new System.EventHandler(this.setClip2ToolStripMenuItem_Click);
            // 
            // createBrushToolStripMenuItem
            // 
            this.createBrushToolStripMenuItem.Name = "createBrushToolStripMenuItem";
            this.createBrushToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.createBrushToolStripMenuItem.Text = "Create brush";
            this.createBrushToolStripMenuItem.Click += new System.EventHandler(this.createBrushToolStripMenuItem_Click);
            // 
            // imagesToolStripMenuItem
            // 
            this.imagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphicsFromImageToolStripMenuItem,
            this.imageFragmentToolStripMenuItem,
            this.imageAttributesToolStripMenuItem,
            this.colorMapToolStripMenuItem,
            this.saveImageToolStripMenuItem,
            this.lockBitsToolStripMenuItem,
            this.setPixelToolStripMenuItem,
            this.rotateToolStripMenuItem});
            this.imagesToolStripMenuItem.Name = "imagesToolStripMenuItem";
            this.imagesToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.imagesToolStripMenuItem.Text = "Images";
            // 
            // graphicsFromImageToolStripMenuItem
            // 
            this.graphicsFromImageToolStripMenuItem.Name = "graphicsFromImageToolStripMenuItem";
            this.graphicsFromImageToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.graphicsFromImageToolStripMenuItem.Text = "GraphicsFromImage";
            this.graphicsFromImageToolStripMenuItem.Click += new System.EventHandler(this.graphicsFromImageToolStripMenuItem_Click);
            // 
            // imageFragmentToolStripMenuItem
            // 
            this.imageFragmentToolStripMenuItem.Name = "imageFragmentToolStripMenuItem";
            this.imageFragmentToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.imageFragmentToolStripMenuItem.Text = "ImageFragment";
            this.imageFragmentToolStripMenuItem.Click += new System.EventHandler(this.imageFragmentToolStripMenuItem_Click);
            // 
            // imageAttributesToolStripMenuItem
            // 
            this.imageAttributesToolStripMenuItem.Name = "imageAttributesToolStripMenuItem";
            this.imageAttributesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.imageAttributesToolStripMenuItem.Text = "ImageAttributes";
            this.imageAttributesToolStripMenuItem.Click += new System.EventHandler(this.imageAttributesToolStripMenuItem_Click);
            // 
            // colorMapToolStripMenuItem
            // 
            this.colorMapToolStripMenuItem.Name = "colorMapToolStripMenuItem";
            this.colorMapToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.colorMapToolStripMenuItem.Text = "ColorMap";
            this.colorMapToolStripMenuItem.Click += new System.EventHandler(this.colorMapToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // lockBitsToolStripMenuItem
            // 
            this.lockBitsToolStripMenuItem.Name = "lockBitsToolStripMenuItem";
            this.lockBitsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.lockBitsToolStripMenuItem.Text = "LockBits";
            this.lockBitsToolStripMenuItem.Click += new System.EventHandler(this.lockBitsToolStripMenuItem_Click);
            // 
            // setPixelToolStripMenuItem
            // 
            this.setPixelToolStripMenuItem.Name = "setPixelToolStripMenuItem";
            this.setPixelToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.setPixelToolStripMenuItem.Text = "SetPixel";
            this.setPixelToolStripMenuItem.Click += new System.EventHandler(this.setPixelToolStripMenuItem_Click);
            // 
            // rotateToolStripMenuItem
            // 
            this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            this.rotateToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.rotateToolStripMenuItem.Text = "Rotate";
            this.rotateToolStripMenuItem.Click += new System.EventHandler(this.rotateToolStripMenuItem_Click);
            // 
            // regionsToolStripMenuItem
            // 
            this.regionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createRegionToolStripMenuItem,
            this.unionToolStripMenuItem,
            this.isVisibleToolStripMenuItem});
            this.regionsToolStripMenuItem.Name = "regionsToolStripMenuItem";
            this.regionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.regionsToolStripMenuItem.Text = "Regions";
            // 
            // createRegionToolStripMenuItem
            // 
            this.createRegionToolStripMenuItem.Name = "createRegionToolStripMenuItem";
            this.createRegionToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.createRegionToolStripMenuItem.Text = "Create region";
            this.createRegionToolStripMenuItem.Click += new System.EventHandler(this.createRegionToolStripMenuItem_Click);
            // 
            // unionToolStripMenuItem
            // 
            this.unionToolStripMenuItem.Name = "unionToolStripMenuItem";
            this.unionToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.unionToolStripMenuItem.Text = "Union";
            this.unionToolStripMenuItem.Click += new System.EventHandler(this.unionToolStripMenuItem_Click);
            // 
            // isVisibleToolStripMenuItem
            // 
            this.isVisibleToolStripMenuItem.Name = "isVisibleToolStripMenuItem";
            this.isVisibleToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.isVisibleToolStripMenuItem.Text = "IsVisible";
            this.isVisibleToolStripMenuItem.Click += new System.EventHandler(this.isVisibleToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 526);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem PrimitivesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ellipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linearGradientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pathGradientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem контурыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flattenPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setClipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphicsFromImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageAttributesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageFragmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createBrushToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createRegionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem isVisibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lockBitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setPixelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setClip2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateToolStripMenuItem;
    }
}

