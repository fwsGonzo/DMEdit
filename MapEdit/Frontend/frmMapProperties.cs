using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapEdit.Frontend
{
    public partial class frmMapProperties : Form
    {
        private Backend.MapFile mapfile;
        TextBox[] PropKeys = new TextBox[4];
        TextBox[] PropVals = new TextBox[4];

        public frmMapProperties(Backend.MapFile mf)
        {
            InitializeComponent();

            this.mapfile = mf;
            // size of current map (copyable)
            txtMapSize.Text = mapfile.layers[0].getTilesX() + ", " + mapfile.layers[0].getTilesY()
                     + " (" + mapfile.layers[0].getWidth() + ", " + mapfile.layers[0].getHeight() + ")";

            chkAutoScroll.Checked = (mf.Attributes & 1) == 1;
            locX.Value = mf.X_location;
            locY.Value = mf.Y_location;
            locX.Enabled = locY.Enabled = chkAutoScroll.Checked;
            // map properties
            PropKeys[0] = txtPropKey1; PropKeys[1] = txtPropKey2; PropKeys[2] = txtPropKey3; PropKeys[3] = txtPropKey4;
            for (int i = 0; i < PropKeys.Length; i++)
            {
                PropKeys[i].Text = mapfile.PropKey[i];
                PropKeys[i].Tag  = i;
                PropKeys[i].TextChanged += propkeys_TextChanged;
            }

            PropVals[0] = txtPropVal1; PropVals[1] = txtPropVal2; PropVals[2] = txtPropVal3; PropVals[3] = txtPropVal4;
            for (int i = 0; i < PropVals.Length; i++)
            {
                PropVals[i].Text = mapfile.PropVal[i];
                PropVals[i].Tag  = i;
                PropVals[i].TextChanged += propvalues_TextChanged;
            }
        }

        private void propkeys_TextChanged(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            mapfile.PropKey[(int)txt.Tag] = txt.Text;
        }
        private void propvalues_TextChanged(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            mapfile.PropVal[(int) txt.Tag] = txt.Text;
        }

        private void locX_ValueChanged(object sender, EventArgs e)
        {
            mapfile.X_location = (int) locX.Value;
        }

        private void locY_ValueChanged(object sender, EventArgs e)
        {
            mapfile.Y_location = (int) locY.Value;
        }

        private void chkAutoScroll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoScroll.Checked)
                mapfile.Attributes |= 1;
            else
                mapfile.Attributes &= ~1;
            locX.Enabled = locY.Enabled = chkAutoScroll.Checked;
        }
    }
}
