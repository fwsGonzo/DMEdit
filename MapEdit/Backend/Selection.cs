using System.Drawing;

namespace MapEdit.Backend
{
	public class Selection
	{
		public Selection(int x, int y)
		{
			p0 = new Point(x, y);
			p1 = new Point(x, y);
		}

		public Point p0;
		public Point p1;
	}
}
