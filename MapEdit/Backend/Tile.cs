
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
            ACTIVATE = 16,

            AUTOJUMP  = 32,
            AUTOMOVE  = 33,
            MOVEFAST  = 34,

            // scanner flags
            CREATE_OBJECT = 40
        };

		public Tile()
		{
            this.tx = 0; this.ty = 0;
            this.form = (int)TileForm.FORM_RECT;
            this.data = 0;
            this.rot  = 0;
            this.shader = 0;
		}
		public Tile(int x, int y, byte shader)
		{
            this.tx = (short) x;
            this.ty = (short) y;
            this.form = (int)TileForm.FORM_RECT;
            this.data = 0;
            this.rot  = 0;
            this.shader = shader;
        }
        public Tile(ulong data)
		{
			// Tile from 64bits ulong
			this.tx =   (short) ((data >>  0) & 0xFFFF);
			this.ty =   (short) ((data >> 16) & 0xFFFF);
            this.rot = (byte)((data >> 32) & 255);
            this.form = (byte) ((data >> 40) & 255);
			this.data = (byte) ((data >> 48) & 255);
        }
        public ulong compressed()
		{
			return (ulong)tx + ((ulong)ty << 16)
                + ((ulong)rot << 32) + ((ulong)form << 40) + ((ulong)data << 48);
		}

		public int getTX() { return tx; }
		public int getTY() { return ty; }
        internal void setXY(int x, int y) {
            tx = (short) x; ty = (short) y;
        }

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

        internal void setShader(int shader)
        {
            this.shader = (byte)shader;
        }
        internal int getShader()
        {
            return this.shader;
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

		private short tx;
		private short ty;
		private byte form;
		private byte data;
        private byte rot;
        private byte shader;

        internal void clear()
        {
            tx = 0; ty = 0; form = 0; data = 0; rot = 0;
        }
    }
}
