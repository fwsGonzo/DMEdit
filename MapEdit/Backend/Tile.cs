
namespace MapEdit.Backend
{
	public enum TileForm
	{
		FORM_RECT = 0,

        FORM_HALF_U,
        FORM_HALF_D,
        FORM_HALF_R,
        FORM_HALF_L,

        FORM_DIAG_UL,
		FORM_DIAG_UR,
		FORM_DIAG_DL,
		FORM_DIAG_DR,
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

            AUTOJUMP  = 32,
            AUTOMOVE  = 33,
            MOVEFAST  = 34,
        };

		public Tile()
		{
            this.tx = 0; this.ty = 0;
            this.form = (int)TileForm.FORM_RECT;
            this.data = 0;
            this.rot  = 0;
		}
		public Tile(byte x, byte y, byte t)
		{
            this.tx = x;
            this.ty = y;
            this.form = (int)TileForm.FORM_RECT;
            this.data = 0;
            this.rot  = 0;
        }
        public Tile(ulong data)
		{
			// Tile from 64bits ulong
			this.tx =   (byte) ((data >>  0) & 255);
			this.ty =   (byte) ((data >>  8) & 255);
            //this.?? = (byte) ((data >> 16) & 255);
            this.form = (byte) ((data >> 24) & 255);
			this.data = (byte) ((data >> 32) & 255);
            this.rot  = (byte) ((data >> 40) & 255);
        }
        public ulong compressed()
		{
			return (ulong)tx + ((ulong)ty << 8) // + ((ulong)tset << 16)
                + ((ulong)form << 24) + ((ulong)data << 32) + ((ulong)rot << 40);
		}

		public byte getTX() { return tx; }
		public byte getTY() { return ty; }
        internal void setXY(byte x, byte y) { tx = x; ty = y; }

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
		private byte form;
		private byte data;
        private byte rot;

        internal void clear()
        {
            tx = 0; ty = 0; form = 0; data = 0; rot = 0;
        }
    }
}
