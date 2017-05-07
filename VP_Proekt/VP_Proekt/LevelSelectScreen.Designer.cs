namespace VP_Proekt
{
    partial class LevelSelectScreen
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnLVL1 = new System.Windows.Forms.Button();
            this.btnLVL2 = new System.Windows.Forms.Button();
            this.btnLVL3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VP_Proekt.Properties.Resources.brickbgimg;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(305, 441);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
            this.comboBox1.Location = new System.Drawing.Point(93, 234);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // btnLVL1
            // 
            this.btnLVL1.BackColor = System.Drawing.Color.DarkRed;
            this.btnLVL1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLVL1.Location = new System.Drawing.Point(12, 88);
            this.btnLVL1.Name = "btnLVL1";
            this.btnLVL1.Size = new System.Drawing.Size(75, 23);
            this.btnLVL1.TabIndex = 2;
            this.btnLVL1.Text = "Level 1";
            this.btnLVL1.UseVisualStyleBackColor = false;
            this.btnLVL1.Click += new System.EventHandler(this.btnLVL1_Click);
            // 
            // btnLVL2
            // 
            this.btnLVL2.BackColor = System.Drawing.Color.DarkRed;
            this.btnLVL2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLVL2.Location = new System.Drawing.Point(113, 88);
            this.btnLVL2.Name = "btnLVL2";
            this.btnLVL2.Size = new System.Drawing.Size(75, 23);
            this.btnLVL2.TabIndex = 3;
            this.btnLVL2.Text = "Level 2";
            this.btnLVL2.UseVisualStyleBackColor = false;
            // 
            // btnLVL3
            // 
            this.btnLVL3.BackColor = System.Drawing.Color.DarkRed;
            this.btnLVL3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLVL3.Location = new System.Drawing.Point(217, 88);
            this.btnLVL3.Name = "btnLVL3";
            this.btnLVL3.Size = new System.Drawing.Size(75, 23);
            this.btnLVL3.TabIndex = 4;
            this.btnLVL3.Text = "Level 3";
            this.btnLVL3.UseVisualStyleBackColor = false;
            // 
            // LevelSelectScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 441);
            this.Controls.Add(this.btnLVL3);
            this.Controls.Add(this.btnLVL2);
            this.Controls.Add(this.btnLVL1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "LevelSelectScreen";
            this.Text = "LevelSelectScreen";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnLVL1;
        private System.Windows.Forms.Button btnLVL2;
        private System.Windows.Forms.Button btnLVL3;
    }
}