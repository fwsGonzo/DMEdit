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
			tx = 0; ty = 0;
			form = (int)TileForm.FORM_RECT;
			data = 0;
		}
		public Tile(byte x, byte y)
		{
			tx = x;
			ty = y;
			form = (int)TileForm.FORM_RECT;
			data = 0;
		}
		public Tile(byte x, byte y, byte form, byte data)
		{
			this.tx = x;
			this.ty = y;
			this.form = form;
			this.data = data;
		}
		public Tile(uint data)
		{
			// Tile from 32bits uint
			this.tx =   (byte) ((data >> 0) & 255);
			this.ty =   (byte) ((data >> 8) & 255);
			this.form = (byte) ((data >> 16) & 255);
			this.data = (byte) ((data >> 24) & 255);
		}
		public uint compressed()
		{
			return (uint)tx + ((uint)ty << 8) + ((uint)form << 16) + ((uint)data << 24);
		}

		public byte getTX() { return tx; }
		public byte getTY() { return ty; }
		public void setXY(byte x, byte y) { tx = x; ty = y; }

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
		private byte form;
		private byte data;
	}
}
