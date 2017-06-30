using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace MapEdit.Backend
{
	public class Layer
	{
		Tileset TSET;
		List<Tile> tiles;
		Bitmap buffer;
		// brushes
		static Brush solidBrush = new SolidBrush(Color.FromArgb(80, Color.Red));
		static Brush abyssBrush = new SolidBrush(Color.FromArgb(80, Color.Magenta));
		static Brush waterBrush = new SolidBrush(Color.FromArgb(80, Color.Green));
		static Brush slowBrush = new SolidBrush(Color.FromArgb(80, Color.YellowGreen));
        static Brush iceBrush = new SolidBrush(Color.FromArgb(80, Color.LightBlue));

        int tilesX;
		int tilesY;
		public bool Visible { set; get; }
		public bool ShowMask { set; get; }

		public Layer(int sizeX, int sizeY)
		{
			this.TSET = null;
			this.tilesX = sizeX;
			this.tilesY = sizeY;
			this.Visible = false;
			this.ShowMask = true;
			// allocate room for X*Y tiles
			this.tiles = new List<Tile>(sizeX * sizeY);
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
		public int load(List<uint> values, int index)
		{
			this.Visible = true;
			for (int y = 0; y < tilesY; y++)
			for (int x = 0; x < tilesX; x++)
			{
				tiles.Add(new Tile(values[index]));
				index ++;
			}
			return index;
		}
		public List<uint> export()
		{
			List<uint> values = new List<uint>();

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
            Debug.Assert(tlist.Count != 0);
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
            if (tile.getTX() != 0 || tile.getTY() != 0 || overdraw)
			{
				Rectangle src = new Rectangle(tile.getTX() * TSET.size, tile.getTY() * TSET.size, TSET.size, TSET.size);
				g.DrawImage(TSET.getBuffer(), dst, src, GraphicsUnit.Pixel);
            }
            // always draw flags, if any
            switch (tile.getFlags())
            {
                case Tile.Flags.SOLID:
                    renderData(g, dst, solidBrush, tile.getForm());
                    break;
                case Tile.Flags.ABYSS:
                    renderData(g, dst, abyssBrush, tile.getForm());
                    break;
                case Tile.Flags.WATER:
                    renderData(g, dst, waterBrush, tile.getForm());
                    break;
                case Tile.Flags.SLOW:
                    renderData(g, dst, slowBrush, tile.getForm());
                    break;
                case Tile.Flags.ICE:
                    renderData(g, dst, iceBrush, tile.getForm());
                    break;
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
		public void setTile(int x, int y, Tile t)
		{
			if (inRange(x, y))
			{
				tiles[tcoord(x, y)] = t;
			}
		}
		public void setTile(Point p, Tile t)
		{
			if (inRange(p.X, p.Y))
			{
				tiles[tcoord(p.X, p.Y)] = t;
			}
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
		public void replace(byte oldX, byte oldY, byte tx, byte ty)
		{
			foreach (Tile t in tiles)
			{
				if (t.getTX() == oldX && t.getTY() == oldY)
				{
					t.setXY(tx, ty);
				}
			}
		}

	}
}
