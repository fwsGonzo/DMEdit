namespace MapEdit.Frontend
{
	partial class frmNewMap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewMap));
            this.cmdOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numFloors = new System.Windows.Forms.NumericUpDown();
            this.cmdClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFloors)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(266, 207);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(81, 29);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "&Create";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Size:";
            // 
            // numX
            // 
            this.numX.Location = new System.Drawing.Point(15, 25);
            this.numX.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(93, 20);
            this.numX.TabIndex = 3;
            this.numX.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // numY
            // 
            this.numY.Location = new System.Drawing.Point(114, 25);
            this.numY.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(94, 20);
            this.numY.TabIndex = 4;
            this.numY.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Floors:";
            // 
            // numFloors
            // 
            this.numFloors.Location = new System.Drawing.Point(15, 73);
            this.numFloors.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numFloors.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFloors.Name = "numFloors";
            this.numFloors.Size = new System.Drawing.Size(93, 20);
            this.numFloors.TabIndex = 6;
            this.numFloors.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmdClose
            // 
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Location = new System.Drawing.Point(179, 207);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(81, 29);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "Cl&ose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmNewMap
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdClose;
            this.ClientSize = new System.Drawing.Size(359, 248);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.numFloors);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numY);
            this.Controls.Add(this.numX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create new map";
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFloors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numX;
		private System.Windows.Forms.NumericUpDown numY;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numFloors;
		private System.Windows.Forms.Button cmdClose;
    }
}