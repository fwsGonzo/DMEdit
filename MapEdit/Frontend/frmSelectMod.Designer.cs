namespace MapEdit.Frontend
{
    partial class frmSelectMod
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
            this.cboModlist = new System.Windows.Forms.ComboBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTileSize = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cboModlist
            // 
            this.cboModlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModlist.FormattingEnabled = true;
            this.cboModlist.Location = new System.Drawing.Point(12, 12);
            this.cboModlist.Name = "cboModlist";
            this.cboModlist.Size = new System.Drawing.Size(526, 28);
            this.cboModlist.TabIndex = 0;
            this.cboModlist.SelectedIndexChanged += new System.EventHandler(this.cboModlist_SelectedIndexChanged);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(442, 46);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(96, 31);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tile size:";
            // 
            // cboTileSize
            // 
            this.cboTileSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTileSize.FormattingEnabled = true;
            this.cboTileSize.Items.AddRange(new object[] {
            "8",
            "16",
            "32"});
            this.cboTileSize.Location = new System.Drawing.Point(66, 52);
            this.cboTileSize.Name = "cboTileSize";
            this.cboTileSize.Size = new System.Drawing.Size(121, 21);
            this.cboTileSize.TabIndex = 3;
            this.cboTileSize.SelectedIndexChanged += new System.EventHandler(this.cboTileSize_SelectedIndexChanged);
            // 
            // frmSelectMod
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 87);
            this.ControlBox = false;
            this.Controls.Add(this.cboTileSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cboModlist);
            this.Name = "frmSelectMod";
            this.Text = "Select mod";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboModlist;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTileSize;
    }
}