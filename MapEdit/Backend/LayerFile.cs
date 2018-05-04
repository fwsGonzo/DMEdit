using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MapEdit.Backend
{
	class LayerFile
	{
        private static char[] MAGIC = { 'D', 'M', 'F', '\0' };
        private static int VERSION = 1;

        struct layerdata_t {
            public bool enabled;
            public byte alpha;
        };

        static byte[] StringToByteArray(string str, int length)
        {
            return Encoding.ASCII.GetBytes(str.PadRight(length, '\0'));
        }

        public static MapFile loadFile(string file, Tileset tset)
		{

            using (var sr = new BinaryReader(File.Open(file, FileMode.Open, FileAccess.Read)))
            {
                MapFile result = new MapFile();
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
                int version = sr.ReadInt32();
                if (version != 1)
                {
                    // do version specific things
                    throw new System.InvalidOperationException();
                }
                // map attributes
                int sizeX = sr.ReadInt32();
                int sizeY = sr.ReadInt32();
                int floors = sr.ReadInt32();

                result.layers = layers;
                result.Attributes = sr.ReadInt64();
                result.X_location = sr.ReadInt32();
                result.Y_location = sr.ReadInt32();
                result.Brightness = sr.ReadSingle();
                // map k/v properties
                for (int i = 0; i < result.PropKey.Length; i++)
                {
                    result.PropKey[i] = new string(sr.ReadChars(24));
                    result.PropVal[i] = new string(sr.ReadChars(40));
                }

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
                        List<ulong> values = new List<ulong>();
                        for (int t = 0; t < sizeX * sizeY; t++)
                        {
                            values.Add(sr.ReadUInt64());
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
                // return mapfile
                return result;
            }
		}
		
		public static bool saveFile(string file, MapFile mapfile)
		{
			using (var sr = new BinaryWriter(File.Open(file, FileMode.Create, FileAccess.Write)))
			{
                var layers = mapfile.layers;
                // header
                sr.Write(MAGIC);
                sr.Write(VERSION);
                sr.Write((int) layers[0].getTilesX());
                sr.Write((int) layers[0].getTilesY());
                sr.Write((int) layers.Count / Layer.LAYERS_PER_FLOOR);
                sr.Write(mapfile.Attributes);
                sr.Write(mapfile.X_location);
                sr.Write(mapfile.Y_location);
                sr.Write(mapfile.Brightness);
                // map properties
                for (int i = 0; i < mapfile.PropKey.Length; i++)
                {
                    sr.Write(StringToByteArray(mapfile.PropKey[i], 24));
                    sr.Write(StringToByteArray(mapfile.PropVal[i], 40));
                }
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
                        List<ulong> tiledata = L.export();
                        foreach (ulong t in tiledata)
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
