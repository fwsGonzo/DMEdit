using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace MapEdit.Backend
{
    public class MapFile
    {
        public List<Layer> layers = new List<Layer>();
        public Int64 Attributes { get; set; }
        public int X_location { get; set; }
        public int Y_location { get; set; }
        public float Brightness { get; set; }
        public string[] PropKey = new string[4];
        public string[] PropVal = new string[4];

        private static char[] MAGIC = { 'D', 'M', 'F', '\0' };
        private static int VERSION = 1;
        private static int HEADER_SIZE = 300;
        private static int KEY_LENGTH = 20;
        private static int VAL_LENGTH = 44;

        internal struct layerdata_t
        {
            public bool enabled;
            public byte alpha;
        };


        public MapFile()
        {
            Attributes = 0;
            X_location = 0;
            Y_location = 0;
            Brightness = 1.0f;
            for (int i = 0; i < PropKey.Length; i++)
            {
                PropKey[i] = "";
                PropVal[i] = "";
            }
        }

        public bool hasProperty(string key)
        {
            foreach (string k in PropKey)
            {
                if (k == key) return true;
            }
            return false;
        }

        public string get(string key)
        {
            for (int i = 0; i < PropKey.Length; i++)
            {
                if (PropKey[i] == key) return PropVal[i];
            }
            return "";
        }

        public Image applyTiles(string mod_dir, Image defaultTiles)
        {
            if (this.hasProperty("tiles"))
            {
                try
                {
                    var tiles = Image.FromFile(mod_dir + "/" + this.get("tiles"));
                    Console.WriteLine("Using tileset from " + this.get("tiles"));
                    return tiles;
                }
                catch (System.IO.IOException)
                {
                    Console.WriteLine("Could not find " + this.get("tiles") + ", using default");
                    return defaultTiles;
                }
            }
            else
            {
                Console.WriteLine("No custom tileset for this map, using default");
                return defaultTiles;
            }
        }

        internal int getFirstVisibleLayer()
        {
            for (int i = layers.Count-1; i >= 0; i--)
            {
                if (layers[i].ShowMask) return i;
            }
            return 0;
        }

        internal static MapFile load(string mod_dir, string file, Tileset tset, Image default_tiles)
        {
            using (var handle = File.Open(file, FileMode.Open, FileAccess.Read))
            {
                using (var sr = new BinaryReader(handle))
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
                        throw new System.InvalidOperationException("Missing signature in map file");
                    }
                    int version = sr.ReadInt32();
                    if (version != 1)
                    {
                        // do version specific things
                        throw new System.InvalidOperationException("Map version mismatch");
                    }
                    // map attributes
                    int sizeX = sr.ReadInt32();
                    int sizeY = sr.ReadInt32();
                    int floors = sr.ReadInt32();
                    int headersize = sr.ReadInt32();
                    if (headersize != HEADER_SIZE)
                    {
                        // do version specific things
                        throw new System.InvalidOperationException("Header size mismatch");
                    }

                    result.layers = layers;
                    result.Attributes = sr.ReadInt64();
                    result.X_location = sr.ReadInt32();
                    result.Y_location = sr.ReadInt32();
                    result.Brightness = sr.ReadSingle();
                    // map k/v properties
                    for (int i = 0; i < result.PropKey.Length; i++)
                    {
                        var rkey = sr.ReadChars(KEY_LENGTH); int keylen = strlen(rkey);
                        var rval = sr.ReadChars(VAL_LENGTH); int vallen = strlen(rval);
                        result.PropKey[i] = new string(rkey, 0, keylen);
                        result.PropVal[i] = new string(rval, 0, vallen);
                    }
                    // resolve tiles image
                    Image tiles = result.applyTiles(mod_dir, default_tiles);
                    tset.setTexture(tiles);

                    // layer data
                    int layerCount = floors * Layer.LAYERS_PER_FLOOR;
                    for (int i = 0; i < layerCount; i++)
                    {
                        layerdata_t ld = new layerdata_t
                        {
                            enabled = sr.ReadBoolean(),
                            alpha = sr.ReadByte()
                        };
                        layerdata.Add(ld);
                    }
                    // layer tile data
                    for (int i = 0; i < layerCount; i++)
                    {
                        Layer L = new Layer(sizeX, sizeY, tset.size)
                        {
                            // set layer properties
                            Alpha = layerdata[i].alpha,
                            Enabled = layerdata[i].enabled
                        };

                        // only load enabled layers
                        if (L.Enabled)
                        {
                            List<ulong> values = new List<ulong>();
                            for (int t = 0; t < sizeX * sizeY; t++)
                            {
                                values.Add(sr.ReadUInt64());
                            }
                            L.load(values);
                        }
                        else
                        {
                            // have to create empty layer
                            L.create();
                        }

                        // default show mask only for layer 1
                        L.ShowMask = (i == 0);
                        // redraw
                        L.invalidate(tset);
                        // add to list
                        layers.Add(L);
                    }
                    // return complete mapfile
                    return result;
                }
            }
        } // load(...)

        internal bool save(string file)
        {
            // to make sure we dispose/unlock the file, double using here
            using (var handle = File.Open(file, FileMode.Create, FileAccess.Write))
            {
                using (var sr = new BinaryWriter(handle))
                {
                    // header
                    sr.Write(MAGIC);
                    sr.Write(VERSION);
                    sr.Write((int)layers[0].getTilesX());
                    sr.Write((int)layers[0].getTilesY());
                    sr.Write((int)layers.Count / Layer.LAYERS_PER_FLOOR);
                    sr.Write((int)HEADER_SIZE); // header size
                    sr.Write(this.Attributes);
                    sr.Write(this.X_location);
                    sr.Write(this.Y_location);
                    sr.Write(this.Brightness);
                    // map properties
                    for (int i = 0; i < this.PropKey.Length; i++)
                    {
                        sr.Write(StringToByteArray(this.PropKey[i], KEY_LENGTH));
                        sr.Write(StringToByteArray(this.PropVal[i], VAL_LENGTH));
                    }
                    // layer data
                    foreach (Layer L in layers)
                    {
                        // verify if layer is actually empty during saving
                        if (L.Enabled)
                        {
                            L.Enabled = !L.determineIfEmpty();
                        }
                        sr.Write(L.Enabled);
                        sr.Write(L.Alpha);
                    }
                    // layer tile data
                    foreach (Layer L in layers)
                    {
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
                } // binary writer
            }
            return true;
        } // save(...)

        private static byte[] StringToByteArray(string str, int length)
        {
            return Encoding.ASCII.GetBytes(str.PadRight(length, '\0'));
        }
        private static int strlen(char[] str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 0) return i;
            }
            return str.Length;
        }

    } // MapFile
}
