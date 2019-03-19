namespace MapEdit.Frontend
{
    partial class frmLayerProperties
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.lblLayerAlpha = new System.Windows.Forms.Label();
            this.scrAlpha = new System.Windows.Forms.HScrollBar();
            this.cmdClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enable layer";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(12, 25);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkEnabled.TabIndex = 1;
            this.chkEnabled.Text = "&Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // lblLayerAlpha
            // 
            this.lblLayerAlpha.AutoSize = true;
            this.lblLayerAlpha.Location = new System.Drawing.Point(12, 45);
            this.lblLayerAlpha.Name = "lblLayerAlpha";
            this.lblLayerAlpha.Size = new System.Drawing.Size(62, 13);
            this.lblLayerAlpha.TabIndex = 2;
            this.lblLayerAlpha.Text = "Layer alpha";
            // 
            // scrAlpha
            // 
            this.scrAlpha.LargeChange = 8;
            this.scrAlpha.Location = new System.Drawing.Point(9, 58);
            this.scrAlpha.Maximum = 262;
            this.scrAlpha.Name = "scrAlpha";
            this.scrAlpha.Size = new System.Drawing.Size(216, 20);
            this.scrAlpha.TabIndex = 3;
            this.scrAlpha.ValueChanged += new System.EventHandler(this.scrAlpha_ValueChanged);
            // 
            // cmdClose
            // 
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdClose.Location = new System.Drawing.Point(480, 243);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(122, 32);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "&Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            // 
            // frmLayerProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 287);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.scrAlpha);
            this.Controls.Add(this.lblLayerAlpha);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLayerProperties";
            this.Text = "Layer properties";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Label lblLayerAlpha;
        private System.Windows.Forms.HScrollBar scrAlpha;
        private System.Windows.Forms.Button cmdClose;
    }
}