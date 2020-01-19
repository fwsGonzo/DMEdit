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
            this.numericShader = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericShader)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enable layer";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(18, 38);
            this.chkEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(94, 24);
            this.chkEnabled.TabIndex = 1;
            this.chkEnabled.Text = "&Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // lblLayerAlpha
            // 
            this.lblLayerAlpha.AutoSize = true;
            this.lblLayerAlpha.Location = new System.Drawing.Point(18, 69);
            this.lblLayerAlpha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLayerAlpha.Name = "lblLayerAlpha";
            this.lblLayerAlpha.Size = new System.Drawing.Size(91, 20);
            this.lblLayerAlpha.TabIndex = 2;
            this.lblLayerAlpha.Text = "Layer alpha";
            // 
            // scrAlpha
            // 
            this.scrAlpha.LargeChange = 8;
            this.scrAlpha.Location = new System.Drawing.Point(14, 89);
            this.scrAlpha.Maximum = 262;
            this.scrAlpha.Name = "scrAlpha";
            this.scrAlpha.Size = new System.Drawing.Size(324, 20);
            this.scrAlpha.TabIndex = 3;
            this.scrAlpha.ValueChanged += new System.EventHandler(this.scrAlpha_ValueChanged);
            // 
            // cmdClose
            // 
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdClose.Location = new System.Drawing.Point(720, 374);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(183, 49);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "&Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            // 
            // numericShader
            // 
            this.numericShader.Location = new System.Drawing.Point(404, 83);
            this.numericShader.Name = "numericShader";
            this.numericShader.Size = new System.Drawing.Size(120, 26);
            this.numericShader.TabIndex = 5;
            this.numericShader.ValueChanged += new System.EventHandler(this.numericShader_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Shader number:";
            // 
            // frmLayerProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 442);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericShader);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.scrAlpha);
            this.Controls.Add(this.lblLayerAlpha);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLayerProperties";
            this.Text = "Layer properties";
            ((System.ComponentModel.ISupportInitialize)(this.numericShader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Label lblLayerAlpha;
        private System.Windows.Forms.HScrollBar scrAlpha;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.NumericUpDown numericShader;
        private System.Windows.Forms.Label label2;
    }
}