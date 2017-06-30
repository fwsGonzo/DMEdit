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
        public void setTexture(Image img)
        {
            tileset = new Bitmap(img);
        }

		private Bitmap tileset;
		public  int size;
	};
}
