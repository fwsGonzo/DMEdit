using System;
using System.Windows.Forms;

namespace MapEdit.Frontend
{
    public partial class frmLayerProperties : Form
    {
        private Backend.Layer current_layer = null;

        public frmLayerProperties(Backend.Layer layer)
        {
            InitializeComponent();
            current_layer = layer;
            chkEnabled.Checked = layer.Enabled;
            scrAlpha.Value = layer.Alpha;
        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            current_layer.Enabled = chkEnabled.Checked;
        }

        private void scrAlpha_ValueChanged(object sender, EventArgs e)
        {
            current_layer.Alpha = (byte) scrAlpha.Value;
            float p = current_layer.Alpha / 255.0f * 100.0f;
            lblLayerAlpha.Text = "Layer alpha: " + scrAlpha.Value + " (" + (int) p + "%)";
        }
    }
}
