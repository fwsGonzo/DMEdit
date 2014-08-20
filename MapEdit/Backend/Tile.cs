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
		enum Bits
		{
			SOLID_BIT = 0,
			ABYSS_BIT,
			WATER_BIT,
			SLOW_BIT,
			ICE_BIT,

			FLOOR_UP_BIT,
			FLOOR_DN_BIT
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

		public void setSolid(bool v) { setdata((int)Bits.SOLID_BIT, v); }
		public bool isSolid() { return getdata((int)Bits.SOLID_BIT); }

		public void setAbyss(bool v) { setdata((int)Bits.ABYSS_BIT, v); }
		public bool isAbyss() { return getdata((int)Bits.ABYSS_BIT); }

		public void setWater(bool v) { setdata((int)Bits.WATER_BIT, v); }
		public bool isWater() { return getdata((int)Bits.WATER_BIT); }

		public void setSlow(bool v) { setdata((int)Bits.SLOW_BIT, v); }
		public bool isSlow() { return getdata((int)Bits.SLOW_BIT); }

		public void setIce(bool v) { setdata((int)Bits.ICE_BIT, v); }
		public bool isIce() { return getdata((int)Bits.ICE_BIT); }

		//uint getColor() const;

		private static int tileSize;
		public static int getSize()
		{
			return tileSize;
		}
		public static void setSize(int size)
		{
			tileSize = size;
		}

		private bool getdata(int bit)
		{
			return ((data >> bit) & 1) != 0;
		}
		private void setdata(int bit, bool v)
		{
			if (v)
				data |= (byte)(1 << bit);
			else
				data &= (byte)~(1 << bit);
		}

		private byte tx;
		private byte ty;
		private byte form;
		private byte data;
	}
}
