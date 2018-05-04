using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace MapEdit.Backend
{
	public class Layer
	{
        public const int LAYERS_PER_FLOOR = 8;

        Tileset TSET;
		List<Tile> tiles;
		Bitmap buffer;
		// brushes
		static Brush solidBrush = new SolidBrush(Color.FromArgb(80, Color.Red));
		static Brush abyssBrush = new SolidBrush(Color.FromArgb(80, Color.Magenta));
		static Brush waterBrush = new SolidBrush(Color.FromArgb(80, Color.Green));
        static Brush puddleBrush = new SolidBrush(Color.FromArgb(80, Color.CornflowerBlue));
        static Brush slowBrush = new SolidBrush(Color.FromArgb(80, Color.YellowGreen));
        static Brush iceBrush = new SolidBrush(Color.FromArgb(80, Color.LightBlue));
        static Brush jumpBrush = new SolidBrush(Color.FromArgb(80, Color.MediumPurple));
        static Brush entranceBrush = new HatchBrush(HatchStyle.DiagonalCross,
                                                    Color.FromArgb(160, Color.Black),
                                                    Color.FromArgb(128, Color.NavajoWhite));

        int tilesX;
		int tilesY;
		public bool Visible { set; get; }
		public bool ShowMask { set; get; }
		public int  ShowFlags { set; get; }

        public bool Enabled { get; set; }
        public byte Alpha { get; set; }

		public Layer(int sizeX, int sizeY)
		{
			this.TSET = null;
			this.tilesX = sizeX;
			this.tilesY = sizeY;
			this.Visible = false;
			this.ShowMask = false;
			this.ShowFlags = 1;
			// allocate room for X*Y tiles
			this.tiles = new List<Tile>(sizeX * sizeY);
            // defaults
            Enabled = false;
            Alpha = 0xFF;
		}

		public void create(Tileset tset)
		{
            this.Visible = true;
            for (int x = 0; x < tilesX; x++)
            for (int y = 0; y < tilesY; y++)
            {
                tiles.Add(new Tile());
            }
            // initialize buffer with tileset
            initializeBuffers(tset);
        }
        public void load(List<ulong> values, Tileset tset)
		{
			this.Visible = true;
			foreach (var v in values)
			{
				tiles.Add(new Tile(v));
			}
            // initialize buffer with tileset
            initializeBuffers(tset);
		}
		public List<ulong> export()
		{
			List<ulong> values = new List<ulong>();

			foreach (Tile t in tiles)
			{
				values.Add(t.compressed());
			}
			return values;
		}
		public void clear()
		{
			tiles.Clear();
		}
		public void initializeBuffers(Tileset tset)
		{
			this.TSET = tset;
			// create buffer for layer
			buffer = new Bitmap(this.tilesX * TSET.size, this.tilesY * TSET.size);
			buffer.MakeTransparent(Color.Magenta);
		}

		public int getWidth()
		{
			return tilesX * TSET.size;
		}
		public int getHeight()
		{
			return tilesY * TSET.size;
		}
		public int getTilesX()
		{
			return tilesX;
		}
		public int getTilesY()
		{
			return tilesY;
		}

        public List<Tile> getTiles()
        {
            return tiles;
        }
        public List<Tile> cloneTiles()
        {
            var newlist = new List<Tile>();
            tiles.ForEach((tile) => { newlist.Add(new Tile(tile.compressed())); });
            return newlist;
        }
        public void setTiles(List<Tile> tlist)
        {
            tiles = tlist;
            this.invalidate();
        }

		private int tcoord(int x, int y)
		{
			return y * tilesX + x;
		}
		
		void renderData(Graphics g, Rectangle dst, Brush brush, byte form)
		{
			switch (form)
			{
			case 0:
					g.FillRectangle(brush, dst);
				break;
			case 1: // Up Left
				g.FillPolygon(brush, new Point[]
					{
						new Point(dst.X + dst.Width, dst.Y-1),
						new Point(dst.X-1, dst.Y + dst.Height),
						new Point(dst.X + dst.Width, dst.Y + dst.Height),
					});
				break;
			case 2: // Up Right
				g.FillPolygon(brush, new Point[]
					{
						new Point(dst.X, dst.Y-1),
						new Point(dst.X, dst.Y + dst.Height),
						new Point(dst.X + dst.Width, dst.Y + dst.Height),
					});
				break;
			case 3:
				g.FillPolygon(brush, new Point[]
					{
						new Point(dst.X, dst.Y),
						new Point(dst.X + dst.Width, dst.Y),
						new Point(dst.X + dst.Width, dst.Y + dst.Height),
					});
				break;
			case 4:
				g.FillPolygon(brush, new Point[]
					{
						new Point(dst.X, dst.Y),
						new Point(dst.X + dst.Width, dst.Y),
						new Point(dst.X, dst.Y + dst.Height),
					});
				break;
			}
		}
		void renderTile(Graphics g, int x, int y, bool overdraw = false)
		{
			Tile tile = tiles[tcoord(x, y)];
            Rectangle dst = new Rectangle(x * TSET.size, y * TSET.size, TSET.size, TSET.size);
            // only draw tile if not (0, 0)
			if (!(tile.getTX() == 0 && tile.getTY() == 0) || overdraw)
			{
				Rectangle src = new Rectangle(tile.getTX() * TSET.size, tile.getTY() * TSET.size, TSET.size, TSET.size);
                if (tile.getRot() > 0)
                {
                    g.TranslateTransform((float)(dst.X + TSET.size / 2), (float) (dst.Y + TSET.size / 2));
                    g.RotateTransform(tile.getRot() * 90);
                    g.TranslateTransform(-(float)(dst.X + TSET.size / 2), -(float)(dst.Y + TSET.size / 2));
                    //g.TranslateTransform(-(float)TSET.size / 2, -(float)TSET.size / 2);
                }
                g.DrawImage(TSET.getBuffer(), dst, src, GraphicsUnit.Pixel);
                if (tile.getRot() > 0)
                {
                    g.ResetTransform();
                }
            }
			if (ShowFlags <= 0)
				return;
            // always draw flags, if any
            Brush brush = null;
            switch (tile.getFlags())
            {
                case Tile.Flags.SOLID:
                    brush = solidBrush;
                    break;
                case Tile.Flags.ABYSS:
                    brush = abyssBrush;
                    break;
                case Tile.Flags.WATER:
                    brush = waterBrush;
                    break;
                case Tile.Flags.SHALW:
                    brush = puddleBrush;
                    break;
                case Tile.Flags.SLOW:
                    brush = slowBrush;
                    break;
                case Tile.Flags.ICE:
                    brush = iceBrush;
                    break;
                case Tile.Flags.ENTRANCE:
                    brush = entranceBrush;
                    break;
                case Tile.Flags.JUMP_UP:
                case Tile.Flags.JUMP_DOWN:
                case Tile.Flags.JUMP_RGT:
                case Tile.Flags.JUMP_LEFT:
                    brush = jumpBrush;
                    break;
                default:
                    return;
            }
            if (brush != null)
            {
                if (ShowFlags > 1 && brush is SolidBrush)
                {
                    Color c = ((SolidBrush)brush).Color;
                    SolidBrush final = new SolidBrush(Color.FromArgb(255, c.R, c.G, c.B));
                    renderData(g, dst, final, tile.getForm());
                }
                else
                {
                    renderData(g, dst, brush, tile.getForm());
                }
            }
        }
        public void updateTile(int x, int y)
		{
			using (Graphics g = Graphics.FromImage(buffer))
			{
				g.InterpolationMode = InterpolationMode.NearestNeighbor;
				renderTile(g, x, y, true);
			}
			if (ShowMask == false)
				buffer.MakeTransparent(Color.Magenta);
		}
		public void invalidate()
		{
			if (tiles.Count == 0) return;
			
			using (Graphics g = Graphics.FromImage(buffer))
			{
				g.InterpolationMode = InterpolationMode.NearestNeighbor;
				g.Clear(Color.Magenta);

				for (int y = 0; y < tilesY; y++)
				for (int x = 0; x < tilesX; x++)
				{
					renderTile(g, x, y);
				}
			}
			if (ShowMask == false)
				buffer.MakeTransparent(Color.Magenta);
		}

		public void render(Graphics g)
		{
			if (Visible)
			{
				g.DrawImageUnscaled(buffer, 0, 0);
			}
		}

		public bool inRange(int x, int y)
		{
			return (x >= 0 && y >= 0 &&
				x < tilesX && y < tilesY);
		}
		public Tile getTile(int x, int y)
		{
			return tiles[tcoord(x, y)];
		}
		public Tile getTile(Point p)
		{
			if (inRange(p.X, p.Y)) return getTile(p.X, p.Y);
			return null;
		}

		public Point toTileCoord(float fx, float fy)
		{
			int x = (int)fx / TSET.size;
			int y = (int)fy / TSET.size;
			return new Point(x, y);
		}

		public void fill(int x, int y, byte ox, byte oy, byte tx, byte ty)
		{
			if (inRange(x, y) == false) return;
			if (tx == ox && ty == oy) return;

			Tile t = getTile(x, y);
			if (t.getTX() == ox && t.getTY() == oy)
			{
				t.setXY(tx, ty);

				fill(x - 1, y, ox, oy, tx, ty);
				fill(x + 1, y, ox, oy, tx, ty);
				fill(x, y - 1, ox, oy, tx, ty);
				fill(x, y + 1, ox, oy, tx, ty);
			}
		}
		public void replace(byte oldX, byte oldY, Tile src)
		{
			foreach (Tile t in tiles)
			{
				if (t.getTX() == oldX && t.getTY() == oldY)
				{
                    t.setXY(src.getTX(), src.getTY());
                    t.setFlags(src.getFlags());
                    t.setForm(src.getForm());
                    t.setRot(src.getRot());
                }
            }
		}

	}
}
