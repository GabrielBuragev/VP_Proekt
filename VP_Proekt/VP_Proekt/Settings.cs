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
    public partial class Settings : Form
    {
        public enum Difficulty
        {
            EASY,
            MEDIUM,
            HARD
        }
        Config settingConfig;
        StartingScreen ss;
        public static int Height;
        public static int Width;
        public Settings(StartingScreen ss,Config settingConfig)
        {
            InitializeComponent();
            this.ss = ss;
            this.settingConfig = settingConfig;
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }


        public void showForm()
        {
            this.Show();
        }
        public void hideForm()
        {
            this.Hide();

        }

        private void btnNazad_Click(object sender, EventArgs e)
        {
            hideForm();
            ss.Show();
        }

        private void btnPomalo_Click(object sender, EventArgs e)
        {
            settingConfig.width = 800;
            settingConfig.height = 600;
        }

        private void btnPogolema_Click(object sender, EventArgs e)
        {
            settingConfig.width = 1200;
            settingConfig.height = 800;
        }

        private void btnPromeni_Click(object sender, EventArgs e)
        {
            if (cbDifficulty.SelectedIndex != -1)
            {
                if (cbDifficulty.SelectedIndex == 0)
                {
                    //Easy
                    //settingConfig.selectedGameDifficulty == ?

                }
                else if (cbDifficulty.SelectedIndex == 1)
                {
                    //Medium
                    //settingConfig.selectedGameDifficulty == ?
                }
                else if (cbDifficulty.SelectedIndex == 2)
                {
                    //Hard
                    //settingConfig.selectedGameDifficulty == ?
                }
                Config.serializeConfig(settingConfig, Config.confFilePath);
                hideForm();
                ss.Show();
            }
        }
    }
}
