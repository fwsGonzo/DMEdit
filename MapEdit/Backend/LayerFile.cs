using System.Collections.Generic;
using System.IO;

namespace MapEdit.Backend
{
	class LayerFile
	{
		public static List<Layer> loadFile(string file, Tileset tset)
		{

            using (var sr = new BinaryReader(File.Open(file, FileMode.Open, FileAccess.Read)))
            {
                List<Layer> layers = new List<Layer>();

                int sizeX = sr.ReadInt32();
                int sizeY = sr.ReadInt32();
                int layerCount = sr.ReadInt32();

                for (int i = 0; i < layerCount; i++)
                {
                    Layer L = new Layer(sizeX, sizeY);

                    List<uint> values = new List<uint>();
                    for (int t = 0; t < sizeX*sizeY; t++)
                    {
                        values.Add(sr.ReadUInt32());
                    }
                    L.load(values);

                    // default show mask only for layer 1
                    L.ShowMask = (i == 0);
                    // create bitmap
                    L.initializeBuffers(tset);
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
                sr.Write((int) layers[0].getTilesX());
                sr.Write((int) layers[0].getTilesY());
                sr.Write((int) layers.Count);

                for (int l = 0; l < layers.Count; l++)
				{
					Layer L = layers[l];
					List<uint> tiledata = L.export();
                    foreach (uint t in tiledata)
                    {
                        sr.Write(t);
                    }
				}
				return true;
			}
		}
	}
}
