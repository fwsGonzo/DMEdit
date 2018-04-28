namespace MapEdit.Frontend
{
    partial class frmMapProperties
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
            this.cmdClose = new System.Windows.Forms.Button();
            this.locY = new System.Windows.Forms.NumericUpDown();
            this.locX = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAutoScroll = new System.Windows.Forms.CheckBox();
            this.txtPropKey1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPropVal1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPropVal2 = new System.Windows.Forms.TextBox();
            this.txtPropKey2 = new System.Windows.Forms.TextBox();
            this.txtPropVal3 = new System.Windows.Forms.TextBox();
            this.txtPropKey3 = new System.Windows.Forms.TextBox();
            this.txtPropVal4 = new System.Windows.Forms.TextBox();
            this.txtPropKey4 = new System.Windows.Forms.TextBox();
            this.lblMapSize = new System.Windows.Forms.Label();
            this.txtMapSize = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.locY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locX)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdClose.Location = new System.Drawing.Point(427, 270);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(92, 31);
            this.cmdClose.TabIndex = 0;
            this.cmdClose.Text = "&Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            // 
            // locY
            // 
            this.locY.Location = new System.Drawing.Point(114, 96);
            this.locY.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.locY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.locY.Name = "locY";
            this.locY.Size = new System.Drawing.Size(94, 20);
            this.locY.TabIndex = 13;
            this.locY.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.locY.ValueChanged += new System.EventHandler(this.locY_ValueChanged);
            // 
            // locX
            // 
            this.locX.Location = new System.Drawing.Point(15, 96);
            this.locX.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.locX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.locX.Name = "locX";
            this.locX.Size = new System.Drawing.Size(93, 20);
            this.locX.TabIndex = 12;
            this.locX.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.locX.ValueChanged += new System.EventHandler(this.locX_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Location in world:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Attributes";
            // 
            // chkAutoScroll
            // 
            this.chkAutoScroll.AutoSize = true;
            this.chkAutoScroll.Location = new System.Drawing.Point(214, 96);
            this.chkAutoScroll.Name = "chkAutoScroll";
            this.chkAutoScroll.Size = new System.Drawing.Size(75, 17);
            this.chkAutoScroll.TabIndex = 15;
            this.chkAutoScroll.Text = "Auto scroll";
            this.chkAutoScroll.UseVisualStyleBackColor = true;
            this.chkAutoScroll.CheckedChanged += new System.EventHandler(this.chkAutoScroll_CheckedChanged);
            // 
            // txtPropKey1
            // 
            this.txtPropKey1.Location = new System.Drawing.Point(53, 166);
            this.txtPropKey1.MaxLength = 23;
            this.txtPropKey1.Name = "txtPropKey1";
            this.txtPropKey1.Size = new System.Drawing.Size(134, 20);
            this.txtPropKey1.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Custom properties:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Name";
            // 
            // txtPropVal1
            // 
            this.txtPropVal1.Location = new System.Drawing.Point(233, 166);
            this.txtPropVal1.MaxLength = 23;
            this.txtPropVal1.Name = "txtPropVal1";
            this.txtPropVal1.Size = new System.Drawing.Size(286, 20);
            this.txtPropVal1.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(193, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Value";
            // 
            // txtPropVal2
            // 
            this.txtPropVal2.Location = new System.Drawing.Point(233, 192);
            this.txtPropVal2.MaxLength = 23;
            this.txtPropVal2.Name = "txtPropVal2";
            this.txtPropVal2.Size = new System.Drawing.Size(286, 20);
            this.txtPropVal2.TabIndex = 22;
            // 
            // txtPropKey2
            // 
            this.txtPropKey2.Location = new System.Drawing.Point(53, 192);
            this.txtPropKey2.MaxLength = 23;
            this.txtPropKey2.Name = "txtPropKey2";
            this.txtPropKey2.Size = new System.Drawing.Size(134, 20);
            this.txtPropKey2.TabIndex = 21;
            // 
            // txtPropVal3
            // 
            this.txtPropVal3.Location = new System.Drawing.Point(233, 218);
            this.txtPropVal3.MaxLength = 23;
            this.txtPropVal3.Name = "txtPropVal3";
            this.txtPropVal3.Size = new System.Drawing.Size(286, 20);
            this.txtPropVal3.TabIndex = 24;
            // 
            // txtPropKey3
            // 
            this.txtPropKey3.Location = new System.Drawing.Point(53, 218);
            this.txtPropKey3.MaxLength = 23;
            this.txtPropKey3.Name = "txtPropKey3";
            this.txtPropKey3.Size = new System.Drawing.Size(134, 20);
            this.txtPropKey3.TabIndex = 23;
            // 
            // txtPropVal4
            // 
            this.txtPropVal4.Location = new System.Drawing.Point(233, 244);
            this.txtPropVal4.MaxLength = 23;
            this.txtPropVal4.Name = "txtPropVal4";
            this.txtPropVal4.Size = new System.Drawing.Size(286, 20);
            this.txtPropVal4.TabIndex = 26;
            // 
            // txtPropKey4
            // 
            this.txtPropKey4.Location = new System.Drawing.Point(53, 244);
            this.txtPropKey4.MaxLength = 23;
            this.txtPropKey4.Name = "txtPropKey4";
            this.txtPropKey4.Size = new System.Drawing.Size(134, 20);
            this.txtPropKey4.TabIndex = 25;
            // 
            // lblMapSize
            // 
            this.lblMapSize.AutoSize = true;
            this.lblMapSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMapSize.Location = new System.Drawing.Point(12, 9);
            this.lblMapSize.Name = "lblMapSize";
            this.lblMapSize.Size = new System.Drawing.Size(76, 20);
            this.lblMapSize.TabIndex = 27;
            this.lblMapSize.Text = "Map size:";
            // 
            // txtMapSize
            // 
            this.txtMapSize.Enabled = false;
            this.txtMapSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMapSize.Location = new System.Drawing.Point(94, 9);
            this.txtMapSize.Name = "txtMapSize";
            this.txtMapSize.Size = new System.Drawing.Size(195, 26);
            this.txtMapSize.TabIndex = 28;
            this.txtMapSize.Text = "0, 0";
            this.txtMapSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmMapProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 312);
            this.Controls.Add(this.txtMapSize);
            this.Controls.Add(this.lblMapSize);
            this.Controls.Add(this.txtPropVal4);
            this.Controls.Add(this.txtPropKey4);
            this.Controls.Add(this.txtPropVal3);
            this.Controls.Add(this.txtPropKey3);
            this.Controls.Add(this.txtPropVal2);
            this.Controls.Add(this.txtPropKey2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPropVal1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPropKey1);
            this.Controls.Add(this.chkAutoScroll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.locY);
            this.Controls.Add(this.locX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMapProperties";
            this.Text = "Properties";
            ((System.ComponentModel.ISupportInitialize)(this.locY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.NumericUpDown locY;
        private System.Windows.Forms.NumericUpDown locX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAutoScroll;
        private System.Windows.Forms.TextBox txtPropKey1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPropVal1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPropVal2;
        private System.Windows.Forms.TextBox txtPropKey2;
        private System.Windows.Forms.TextBox txtPropVal3;
        private System.Windows.Forms.TextBox txtPropKey3;
        private System.Windows.Forms.TextBox txtPropVal4;
        private System.Windows.Forms.TextBox txtPropKey4;
        private System.Windows.Forms.Label lblMapSize;
        private System.Windows.Forms.TextBox txtMapSize;
    }
}