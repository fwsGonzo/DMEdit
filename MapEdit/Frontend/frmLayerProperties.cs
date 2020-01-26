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
            numericShader.Value = layer.Shader;
            chkAutoCreateObjects.Checked = layer.GetFeature(Backend.Layer.Features.AUTO_CREATE_OBJECTS);
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

        private void numericShader_ValueChanged(object sender, EventArgs e)
        {
            current_layer.Shader = (byte) numericShader.Value;
        }

        private void chkAutoCreateObjects_CheckedChanged(object sender, EventArgs e)
        {
            current_layer.SetFeature(Backend.Layer.Features.AUTO_CREATE_OBJECTS, chkAutoCreateObjects.Enabled);
        }
    }
}
