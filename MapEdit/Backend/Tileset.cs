using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace MapEdit.Backend
{
	public class Tileset
	{
		public Tileset(Image image, int size)
		{
			this.size = size;
            this.setTexture(image);
        }

        public Image getBuffer()
		{
			return tileset;
		}
        public void setTexture(Image img)
        {
            tileset = new Bitmap(img.Width, img.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(tileset))
            {
                g.DrawImageUnscaled(img, 0, 0);
            }
            replaceColor(this.tileset, Color.FromArgb(255, Color.Magenta), Color.FromArgb(0));
        }

        private void replaceColor(Bitmap bmp, System.Drawing.Color source, System.Drawing.Color target)
        {
            Rectangle rect = new Rectangle(Point.Empty, bmp.Size);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            // Declare an array to hold the bytes of the bitmap.
            int bytes = bmpData.Stride * bmpData.Height;
            var buffer = new byte[bytes];

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;
            Marshal.Copy(ptr, buffer, 0, bytes);

            int i = 0;
            for (int y = 0; y < bmpData.Height; y++)
            {
                for (int x = 0; x < bmpData.Stride; x += 4)
                {
                    if (buffer[i+0] == source.R && buffer[i+1] == source.G && buffer[i+2] == source.B)
                    {
                        buffer[i+0] = target.R;
                        buffer[i+1] = target.G;
                        buffer[i+2] = target.B;
                        buffer[i+3] = target.A;
                    }
                    i += 4;
                }
            }
            Debug.Assert(i == bytes);
            // copy back to image
            Marshal.Copy(buffer, 0, ptr, bytes);
            bmp.UnlockBits(bmpData);
        }

        private Bitmap tileset;
		public  int size;
	};
}
