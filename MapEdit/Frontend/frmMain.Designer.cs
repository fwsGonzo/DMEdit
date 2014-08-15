namespace MapEdit
{
    partial class frmMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolDraw = new System.Windows.Forms.RadioButton();
			this.toolRect = new System.Windows.Forms.RadioButton();
			this.toolFill = new System.Windows.Forms.RadioButton();
			this.toolReplace = new System.Windows.Forms.RadioButton();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuSelectLayer = new System.Windows.Forms.ToolStripDropDownButton();
			this.mnuLayer = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
			this.editor1 = new MapEdit.Controls.Editor();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 25);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.editor1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
			this.splitContainer1.Size = new System.Drawing.Size(698, 430);
			this.splitContainer1.SplitterDistance = 538;
			this.splitContainer1.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.flowLayoutPanel1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(154, 196);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Tools";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.toolDraw);
			this.flowLayoutPanel1.Controls.Add(this.toolRect);
			this.flowLayoutPanel1.Controls.Add(this.toolFill);
			this.flowLayoutPanel1.Controls.Add(this.toolReplace);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(148, 177);
			this.flowLayoutPanel1.TabIndex = 1;
			// 
			// toolDraw
			// 
			this.toolDraw.Appearance = System.Windows.Forms.Appearance.Button;
			this.toolDraw.Location = new System.Drawing.Point(3, 3);
			this.toolDraw.Name = "toolDraw";
			this.toolDraw.Size = new System.Drawing.Size(135, 24);
			this.toolDraw.TabIndex = 0;
			this.toolDraw.TabStop = true;
			this.toolDraw.Text = "Draw";
			this.toolDraw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolDraw.UseVisualStyleBackColor = true;
			this.toolDraw.Click += new System.EventHandler(this.toolDraw_Click);
			// 
			// toolRect
			// 
			this.toolRect.Appearance = System.Windows.Forms.Appearance.Button;
			this.toolRect.Location = new System.Drawing.Point(3, 33);
			this.toolRect.Name = "toolRect";
			this.toolRect.Size = new System.Drawing.Size(135, 24);
			this.toolRect.TabIndex = 1;
			this.toolRect.TabStop = true;
			this.toolRect.Text = "Rectangle";
			this.toolRect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolRect.UseVisualStyleBackColor = true;
			this.toolRect.Click += new System.EventHandler(this.toolDraw_Click);
			// 
			// toolFill
			// 
			this.toolFill.Appearance = System.Windows.Forms.Appearance.Button;
			this.toolFill.Location = new System.Drawing.Point(3, 63);
			this.toolFill.Name = "toolFill";
			this.toolFill.Size = new System.Drawing.Size(135, 24);
			this.toolFill.TabIndex = 2;
			this.toolFill.TabStop = true;
			this.toolFill.Text = "Fill";
			this.toolFill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolFill.UseVisualStyleBackColor = true;
			this.toolFill.Click += new System.EventHandler(this.toolDraw_Click);
			// 
			// toolReplace
			// 
			this.toolReplace.Appearance = System.Windows.Forms.Appearance.Button;
			this.toolReplace.Location = new System.Drawing.Point(3, 93);
			this.toolReplace.Name = "toolReplace";
			this.toolReplace.Size = new System.Drawing.Size(135, 24);
			this.toolReplace.TabIndex = 3;
			this.toolReplace.TabStop = true;
			this.toolReplace.Text = "Replace";
			this.toolReplace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolReplace.UseVisualStyleBackColor = true;
			this.toolReplace.Click += new System.EventHandler(this.toolDraw_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator3,
            this.mnuSelectLayer,
            this.toolStripSeparator4,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(698, 25);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// mnuFile
			// 
			this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.mnuSave,
            this.toolStripSeparator1,
            this.mnuExit});
			this.mnuFile.Name = "mnuFile";
			this.mnuFile.Size = new System.Drawing.Size(37, 25);
			this.mnuFile.Text = "&File";
			// 
			// mnuOpen
			// 
			this.mnuOpen.Name = "mnuOpen";
			this.mnuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.mnuOpen.Size = new System.Drawing.Size(155, 22);
			this.mnuOpen.Text = "&Open...";
			// 
			// mnuSave
			// 
			this.mnuSave.Name = "mnuSave";
			this.mnuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.mnuSave.Size = new System.Drawing.Size(155, 22);
			this.mnuSave.Text = "&Save...";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
			// 
			// mnuExit
			// 
			this.mnuExit.Name = "mnuExit";
			this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.mnuExit.Size = new System.Drawing.Size(155, 22);
			this.mnuExit.Text = "&Exit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.White;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "toolStripButton1";
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.White;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton2.Text = "toolStripButton2";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// mnuSelectLayer
			// 
			this.mnuSelectLayer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLayer});
			this.mnuSelectLayer.Image = ((System.Drawing.Image)(resources.GetObject("mnuSelectLayer.Image")));
			this.mnuSelectLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuSelectLayer.Name = "mnuSelectLayer";
			this.mnuSelectLayer.Size = new System.Drawing.Size(69, 22);
			this.mnuSelectLayer.Text = "Layers";
			// 
			// mnuLayer
			// 
			this.mnuLayer.Checked = true;
			this.mnuLayer.CheckState = System.Windows.Forms.CheckState.Checked;
			this.mnuLayer.Name = "mnuLayer";
			this.mnuLayer.Size = new System.Drawing.Size(111, 22);
			this.mnuLayer.Text = "Layer 1";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(55, 22);
			this.toolStripButton3.Text = "Reset";
			this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
			// 
			// toolStripButton4
			// 
			this.toolStripButton4.Checked = true;
			this.toolStripButton4.CheckOnClick = true;
			this.toolStripButton4.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
			this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Size = new System.Drawing.Size(95, 22);
			this.toolStripButton4.Text = "Layers above";
			// 
			// toolStripButton5
			// 
			this.toolStripButton5.Checked = true;
			this.toolStripButton5.CheckOnClick = true;
			this.toolStripButton5.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
			this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton5.Name = "toolStripButton5";
			this.toolStripButton5.Size = new System.Drawing.Size(87, 22);
			this.toolStripButton5.Text = "Show mask";
			this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
			// 
			// editor1
			// 
			this.editor1.CurrentTool = MapEdit.Controls.tools_t.TOOL_DRAW;
			this.editor1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.editor1.GraphGridColor = System.Drawing.Color.DarkOliveGreen;
			this.editor1.GraphGridOpacity = 0.5F;
			this.editor1.GraphOffset = ((System.Drawing.PointF)(resources.GetObject("editor1.GraphOffset")));
			this.editor1.GraphZoom = 4F;
			this.editor1.Location = new System.Drawing.Point(0, 0);
			this.editor1.Name = "editor1";
			this.editor1.ShowGrid = true;
			this.editor1.Size = new System.Drawing.Size(536, 428);
			this.editor1.TabIndex = 0;
			this.editor1.TileMode = false;
			this.editor1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editor1_KeyDown);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(698, 455);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.toolStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMain";
			this.Text = "DM Map Editor";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private Controls.Editor editor1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.RadioButton toolDraw;
		private System.Windows.Forms.RadioButton toolRect;
		private System.Windows.Forms.RadioButton toolFill;
		private System.Windows.Forms.RadioButton toolReplace;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripMenuItem mnuFile;
		private System.Windows.Forms.ToolStripMenuItem mnuOpen;
		private System.Windows.Forms.ToolStripMenuItem mnuSave;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem mnuExit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStripButton toolStripButton4;
		private System.Windows.Forms.ToolStripButton toolStripButton5;
		private System.Windows.Forms.ToolStripDropDownButton mnuSelectLayer;
		private System.Windows.Forms.ToolStripMenuItem mnuLayer;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

