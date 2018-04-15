﻿using System;
using System.Windows.Forms;
using MapEdit.Controls;
using System.Collections.Generic;
using System.Drawing;

namespace MapEdit.Frontend
{
    public partial class frmMain : Form
    {
		List<ToolStripMenuItem> layerList;
		static string MOD_DIR = "mods/HylianPhoenix";
		static string MOD_DIR_FB = "/home/gonzo/github/dm2/Debug/mods/HylianPhoenix";

        private string current_mod_dir;
        private string getModDir()
        {
            return current_mod_dir;
        }


        public frmMain()
        {
            InitializeComponent();

			editor1.onTileChanged += editor1_onTileChanged;

			Image checkers = Resource1.checker;
            Image tiles = null;
            try
            {
                tiles = Image.FromFile(MOD_DIR + "/bitmaps/tiles.png");
                current_mod_dir = MOD_DIR;
            }
            catch (Exception)
            {
                tiles = Image.FromFile(MOD_DIR_FB + "/bitmaps/tiles.png");
                current_mod_dir = MOD_DIR_FB;
            }
			editor1.initialize(checkers, tiles, 8);
			
			toolShowGrid.Checked = editor1.ShowGrid;
			toolLayerAbove.Checked = editor1.LayersAbove;
			toolShowMask.Enabled = false;

			layerList = new List<ToolStripMenuItem>();
        }

		void editor1_onTileChanged(int l, int x, int y, int tx, int ty, int stx, int sty)
		{
			sbarXY.Text = "Layer: " + (l + 1) + " XY: " + x + ", " + y;
			sbarTXY.Text = "Tile: " + tx + ", " + ty;
			sbarSTXY.Text = "Selected: " + stx + ", " + sty;
		}
        private void editor1_OnZoomChanged(float v)
        {
            sbarZoomLevel.Text = "Zoom: " + v;
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
			Application.Exit();
        }

		private void frmMain_Load(object sender, EventArgs e)
		{
			toolDraw.Checked = editor1.TileDrawing;
			// reset camera to def values
			toolReset_Click(null, null);
			// select rectangular
			listTileForm.SelectedIndex = 0;
			// set GUI in correct state
			updateGUI();

			setTitle("(none)");
        }
		private void setTitle(string t)
		{
			this.Text = "DMEdit - " + t;
		}
		
		private void editor1_KeyDown(object sender, KeyEventArgs e)
		{
			Editor ed = (sender as Editor);

			if (e.KeyCode == Keys.Space)
			{
				ed.TileMode = !ed.TileMode;
				ed.Invalidate();
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
			if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.F) {
				ed.toggleShowFlags ();
			}
			if (e.KeyCode == Keys.G)
			{
				e.Handled = true;
				e.SuppressKeyPress = true;
				toggleGrid();
			}
            if (e.KeyCode == Keys.Z && e.Control && e.Shift) // Ctrl+Shift+Z
            {
                toolRedo_Click(this, e);
            }
            else if (e.KeyCode == Keys.Z && e.Control) // Ctrl+Z
            {
                toolUndo_Click(this, e);
            }
            else if (e.KeyCode == Keys.R && e.Control) // Ctrl+R
            {
                toolReloadTex_Click(this, e);
            }

        }

        private void toggleGrid()
		{
			editor1.ShowGrid = !editor1.ShowGrid;
			editor1.Invalidate();
		}
		
		private void toolDraw_Click(object sender, EventArgs e)
		{
			if (toolDraw.Checked)
				editor1.CurrentTool = tools_t.TOOL_DRAW;
			else if (toolRect.Checked)
				editor1.CurrentTool = tools_t.TOOL_RECT;
			else if (toolFill.Checked)
				editor1.CurrentTool = tools_t.TOOL_FILL;
			else if (toolReplace.Checked)
				editor1.CurrentTool = tools_t.TOOL_REPLACE;

			editor1.Focus();
		}

		private void toolReset_Click(object sender, EventArgs e)
		{
			editor1.GraphOffset = new System.Drawing.PointF(0.0f, 0.0f);
			editor1.GraphZoom = 1.5f;
			editor1.Invalidate();
		}

		private void mnuNewWnd_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(Application.ExecutablePath);
		}

		private void mnuNew_Click(object sender, EventArgs e)
		{
			CreateReturn ret = frmNewMap.start();
			if (ret.layers == 0 || ret.sizeX == 0 || ret.sizeY == 0)
			{
				// operation cancelled
				return;
			}
			// create new map
			editor1.createMap(ret.sizeX, ret.sizeY, ret.layers);
			editor1.Invalidate();

			setTitle("(untitled)");
			updateGUI();
		}
		void updateGUI()
		{
			// set default selected layer
			editor1.SelectedLayer = 0;
			// get showmask value for selected layer
			toolShowMask.Enabled = editor1.getLayerCount() > 0;
			// recreate layer menu list
			resizeMenuLayers();
		}

		private void resizeMenuLayers()
		{
			// remove old layers
			mnuSelectLayer.DropDownItems.Clear();
			layerList.Clear();
			// exit when there are no layers
			if (editor1.getLayerCount() == 0) return;

			// create new layers
			for (int i = 0; i < editor1.getLayerCount(); i++)
			{
				ToolStripMenuItem layer = new ToolStripMenuItem("Layer &" + (i + 1), null, mnuLayer_Click);
				layer.ShortcutKeys = Keys.Alt | (Keys.D1 + i);
				layer.Tag = i;

				layerList.Add(layer);
				mnuSelectLayer.DropDownItems.Add(layer);
			}
			// [x] selected layer
			layerSetUpdate();
		}

		private void mnuLayer_Click(object sender, EventArgs e)
		{
			if (layerList.Count == 0) return;

			// unselect old layer
			layerList[editor1.SelectedLayer].Checked = false;
			// select new layer
			ToolStripMenuItem layer = (sender as ToolStripMenuItem);
			editor1.SelectedLayer = (int)layer.Tag;
			// update GUI
			layerSetUpdate();
			// redraw
			editor1.Invalidate();
		}
		private void layerSetUpdate()
		{
			layerList[editor1.SelectedLayer].Checked = true;
			mnuSelectLayer.Text = "Layer: " + (editor1.SelectedLayer + 1);
			toolShowMask.Checked = editor1.getShowMask(editor1.SelectedLayer);
		}

		private void toolLayerAbove_Click(object sender, EventArgs e)
		{
			editor1.LayersAbove = toolLayerAbove.Checked;
			editor1.Invalidate();
		}

		private void toolShowMask_Click(object sender, EventArgs e)
		{
			editor1.setShowMask(toolShowMask.Checked);
		}

		private void toolShowGrid_Click(object sender, EventArgs e)
		{
			editor1.ShowGrid = toolShowGrid.Checked;
			editor1.Invalidate();
		}

		private void mnuOpen_Click(object sender, EventArgs e)
		{
			openFile1.InitialDirectory = current_mod_dir + "/maps";
			DialogResult res = openFile1.ShowDialog(this);

			if (res == System.Windows.Forms.DialogResult.OK)
			{
				if (editor1.loadMap(openFile1.FileName))
				{
					setTitle(openFile1.FileName);
				}
				updateGUI();
			}
		}

		private bool containsMapMessage()
		{
			if (editor1.containsMap() == false)
			{
				MessageBox.Show(
					"Editor has no map to save",
					"Save As...",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
			}
			return editor1.containsMap();
		}

		private void mnuSave_Click(object sender, EventArgs e)
		{
			if (containsMapMessage() == false) return;

			if (editor1.saveChanges())
			{
				// all changes were saved
				return;
			}
			// try save as instead
			mnuSaveAs_Click(sender, e);
		}

		private void mnuSaveAs_Click(object sender, EventArgs e)
		{
			if (containsMapMessage() == false) return;

			saveFile1.InitialDirectory = current_mod_dir + "/maps";
			DialogResult res = saveFile1.ShowDialog(this);
			
			if (res == System.Windows.Forms.DialogResult.OK)
			if (editor1.saveMapAs(saveFile1.FileName))
			{
				setTitle(saveFile1.FileName);
			}
			else
			{
				MessageBox.Show(
					"Could not save map to:\n" + saveFile1.FileName, 
					"Save As...", 
					MessageBoxButtons.OK, 
					MessageBoxIcon.Error);
			}
		}

		private void listTileForm_SelectedIndexChanged(object sender, EventArgs e)
		{
			editor1.TileForm = listTileForm.SelectedIndex;
		}

		private void chkSetTile_CheckedChanged(object sender, EventArgs e)
		{
			editor1.TileDrawing = chkSetTile.Checked;
		}

        private void toolUndo_Click(object sender, EventArgs e)
        {
            editor1.undo();
        }

        private void toolRedo_Click(object sender, EventArgs e)
        {
            editor1.redo();
        }

        private void radioNone_CheckedChanged(object sender, EventArgs e)
        {
            editor1.TileFlags = Backend.Tile.Flags.NONE;
        }
        private void radioSolid_CheckedChanged(object sender, EventArgs e)
        {
            editor1.TileFlags = Backend.Tile.Flags.SOLID;
        }

        private void radioAbyss_CheckedChanged(object sender, EventArgs e)
        {
            editor1.TileFlags = Backend.Tile.Flags.ABYSS;
        }
        private void radioWater_CheckedChanged(object sender, EventArgs e)
        {
            editor1.TileFlags = Backend.Tile.Flags.WATER;
        }
        private void radioSlow_CheckedChanged(object sender, EventArgs e)
        {
            editor1.TileFlags = Backend.Tile.Flags.SLOW;
        }
        private void radioIce_CheckedChanged(object sender, EventArgs e)
        {
            editor1.TileFlags = Backend.Tile.Flags.ICE;
        }
        private void radioJup_CheckedChanged(object sender, EventArgs e)
        {
            editor1.TileFlags = Backend.Tile.Flags.JUMP_UP;
        }
        private void radioJdown_CheckedChanged(object sender, EventArgs e)
        {
            editor1.TileFlags = Backend.Tile.Flags.JUMP_DOWN;
        }
        private void radioJright_CheckedChanged(object sender, EventArgs e)
        {
            editor1.TileFlags = Backend.Tile.Flags.JUMP_RGT;
        }
        private void radioJleft_CheckedChanged(object sender, EventArgs e)
        {
            editor1.TileFlags = Backend.Tile.Flags.JUMP_LEFT;
        }

        private void toolReloadTex_Click(object sender, EventArgs e)
        {
            var tiles = Image.FromFile(getModDir() + "/bitmaps/tiles.png");
            editor1.reload_textures(tiles);
        }

    }
}
