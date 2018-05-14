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

            WATER  = 3,
            PUDDLE = 4,
            SNOW   = 5,
            ICE    = 6,
            DAMAGE = 7,
            PUSHBACK = 9,

            SLOW = 12,
            CLIMB = 13,
            FENCE = 14,
            ENTRANCE = 15,

            JUMP_UP   = 32,
            JUMP_DOWN = 33,
            JUMP_RGT  = 34,
            JUMP_LEFT = 35,

            MOVE_UP = 36,
            MOVE_DN = 37,
            MOVE_RI = 38,
            MOVE_LE = 39,
        };

		public Tile()
		{
            this.tx = 0; this.ty = 0; this.tset = 0;
            this.form = (int)TileForm.FORM_RECT;
            this.data = 0;
            this.rot  = 0;
		}
		public Tile(byte x, byte y, byte t)
		{
            this.tx = x;
            this.ty = y;
            this.tset = t;
            this.form = (int)TileForm.FORM_RECT;
            this.data = 0;
            this.rot  = 0;
        }
        public Tile(ulong data)
		{
			// Tile from 64bits ulong
			this.tx =   (byte) ((data >>  0) & 255);
			this.ty =   (byte) ((data >>  8) & 255);
            this.tset = (byte) ((data >> 16) & 255);
            this.form = (byte) ((data >> 24) & 255);
			this.data = (byte) ((data >> 32) & 255);
            this.rot  = (byte) ((data >> 40) & 255);
        }
        public ulong compressed()
		{
			return (ulong)tx + ((ulong)ty << 8) + ((ulong)tset << 16)
                + ((ulong)form << 24) + ((ulong)data << 32) + ((ulong)rot << 40);
		}

		public byte getTX() { return tx; }
		public byte getTY() { return ty; }
        internal void setXY(byte x, byte y) { tx = x; ty = y; }

        public byte getTileset() { return this.tset;  }

        internal byte getForm() { return form; }
        internal void setForm(byte f) { form = f; }

        internal void setData(byte src) { data = src; }
        internal byte getData() { return data; }

        internal Flags getFlags()
        {
            return (Flags)data;
        }
        internal void setFlags(Flags flag)
        {
            data = (byte)flag;
        }

        internal void setRot(int rotation)
        {
            this.rot = (byte) rotation;
        }
        internal int getRot()
        {
            return this.rot;
        }

		private static int tileSize;
        internal static int getSize()
		{
			return tileSize;
		}
        internal static void setSize(int size)
		{
			tileSize = size;
		}

		private byte tx;
		private byte ty;
        private byte tset;
		private byte form;
		private byte data;
        private byte rot;

        internal void clear()
        {
            tx = 0; ty = 0; tset = 0; form = 0; data = 0; rot = 0;
        }
    }
}
