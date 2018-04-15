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
            this.radioJleft = new System.Windows.Forms.RadioButton();
            this.radioJright = new System.Windows.Forms.RadioButton();
            this.radioJdown = new System.Windows.Forms.RadioButton();
            this.radioJup = new System.Windows.Forms.RadioButton();
            this.radioIce = new System.Windows.Forms.RadioButton();
            this.radioSlow = new System.Windows.Forms.RadioButton();
            this.radioWater = new System.Windows.Forms.RadioButton();
            this.radioAbyss = new System.Windows.Forms.RadioButton();
            this.radioSolid = new System.Windows.Forms.RadioButton();
            this.radioNone = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolDraw = new System.Windows.Forms.RadioButton();
            this.toolRect = new System.Windows.Forms.RadioButton();
            this.toolFill = new System.Windows.Forms.RadioButton();
            this.toolReplace = new System.Windows.Forms.RadioButton();
            this.listTileForm = new System.Windows.Forms.ListBox();
            this.chkSetTile = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
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
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolUndo = new System.Windows.Forms.ToolStripButton();
            this.toolRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSelectLayer = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolReloadTex = new System.Windows.Forms.ToolStripButton();
            this.toolReset = new System.Windows.Forms.ToolStripButton();
            this.toolShowGrid = new System.Windows.Forms.ToolStripButton();
            this.toolLayerAbove = new System.Windows.Forms.ToolStripButton();
            this.toolShowMask = new System.Windows.Forms.ToolStripButton();
            this.toolShowFlags = new System.Windows.Forms.ToolStripComboBox();
            this.openFile1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFile1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupFlags.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(1031, 700);
            this.splitContainer1.SplitterDistance = 871;
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
            this.editor1.LayersAbove = false;
            this.editor1.Location = new System.Drawing.Point(0, 0);
            this.editor1.Margin = new System.Windows.Forms.Padding(4);
            this.editor1.Name = "editor1";
            this.editor1.SelectedLayer = 0;
            this.editor1.ShowGrid = true;
            this.editor1.Size = new System.Drawing.Size(869, 673);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 673);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(869, 25);
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
            this.sbarXY.Name = "sbarXY";
            this.sbarXY.Size = new System.Drawing.Size(43, 20);
            this.sbarXY.Text = "sbarXY";
            // 
            // sbarTXY
            // 
            this.sbarTXY.Name = "sbarTXY";
            this.sbarTXY.Size = new System.Drawing.Size(50, 20);
            this.sbarTXY.Text = "sbarTXY";
            // 
            // sbarSTXY
            // 
            this.sbarSTXY.Name = "sbarSTXY";
            this.sbarSTXY.Size = new System.Drawing.Size(56, 20);
            this.sbarSTXY.Text = "sbarSTXY";
            // 
            // sbarZoomLevel
            // 
            this.sbarZoomLevel.Name = "sbarZoomLevel";
            this.sbarZoomLevel.Size = new System.Drawing.Size(88, 20);
            this.sbarZoomLevel.Text = "sbarZoomLevel";
            // 
            // groupFlags
            // 
            this.groupFlags.Controls.Add(this.radioJleft);
            this.groupFlags.Controls.Add(this.radioJright);
            this.groupFlags.Controls.Add(this.radioJdown);
            this.groupFlags.Controls.Add(this.radioJup);
            this.groupFlags.Controls.Add(this.radioIce);
            this.groupFlags.Controls.Add(this.radioSlow);
            this.groupFlags.Controls.Add(this.radioWater);
            this.groupFlags.Controls.Add(this.radioAbyss);
            this.groupFlags.Controls.Add(this.radioSolid);
            this.groupFlags.Controls.Add(this.radioNone);
            this.groupFlags.Location = new System.Drawing.Point(0, 296);
            this.groupFlags.Name = "groupFlags";
            this.groupFlags.Size = new System.Drawing.Size(154, 227);
            this.groupFlags.TabIndex = 2;
            this.groupFlags.TabStop = false;
            this.groupFlags.Text = "Flags";
            // 
            // radioJleft
            // 
            this.radioJleft.AutoSize = true;
            this.radioJleft.Location = new System.Drawing.Point(6, 159);
            this.radioJleft.Name = "radioJleft";
            this.radioJleft.Size = new System.Drawing.Size(71, 17);
            this.radioJleft.TabIndex = 9;
            this.radioJleft.Text = "Jump Left";
            this.radioJleft.UseVisualStyleBackColor = true;
            this.radioJleft.CheckedChanged += new System.EventHandler(this.radioJleft_CheckedChanged);
            // 
            // radioJright
            // 
            this.radioJright.AutoSize = true;
            this.radioJright.Location = new System.Drawing.Point(6, 136);
            this.radioJright.Name = "radioJright";
            this.radioJright.Size = new System.Drawing.Size(78, 17);
            this.radioJright.TabIndex = 8;
            this.radioJright.Text = "Jump Right";
            this.radioJright.UseVisualStyleBackColor = true;
            this.radioJright.CheckedChanged += new System.EventHandler(this.radioJright_CheckedChanged);
            // 
            // radioJdown
            // 
            this.radioJdown.AutoSize = true;
            this.radioJdown.Location = new System.Drawing.Point(6, 112);
            this.radioJdown.Name = "radioJdown";
            this.radioJdown.Size = new System.Drawing.Size(81, 17);
            this.radioJdown.TabIndex = 7;
            this.radioJdown.Text = "Jump Down";
            this.radioJdown.UseVisualStyleBackColor = true;
            this.radioJdown.CheckedChanged += new System.EventHandler(this.radioJdown_CheckedChanged);
            // 
            // radioJup
            // 
            this.radioJup.AutoSize = true;
            this.radioJup.Location = new System.Drawing.Point(6, 89);
            this.radioJup.Name = "radioJup";
            this.radioJup.Size = new System.Drawing.Size(67, 17);
            this.radioJup.TabIndex = 6;
            this.radioJup.Text = "Jump Up";
            this.radioJup.UseVisualStyleBackColor = true;
            this.radioJup.CheckedChanged += new System.EventHandler(this.radioJup_CheckedChanged);
            // 
            // radioIce
            // 
            this.radioIce.AutoSize = true;
            this.radioIce.Location = new System.Drawing.Point(74, 65);
            this.radioIce.Name = "radioIce";
            this.radioIce.Size = new System.Drawing.Size(40, 17);
            this.radioIce.TabIndex = 5;
            this.radioIce.Text = "Ice";
            this.radioIce.UseVisualStyleBackColor = true;
            this.radioIce.CheckedChanged += new System.EventHandler(this.radioIce_CheckedChanged);
            // 
            // radioSlow
            // 
            this.radioSlow.AutoSize = true;
            this.radioSlow.Location = new System.Drawing.Point(6, 65);
            this.radioSlow.Name = "radioSlow";
            this.radioSlow.Size = new System.Drawing.Size(48, 17);
            this.radioSlow.TabIndex = 4;
            this.radioSlow.Text = "Slow";
            this.radioSlow.UseVisualStyleBackColor = true;
            this.radioSlow.CheckedChanged += new System.EventHandler(this.radioSlow_CheckedChanged);
            // 
            // radioWater
            // 
            this.radioWater.AutoSize = true;
            this.radioWater.Location = new System.Drawing.Point(74, 42);
            this.radioWater.Name = "radioWater";
            this.radioWater.Size = new System.Drawing.Size(54, 17);
            this.radioWater.TabIndex = 3;
            this.radioWater.Text = "Water";
            this.radioWater.UseVisualStyleBackColor = true;
            this.radioWater.CheckedChanged += new System.EventHandler(this.radioWater_CheckedChanged);
            // 
            // radioAbyss
            // 
            this.radioAbyss.AutoSize = true;
            this.radioAbyss.Location = new System.Drawing.Point(74, 19);
            this.radioAbyss.Name = "radioAbyss";
            this.radioAbyss.Size = new System.Drawing.Size(53, 17);
            this.radioAbyss.TabIndex = 2;
            this.radioAbyss.Text = "Abyss";
            this.radioAbyss.UseVisualStyleBackColor = true;
            this.radioAbyss.CheckedChanged += new System.EventHandler(this.radioAbyss_CheckedChanged);
            // 
            // radioSolid
            // 
            this.radioSolid.AutoSize = true;
            this.radioSolid.Location = new System.Drawing.Point(6, 42);
            this.radioSolid.Name = "radioSolid";
            this.radioSolid.Size = new System.Drawing.Size(48, 17);
            this.radioSolid.TabIndex = 1;
            this.radioSolid.Text = "Solid";
            this.radioSolid.UseVisualStyleBackColor = true;
            this.radioSolid.CheckedChanged += new System.EventHandler(this.radioSolid_CheckedChanged);
            // 
            // radioNone
            // 
            this.radioNone.AutoSize = true;
            this.radioNone.Checked = true;
            this.radioNone.Location = new System.Drawing.Point(6, 19);
            this.radioNone.Name = "radioNone";
            this.radioNone.Size = new System.Drawing.Size(51, 17);
            this.radioNone.TabIndex = 0;
            this.radioNone.TabStop = true;
            this.radioNone.Text = "None";
            this.radioNone.UseVisualStyleBackColor = true;
            this.radioNone.CheckedChanged += new System.EventHandler(this.radioNone_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 293);
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
            this.flowLayoutPanel1.Controls.Add(this.listTileForm);
            this.flowLayoutPanel1.Controls.Add(this.chkSetTile);
            this.flowLayoutPanel1.Controls.Add(this.checkBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(148, 274);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // toolDraw
            // 
            this.toolDraw.Appearance = System.Windows.Forms.Appearance.Button;
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
            // listTileForm
            // 
            this.listTileForm.FormattingEnabled = true;
            this.listTileForm.Items.AddRange(new object[] {
            "Rectangle",
            "NW: Up-Left",
            "NE: Up-Right",
            "SW: Down-Left",
            "SE: Down-Right"});
            this.listTileForm.Location = new System.Drawing.Point(3, 123);
            this.listTileForm.Name = "listTileForm";
            this.listTileForm.Size = new System.Drawing.Size(142, 69);
            this.listTileForm.TabIndex = 7;
            this.listTileForm.SelectedIndexChanged += new System.EventHandler(this.listTileForm_SelectedIndexChanged);
            // 
            // chkSetTile
            // 
            this.chkSetTile.AutoSize = true;
            this.chkSetTile.Checked = true;
            this.chkSetTile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSetTile.Location = new System.Drawing.Point(3, 198);
            this.chkSetTile.Name = "chkSetTile";
            this.chkSetTile.Size = new System.Drawing.Size(72, 17);
            this.chkSetTile.TabIndex = 8;
            this.chkSetTile.Text = "Draw tiles";
            this.chkSetTile.UseVisualStyleBackColor = true;
            this.chkSetTile.CheckedChanged += new System.EventHandler(this.chkSetTile_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(3, 221);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(65, 17);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "Lift flags";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.toolStripSeparator2,
            this.toolUndo,
            this.toolRedo,
            this.toolStripSeparator3,
            this.mnuSelectLayer,
            this.toolStripSeparator4,
            this.toolReloadTex,
            this.toolReset,
            this.toolShowGrid,
            this.toolLayerAbove,
            this.toolShowMask,
            this.toolShowFlags});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1031, 27);
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
            this.mnuFile.Size = new System.Drawing.Size(37, 27);
            this.mnuFile.Text = "&File";
            // 
            // mnuNewWnd
            // 
            this.mnuNewWnd.Name = "mnuNewWnd";
            this.mnuNewWnd.Size = new System.Drawing.Size(195, 22);
            this.mnuNewWnd.Text = "New &Window";
            this.mnuNewWnd.Click += new System.EventHandler(this.mnuNewWnd_Click);
            // 
            // mnuNew
            // 
            this.mnuNew.Image = ((System.Drawing.Image)(resources.GetObject("mnuNew.Image")));
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuNew.Size = new System.Drawing.Size(195, 22);
            this.mnuNew.Text = "&New...";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(192, 6);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Image = ((System.Drawing.Image)(resources.GetObject("mnuOpen.Image")));
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuOpen.Size = new System.Drawing.Size(195, 22);
            this.mnuOpen.Text = "&Open...";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuSave.Image")));
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSave.Size = new System.Drawing.Size(195, 22);
            this.mnuSave.Text = "&Save...";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuSaveAs
            // 
            this.mnuSaveAs.Name = "mnuSaveAs";
            this.mnuSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.mnuSaveAs.Size = new System.Drawing.Size(195, 22);
            this.mnuSaveAs.Text = "Save &As...";
            this.mnuSaveAs.Click += new System.EventHandler(this.mnuSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnuExit.Size = new System.Drawing.Size(195, 22);
            this.mnuExit.Text = "&Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
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
            this.mnuSelectLayer.Image = ((System.Drawing.Image)(resources.GetObject("mnuSelectLayer.Image")));
            this.mnuSelectLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuSelectLayer.Name = "mnuSelectLayer";
            this.mnuSelectLayer.Size = new System.Drawing.Size(73, 24);
            this.mnuSelectLayer.Text = "Layers";
            // 
            // mnuLayer
            // 
            this.mnuLayer.Checked = true;
            this.mnuLayer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuLayer.Enabled = false;
            this.mnuLayer.Name = "mnuLayer";
            this.mnuLayer.Size = new System.Drawing.Size(111, 22);
            this.mnuLayer.Text = "Layer 1";
            this.mnuLayer.Click += new System.EventHandler(this.mnuLayer_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // toolReloadTex
            // 
            this.toolReloadTex.Image = ((System.Drawing.Image)(resources.GetObject("toolReloadTex.Image")));
            this.toolReloadTex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolReloadTex.Name = "toolReloadTex";
            this.toolReloadTex.Size = new System.Drawing.Size(74, 24);
            this.toolReloadTex.Text = "Textures";
            this.toolReloadTex.Click += new System.EventHandler(this.toolReloadTex_Click);
            // 
            // toolReset
            // 
            this.toolReset.Image = ((System.Drawing.Image)(resources.GetObject("toolReset.Image")));
            this.toolReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolReset.Name = "toolReset";
            this.toolReset.Size = new System.Drawing.Size(72, 24);
            this.toolReset.Text = "Camera";
            this.toolReset.Click += new System.EventHandler(this.toolReset_Click);
            // 
            // toolShowGrid
            // 
            this.toolShowGrid.Checked = true;
            this.toolShowGrid.CheckOnClick = true;
            this.toolShowGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolShowGrid.Image = ((System.Drawing.Image)(resources.GetObject("toolShowGrid.Image")));
            this.toolShowGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolShowGrid.Name = "toolShowGrid";
            this.toolShowGrid.Size = new System.Drawing.Size(53, 24);
            this.toolShowGrid.Text = "Grid";
            this.toolShowGrid.Click += new System.EventHandler(this.toolShowGrid_Click);
            // 
            // toolLayerAbove
            // 
            this.toolLayerAbove.Checked = true;
            this.toolLayerAbove.CheckOnClick = true;
            this.toolLayerAbove.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolLayerAbove.Image = ((System.Drawing.Image)(resources.GetObject("toolLayerAbove.Image")));
            this.toolLayerAbove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLayerAbove.Name = "toolLayerAbove";
            this.toolLayerAbove.Size = new System.Drawing.Size(99, 24);
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
            this.toolShowMask.Size = new System.Drawing.Size(88, 24);
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 727);
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
            this.groupFlags.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
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
		private System.Windows.Forms.ToolStripButton toolUndo;
		private System.Windows.Forms.ToolStripButton toolRedo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton toolReset;
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
		private System.Windows.Forms.ListBox listTileForm;
		private System.Windows.Forms.CheckBox chkSetTile;
        private System.Windows.Forms.GroupBox groupFlags;
        private System.Windows.Forms.RadioButton radioIce;
        private System.Windows.Forms.RadioButton radioSlow;
        private System.Windows.Forms.RadioButton radioWater;
        private System.Windows.Forms.RadioButton radioAbyss;
        private System.Windows.Forms.RadioButton radioSolid;
        private System.Windows.Forms.RadioButton radioNone;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripButton toolReloadTex;
        private System.Windows.Forms.ToolStripStatusLabel sbarZoomLevel;
        private System.Windows.Forms.RadioButton radioJleft;
        private System.Windows.Forms.RadioButton radioJright;
        private System.Windows.Forms.RadioButton radioJdown;
        private System.Windows.Forms.RadioButton radioJup;
        private System.Windows.Forms.ToolStripComboBox toolShowFlags;
    }
}

