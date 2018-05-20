﻿using System;
using System.Collections.Generic;
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
    }
}
