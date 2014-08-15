using System;
using System.Windows.Forms;
using MapEdit.Controls;

namespace MapEdit
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

			editor1.initialize("tiles.png", 8);
			editor1.createMap(32, 32, 1);
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
			Application.Exit();
        }

		private void frmMain_Load(object sender, EventArgs e)
		{
			toolDraw.Checked = true;

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

		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			editor1.GraphOffset = new System.Drawing.PointF(0.0f, 0.0f);
			editor1.GraphZoom = 2.0f;
			editor1.Invalidate();
		}

		private void toolStripButton5_Click(object sender, EventArgs e)
		{
			bool c = (sender as ToolStripButton).Checked;
			editor1.setMask(c);
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
    }
}
