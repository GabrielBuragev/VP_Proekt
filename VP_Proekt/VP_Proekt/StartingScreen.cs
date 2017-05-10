using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VP_Proekt
{
    public partial class StartingScreen : Form
    {
        Config startupConfig;
        public StartingScreen()
        {
            InitializeComponent();
            startupConfig = Config.deserializeConfig(Config.confFilePath);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Form lvlSelecet = new LevelSelectScreen(this,startupConfig);
            lvlSelecet.FormClosing += delegate { this.Close(); };
            hideForm();
            lvlSelecet.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Form lvlSelecet = new LevelSelectScreen(this, startupConfig);
            lvlSelecet.FormClosing += delegate { this.Close(); };
            hideForm();
            lvlSelecet.Show();
        }

        private void btnAboutUs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Овој проект го изработија Габриел Бурагев, Давид Стојановски, Симон Стојановски", "AboutUs");
        }
        public void showForm(){
            this.Show();
        }
        public void hideForm() {
            this.Hide();
        }
    }
}
