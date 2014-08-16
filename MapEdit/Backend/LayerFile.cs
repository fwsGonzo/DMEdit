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
		public static List<Layer> loadFile(string file)
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
					layers.Add(L);
				}
				return layers;
			}
			return null;
		}

	}
}
