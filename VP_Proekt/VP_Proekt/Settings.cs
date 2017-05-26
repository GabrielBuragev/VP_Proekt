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
            else if (settingConfig.width == 900 && settingConfig.height == 700) {
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
            int tmpWidth = settingConfig.width;
            int tmpHeight = settingConfig.height;

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
                settingConfig.width = 900;
                settingConfig.height = 700;
            }
            

            IFormatter serializeFormatter = new BinaryFormatter();
            Console.WriteLine(String.Format("tmpWidth: {0} , confWidth: {1} ",tmpWidth,settingConfig.width));
            if (tmpWidth != settingConfig.width && tmpHeight != settingConfig.height)
            {
                foreach (Level lvl in settingConfig.levels)
                {
                    Level tmp = Config.deserializeLevel(lvl.filePathName);
                    tmp.formWidth = settingConfig.width;
                    tmp.formHeight = settingConfig.height;

                    int brickWidth = tmp.formWidth / 10;
                   

                    int rows = Level.maxHeight / Brick.height;
                    int numberOfBricks = tmp.bricks.Count / rows;

                    for (int i = 0; i < rows; i++) {

                        for (int j = 0; j < numberOfBricks; j++)
                        {
                            tmp.bricks[i * numberOfBricks + j] = new Brick(new Point(j * brickWidth,tmp.bricks[i * numberOfBricks + j].xy.Y), brickWidth, tmp.bricks[i * numberOfBricks + j].brickType);
                        }
                    }
                    

                    using (FileStream fileStream = new FileStream(lvl.filePathName, FileMode.Create))
                    {
                        IFormatter formatter = new BinaryFormatter();
                        Level tmplvl = new Level(tmp.bricks, settingConfig);
                        
                        tmplvl.id = tmp.id;
                        formatter.Serialize(fileStream, tmplvl);
                    }
                }
            }

            Config.serializeConfig(settingConfig, Config.confFilePath);

            hideForm();
            ss.updateConfig(settingConfig);
            ss.Show();
        }
    }
}
