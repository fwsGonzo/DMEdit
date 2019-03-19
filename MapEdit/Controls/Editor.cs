using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MapEdit.Backend;
using System.Diagnostics;

namespace MapEdit.Controls
{
	public enum tools_t
	{
		TOOL_NONE,
		TOOL_READ,
		TOOL_DRAW,
		TOOL_RECT,
		TOOL_FILL,
		TOOL_REPLACE,
        TOOL_ROTATE,
    }

    public partial class Editor : UserControl
    {
		public delegate void TileChangedEvent(int l, int x, int y, int tx, int ty, int stx, int sty);
		public event TileChangedEvent onTileChanged;

        string current_mod_dir = "";
        string filename;
		bool   has_filename = false;
		bool   is_saved = false;

        Bitmap  buffer   = null;
        Image   checkers = null;
        Image   default_tiles = null;
        Tileset tileset  = null;
		Selection selection = null;

        MapFile mapfile;
        List<LayerBuffer> undoBuffer = new List<LayerBuffer>();
        List<LayerBuffer> redoBuffer = new List<LayerBuffer>();

		public int  SelectedLayer { get; set; }
		public bool ShowGrid { get; set; }
        public int  GridSize { get; set; }
        public bool LayersAbove { get; set; }

		public bool TileMode { get; set; }
		// true if we set tile (X, Y) values
		public bool TileDrawing { get; set; }
        // enabled: sets solid-flag to tiles
        public Backend.Tile.Flags TileFlags { get; set; }
        public int TileForm { get; set; }
	
		private bool mouseDown;
        private Point mouseLocation;
		
		// graph constants
		private const float ZOOM_DELTA = 0.15f;
		
		public Color GraphGridColor { get; set; }
		public float GraphGridOpacity { get; set; }

        public delegate void zoom_event_t(float v);
        public event zoom_event_t OnZoomChanged = null;

		PointF graphOffset; float graphZoom;
		PointF tileOffset;  float tileZoom;
		public PointF GraphOffset
		{
			get { if (TileMode) return tileOffset; else return graphOffset; }
			set { if (TileMode) tileOffset = value; else graphOffset = value; }
		}
		public float GraphZoom
		{
			get {
                if (TileMode) return tileZoom; else return graphZoom;
            }
			set {
                if (TileMode) tileZoom = value;
                else graphZoom = value;
                // call handler for when zoom changes
                if (OnZoomChanged != null) OnZoomChanged(getZoomFactor());
            }
		}
        public float getZoomFactor() {
            if (GraphZoom < 1.0)
                return GraphZoom;
            else
                return (float) Math.Pow(GraphZoom, 2.5);
        }
		public tools_t CurrentTool { get; set; }
		
		public int getLayerCount()
		{
			return mapfile.layers.Count;
		}

		public Editor()
		{
			// default graph properties
			GraphGridColor = Color.DarkOliveGreen;
			GraphGridOpacity = 0.5f;	// default 10% visible

			graphOffset = new PointF(0.0f, 0.0f); // panning offset
			graphZoom = 1.2f;
			tileOffset = new PointF(0.0f, 0.0f);
			tileZoom = 1.2f;
            GridSize = 16;
			
			CurrentTool = tools_t.TOOL_NONE;
			selection = new Selection(1, 0);
			// initialize private stuff
            mapfile = new MapFile();
			SelectedLayer = 0;
			ShowGrid = true;
			TileMode = false;
			TileDrawing = true;
			LayersAbove = true;

			// designer auto-generated initialization procedure
			InitializeComponent();
			
			// add mousewheel function to event trigger list
			SizeChanged += Editor_SizeChanged;
			Paint += Editor_Paint;

			MouseWheel += Editor_MouseWheel;
			MouseDown += Editor_MouseDown;
			MouseMove += Editor_MouseMove;
			MouseUp += Editor_MouseUp;
			
			// make sure only we can paint, and double-buffered
			this.SetStyle(ControlStyles.AllPaintingInWmPaint
					| ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
		}
		public void initialize(string mod_dir, Image tileset, int tilesize)
		{
			this.current_mod_dir = mod_dir;
            // tileset image && tilesize
            this.default_tiles = tileset;
            this.tileset = new Tileset(tileset, tilesize);
            GridSize = tilesize;
		}
        public void reload_textures(Image tiles)
        {
            this.tileset.setTexture(tiles);
            this.Invalidate();
        }

		// returns true if there is an existing valid map
		public bool containsMap()
		{
			return mapfile.layers.Count > 0 && tileset != null;
		}
        internal MapFile getMapFile()
        {
            return mapfile;
        }
        // creates a new map based on size & mapfile.layers
        public void createMap(int sizeX, int sizeY, int floors)
		{
            has_filename = false;
            mapfile = new MapFile();
            
            // create new mapfile.layers
            int layerCount = floors * Layer.LAYERS_PER_FLOOR;

			for (int i = 0; i < layerCount; i++)
			{
				Layer L = new Layer(sizeX, sizeY, tileset.size);
				L.create();
				L.ShowMask = (i == 0);
                L.Enabled  = (i == 0);
				L.invalidate(tileset);
				mapfile.layers.Add(L);
			}
            // some changes were made to this map
            undoBuffer.Clear();
            redoBuffer.Clear();
		}
		public void setMap(Backend.MapFile mapfile)
		{
			this.mapfile= mapfile;
			this.has_filename = false;
			this.is_saved = false;
		}
		public bool loadMap(string filename)
		{
			// load map
			this.mapfile = MapFile.load(current_mod_dir, filename, this.tileset, default_tiles);
			if (mapfile.layers != null)
			{
				this.Invalidate();
                // set filename & no changes made
                this.filename = filename;
				this.has_filename = true;
				this.is_saved = true;
				return true;
			}
			else
			{
				this.mapfile.layers = new List<Layer>();
				return false;
			}
		}
		public bool saveMapAs(string filename)
		{
			if (this.mapfile.save(filename))
			{
				this.filename = filename;
				this.has_filename = true;
				this.is_saved = true;
				return true;
			}
			return false;
		}
		public bool saveChanges()
		{
			if (has_filename)
			if (this.mapfile.save(this.filename))
			{
				this.is_saved = true;
				return true;
			}
			return false;
		}
		public bool isSaved()
		{
			return this.is_saved;
		}
        public void applyProperties()
        {
            this.tileset.setTexture(mapfile.applyTiles(current_mod_dir, default_tiles));
            foreach (Layer L in mapfile.layers) L.invalidate(this.tileset);
            this.Invalidate();
        }

        public Bitmap renderToBitmap()
        {
            return new Bitmap(buffer);
        }
        internal void createOneFloor()
        {
            int sx = mapfile.layers[0].getTilesX();
            int sy = mapfile.layers[0].getTilesY();
            for (int i = 0; i < Layer.LAYERS_PER_FLOOR; i++)
            {
                Layer L = new Layer(sx, sy, this.tileset.size);
                L.create();
                mapfile.layers.Add(L);
            }
        }
        internal void clearLayer(int layer)
        {
            aboutToMakeChanges(layer);
            {
                var L = mapfile.layers[layer];
                L.clear();
                L.invalidate(this.tileset);
            }
            changesWereMade();
            this.Invalidate();
        }

        private void aboutToMakeChanges(int layer)
        {
            // Clone layer tiles
            var t = this.mapfile.layers[layer].cloneTiles();
            // Create new undo buffer
            undoBuffer.Add(new LayerBuffer(t, layer));
            // Destroy any redo buffers
            redoBuffer.Clear();
		}
		private void changesWereMade()
		{
			// the file is no longer 'current'
			this.is_saved = false;
            // enable the layer if modified
            this.getCurrentLayer().Enabled = true;
		}

		public void setShowMask(bool mask)
		{
            if (getLayerCount() == 0) return;
            getCurrentLayer().ShowMask = mask;
			this.Invalidate();
		}
		public bool getShowMask(int layer)
		{
			return mapfile.layers[layer].ShowMask;
		}
        internal void setShowFlags(int level)
        {
            if (getLayerCount() == 0) return;
            getCurrentLayer().ShowFlags = level;
            getCurrentLayer().invalidate(this.tileset);
            this.Invalidate();
        }
        internal void setShowLayer(bool visible)
        {
            if (getLayerCount() == 0) return;
            getCurrentLayer().Visible = visible;
            getCurrentLayer().invalidate(this.tileset);
            this.Invalidate();
        }
        public Layer getCurrentLayer()
        {
            return mapfile.layers[SelectedLayer];
        }

        // transforms a point p, in window coordinate system
        // to graph (0, 0)-based coordinate system
        public PointF transformPoint(PointF p)
		{
			return new PointF(p.X / getZoomFactor(),
							  p.Y / getZoomFactor());
		}
		public Point toTilesheet(PointF p)
		{
			// clamp selection to inside tilesheet
			int sx = (int)p.X; if (sx < 0) sx = 0;
			if (sx >= tileset.getBuffer().Width) sx = tileset.getBuffer().Width - 1;
			sx /= tileset.size;

			int sy = (int)p.Y; if (sy < 0) sy = 0;
			if (sy >= tileset.getBuffer().Height) sy = tileset.getBuffer().Height - 1;
			sy /= tileset.size;

			return new Point(sx, sy);
		}

		// drawing rectangle
		bool drawDragRect = false;
		Rectangle dragRect;
		// selection rectangle
		bool drawSelectionRect = false;
		bool selectionFromTiles = false;
		Rectangle selectionRect;

		Point originalTilePoint;

		Rectangle toTileRect(Point a, Point b)
		{
			int x1 = (a.X < b.X) ? a.X : b.X;
			int x2 = ((a.X > b.X) ? a.X : b.X) + 1;
			int y1 = (a.Y < b.Y) ? a.Y : b.Y;
			int y2 = ((a.Y > b.Y) ? a.Y : b.Y) + 1;

			return new Rectangle(x1, y1, x2 - x1, y2 - y1);
		}
		void drawTile(Layer L, int tx, int ty, Tile source, bool flags = true)
		{
			Tile T = L.getTile(tx, ty);

            if (TileDrawing)
            {
                T.setXY(source.getTX(), source.getTY());
                T.setRot(source.getRot());
            }
            if (flags)
            {
                T.setFlags(TileFlags);
                T.setForm((byte)TileForm);
            }
            L.updateTile(this.tileset, tx, ty);
		}

		private void applyTool(tools_t tool, int state, Point e)
		{
			// ignore empty maps
			if (mapfile.layers.Count == 0) return;

			PointF p = new PointF(e.X, e.Y);
			// transformed relative mouse position
			p = transformPoint(p);
			p.X -= GraphOffset.X;
			p.Y -= GraphOffset.Y;
			// get current point & tile
			Layer L = getCurrentLayer();
			Point tp = L.toTileCoord(p.X, p.Y);
			Tile t = L.getTile(tp);
			// outside of area (most likely)
			if (t == null) return;

			if (state == 0)
			{
				// set mousedown tilepoint
				originalTilePoint = tp;
			}
			
			if (tool == tools_t.TOOL_RECT)
			{
				dragRect = toTileRect(originalTilePoint, tp);
				dragRect.X *= tileset.size;
				dragRect.Y *= tileset.size;
				dragRect.Width  *= tileset.size;
				dragRect.Height *= tileset.size;
				// invalidate to draw the rectangle
				this.drawDragRect = true;
				this.Invalidate();
			}
			else if (tool == tools_t.TOOL_READ)
			{
				selectionRect = toTileRect(originalTilePoint, tp);
				selectionRect.X *= tileset.size;
				selectionRect.Y *= tileset.size;
				selectionRect.Width *= tileset.size;
				selectionRect.Height *= tileset.size;
				// invalidate to draw the rectangle
				this.drawSelectionRect = true;
				this.selectionFromTiles = false;
				this.Invalidate();
			}

			switch (tool) {
			case tools_t.TOOL_READ:
				if (state == 2)
				{
					selection = new Selection(L, originalTilePoint, tp);
				}
				// lifting a tile didn't change map, so just exit
				return;
			case tools_t.TOOL_DRAW:
				// signal that changes are about to be made to @layer
				if (state == 0) aboutToMakeChanges(SelectedLayer);
                if (state != 2) // not mouse up
				{
					// get drawing deltas
					Tile cur = selection.delta(originalTilePoint, tp);
					// draw at tile position
					drawTile(L, tp.X, tp.Y, cur);
				}
				this.Invalidate();
				break;
			case tools_t.TOOL_RECT:
				if (state == 2)
				{
					// now that we're here, before doing anything
					// signal that changes are about to be made to @layer
					aboutToMakeChanges(SelectedLayer);
					Rectangle TR = toTileRect(originalTilePoint, tp);

					for (int y = 0; y < TR.Height; y++)
					for (int x = 0; x < TR.Width; x++)
					{
						int tx = TR.X + x;
						int ty = TR.Y + y;
						if (L.inRange(tx, ty))
						{
							Tile cur = selection.get(x, y);
							drawTile(L, tx, ty, cur);
						}
					}
					// mouse up event, map has changed
					break;
				}
				else return;
			case tools_t.TOOL_FILL:
                // signal that changes are about to be made to @layer
                if (state == 0) aboutToMakeChanges(SelectedLayer);
				{
					// get drawing deltas
					Tile cur = selection.delta(originalTilePoint, tp);
					// fill at tile position
					L.fill(tp.X, tp.Y, t.getTX(), t.getTY(), cur.getTX(), cur.getTY());
				}
				L.invalidate(this.tileset);
				this.Invalidate();
				break;
			case tools_t.TOOL_REPLACE:
                // signal that changes are about to be made to @layer
                if (state == 0) aboutToMakeChanges(SelectedLayer);
				{
					// get drawing deltas
					Tile cur = selection.delta(originalTilePoint, tp);
					// replace at tile position
					L.replace(t.getTX(), t.getTY(), cur);
				}
				L.invalidate(this.tileset);
				this.Invalidate();
				break;
            case tools_t.TOOL_ROTATE:
                // signal that changes are about to be made to @layer
                if (state == 0) aboutToMakeChanges(SelectedLayer);
                if (state != 2) // not mouse up
                {
                    // use original tile
                    Tile cur = t;
                    t.setRot((t.getRot() + 1) % 4);
                    // draw at tile position
                    drawTile(L, tp.X, tp.Y, cur, false);
                }
                this.Invalidate();
                break;

                default:
				// unimplemented tools can't change the map, just exit
				return;
			}
			// changes were potentially made
			changesWereMade();
		}

        private void applySelection(int state, Point loc)
		{
			// ignore empty tileset
			if (tileset == null) return;
			
			PointF p = new PointF(loc.X, loc.Y);
			// transformed relative mouse position
			p = transformPoint(p);
			p.X -= GraphOffset.X;
			p.Y -= GraphOffset.Y;

			Point sp = toTilesheet(p);

			if (state == 0)
			{
				// set mousedown tilepoint
				originalTilePoint = sp;
			}
			selectionRect = toTileRect(originalTilePoint, sp);
			selectionRect.X *= tileset.size;
			selectionRect.Y *= tileset.size;
			selectionRect.Width *= tileset.size;
			selectionRect.Height *= tileset.size;
			// draw the selection rectangle
			this.drawSelectionRect = true;
			// set selection from tileset
			this.selectionFromTiles = TileMode;

			// set new selection
			selection = new Selection(originalTilePoint, sp);
			this.Invalidate();
		}

        private void Editor_SizeChanged(object sender, EventArgs e)
		{
			if (this.ClientSize.Height != 0)
			{
				// recreate backbuffer with new size
				buffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
				// redraw graph
				this.Invalidate();
			}
		}
		// manipulate zoom factor based on mousewheel event
		// also move the offset slightly closer to mouse location
		void Editor_MouseWheel(object sender, MouseEventArgs e)
		{
			// get old transformed mouse position
			PointF p1 = transformPoint(new PointF(e.Location.X, e.Location.Y));
			// -= zooming =-
			// increase by mousewheel delta
			int delta = e.Delta < 0 ? -1 : 1;
			zoom(delta);
			// get new transformed mouse position
			PointF p2 = transformPoint(new PointF(e.Location.X, e.Location.Y));
			// calculate difference
			float zofx = (p2.X - p1.X);
			float zofy = (p2.Y - p1.Y);
			// set new graph offset
			GraphOffset = new PointF(GraphOffset.X + zofx, GraphOffset.Y + zofy);
		}
		public void zoom(int delta)
		{
			GraphZoom += ZOOM_DELTA * delta;
            // clamp to min value
            if (GraphZoom < 2 * ZOOM_DELTA) GraphZoom = 2 * ZOOM_DELTA;
			// redraw
			this.Invalidate();
		}

		private void Editor_Paint(object sender, PaintEventArgs e)
		{
			renderBuffers();

			// blit backbuffer to usercontrol
			e.Graphics.DrawImage(buffer, 0, 0);
        }

		tools_t selectedTool = tools_t.TOOL_NONE;

		private void Editor_MouseDown(object sender, MouseEventArgs e)
		{
			// reset selected tool
			selectedTool = tools_t.TOOL_NONE;

			if (e.Button == MouseButtons.Left)
			{
				if (TileMode)
					applySelection(0, e.Location);
				else
				{
					if (Control.ModifierKeys == Keys.Control)
					{
						// Ctrl: set lift/read tool
						selectedTool = tools_t.TOOL_READ;
					}
					else
					{
						// Normal: set selected tool
						selectedTool = CurrentTool;
					}
				}
			}
			else if (e.Button == MouseButtons.Right)
			{
                // set to read tiles from map
                if (TileMode == false)
                {
                    TileMode = true;
                    this.Invalidate();
                }
			}

			if (selectedTool != tools_t.TOOL_NONE)
			{
				// use current tool drawing
				applyTool(selectedTool, 0, e.Location);
			}
			this.mouseDown = true;
		}
		private void Editor_MouseMove(object sender, MouseEventArgs e)
		{
			// statusbar updates
			if (onTileChanged != null)
			{
				PointF p = new PointF(e.Location.X, e.Location.Y);
				// transformed relative mouse position
				p = transformPoint(p);
				p.X -= GraphOffset.X;
				p.Y -= GraphOffset.Y;

				if (mapfile.layers.Count == 0)
				{
					onTileChanged.Invoke(0, e.Location.X, e.Location.Y, 0, 0, 0, 0);
				}
				else
				{
					// get tile position on map

					if (TileMode == false)
					{
						// get current point & written tile
						Layer L = getCurrentLayer();
						Point tp = L.toTileCoord(p.X, p.Y);
						Tile t = L.getTile(tp);
						if (t != null)
						{
							onTileChanged.Invoke(SelectedLayer, (int)p.X, (int)p.Y, tp.X, tp.Y, t.getTX(), t.getTY());
						}
						else
						{
							onTileChanged.Invoke(SelectedLayer, (int)p.X, (int)p.Y, tp.X, tp.Y, 0, 0);
						}
					}
					else
					{
                        Point sp = toTilesheet(p);
                        // tilemode
                        onTileChanged.Invoke(SelectedLayer, (int)p.X, (int)p.Y, sp.X, sp.Y, sp.X, sp.Y);
					}
				}
			}
			// mouse movement events
			if (this.mouseDown)
			{
				if (e.Button == MouseButtons.Middle)
				{
					PointF p = new PointF(e.Location.X - mouseLocation.X,
										e.Location.Y - mouseLocation.Y);
					// transformed relative mouse position
					p = transformPoint(p);
					// set new offset value
					GraphOffset = new PointF(GraphOffset.X + p.X, GraphOffset.Y + p.Y);
					// redraw
					this.Invalidate();
				}
				else if (TileMode)
				{
                    // only process mouse when Left button is used in TileMode
                    if (e.Button == MouseButtons.Left)
                    {
                        applySelection(1, e.Location);
                    }
				}
			} // mouseDown
			this.mouseLocation = e.Location;

			if (selectedTool != tools_t.TOOL_NONE)
			{
				// use current tool drawing
				applyTool(selectedTool, 1, e.Location);
			}
		}
		private void Editor_MouseUp(object sender, MouseEventArgs e)
		{
			if (selectedTool != tools_t.TOOL_NONE)
			{
				// use current tool drawing
				applyTool(selectedTool, 2, e.Location);
			}
			this.selectedTool = tools_t.TOOL_NONE;
			
			// end tile selection mode when "finished" left-clicking
			if (e.Button == MouseButtons.Left && TileMode == true)
			{
				// set to read tiles from map
				TileMode = false;
				this.Invalidate();
			}
			this.mouseDown = false;
			this.drawDragRect = false;
		}

		private void renderBuffers()
		{
            float zfactor = getZoomFactor();
            // get graphics object from buffer image
            Graphics g = Graphics.FromImage(buffer);
			g.SmoothingMode = SmoothingMode.None;
			g.InterpolationMode = InterpolationMode.NearestNeighbor;
			g.PixelOffsetMode = PixelOffsetMode.Half;
			g.CompositingQuality = CompositingQuality.HighSpeed;
            g.CompositingMode = CompositingMode.SourceCopy;

            /////////////////////////////
            // -= coordinate system =- //
            /////////////////////////////

            g.ResetTransform();
			// rescale to (-sx, -sy)-(sx, sy)
			g.ScaleTransform(zfactor, zfactor);
			// offset
			g.TranslateTransform(GraphOffset.X, GraphOffset.Y);
			
			///////////////////////////////
			// -= render checkerboard =- //
			///////////////////////////////
			
			if (checkers != null)
			{
				using (TextureBrush tbrush = new TextureBrush(checkers, WrapMode.Tile))
				{
					g.FillRectangle(tbrush, -GraphOffset.X, -GraphOffset.Y,
						ClientSize.Width / zfactor, ClientSize.Height / zfactor);
				}
			}
			else
			{
                g.Clear(this.BackColor);
			}
			
			// nothing to do without at least a tileset
			if (tileset == null)
			{
				return;
			}

            //////////////////////////////
            // -= render tile layers =- //
            //////////////////////////////

            using (var myBrush = new SolidBrush(Color.Magenta))
            {
                if (TileMode)
                {
                    Rectangle area = new Rectangle(Point.Empty, tileset.getBuffer().Size);
                    // draw magenta behind the tiles (not strictly necessary)
                    g.FillRectangle(myBrush, area);
                    // draw tileset
                    g.InterpolationMode = InterpolationMode.NearestNeighbor;
                    g.CompositingMode = CompositingMode.SourceOver;
                    g.DrawImageUnscaled(tileset.getBuffer(), 0, 0);
                }
                else if (mapfile.layers.Count > 0)
                {
                    Rectangle area = new Rectangle(Point.Empty, mapfile.layers[0].getSizePixels());
                    g.CompositingMode = CompositingMode.SourceOver;
                    int startLayer = mapfile.getFirstVisibleLayer();
                    // render layers above using source over
                    for (int i = startLayer; i < mapfile.layers.Count; i++)
                    {
                        var L = mapfile.layers[i];
                        if (L.Enabled && (i <= SelectedLayer || LayersAbove))
                        {
                            if (L.ShowMask || i == 0)
                            {
                                // draw magenta behind the tiles (not strictly necessary)
                                g.FillRectangle(myBrush, area);
                                //g.CompositingMode = CompositingMode.SourceCopy;
                            }
                            L.render(g);
                        }
                    }
                }
            }

			///////////////////////
			// -= render grid =- //
			///////////////////////
			if (ShowGrid)
			{
				renderGrid(g);
			}

			/////////////////////////////
			// -= render rectangles =- //
			/////////////////////////////
			if (this.drawDragRect)
			{
				using (Pen P = new Pen(Color.Blue))
				{
					g.DrawRectangle(P, dragRect);
				}
			}
			if (this.drawSelectionRect)
			if (this.selectionFromTiles == TileMode)
			{
				using (Pen P = new Pen(Color.SeaShell))
				{
					P.Width = 1.5f;
					P.DashStyle = DashStyle.Dash;
					g.DrawRectangle(P, selectionRect);
						
					P.Color = Color.RoyalBlue;
					P.DashStyle = DashStyle.DashDotDot;
					g.DrawRectangle(P, selectionRect);
				}
			}

		} // renderBuffers()
		private void renderGrid(Graphics g)
		{
            //////////////////////
            // -= grid setup =- //
            //////////////////////
            float zfactor = getZoomFactor();
			float gridWidth = 1.0f / zfactor;
            // distance between axis ticks
            float axisSpacing = GridSize;
			// grid opacity color (value)
			Color gridColor = Color.DarkGray;
			
			// offset adjusted min/max values for grid
			float minX = -GraphOffset.X;
			float maxX = -GraphOffset.X + (float)ClientSize.Width / zfactor;
            float minY = -GraphOffset.Y;
			float maxY = -GraphOffset.Y + (float)ClientSize.Height / zfactor;

            // offset from left to truncated right
            float ax0 = minX - (float)Math.IEEERemainder(minX, axisSpacing);
			float ax1 = maxX + (float)Math.IEEERemainder(maxX, axisSpacing);
			// offset from bottom to truncated top
			float ay0 = minY - (float)Math.IEEERemainder(minY, axisSpacing);
			float ay1 = maxY + (float)Math.IEEERemainder(maxY, axisSpacing);

			//////////////////////
			// -= grid lines =- //
			//////////////////////
			Pen pen = new Pen(gridColor, gridWidth);
			//pen.DashStyle = DashStyle.DashDot;

			// X-axis left
			PointF axisP0 = new PointF(minX, 0);
			// X-axis right
			PointF axisP1 = new PointF(maxX, 0);
			for (float y = ay0; y < ay1; y += axisSpacing)
			{
				// X-axis gridlines
				axisP0.Y = y; axisP1.Y = y;
				// draw full-height lines
				g.DrawLine(pen, axisP0, axisP1);
			}
			// Y-axis top
			axisP0 = new PointF(0, maxY);
			// Y-axis bottom
			axisP1 = new PointF(0, minY);
			for (float x = ax0; x < ax1; x += axisSpacing)
			{
				// Y-axis gridlines
				axisP0.X = x; axisP1.X = x;
				// draw full-width lines
				g.DrawLine(pen, axisP0, axisP1);
			}

			pen.Dispose();
		}

		private void Editor_KeyDown(object sender, KeyEventArgs e)
        {
			//MessageBox.Show(e.KeyCode.ToString());
        }

        public void undo()
        {
            if (undoBuffer.Count > 0)
            {
                var index = undoBuffer.Count - 1;
                var buf = undoBuffer[index];
                // Create redo
                redoBuffer.Add(new LayerBuffer(mapfile.layers[buf.getIndex()].getTiles(), buf.getIndex()));

                // overwrite tiles of the old layer (and re-render layer)
                mapfile.layers[buf.getIndex()].setTiles(buf.getTiles(), this.tileset);
                // remove undobuffer
                undoBuffer.RemoveAt(index);
                // redraw screen
                this.Invalidate();
            }
        }
        public void redo()
        {
            if (redoBuffer.Count > 0)
            {
                var index = redoBuffer.Count - 1;
                var buf = redoBuffer[index];
                // Create undo
                undoBuffer.Add(new LayerBuffer(mapfile.layers[buf.getIndex()].getTiles(), buf.getIndex()));

                // overwrite tiles of the old layer (and re-render layer)
                mapfile.layers[buf.getIndex()].setTiles(buf.getTiles(), this.tileset);
                // remove redobuffer
                redoBuffer.RemoveAt(index);
                // redraw screen
                this.Invalidate();
            }
        }


    } // Editor class

} // namespace
