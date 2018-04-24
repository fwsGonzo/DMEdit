using System;

namespace MapEdit.Backend
{
	enum TileForm
	{
		FORM_RECT = 0,

		FORM_DIAG_UL = 1,
		FORM_DIAG_UR = 2,
		FORM_DIAG_DL = 3,
		FORM_DIAG_DR = 4,

		FORM_HALF_U = 5,
		FORM_HALF_D = 6,
		FORM_HALF_R = 7,
		FORM_HALF_L = 8,
	};

	public class Tile
	{
		public enum Flags
		{
            NONE = 0,
            SOLID = 1,
            ABYSS = 2,

            WATER = 3,
            SHALW = 4,
            SNOW = 5,
            ICE = 6,

            SLOW = 12,
            CLIMB = 13,
            STAIR = 14,

            JUMP_UP   = 24,
            JUMP_DOWN = 25,
            JUMP_RGT  = 26,
            JUMP_LEFT = 27,
        };

		public Tile()
		{
            this.tx = 0; this.ty = 0; this.tset = 0;
            this.form = (int)TileForm.FORM_RECT;
            this.data = 0;
		}
		public Tile(byte x, byte y, byte t)
		{
            this.tx = x;
            this.ty = y;
            this.tset = t;
            this.form = (int)TileForm.FORM_RECT;
            this.data = 0;
		}
		public Tile(ulong data)
		{
			// Tile from 64bits ulong
			this.tx =   (byte) ((data >> 0) & 255);
			this.ty =   (byte) ((data >> 8) & 255);
            this.tset = (byte)((data >> 16) & 255);
            this.form = (byte) ((data >> 24) & 255);
			this.data = (byte) ((data >> 32) & 255);
		}
		public ulong compressed()
		{
			return (ulong)tx + ((ulong)ty << 8) + ((ulong)tset << 16) + ((ulong)form << 24) + ((ulong)data << 32);
		}

		public byte getTX() { return tx; }
		public byte getTY() { return ty; }
		public void setXY(byte x, byte y) { tx = x; ty = y; }

        public byte getTileset() { return this.tset;  }

		public byte getForm() { return form; }
		public void setForm(byte f) { form = f; }

		public byte getData() { return data; }

        public Flags getFlags()
        {
            return (Flags)data;
        }
        public void setFlags(Flags flag)
        {
            data = (byte)flag;
        }

		private static int tileSize;
		public static int getSize()
		{
			return tileSize;
		}
		public static void setSize(int size)
		{
			tileSize = size;
		}

		private byte tx;
		private byte ty;
        private byte tset;
		private byte form;
		private byte data;
	}
}
