using System.Collections.Generic;
using System.IO;

namespace MapEdit.Backend
{
	class LayerFile
	{
        private static char[] MAGIC = { 'D', 'M', 'F', '\0' };

        struct layerdata_t {
            public bool enabled;
            public byte alpha;
        };

        public static List<Layer> loadFile(string file, Tileset tset)
		{

            using (var sr = new BinaryReader(File.Open(file, FileMode.Open, FileAccess.Read)))
            {
                List<layerdata_t> layerdata = new List<layerdata_t>();
                List<Layer> layers = new List<Layer>();

                // map header
                // Verify magic
                char[] magic = sr.ReadChars(4);
                string src = new string(MAGIC);
                string dst = new string(magic);
                int c = src.CompareTo(dst);
                if (c != 0)
                {
                    throw new System.InvalidOperationException();
                }
                // map properties
                int sizeX = sr.ReadInt32();
                int sizeY = sr.ReadInt32();
                int floors = sr.ReadInt32();
                // layer data
                int layerCount = floors * Layer.LAYERS_PER_FLOOR;
                for (int i = 0; i < layerCount; i++)
                {
                    layerdata_t ld = new layerdata_t();
                    ld.enabled = sr.ReadBoolean();
                    ld.alpha = sr.ReadByte();
                    layerdata.Add(ld);
                }
                // layer tile data
                for (int i = 0; i < layerCount; i++)
                {
                    Layer L = new Layer(sizeX, sizeY);
                    // set layer properties
                    L.Alpha = layerdata[i].alpha;
                    L.Enabled = layerdata[i].enabled;

                    // only load enabled layers
                    if (L.Enabled)
                    {
                        List<uint> values = new List<uint>();
                        for (int t = 0; t < sizeX * sizeY; t++)
                        {
                            values.Add(sr.ReadUInt32());
                        }
                        L.load(values, tset);
                    }
                    else
                    {
                        // have to create empty layer
                        L.create(tset);
                    }

                    // default show mask only for layer 1
                    L.ShowMask = (i == 0);
                    // redraw
                    L.invalidate();
                    // add to list
                    layers.Add(L);
                }
                // return list of layers
                return layers;
            }
		}
		
		public static bool saveFile(string file, List<Layer> layers)
		{
			using (var sr = new BinaryWriter(File.Open(file, FileMode.Create, FileAccess.Write)))
			{
                // header
                sr.Write(MAGIC);
                sr.Write((int) layers[0].getTilesX());
                sr.Write((int) layers[0].getTilesY());
                sr.Write((int) layers.Count / Layer.LAYERS_PER_FLOOR);
                // layer data
                for (int i = 0; i < layers.Count; i++)
                {
                    sr.Write(layers[i].Enabled);
                    sr.Write(layers[i].Alpha);
                }
                // layer tile data
                for (int l = 0; l < layers.Count; l++)
				{
					Layer L = layers[l];
                    // only write enabled layers
                    if (L.Enabled)
                    {
                        List<uint> tiledata = L.export();
                        foreach (uint t in tiledata)
                        {
                            sr.Write(t);
                        }
                    }
				}
				return true;
			}
		}
	}
}
