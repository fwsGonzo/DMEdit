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
            // replace magenta with invisible magenta
            replaceColor(this.tileset, Color.Magenta, Color.FromArgb(0, 255, 0, 255));
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
                for (int x = 0; x < bmpData.Stride; x += 4, i +=4)
                {
                    int color = ((int) buffer[i+0] << 0)  | 
                                ((int) buffer[i+1] << 8)  | 
                                ((int) buffer[i+2] << 16) | 
                                ((int) buffer[i+3] << 24);
                    if (source.ToArgb() == color)
                    {
                        buffer[i+0] = target.B;
                        buffer[i+1] = target.G;
                        buffer[i+2] = target.R;
                        buffer[i+3] = target.A;
                    }
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
