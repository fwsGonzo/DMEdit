﻿using System;
using System.Windows.Forms;
using MapEdit.Controls;
using System.Collections.Generic;

namespace MapEdit.Frontend
{
    public partial class frmMain : Form
    {
		List<ToolStripMenuItem> layerList;
		
		public frmMain()
        {
            InitializeComponent();

			editor1.initialize("tiles.png", 8);
			//editor1.createMap(32, 32, 1);
			toolShowGrid.Checked = editor1.ShowGrid;
			toolLayerAbove.Checked = editor1.LayersAbove;
			toolShowMask.Enabled = false;

			layerList = new List<ToolStripMenuItem>();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
			Application.Exit();
        }

		private void frmMain_Load(object sender, EventArgs e)
		{
			toolDraw.Checked = true;
			// reset camera to def values
			toolReset_Click(null, null);
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
			if (e.KeyCode == Keys.G)
			{
				e.Handled = true;
				e.SuppressKeyPress = true;
				toggleGrid();
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
			editor1.GraphZoom = 2.0f;
			editor1.Invalidate();
		}

		private void mnuNewWnd_Click(object sender, EventArgs e)
		{
			frmMain main = new frmMain();
			main.Show();
		}

		private void mnuNew_Click(object sender, EventArgs e)
		{
			CreateReturn ret = frmNewMap.start();

			editor1.createMap(ret.sizeX, ret.sizeY, ret.layers);
			editor1.Invalidate();

			updateGUI();
		}
		void updateGUI()
		{
			// set default selected layer
			editor1.SelectedLayer = 0;
			// recreate layer menu list
			resizeMenuLayers();
			// get showmask value for selected layer
			toolShowMask.Enabled = true;
			toolShowMask.Checked = editor1.getShowMask(editor1.SelectedLayer);
		}

		private void resizeMenuLayers()
		{
			// remove old layers
			mnuSelectLayer.DropDownItems.Clear();
			layerList.Clear();

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
		void layerSetUpdate()
		{
			layerList[editor1.SelectedLayer].Checked = true;
			mnuSelectLayer.Text = "Layer: " + (editor1.SelectedLayer + 1);
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
    }
}
