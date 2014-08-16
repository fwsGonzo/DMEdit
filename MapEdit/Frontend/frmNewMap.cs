using System;
using System.Windows.Forms;

namespace MapEdit.Frontend
{
	public partial class frmNewMap : Form
	{
		public frmNewMap()
		{
			InitializeComponent();
		}

		public static CreateReturn start()
		{
			frmNewMap F = new frmNewMap();
			DialogResult res = F.ShowDialog();

			if (res == System.Windows.Forms.DialogResult.OK)
			{
				return new CreateReturn(
					(int) F.numX.Value, 
					(int) F.numY.Value, 
					(int) F.numLayers.Value);
			}
			return new CreateReturn(0, 0, 0);
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		private void cmdClose_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}
	}
	public class CreateReturn
	{
		public CreateReturn(int sx, int sy, int l)
		{
			sizeX = sx; sizeY = sy; layers = l;
		}

		public int sizeX;
		public int sizeY;
		public int layers;
	}
}
