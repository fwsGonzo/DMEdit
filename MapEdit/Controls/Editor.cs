using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MapEdit.Backend;

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
	}

	public partial class Editor : UserControl
    {
		public delegate void TileChangedEvent(int l, int x, int y, int tx, int ty, int stx, int sty);
		public event TileChangedEvent onTileChanged;

		string filename;
		bool   has_filename = false;
		bool   is_saved = false;

        Bitmap buffer = null;
		Image checkers = null;
		Tileset tileset = null;
		Selection selection = null;

		List<Layer> layers;
		public int SelectedLayer { get; set; }
		public bool ShowGrid { get; set; }
		public bool TileMode { get; set; }
		public bool LayersAbove { get; set; }

        private bool mouseDown;
        private Point mouseLocation;
		
		// graph constants
		private const float ZOOM_DELTA = 0.15f;
		
		public Color GraphGridColor { get; set; }
		public float GraphGridOpacity { get; set; }

		PointF graphOffset; float graphZoom;
		PointF tileOffset;  float tileZoom;
		public PointF GraphOffset
		{
			get { if (TileMode) return tileOffset; else return graphOffset; }
			set { if (TileMode) tileOffset = value; else graphOffset = value; }
		}
		public float GraphZoom
		{
			get { if (TileMode) return tileZoom; else return graphZoom; }
			set { if (TileMode) tileZoom = value; else graphZoom = value; }
		}
		public tools_t CurrentTool { get; set; }
		
		public int getLayerCount()
		{
			return layers.Count;
		}

		public Editor()
		{
			// default graph properties
			GraphGridColor = Color.DarkOliveGreen;
			GraphGridOpacity = 0.5f;	// default 10% visible

			graphOffset = new PointF(0.0f, 0.0f); // panning offset
			graphZoom = 4.0f;
			tileOffset = new PointF(0.0f, 0.0f);
			tileZoom = 2.0f;
			
			CurrentTool = tools_t.TOOL_NONE;
			selection = new Selection(1, 0);
			// initialize private stuff
			layers = new List<Layer>();
			SelectedLayer = 0;
			ShowGrid = true;
			TileMode = false;
			LayersAbove = false;

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
		public void initialize(string file, int tsize)
		{
			// checkerboard background
			checkers = Image.FromFile("checker.png");
			// tileset image && tilesize
			this.tileset = new Tileset(Image.FromFile(file), tsize);
		}

		// returns true if there is an existing valid map
		public bool containsMap()
		{
			return layers.Count > 0 && tileset != null;
		}
		// creates a new map based on size & layers
		public void createMap(int sizeX, int sizeY, int layerCount)
		{
			for (int i = 0; i < layerCount; i++)
			{
				Layer L = new Layer(sizeX, sizeY);
				L.create(this.tileset);
				L.ShowMask = (i == 0);
				L.invalidate();
				layers.Add(L);
			}
			// some changes were made to this map
			changesWereMade();
		}
		public void setMap(List<Layer> layers)
		{
			this.layers = layers;
			this.has_filename = false;
			this.is_saved = false;
		}
		public void loadMap(string filename)
		{
			// load map
			this.layers = LayerFile.loadFile(filename, this.tileset);
			this.Invalidate();
			// set filename & no changes made
			this.filename = filename;
			this.has_filename = true;
			this.is_saved = true;
		}
		public bool saveMapAs(string filename)
		{
			if (LayerFile.saveFile(filename, this.layers))
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
			if (LayerFile.saveFile(this.filename, this.layers))
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

		private void aboutToMakeChanges(int layer)
		{
			// TODO: Create undo
			// Call undo created signal
		}
		private void changesWereMade()
		{
			// the file is no longer 'current'
			this.is_saved = false;
		}

		public void setShowMask(bool mask)
		{
			layers[SelectedLayer].ShowMask = mask;
			layers[SelectedLayer].invalidate();
			this.Invalidate();
		}
		public bool getShowMask(int layer)
		{
			return layers[layer].ShowMask;
		}

		// transforms a point p, in window coordinate system
		// to graph (0, 0)-based coordinate system
		public PointF transformPoint(PointF p)
		{
			return new PointF(p.X / GraphZoom,
							  p.Y / GraphZoom);
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

		private void applyTool(tools_t tool, int state, Point e)
		{
			// ignore empty maps
			if (layers.Count == 0) return;

			PointF p = new PointF(e.X, e.Y);
			// transformed relative mouse position
			p = transformPoint(p);
			p.X -= GraphOffset.X;
			p.Y -= GraphOffset.Y;
			// get current point & tile
			Layer L = layers[SelectedLayer];
			Point tp = L.toTileCoord(p.X, p.Y);
			Tile t = L.getTile(tp);
			// outside of area (most likely)
			if (t == null) return;

			// now that we're here, before doing anything
			// signal that changes are about to be made to @layer
			aboutToMakeChanges(SelectedLayer);
			
			byte sx = (byte)selection.p0.X;
			byte sy = (byte)selection.p0.Y;

			switch (tool)
			{
			case tools_t.TOOL_READ:
				selection = new Selection(t.getTX(), t.getTY());
				// lifting a tile didn't change map, so just exit
				return;
			case tools_t.TOOL_DRAW:
				t.setXY(sx, sy);
				L.updateTile(tp.X, tp.Y);
				this.Invalidate();
				break;
			case tools_t.TOOL_FILL:
				L.fill(tp.X, tp.Y, t.getTX(), t.getTY(), sx, sy);
				L.invalidate();
				this.Invalidate();
				break;
			case tools_t.TOOL_REPLACE:
				L.replace(t.getTX(), t.getTY(), sx, sy);
				L.invalidate();
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

			// set new selection
			selection = new Selection(sp.X, sp.Y);
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
			e.Graphics.DrawImageUnscaled(buffer, 0, 0);
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
				TileMode = true;
				applySelection(0, e.Location);
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

				if (layers.Count == 0)
				{
					onTileChanged.Invoke(0, e.Location.X, e.Location.Y, 0, 0, 0, 0);
				}
				else
				{
					// get tile position on map

					if (TileMode == false)
					{
						// get current point & written tile
						Layer L = layers[SelectedLayer];
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
				else
				{
					if (TileMode) applySelection(1, e.Location);
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
			
			// end tile selection mode
			if (e.Button == MouseButtons.Right)
			{
				// set to read tiles from map
				TileMode = false;
				this.Invalidate();
			}
			this.mouseDown = false;
		}

		void renderBuffers()
		{
			// get graphics object from buffer image
			Graphics g = Graphics.FromImage(buffer);
			g.SmoothingMode = SmoothingMode.None;
			g.InterpolationMode = InterpolationMode.NearestNeighbor;
			g.PixelOffsetMode = PixelOffsetMode.Half;
			g.CompositingQuality = CompositingQuality.HighSpeed;
			
			/////////////////////////////
			// -= coordinate system =- //
			/////////////////////////////
			
			g.ResetTransform();
			// rescale to (-sx, -sy)-(sx, sy)
			g.ScaleTransform(GraphZoom, GraphZoom);
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
						ClientSize.Width / GraphZoom, ClientSize.Height / GraphZoom);
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

			if (TileMode)
			{
				// draw tileset
				Rectangle src = new Rectangle(new Point(0, 0), tileset.getBuffer().Size);
				Rectangle dst = new Rectangle(new Point(0, 0), tileset.getBuffer().Size);
				g.DrawImage(tileset.getBuffer(), dst, src, GraphicsUnit.Pixel);

				// draw selection
				using (SolidBrush brush = new SolidBrush(Color.FromArgb(80, 255, 255, 255)))
				{
					Point p0 = new Point(selection.p0.X * tileset.size, selection.p0.Y * tileset.size);
					Size  sz = new Size(tileset.size, tileset.size);

					g.CompositingMode = CompositingMode.SourceOver;
					g.FillRectangle(brush, new Rectangle(p0, sz));
				}
				
			}
			else
			{
				g.CompositingMode = CompositingMode.SourceCopy;
				for (int i = 0; i < layers.Count; i++)
				{
					if (i <= SelectedLayer || LayersAbove)
						layers[i].render(g);
				}
			}

			///////////////////////
			// -= render grid =- //
			///////////////////////
			if (ShowGrid)
			{
				renderGrid(g);
			}
			g.Dispose();

		} // renderBuffers()
		private void renderGrid(Graphics g)
		{
			//////////////////////
			// -= grid setup =- //
			//////////////////////
			float gridWidth = 1.0f / GraphZoom;
			// distance between axis ticks
			float axisSpacing = tileset.size;
			// grid opacity color (value)
			Color gridColor = Color.Black;
			
			// offset adjusted min/max values for grid
			float minX = -GraphOffset.X;
			float maxX = -GraphOffset.X + (float)ClientSize.Width / GraphZoom;
			float minY = -GraphOffset.Y;
			float maxY = -GraphOffset.Y + (float)ClientSize.Height / GraphZoom;
			
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

    } // Editor class

} // namespace
