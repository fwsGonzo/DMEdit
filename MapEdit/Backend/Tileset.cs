using System;
using System.Drawing;

namespace MapEdit.Backend
{
	public class Tileset
	{
		public Tileset(Image image, int size)
		{
			this.tileset = image;
			this.size = size;
		}

		public Image getBuffer()
		{
			return tileset;
		}

		Image tileset;
		public int size;
	};
}
