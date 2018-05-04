using System;
using System.Windows.Forms;

namespace MapEdit.Frontend
{
	public partial class frmNewMap : Form
	{
		public frmNewMap()
		{
			InitializeComponent();
            numX.Select();
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
					(int) F.numFloors.Value);
			}
			return new CreateReturn();
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

        private void numX_Enter(object sender, EventArgs e)
        {
            numX.Select(0, 99);
        }
        private void numX_MouseDown(object sender, MouseEventArgs e)
        {
            numX.Select(0, 99);
        }

        private void numY_Enter(object sender, EventArgs e)
        {
            numY.Select(0, 99);
        }
        private void numY_MouseDown(object sender, MouseEventArgs e)
        {
            numY.Select(0, 99);
        }
    }
    public class CreateReturn
	{
		public CreateReturn(int sx = 0, int sy = 0, int f = 0)
		{
			sizeX = sx; sizeY = sy; floors = f;
		}

		public int sizeX;
		public int sizeY;
		public int floors;
    }
}
