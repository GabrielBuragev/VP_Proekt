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
            this.btnNazad = new System.Windows.Forms.Button();
            this.btnPromeni = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rbEasy = new System.Windows.Forms.RadioButton();
            this.rbHard = new System.Windows.Forms.RadioButton();
            this.rbMedium = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbMediumSize = new System.Windows.Forms.RadioButton();
            this.rbSmallSize = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(164, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose resolution :";
            // 
            // btnNazad
            // 
            this.btnNazad.BackColor = System.Drawing.Color.DarkRed;
            this.btnNazad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNazad.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNazad.Location = new System.Drawing.Point(26, 393);
            this.btnNazad.Name = "btnNazad";
            this.btnNazad.Size = new System.Drawing.Size(115, 23);
            this.btnNazad.TabIndex = 4;
            this.btnNazad.Text = "BACK";
            this.btnNazad.UseVisualStyleBackColor = false;
            this.btnNazad.Click += new System.EventHandler(this.btnNazad_Click);
            // 
            // btnPromeni
            // 
            this.btnPromeni.BackColor = System.Drawing.Color.DarkRed;
            this.btnPromeni.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPromeni.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPromeni.Location = new System.Drawing.Point(164, 393);
            this.btnPromeni.Name = "btnPromeni";
            this.btnPromeni.Size = new System.Drawing.Size(114, 23);
            this.btnPromeni.TabIndex = 5;
            this.btnPromeni.Text = "CONFIRM";
            this.btnPromeni.UseVisualStyleBackColor = false;
            this.btnPromeni.Click += new System.EventHandler(this.btnPromeni_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(28, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Choose difficulty :";
            // 
            // rbEasy
            // 
            this.rbEasy.AutoSize = true;
            this.rbEasy.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbEasy.Location = new System.Drawing.Point(3, 3);
            this.rbEasy.Name = "rbEasy";
            this.rbEasy.Size = new System.Drawing.Size(48, 17);
            this.rbEasy.TabIndex = 11;
            this.rbEasy.TabStop = true;
            this.rbEasy.Text = "Easy";
            this.rbEasy.UseVisualStyleBackColor = true;
            // 
            // rbHard
            // 
            this.rbHard.AutoSize = true;
            this.rbHard.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbHard.Location = new System.Drawing.Point(3, 49);
            this.rbHard.Name = "rbHard";
            this.rbHard.Size = new System.Drawing.Size(48, 17);
            this.rbHard.TabIndex = 12;
            this.rbHard.TabStop = true;
            this.rbHard.Text = "Hard";
            this.rbHard.UseVisualStyleBackColor = true;
            // 
            // rbMedium
            // 
            this.rbMedium.AutoSize = true;
            this.rbMedium.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbMedium.Location = new System.Drawing.Point(3, 26);
            this.rbMedium.Name = "rbMedium";
            this.rbMedium.Size = new System.Drawing.Size(62, 17);
            this.rbMedium.TabIndex = 13;
            this.rbMedium.TabStop = true;
            this.rbMedium.Text = "Medium";
            this.rbMedium.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.rbEasy);
            this.panel1.Controls.Add(this.rbHard);
            this.panel1.Controls.Add(this.rbMedium);
            this.panel1.Location = new System.Drawing.Point(26, 126);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(115, 123);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkRed;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.rbSmallSize);
            this.panel2.Controls.Add(this.rbMediumSize);
            this.panel2.Location = new System.Drawing.Point(164, 126);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(114, 123);
            this.panel2.TabIndex = 16;
            // 
            // rbMediumSize
            // 
            this.rbMediumSize.AutoSize = true;
            this.rbMediumSize.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbMediumSize.Location = new System.Drawing.Point(3, 26);
            this.rbMediumSize.Name = "rbMediumSize";
            this.rbMediumSize.Size = new System.Drawing.Size(72, 17);
            this.rbMediumSize.TabIndex = 12;
            this.rbMediumSize.TabStop = true;
            this.rbMediumSize.Text = "1000x800";
            this.rbMediumSize.UseVisualStyleBackColor = true;
            // 
            // rbSmallSize
            // 
            this.rbSmallSize.AutoSize = true;
            this.rbSmallSize.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbSmallSize.Location = new System.Drawing.Point(3, 3);
            this.rbSmallSize.Name = "rbSmallSize";
            this.rbSmallSize.Size = new System.Drawing.Size(72, 17);
            this.rbSmallSize.TabIndex = 13;
            this.rbSmallSize.TabStop = true;
            this.rbSmallSize.Text = "800 x 600";
            this.rbSmallSize.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 441);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPromeni);
            this.Controls.Add(this.btnNazad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNazad;
        private System.Windows.Forms.Button btnPromeni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbEasy;
        private System.Windows.Forms.RadioButton rbHard;
        private System.Windows.Forms.RadioButton rbMedium;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbSmallSize;
        private System.Windows.Forms.RadioButton rbMediumSize;
    }
}