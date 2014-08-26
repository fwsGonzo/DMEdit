using System.Collections.Generic;
using System.Drawing;

namespace MapEdit.Backend
{
	public class Selection
	{
		public Selection(Point P0, Point P1)
		{
			Rectangle rect = toTileRect(P0, P1);
			size = new Size(rect.Width, rect.Height);
			tiles = new List<Tile>();

			for (int y = 0; y < size.Height; y++)
			for (int x = 0; x < size.Width;  x++)
			{
				byte tx = (byte) (rect.X + x);
				byte ty = (byte) (rect.Y + y);
				tiles.Add(new Tile(tx, ty));
			}
		}
		public Selection(int x, int y)
			: this(new Point(x, y), new Point(x, y))
		{
		}
		public Selection(Layer L, Point P0, Point P1)
		{
			Rectangle rect = toTileRect(P0, P1);
			size = new Size(rect.Width, rect.Height);
			tiles = new List<Tile>();

			for (int y = 0; y < size.Height; y++)
			for (int x = 0; x < size.Width; x++)
			{
				byte tx = (byte)(rect.X + x);
				byte ty = (byte)(rect.Y + y);
				tiles.Add(L.getTile(tx, ty));
			}
		}

		Rectangle toTileRect(Point a, Point b)
		{
			int x1 = (a.X < b.X) ? a.X : b.X;
			int x2 = ((a.X > b.X) ? a.X : b.X) + 1;
			int y1 = (a.Y < b.Y) ? a.Y : b.Y;
			int y2 = ((a.Y > b.Y) ? a.Y : b.Y) + 1;

			return new Rectangle(x1, y1, x2 - x1, y2 - y1);
		}


		private int mod(int x, int m)
		{
			int r = x % m;
			return r < 0 ? r + m : r;
		}
		public Tile get(int x, int y)
		{
			return tiles[(mod(y, size.Height) * size.Width) + mod(x, size.Width)];
		}
		public Tile delta(Point P0, Point P1)
		{
			int x = P1.X - P0.X;
			int y = P1.Y - P0.Y;
			
			return get(x, y);
		}

		public Size size;
		public List<Tile> tiles;
	}
}
