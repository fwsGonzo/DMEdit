using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Drawing.Imaging;
using System;

namespace MapEdit.Backend
{
    public class Layer
    {
        public const int LAYERS_PER_FLOOR = 8;

        private int tile_size;
        List<Tile> tiles;
        Bitmap buffer;
        // brushes
        static Brush solidBrush = new SolidBrush(Color.FromArgb(80, Color.Red));
        static Brush abyssBrush = new SolidBrush(Color.FromArgb(80, Color.Magenta));
        static Brush waterBrush = new SolidBrush(Color.FromArgb(80, Color.Green));
        static Brush puddleBrush = new SolidBrush(Color.FromArgb(80, Color.CornflowerBlue));
        static Brush slowBrush = new SolidBrush(Color.FromArgb(80, Color.YellowGreen));
        static Brush iceBrush = new SolidBrush(Color.FromArgb(80, Color.LightBlue));
        static Brush jumpBrush = new SolidBrush(Color.FromArgb(80, Color.MediumPurple));
        static Brush entranceBrush = new HatchBrush(HatchStyle.DiagonalCross,
                                                    Color.FromArgb(160, Color.Black),
                                                    Color.FromArgb(128, Color.NavajoWhite));
        static Brush pushbackBrush = new HatchBrush(HatchStyle.DiagonalCross,
                                                    Color.FromArgb(120, Color.Black),
                                                    Color.FromArgb(80, Color.Red));
        static Pen arrowPen = new Pen(Color.Magenta, 3.0f);
        static AdjustableArrowCap cap = new AdjustableArrowCap(4, 2);

        int tilesX;
        int tilesY;
        public bool Visible { set; get; }
        public bool ShowMask { set; get; }
        public int ShowFlags { set; get; }

        public bool Enabled { get; set; }
        public byte Alpha { get; set; }

        public Layer(int sizeX, int sizeY, int tilesize)
        {
            arrowPen.CustomEndCap = cap;
            
            this.tile_size = tilesize;
            this.tilesX = sizeX;
            this.tilesY = sizeY;
            this.Visible = false;
            this.ShowMask = false;
            this.ShowFlags = 1;
            // allocate room for X*Y tiles
            this.tiles = new List<Tile>(sizeX * sizeY);
            // defaults
            Enabled = false;
            Alpha = 0xFF;
        }

        public void create()
        {
            this.Visible = true;
            for (int x = 0; x < tilesX; x++)
            for (int y = 0; y < tilesY; y++)
            {
                tiles.Add(new Tile());
            }
            // initialize buffer with tileset
            initializeBuffers();
        }
        public void load(List<ulong> values)
        {
            this.Visible = true;
            foreach (var v in values)
            {
                tiles.Add(new Tile(v));
            }
            // initialize draw buffer
            initializeBuffers();
        }
        public void setTiles(List<Tile> tiles, Tileset tset)
        {
            this.tiles = tiles;
            this.invalidate(tset);
        }
        public List<ulong> export()
        {
            List<ulong> values = new List<ulong>();

            foreach (Tile t in tiles)
            {
                values.Add(t.compressed());
            }
            return values;
        }
        public void clear()
        {
            foreach (Tile t in tiles)
            {
                t.clear();
            }
        }
        private void initializeBuffers()
        {
            // create buffer for layer
            buffer = new Bitmap(this.tilesX * this.tile_size, this.tilesY * this.tile_size, PixelFormat.Format32bppArgb);
            //buffer.MakeTransparent(Color.Magenta);
        }

        public int getWidth()
        {
            return tilesX * this.tile_size;
        }
        public int getHeight()
        {
            return tilesY * this.tile_size;
        }
        public int getTilesX()
        {
            return tilesX;
        }
        public int getTilesY()
        {
            return tilesY;
        }

        public List<Tile> getTiles()
        {
            return tiles;
        }
        public List<Tile> cloneTiles()
        {
            var newlist = new List<Tile>();
            tiles.ForEach((tile) => { newlist.Add(new Tile(tile.compressed())); });
            return newlist;
        }

        private int tcoord(int x, int y)
        {
            return y * tilesX + x;
        }

        void renderData(Graphics g, Rectangle dst, Brush brush, byte form)
        {
            switch ((TileForm) form)
            {
                case TileForm.FORM_RECT:
                    g.FillRectangle(brush, dst);
                    break;
                case TileForm.FORM_DIAG_UL: // Up Left
                    g.FillPolygon(brush, new Point[]
                        {
                        new Point(dst.X + dst.Width, dst.Y-1),
                        new Point(dst.X-1, dst.Y + dst.Height),
                        new Point(dst.X + dst.Width, dst.Y + dst.Height),
                        });
                    break;
                case TileForm.FORM_DIAG_UR: // Up Right
                    g.FillPolygon(brush, new Point[]
                        {
                        new Point(dst.X, dst.Y-1),
                        new Point(dst.X, dst.Y + dst.Height),
                        new Point(dst.X + dst.Width, dst.Y + dst.Height),
                        });
                    break;
                case TileForm.FORM_DIAG_DL:
                    g.FillPolygon(brush, new Point[]
                        {
                        new Point(dst.X, dst.Y),
                        new Point(dst.X + dst.Width, dst.Y),
                        new Point(dst.X + dst.Width, dst.Y + dst.Height),
                        });
                    break;
                case TileForm.FORM_DIAG_DR:
                    g.FillPolygon(brush, new Point[]
                        {
                        new Point(dst.X, dst.Y),
                        new Point(dst.X + dst.Width, dst.Y),
                        new Point(dst.X, dst.Y + dst.Height),
                        });
                    break;
                case TileForm.FORM_HALF_U: // upper half
                    g.FillRectangle(brush, new RectangleF(
                        dst.X, dst.Y, dst.Width, dst.Height / 2
                    ));
                    break;
                case TileForm.FORM_HALF_D: // lower half
                    g.FillRectangle(brush, new RectangleF(
                        dst.X, dst.Y + dst.Height / 2, dst.Width, dst.Height / 2
                    ));
                    break;
                case TileForm.FORM_HALF_R: // right half
                    g.FillRectangle(brush, new RectangleF(
                        dst.X + dst.Width / 2, dst.Y, dst.Width / 2, dst.Height
                    ));
                    break;
                case TileForm.FORM_HALF_L: // left half
                    g.FillRectangle(brush, new RectangleF(
                        dst.X, dst.Y, dst.Width / 2, dst.Height
                    ));
                    break;
            }
        }
        void renderTile(Tileset tset, Graphics g, int x, int y, bool overdraw = false)
        {
            Tile tile = tiles[tcoord(x, y)];
            Rectangle dst = new Rectangle(x * this.tile_size, y * this.tile_size, this.tile_size, this.tile_size);
            // only draw tile if not (0, 0)
            if (!(tile.getTX() == 0 && tile.getTY() == 0) || overdraw)
            {
                Rectangle src = new Rectangle(tile.getTX() * this.tile_size, tile.getTY() * this.tile_size, this.tile_size, this.tile_size);
                if (tile.getRot() > 0)
                {
                    g.TranslateTransform((float)(dst.X + this.tile_size / 2), (float)(dst.Y + this.tile_size / 2));
                    g.RotateTransform(tile.getRot() * 90);
                    g.TranslateTransform(-(float)(dst.X + this.tile_size / 2), -(float)(dst.Y + this.tile_size / 2));
                }
                g.DrawImage(tset.getBuffer(), dst, src, GraphicsUnit.Pixel);
                if (tile.getRot() > 0)
                {
                    g.ResetTransform();
                }
            }
            if (ShowFlags <= 0)
                return;
            // always draw flags, if any
            Brush brush = null;
            switch (tile.getFlags())
            {
                case Tile.Flags.SOLID:
                    brush = solidBrush;
                    break;
                case Tile.Flags.ABYSS:
                    brush = abyssBrush;
                    break;
                case Tile.Flags.WATER:
                    brush = waterBrush;
                    break;
                case Tile.Flags.PUDDLE:
                    brush = puddleBrush;
                    break;
                case Tile.Flags.SLOW:
                    brush = slowBrush;
                    break;
                case Tile.Flags.ICE:
                    brush = iceBrush;
                    break;
                case Tile.Flags.ENTRANCE:
                    brush = entranceBrush;
                    break;
                case Tile.Flags.PUSHBACK:
                    brush = pushbackBrush;
                    break;
                case Tile.Flags.AUTOJUMP:
                    brush = jumpBrush;
                    break;
                default:
                    return;
            }
            if (brush != null)
            {
                if (ShowFlags > 1 && brush is SolidBrush)
                {
                    Color c = ((SolidBrush)brush).Color;
                    SolidBrush final = new SolidBrush(Color.FromArgb(255, c.R, c.G, c.B));
                    renderData(g, dst, final, tile.getForm());
                }
                else
                {
                    renderData(g, dst, brush, tile.getForm());
                }
            }
            // assist showing rotation
            if ((int) tile.getFlags() >= 32)
            {
                Point p0, p1;
                switch(tile.getRot())
                {
                    case 0:
                        p0 = new Point(dst.X + dst.Size.Width / 2, dst.Y + dst.Size.Height);
                        p1 = new Point(dst.X + dst.Size.Width / 2, dst.Y);
                        break;
                    case 1:
                        p0 = new Point(dst.X, dst.Y + dst.Size.Height / 2);
                        p1 = new Point(dst.X + dst.Size.Width, dst.Y + dst.Size.Height / 2);
                        break;
                    case 2:
                        p0 = new Point(dst.X + dst.Size.Width / 2, dst.Y);
                        p1 = new Point(dst.X + dst.Size.Width / 2, dst.Y + dst.Size.Height);
                        break;
                    case 3:
                        p0 = new Point(dst.X + dst.Size.Width, dst.Y + dst.Size.Height / 2);
                        p1 = new Point(dst.X, dst.Y + dst.Size.Height / 2);
                        break;
                    default:
                        throw new System.Exception("Invalid rotation for direction arrow");
                }
                g.DrawLine(arrowPen, p0, p1);
            }
        }
        public void updateTile(Tileset tset, int x, int y)
        {
            using (Graphics g = Graphics.FromImage(buffer))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.CompositingMode = CompositingMode.SourceCopy;
                renderTile(tset, g, x, y, true);
            }
        }
        public void invalidate(Tileset tset)
        {
            if (tiles.Count == 0) return;

            using (Graphics g = Graphics.FromImage(buffer))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.Clear(Color.Transparent);

                for (int y = 0; y < tilesY; y++)
                for (int x = 0; x < tilesX; x++)
                {
                    renderTile(tset, g, x, y);
                }
            }
        }

        public void render(Graphics g)
        {
            if (Visible)
            {
                g.DrawImageUnscaled(buffer, 0, 0);
            }
        }

        public bool inRange(int x, int y)
        {
            return (x >= 0 && y >= 0 &&
                x < tilesX && y < tilesY);
        }
        public Tile getTile(int x, int y)
        {
            return tiles[tcoord(x, y)];
        }
        public Tile getTile(Point p)
        {
            if (inRange(p.X, p.Y)) return getTile(p.X, p.Y);
            return null;
        }

        public Point toTileCoord(float fx, float fy)
        {
            int x = (int)fx / this.tile_size;
            int y = (int)fy / this.tile_size;
            return new Point(x, y);
        }

        public void fill(int x, int y, byte ox, byte oy, byte tx, byte ty)
        {
            if (inRange(x, y) == false) return;
            if (tx == ox && ty == oy) return;

            Tile t = getTile(x, y);
            if (t.getTX() == ox && t.getTY() == oy)
            {
                t.setXY(tx, ty);

                fill(x - 1, y, ox, oy, tx, ty);
                fill(x + 1, y, ox, oy, tx, ty);
                fill(x, y - 1, ox, oy, tx, ty);
                fill(x, y + 1, ox, oy, tx, ty);
            }
        }
        public void replace(byte oldX, byte oldY, Tile src)
        {
            foreach (Tile t in tiles)
            {
                if (t.getTX() == oldX && t.getTY() == oldY)
                {
                    t.setXY(src.getTX(), src.getTY());
                    t.setFlags(src.getFlags());
                    t.setForm(src.getForm());
                    t.setRot(src.getRot());
                }
            }
        }

        public bool determineIfEmpty()
        {
            foreach (Tile t in tiles)
            {
                if (t.getTX() != 0 || t.getTY() != 0) return false;
            }
            return true;
        }

        internal Size getSizePixels()
        {
            return new Size(getTilesX() * tile_size, getTilesY() * tile_size);
        }
    } // Layer
}
