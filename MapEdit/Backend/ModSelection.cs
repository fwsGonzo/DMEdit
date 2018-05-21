using System;
using System.Text;

namespace MapEdit.Backend
{
    public class ModSelection
    {
        public string ModBase { get; set; }
        public string ModDir { get; set; }
        public int    TileSize { get; set; }

        public ModSelection(string mod_base)
        {
            this.ModBase = mod_base;
        }
    }
}
