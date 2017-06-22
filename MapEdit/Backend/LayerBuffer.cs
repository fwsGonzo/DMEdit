using System.Collections.Generic;
using System.Diagnostics;

namespace MapEdit.Backend
{
	public class LayerBuffer
    {
		List<Tile> tiles;
        int lindex;

		public LayerBuffer(List<Tile> from_tiles, int index)
		{
			this.tiles = from_tiles;
            Debug.Assert(this.tiles.Count != 0);
            this.lindex = index;
		}

        public List<Tile> getTiles()
        {
            return tiles;
        }

        public int getIndex()
        {
            return lindex;
        }

	}
}
