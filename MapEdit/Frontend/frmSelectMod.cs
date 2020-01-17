using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MapEdit.Frontend
{
    public partial class frmSelectMod : Form
    {
        private Backend.ModSelection modsel;
        private static string MOD_DIR_FB = "C:/Users/fwsgo/Dropbox/dm2/Debug/";

        public frmSelectMod(Backend.ModSelection selector)
        {
            this.modsel = selector;
            InitializeComponent();

            // detect where the game is located
            // 1. custom path from args[0]
            modsel.ModDir = modsel.ModBase + "/mods/";
            if (Directory.Exists(modsel.ModDir) == false)
            {
                // 2. path from current directory
                modsel.ModDir = Directory.GetCurrentDirectory() + "/mods/";
                if (Directory.Exists(modsel.ModDir) == false)
                {
                    // 3. path from hard-coded location
                    modsel.ModDir = MOD_DIR_FB + "mods/";
                    if (Directory.Exists(modsel.ModDir) == false)
                    {
                        throw new IOException("Could not detect game mods folder");
                    }
                }
            }
            modsel.ModBase = modsel.ModDir;
            // populate mods
            string[] subs = Directory.GetDirectories(modsel.ModBase);
            cboModlist.Items.AddRange(subs);
            foreach (string subdir in subs)
            {
                Console.WriteLine("Found mod folder: " + subdir);
            }
            // select first available mod
            cboModlist.SelectedIndex = 0;
            // select most common tile size
            cboTileSize.SelectedIndex = 0;
        }

        private void cboModlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            modsel.ModDir = cboModlist.Text;
        }

        private void cboTileSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboTileSize.SelectedIndex)
            {
                case 0:
                    modsel.TileSize = 8; break;
                case 1:
                    modsel.TileSize = 16; break;
                case 2:
                    modsel.TileSize = 32; break;
                default:
                    throw new InvalidOperationException();
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
