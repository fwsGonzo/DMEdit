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
			
			//this.tileset = image;
			this.size = size;
		}

		public Image getBuffer()
		{
			return tileset;
		}

		Bitmap tileset;
		public int size;
	};
}
