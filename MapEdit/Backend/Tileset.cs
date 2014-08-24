using System.Drawing;

namespace MapEdit.Backend
{
	public class Tileset
	{
		public Tileset(Image image, int size)
		{
			this.tileset = new Bitmap(image);
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
