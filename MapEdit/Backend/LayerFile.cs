using System.Collections.Generic;
using System.IO;

namespace MapEdit.Backend
{
	class LayerFile
	{
		public static List<Layer> loadFile(string file, Tileset tset)
		{
			List<uint> values = new List<uint>();

			using (StreamReader sr = new StreamReader(file))
			{
				while (sr.Peek() >= 0)
				{
					string line = sr.ReadLine();
					string[] words = line.Split();
					foreach (string word in words)
					{
						if (word.Length > 0)
							values.Add(uint.Parse(word));
					}
				}
			}
			if (values.Count > 3)
			{
				List<Layer> layers = new List<Layer>();

				int sizeX = (int) values[0];
				int sizeY = (int) values[1];
				int layerCount = (int) values[2];

				int index = 3;

				for (int i = 0; i < layerCount; i++)
				{
					Layer L = new Layer(sizeX, sizeY);
					index = L.load(values, index);
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
			return null;
		}
		
		public static bool saveFile(string file, List<Layer> layers)
		{
			using (StreamWriter sr = new StreamWriter(file))
			{
				const string CRLF = "\r\n";
				string w = layers[0].getTilesX() + " " +
						   layers[1].getTilesY() + " " +
						   layers.Count + CRLF + CRLF;
				sr.Write(w);

				for (int l = 0; l < layers.Count; l++)
				{
					Layer L = layers[l];
					List<uint> tiledata = L.export();
					int index = 0;

					for (int y = 0; y < L.getTilesY(); y++)
					{
						w = "";
						// build row of tiles
						for (int x = 0; x < L.getTilesX(); x++)
						{
							w += tiledata[index] + " ";
							index++;
						}
						w += CRLF;
						// write row of tiles
						sr.Write(w);
					}
					// write opening between layers
					sr.Write(CRLF);
				}
				return true;
			}
			return false;
		}
	}
}
