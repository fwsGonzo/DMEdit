using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEdit.Backend
{
	class LayerFile
	{
		public static List<Layer> loadFile(string file, Tileset tset)
		{
			List<int> values = new List<int>();

			using (StreamReader sr = new StreamReader(file))
			{
				while (sr.Peek() >= 0)
				{
					string line = sr.ReadLine();
					string[] words = line.Split();
					foreach (string word in words)
					{
						if (word.Length > 0)
							values.Add(int.Parse(word));
					}
				}
			}
			if (values.Count > 3)
			{
				List<Layer> layers = new List<Layer>();

				int sizeX = values[0];
				int sizeY = values[1];
				int layerCount = values[2];

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

	}
}
