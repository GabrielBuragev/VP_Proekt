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
            if (settingConfig.selectedGameDifficulty == Config.GameDifficulty.EASY) {
                rbEasy.Checked = true;
            }
            else if (settingConfig.selectedGameDifficulty == Config.GameDifficulty.MEDIUM)
            {
                rbMedium.Checked = true;
            }
            else if (settingConfig.selectedGameDifficulty == Config.GameDifficulty.HARD)
            {
                rbHard.Checked = true;
            }

            if (settingConfig.width == 800 && settingConfig.height == 600) {
                rbSmallSize.Checked = true;
            }
            else if (settingConfig.width == 1000 && settingConfig.height == 800) {
                rbMediumSize.Checked = true;
            }
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


        private void btnPromeni_Click(object sender, EventArgs e)
        {
            if (rbEasy.Checked == true)
            {
                settingConfig.selectedGameDifficulty = Config.GameDifficulty.EASY;
            }
            else if (rbMedium.Checked == true) {
                settingConfig.selectedGameDifficulty = Config.GameDifficulty.MEDIUM;
            }else if(rbHard.Checked == true){
                settingConfig.selectedGameDifficulty = Config.GameDifficulty.HARD;
            }

            if (rbSmallSize.Checked == true) {
                settingConfig.width = 800;
                settingConfig.height = 600;
            }
            else if (rbMediumSize.Checked == true) {
                settingConfig.width = 1000;
                settingConfig.height = 800;
            }
            Config.serializeConfig(settingConfig, Config.confFilePath);
            hideForm();
            ss.Show();
        }
    }
}
