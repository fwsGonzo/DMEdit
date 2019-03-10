namespace MapEdit.Frontend
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.editor1 = new MapEdit.Controls.Editor();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.sbarXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbarTXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbarSTXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbarZoomLevel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupFlags = new System.Windows.Forms.GroupBox();
            this.cboTileForm = new System.Windows.Forms.ComboBox();
            this.cboTileFlags = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolDraw = new System.Windows.Forms.RadioButton();
            this.toolRect = new System.Windows.Forms.RadioButton();
            this.toolFill = new System.Windows.Forms.RadioButton();
            this.toolReplace = new System.Windows.Forms.RadioButton();
            this.toolRotate = new System.Windows.Forms.RadioButton();
            this.chkSetTile = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewWnd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.imageBufferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolImageToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolImageToFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolReset = new System.Windows.Forms.ToolStripButton();
            this.mnuGrid8x8 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGrid16x16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolReloadTex = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.clearAllTilesOnLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.addOneFloorOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMapProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolUndo = new System.Windows.Forms.ToolStripButton();
            this.toolRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSelectLayer = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolShowGrid = new System.Windows.Forms.ToolStripButton();
            this.toolLayerAbove = new System.Windows.Forms.ToolStripButton();
            this.toolShowMask = new System.Windows.Forms.ToolStripButton();
            this.toolShowFlags = new System.Windows.Forms.ToolStripComboBox();
            this.openFile1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFile1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.drawTilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolTileFlags = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupFlags.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.editor1);
            this.splitContainer1.Panel1.Controls.Add(this.statusStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupFlags);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1064, 719);
            this.splitContainer1.SplitterDistance = 904;
            this.splitContainer1.TabIndex = 1;
            // 
            // editor1
            // 
            this.editor1.BackColor = System.Drawing.Color.Black;
            this.editor1.CurrentTool = MapEdit.Controls.tools_t.TOOL_DRAW;
            this.editor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor1.GraphGridColor = System.Drawing.Color.DarkOliveGreen;
            this.editor1.GraphGridOpacity = 0.5F;
            this.editor1.GraphOffset = ((System.Drawing.PointF)(resources.GetObject("editor1.GraphOffset")));
            this.editor1.GraphZoom = 1.5F;
            this.editor1.GridSize = 16;
            this.editor1.LayersAbove = true;
            this.editor1.Location = new System.Drawing.Point(0, 0);
            this.editor1.Margin = new System.Windows.Forms.Padding(4);
            this.editor1.Name = "editor1";
            this.editor1.SelectedLayer = 0;
            this.editor1.ShowGrid = true;
            this.editor1.Size = new System.Drawing.Size(902, 692);
            this.editor1.TabIndex = 0;
            this.editor1.TileDrawing = true;
            this.editor1.TileFlags = MapEdit.Backend.Tile.Flags.NONE;
            this.editor1.TileForm = 0;
            this.editor1.TileMode = false;
            this.editor1.OnZoomChanged += new MapEdit.Controls.Editor.zoom_event_t(this.editor1_OnZoomChanged);
            this.editor1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editor1_KeyDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.sbarXY,
            this.sbarTXY,
            this.sbarSTXY,
            this.sbarZoomLevel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 692);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(902, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 19);
            // 
            // sbarXY
            // 
            this.sbarXY.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.sbarXY.Name = "sbarXY";
            this.sbarXY.Size = new System.Drawing.Size(54, 20);
            this.sbarXY.Text = "sbarXY";
            // 
            // sbarTXY
            // 
            this.sbarTXY.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.sbarTXY.Name = "sbarTXY";
            this.sbarTXY.Size = new System.Drawing.Size(62, 20);
            this.sbarTXY.Text = "sbarTXY";
            // 
            // sbarSTXY
            // 
            this.sbarSTXY.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.sbarSTXY.Name = "sbarSTXY";
            this.sbarSTXY.Size = new System.Drawing.Size(70, 20);
            this.sbarSTXY.Text = "sbarSTXY";
            // 
            // sbarZoomLevel
            // 
            this.sbarZoomLevel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.sbarZoomLevel.Name = "sbarZoomLevel";
            this.sbarZoomLevel.Size = new System.Drawing.Size(111, 20);
            this.sbarZoomLevel.Text = "sbarZoomLevel";
            // 
            // groupFlags
            // 
            this.groupFlags.Controls.Add(this.cboTileForm);
            this.groupFlags.Controls.Add(this.cboTileFlags);
            this.groupFlags.Location = new System.Drawing.Point(0, 332);
            this.groupFlags.Name = "groupFlags";
            this.groupFlags.Size = new System.Drawing.Size(154, 78);
            this.groupFlags.TabIndex = 2;
            this.groupFlags.TabStop = false;
            this.groupFlags.Text = "Tile typing";
            // 
            // cboTileForm
            // 
            this.cboTileForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTileForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTileForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTileForm.FormattingEnabled = true;
            this.cboTileForm.Items.AddRange(new object[] {
            "Rectangle",
            "Upper half",
            "Lower half",
            "Right half",
            "Left half",
            "Diagonal Upper-Left",
            "Diagonal Upper-Right",
            "Diagonal Lower-Left",
            "Diagonal Lower-Right"});
            this.cboTileForm.Location = new System.Drawing.Point(6, 19);
            this.cboTileForm.Name = "cboTileForm";
            this.cboTileForm.Size = new System.Drawing.Size(142, 26);
            this.cboTileForm.TabIndex = 1;
            this.cboTileForm.SelectedIndexChanged += new System.EventHandler(this.cboTileForm_SelectedIndexChanged);
            // 
            // cboTileFlags
            // 
            this.cboTileFlags.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTileFlags.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTileFlags.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTileFlags.FormattingEnabled = true;
            this.cboTileFlags.Items.AddRange(new object[] {
            "None",
            "Solid",
            "Abyss",
            "Water",
            "Puddle",
            "Snow",
            "Ice",
            "Damage",
            "-",
            "Pushback",
            "-",
            "-",
            "Slow",
            "Climb",
            "Fence",
            "Entrance",
            "Activate",
            "-",
            "-",
            "-",
            "-",
            "-",
            "-",
            "-",
            "-",
            "-",
            "-",
            "-",
            "-",
            "-",
            "-",
            "-",
            "Auto-jump",
            "Conveyor (normal)",
            "Conveyor (fast)"});
            this.cboTileFlags.Location = new System.Drawing.Point(6, 46);
            this.cboTileFlags.Name = "cboTileFlags";
            this.cboTileFlags.Size = new System.Drawing.Size(142, 26);
            this.cboTileFlags.TabIndex = 0;
            this.cboTileFlags.SelectedIndexChanged += new System.EventHandler(this.cboTileFlags_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 329);
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
            this.flowLayoutPanel1.Controls.Add(this.toolRotate);
            this.flowLayoutPanel1.Controls.Add(this.chkSetTile);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(148, 310);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // toolDraw
            // 
            this.toolDraw.Appearance = System.Windows.Forms.Appearance.Button;
            this.toolDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolDraw.Location = new System.Drawing.Point(3, 3);
            this.toolDraw.Name = "toolDraw";
            this.toolDraw.Size = new System.Drawing.Size(142, 24);
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
            this.toolRect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolRect.Location = new System.Drawing.Point(3, 33);
            this.toolRect.Name = "toolRect";
            this.toolRect.Size = new System.Drawing.Size(142, 24);
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
            this.toolFill.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolFill.Location = new System.Drawing.Point(3, 63);
            this.toolFill.Name = "toolFill";
            this.toolFill.Size = new System.Drawing.Size(142, 24);
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
            this.toolReplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolReplace.Location = new System.Drawing.Point(3, 93);
            this.toolReplace.Name = "toolReplace";
            this.toolReplace.Size = new System.Drawing.Size(142, 24);
            this.toolReplace.TabIndex = 3;
            this.toolReplace.TabStop = true;
            this.toolReplace.Text = "Replace";
            this.toolReplace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolReplace.UseVisualStyleBackColor = true;
            this.toolReplace.Click += new System.EventHandler(this.toolDraw_Click);
            // 
            // toolRotate
            // 
            this.toolRotate.Appearance = System.Windows.Forms.Appearance.Button;
            this.toolRotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolRotate.Location = new System.Drawing.Point(3, 123);
            this.toolRotate.Name = "toolRotate";
            this.toolRotate.Size = new System.Drawing.Size(142, 24);
            this.toolRotate.TabIndex = 4;
            this.toolRotate.TabStop = true;
            this.toolRotate.Text = "Rotate";
            this.toolRotate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolRotate.UseVisualStyleBackColor = true;
            this.toolRotate.Click += new System.EventHandler(this.toolDraw_Click);
            // 
            // chkSetTile
            // 
            this.chkSetTile.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSetTile.AutoSize = true;
            this.chkSetTile.Checked = true;
            this.chkSetTile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSetTile.Image = global::MapEdit.Properties.Resources._8M1tZ;
            this.chkSetTile.Location = new System.Drawing.Point(3, 153);
            this.chkSetTile.Name = "chkSetTile";
            this.chkSetTile.Size = new System.Drawing.Size(134, 151);
            this.chkSetTile.TabIndex = 6;
            this.chkSetTile.Text = "Draw tiles";
            this.chkSetTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSetTile.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.chkSetTile.UseVisualStyleBackColor = true;
            this.chkSetTile.CheckedChanged += new System.EventHandler(this.chkSetTile_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.toolStripDropDownButton1,
            this.toolStripSeparator2,
            this.toolUndo,
            this.toolRedo,
            this.toolStripSeparator3,
            this.mnuSelectLayer,
            this.toolStripSeparator4,
            this.toolShowGrid,
            this.toolLayerAbove,
            this.toolShowMask,
            this.toolShowFlags});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1064, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewWnd,
            this.mnuNew,
            this.toolStripMenuItem1,
            this.mnuOpen,
            this.mnuSave,
            this.mnuSaveAs,
            this.toolStripSeparator1,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(41, 27);
            this.mnuFile.Text = "&File";
            // 
            // mnuNewWnd
            // 
            this.mnuNewWnd.Name = "mnuNewWnd";
            this.mnuNewWnd.Size = new System.Drawing.Size(223, 26);
            this.mnuNewWnd.Text = "New &Window";
            this.mnuNewWnd.Click += new System.EventHandler(this.mnuNewWnd_Click);
            // 
            // mnuNew
            // 
            this.mnuNew.Image = ((System.Drawing.Image)(resources.GetObject("mnuNew.Image")));
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuNew.Size = new System.Drawing.Size(223, 26);
            this.mnuNew.Text = "&New...";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(220, 6);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Image = ((System.Drawing.Image)(resources.GetObject("mnuOpen.Image")));
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuOpen.Size = new System.Drawing.Size(223, 26);
            this.mnuOpen.Text = "&Open...";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuSave.Image")));
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSave.Size = new System.Drawing.Size(223, 26);
            this.mnuSave.Text = "&Save...";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuSaveAs
            // 
            this.mnuSaveAs.Name = "mnuSaveAs";
            this.mnuSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.mnuSaveAs.Size = new System.Drawing.Size(223, 26);
            this.mnuSaveAs.Text = "Save &As...";
            this.mnuSaveAs.Click += new System.EventHandler(this.mnuSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(220, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnuExit.Size = new System.Drawing.Size(223, 26);
            this.mnuExit.Text = "&Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageBufferToolStripMenuItem,
            this.toolReset,
            this.mnuGrid8x8,
            this.mnuGrid16x16,
            this.toolReloadTex,
            this.toolStripSeparator5,
            this.clearAllTilesOnLayerToolStripMenuItem,
            this.toolStripSeparator6,
            this.addOneFloorOnTopToolStripMenuItem,
            this.toolMapProperties});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(58, 24);
            this.toolStripDropDownButton1.Text = "&Editor";
            // 
            // imageBufferToolStripMenuItem
            // 
            this.imageBufferToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolImageToClipboard,
            this.toolImageToFile});
            this.imageBufferToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("imageBufferToolStripMenuItem.Image")));
            this.imageBufferToolStripMenuItem.Name = "imageBufferToolStripMenuItem";
            this.imageBufferToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.imageBufferToolStripMenuItem.Text = "Image buffer";
            // 
            // toolImageToClipboard
            // 
            this.toolImageToClipboard.Name = "toolImageToClipboard";
            this.toolImageToClipboard.Size = new System.Drawing.Size(152, 24);
            this.toolImageToClipboard.Text = "To clipboard";
            this.toolImageToClipboard.Click += new System.EventHandler(this.toolImageToClipboard_Click);
            // 
            // toolImageToFile
            // 
            this.toolImageToFile.Enabled = false;
            this.toolImageToFile.Name = "toolImageToFile";
            this.toolImageToFile.Size = new System.Drawing.Size(152, 24);
            this.toolImageToFile.Text = "To file...";
            // 
            // toolReset
            // 
            this.toolReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolReset.Name = "toolReset";
            this.toolReset.Size = new System.Drawing.Size(94, 23);
            this.toolReset.Text = "Reset camera";
            // 
            // mnuGrid8x8
            // 
            this.mnuGrid8x8.Name = "mnuGrid8x8";
            this.mnuGrid8x8.Size = new System.Drawing.Size(211, 26);
            this.mnuGrid8x8.Text = "Grid 8x8";
            this.mnuGrid8x8.Click += new System.EventHandler(this.mnuGrid8x8_Click);
            // 
            // mnuGrid16x16
            // 
            this.mnuGrid16x16.Name = "mnuGrid16x16";
            this.mnuGrid16x16.Size = new System.Drawing.Size(211, 26);
            this.mnuGrid16x16.Text = "Grid 16x16";
            this.mnuGrid16x16.Click += new System.EventHandler(this.mnuGrid16x16_Click);
            // 
            // toolReloadTex
            // 
            this.toolReloadTex.Image = ((System.Drawing.Image)(resources.GetObject("toolReloadTex.Image")));
            this.toolReloadTex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolReloadTex.Name = "toolReloadTex";
            this.toolReloadTex.Size = new System.Drawing.Size(127, 24);
            this.toolReloadTex.Text = "Reload textures";
            this.toolReloadTex.Click += new System.EventHandler(this.toolReloadTex_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(208, 6);
            // 
            // clearAllTilesOnLayerToolStripMenuItem
            // 
            this.clearAllTilesOnLayerToolStripMenuItem.Enabled = false;
            this.clearAllTilesOnLayerToolStripMenuItem.Name = "clearAllTilesOnLayerToolStripMenuItem";
            this.clearAllTilesOnLayerToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.clearAllTilesOnLayerToolStripMenuItem.Text = "Clear all tiles on layer";
            this.clearAllTilesOnLayerToolStripMenuItem.Click += new System.EventHandler(this.clearAllTilesOnLayerToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(208, 6);
            // 
            // addOneFloorOnTopToolStripMenuItem
            // 
            this.addOneFloorOnTopToolStripMenuItem.Enabled = false;
            this.addOneFloorOnTopToolStripMenuItem.Name = "addOneFloorOnTopToolStripMenuItem";
            this.addOneFloorOnTopToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.addOneFloorOnTopToolStripMenuItem.Text = "Add one floor on top";
            this.addOneFloorOnTopToolStripMenuItem.Click += new System.EventHandler(this.addOneFloorOnTopToolStripMenuItem_Click);
            // 
            // toolMapProperties
            // 
            this.toolMapProperties.Enabled = false;
            this.toolMapProperties.Image = ((System.Drawing.Image)(resources.GetObject("toolMapProperties.Image")));
            this.toolMapProperties.Name = "toolMapProperties";
            this.toolMapProperties.Size = new System.Drawing.Size(211, 26);
            this.toolMapProperties.Text = "Map properties";
            this.toolMapProperties.Click += new System.EventHandler(this.mapPropertiesToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolUndo
            // 
            this.toolUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolUndo.Image = ((System.Drawing.Image)(resources.GetObject("toolUndo.Image")));
            this.toolUndo.ImageTransparentColor = System.Drawing.Color.White;
            this.toolUndo.Name = "toolUndo";
            this.toolUndo.Size = new System.Drawing.Size(24, 24);
            this.toolUndo.Text = "Undo";
            this.toolUndo.Click += new System.EventHandler(this.toolUndo_Click);
            // 
            // toolRedo
            // 
            this.toolRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolRedo.Image = ((System.Drawing.Image)(resources.GetObject("toolRedo.Image")));
            this.toolRedo.ImageTransparentColor = System.Drawing.Color.White;
            this.toolRedo.Name = "toolRedo";
            this.toolRedo.Size = new System.Drawing.Size(24, 24);
            this.toolRedo.Text = "Redo";
            this.toolRedo.Click += new System.EventHandler(this.toolRedo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // mnuSelectLayer
            // 
            this.mnuSelectLayer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLayer});
            this.mnuSelectLayer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mnuSelectLayer.Image = ((System.Drawing.Image)(resources.GetObject("mnuSelectLayer.Image")));
            this.mnuSelectLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuSelectLayer.Name = "mnuSelectLayer";
            this.mnuSelectLayer.Size = new System.Drawing.Size(81, 24);
            this.mnuSelectLayer.Text = "Layers";
            // 
            // mnuLayer
            // 
            this.mnuLayer.Checked = true;
            this.mnuLayer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuLayer.Enabled = false;
            this.mnuLayer.Name = "mnuLayer";
            this.mnuLayer.Size = new System.Drawing.Size(123, 24);
            this.mnuLayer.Text = "Layer 1";
            this.mnuLayer.Click += new System.EventHandler(this.mnuLayer_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // toolShowGrid
            // 
            this.toolShowGrid.Checked = true;
            this.toolShowGrid.CheckOnClick = true;
            this.toolShowGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolShowGrid.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolShowGrid.Image = ((System.Drawing.Image)(resources.GetObject("toolShowGrid.Image")));
            this.toolShowGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolShowGrid.Name = "toolShowGrid";
            this.toolShowGrid.Size = new System.Drawing.Size(59, 24);
            this.toolShowGrid.Text = "Grid";
            this.toolShowGrid.Click += new System.EventHandler(this.toolShowGrid_Click);
            // 
            // toolLayerAbove
            // 
            this.toolLayerAbove.Checked = true;
            this.toolLayerAbove.CheckOnClick = true;
            this.toolLayerAbove.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolLayerAbove.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolLayerAbove.Image = ((System.Drawing.Image)(resources.GetObject("toolLayerAbove.Image")));
            this.toolLayerAbove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLayerAbove.Name = "toolLayerAbove";
            this.toolLayerAbove.Size = new System.Drawing.Size(113, 24);
            this.toolLayerAbove.Text = "Layers above";
            this.toolLayerAbove.Click += new System.EventHandler(this.toolLayerAbove_Click);
            // 
            // toolShowMask
            // 
            this.toolShowMask.Checked = true;
            this.toolShowMask.CheckOnClick = true;
            this.toolShowMask.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolShowMask.Image = ((System.Drawing.Image)(resources.GetObject("toolShowMask.Image")));
            this.toolShowMask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolShowMask.Name = "toolShowMask";
            this.toolShowMask.Size = new System.Drawing.Size(98, 24);
            this.toolShowMask.Text = "Colormask";
            this.toolShowMask.Click += new System.EventHandler(this.toolShowMask_Click);
            // 
            // toolShowFlags
            // 
            this.toolShowFlags.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolShowFlags.Enabled = false;
            this.toolShowFlags.Items.AddRange(new object[] {
            "Hide flags",
            "Show flags",
            "Show opaque flags"});
            this.toolShowFlags.Name = "toolShowFlags";
            this.toolShowFlags.Size = new System.Drawing.Size(121, 27);
            this.toolShowFlags.SelectedIndexChanged += new System.EventHandler(this.toolShowFlags_SelectedIndexChanged);
            // 
            // openFile1
            // 
            this.openFile1.Filter = "DM Map files|*.dmf|All files|*.*";
            this.openFile1.Title = "Open map file";
            // 
            // saveFile1
            // 
            this.saveFile1.Filter = "DM Map files|*.dmf|All files|*.*";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawTilesToolStripMenuItem,
            this.toolStripSeparator7,
            this.toolTileFlags});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(126, 54);
            // 
            // drawTilesToolStripMenuItem
            // 
            this.drawTilesToolStripMenuItem.Checked = true;
            this.drawTilesToolStripMenuItem.CheckOnClick = true;
            this.drawTilesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawTilesToolStripMenuItem.Image = global::MapEdit.Properties.Resources._8M1tZ;
            this.drawTilesToolStripMenuItem.Name = "drawTilesToolStripMenuItem";
            this.drawTilesToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.drawTilesToolStripMenuItem.Text = "Draw tiles";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(122, 6);
            // 
            // toolTileFlags
            // 
            this.toolTileFlags.Name = "toolTileFlags";
            this.toolTileFlags.Size = new System.Drawing.Size(125, 22);
            this.toolTileFlags.Text = "None";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 746);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "DM Map Editor";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupFlags.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
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
		private System.Windows.Forms.ToolStripButton toolUndo;
		private System.Windows.Forms.ToolStripButton toolRedo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton toolLayerAbove;
		private System.Windows.Forms.ToolStripButton toolShowMask;
		private System.Windows.Forms.ToolStripDropDownButton mnuSelectLayer;
		private System.Windows.Forms.ToolStripMenuItem mnuLayer;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem mnuNew;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem mnuSaveAs;
		private System.Windows.Forms.ToolStripMenuItem mnuNewWnd;
		private System.Windows.Forms.ToolStripButton toolShowGrid;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.ToolStripStatusLabel sbarXY;
		private System.Windows.Forms.ToolStripStatusLabel sbarTXY;
		private System.Windows.Forms.ToolStripStatusLabel sbarSTXY;
		private System.Windows.Forms.OpenFileDialog openFile1;
		private System.Windows.Forms.SaveFileDialog saveFile1;
		private System.Windows.Forms.CheckBox chkSetTile;
        private System.Windows.Forms.GroupBox groupFlags;
        private System.Windows.Forms.ToolStripStatusLabel sbarZoomLevel;
        private System.Windows.Forms.ToolStripComboBox toolShowFlags;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem mnuGrid8x8;
        private System.Windows.Forms.ToolStripMenuItem mnuGrid16x16;
        private System.Windows.Forms.ToolStripMenuItem toolMapProperties;
        private System.Windows.Forms.RadioButton toolRotate;
        private System.Windows.Forms.ToolStripMenuItem imageBufferToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolImageToClipboard;
        private System.Windows.Forms.ToolStripMenuItem toolImageToFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem addOneFloorOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllTilesOnLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ComboBox cboTileFlags;
        private System.Windows.Forms.ToolStripButton toolReset;
        private System.Windows.Forms.ToolStripButton toolReloadTex;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolTileFlags;
        private System.Windows.Forms.ToolStripMenuItem drawTilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ComboBox cboTileForm;
    }
}

