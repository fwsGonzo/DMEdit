using System.Drawing;

namespace MapEdit.Backend
{
	public class Selection
	{
		public Selection(Point P0, Point P1)
		{
			select = toTileRect(P0, P1);
		}
		public Selection (int x, int y)
		{
			select = new Rectangle(x, y, 1, 1);
		}

		Rectangle toTileRect(Point a, Point b)
		{
			int x1 = (a.X < b.X) ? a.X : b.X;
			int x2 = ((a.X > b.X) ? a.X : b.X) + 1;
			int y1 = (a.Y < b.Y) ? a.Y : b.Y;
			int y2 = ((a.Y > b.Y) ? a.Y : b.Y) + 1;

			return new Rectangle(x1, y1, x2 - x1, y2 - y1);
		}

		public byte deltaX(int x, int nx)
		{
			return (byte)(select.X + (nx - x) % select.Width);
		}
		public byte deltaY(int y, int ny)
		{
			return (byte)(select.Y + (ny - y) % select.Height);
		}
		public byte getX(int dx)
		{
			return (byte)(select.X + dx % select.Width);
		}
		public byte getY(int dy)
		{
			return (byte)(select.Y + dy % select.Height);
		}

		public Rectangle select;
	}
}
