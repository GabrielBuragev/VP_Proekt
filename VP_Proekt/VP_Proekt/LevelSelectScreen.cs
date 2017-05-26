using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace VP_Proekt
{
    public partial class LevelSelectScreen : Form
    {
        Config startupConfig;
        StartingScreen ss;
        public LevelSelectScreen(StartingScreen ss,Config startupConfig)
        {
            InitializeComponent();
            this.ss = ss;
            this.startupConfig = startupConfig;
            // Dynamicly append the buttons according to the number of levels there are.
            for (int i = 1; i <= startupConfig.num_levels; i++)
            {
                Button b = new Button();
                b.Size = new Size(85, 23);
                b.BackColor = Color.DarkRed;
                b.ForeColor = Color.Black;
                b.TextAlign = ContentAlignment.MiddleCenter;
                b.Text = "Level " + i;
                b.TabStop = false;
                b.FlatStyle = FlatStyle.Popup;
                b.FlatAppearance.BorderSize = 1;
                b.FlatAppearance.BorderColor = Color.Gold;
                b.Tag = startupConfig.levels[i-1].filePathName;
                b.Click += btn_click;
                FLLevels.Controls.Add(b);
            }
        }

        private void btn_click(object sender, EventArgs e)
        {
            if (sender is Button) {
                Button btnClicked = (Button)sender;
                Level lvl = Config.deserializeLevel(btnClicked.Tag.ToString());
                Console.WriteLine(lvl.id);
                GameScreen gs = new GameScreen(lvl,this);
                gs.Location = this.Location;
                gs.StartPosition = FormStartPosition.Manual;
                gs.FormClosing += delegate { this.Close();  };
                gs.Show();
                this.Hide();
            }
        }

        
        

        private void btnBack_Click(object sender, EventArgs e)
        {
            hideForm();
            ss.Show();
        }

        public void showForm()
        {
            this.Show();
        }
        public void hideForm()
        {
            this.Hide();

        }

        private void FLLevels_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
