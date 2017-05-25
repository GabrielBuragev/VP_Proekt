namespace VP_Proekt
{
    partial class Settings
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnPomalo = new System.Windows.Forms.Button();
            this.btnPogolema = new System.Windows.Forms.Button();
            this.btnNazad = new System.Windows.Forms.Button();
            this.btnPromeni = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDifficulty = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VP_Proekt.Properties.Resources.brickbgimg;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(303, 441);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please choose your resolution :";
            // 
            // btnPomalo
            // 
            this.btnPomalo.BackColor = System.Drawing.Color.DarkRed;
            this.btnPomalo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPomalo.Location = new System.Drawing.Point(39, 65);
            this.btnPomalo.Name = "btnPomalo";
            this.btnPomalo.Size = new System.Drawing.Size(75, 23);
            this.btnPomalo.TabIndex = 2;
            this.btnPomalo.Text = "800 x 600";
            this.btnPomalo.UseVisualStyleBackColor = false;
            this.btnPomalo.Click += new System.EventHandler(this.btnPomalo_Click);
            // 
            // btnPogolema
            // 
            this.btnPogolema.BackColor = System.Drawing.Color.DarkRed;
            this.btnPogolema.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPogolema.Location = new System.Drawing.Point(164, 64);
            this.btnPogolema.Name = "btnPogolema";
            this.btnPogolema.Size = new System.Drawing.Size(75, 23);
            this.btnPogolema.TabIndex = 3;
            this.btnPogolema.Text = "1280 x 800";
            this.btnPogolema.UseVisualStyleBackColor = false;
            this.btnPogolema.Click += new System.EventHandler(this.btnPogolema_Click);
            // 
            // btnNazad
            // 
            this.btnNazad.BackColor = System.Drawing.Color.DarkRed;
            this.btnNazad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNazad.Location = new System.Drawing.Point(39, 393);
            this.btnNazad.Name = "btnNazad";
            this.btnNazad.Size = new System.Drawing.Size(75, 23);
            this.btnNazad.TabIndex = 4;
            this.btnNazad.Text = "Back";
            this.btnNazad.UseVisualStyleBackColor = false;
            this.btnNazad.Click += new System.EventHandler(this.btnNazad_Click);
            // 
            // btnPromeni
            // 
            this.btnPromeni.BackColor = System.Drawing.Color.DarkRed;
            this.btnPromeni.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPromeni.Location = new System.Drawing.Point(164, 393);
            this.btnPromeni.Name = "btnPromeni";
            this.btnPromeni.Size = new System.Drawing.Size(75, 23);
            this.btnPromeni.TabIndex = 5;
            this.btnPromeni.Text = "Ok";
            this.btnPromeni.UseVisualStyleBackColor = false;
            this.btnPromeni.Click += new System.EventHandler(this.btnPromeni_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(36, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Choose difficulty:";
            // 
            // cbDifficulty
            // 
            this.cbDifficulty.BackColor = System.Drawing.Color.DarkRed;
            this.cbDifficulty.FormattingEnabled = true;
            this.cbDifficulty.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
            this.cbDifficulty.Location = new System.Drawing.Point(39, 161);
            this.cbDifficulty.Name = "cbDifficulty";
            this.cbDifficulty.Size = new System.Drawing.Size(120, 49);
            this.cbDifficulty.TabIndex = 10;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 441);
            this.Controls.Add(this.cbDifficulty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPromeni);
            this.Controls.Add(this.btnNazad);
            this.Controls.Add(this.btnPogolema);
            this.Controls.Add(this.btnPomalo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPomalo;
        private System.Windows.Forms.Button btnPogolema;
        private System.Windows.Forms.Button btnNazad;
        private System.Windows.Forms.Button btnPromeni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox cbDifficulty;
    }
}