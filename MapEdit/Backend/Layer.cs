using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MapEdit.Backend
{
	public class Layer
	{
		Tileset TSET;
		List<Tile> tiles;
		Bitmap buffer;
		
		int tilesX;
		int tilesY;
		bool visible;
		byte alpha;
		public bool ShowMask { set; get; }

		public Layer()
		{
			this.TSET = null;
			this.tilesX = this.tilesY = 0;
			this.visible = false;
			this.ShowMask = true;
			this.alpha = 0;

			this.tiles = new List<Tile>();
		}

		public void create(Tileset tset, int sizeX, int sizeY)
		{
			this.TSET = tset;
			this.tilesX = sizeX;
			this.tilesY = sizeY;
			this.visible = true;

			// create buffer for layer
			buffer = new Bitmap(sizeX * TSET.size, sizeY * TSET.size);
			buffer.MakeTransparent(Color.Magenta);
			
			tiles.Clear();
			for (int x = 0; x < tilesX; x++)
			for (int y = 0; y < tilesY; y++)
			{
				tiles.Add(new Tile());
			}
		}
		
		public int getWidth()
		{
			return tilesX * TSET.size;
		}
		public int getHeight()
		{
			return tilesY * TSET.size;
		}

		private int tcoord(int x, int y)
		{
			return y * tilesX + x;
		}
		
		void renderTile(Graphics g, int x, int y)
		{
			Tile tile = tiles[tcoord(x, y)];
			if (tile.getTX() != 0 || tile.getTY() != 0)
			{
				RectangleF src = new RectangleF(tile.getTX() * TSET.size, tile.getTY() * TSET.size, TSET.size, TSET.size);
				RectangleF dst = new RectangleF(x * TSET.size, y * TSET.size, TSET.size, TSET.size);
				g.DrawImage(TSET.getBuffer(), dst, src, GraphicsUnit.Pixel);
			}
		}
		public void updateTile(int x, int y)
		{
			using (Graphics g = Graphics.FromImage(buffer))
			{
				g.InterpolationMode = InterpolationMode.NearestNeighbor;
				renderTile(g, x, y);
			}
		}
		public void invalidate()
		{
			if (tiles.Count == 0 || visible == false) return;
			
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
			g.DrawImageUnscaled(buffer, 0, 0);
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
