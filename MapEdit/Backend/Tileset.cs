using System;
using System.Drawing;

namespace MapEdit.Backend
{
	public class Tileset
	{
		public Tileset(Image image, int size)
		{
			this.tileset = new Bitmap(image);
			tileset.MakeTransparent(Color.Magenta);
			this.size = size;
		}

		public Image getBuffer()
		{
			return tileset;
		}

		private Bitmap tileset;
		public  int size;
	};
}
