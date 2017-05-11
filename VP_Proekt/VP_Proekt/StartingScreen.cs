using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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
            Form settings = new Settings(this,startupConfig);
            settings.FormClosing += delegate { this.Close(); };
            hideForm();
            settings.Show();
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
        public void generateMap()
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            
            int width = 80;
            int rows = Level.maxHeight / Brick.height;
            int numberOfBricks = startupConfig.width / width;
            Random rand = new Random();
            for (int k = 0; k < 10; k++)
            {
                List<Brick> bricks = new List<Brick>();

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < numberOfBricks; j++)
                    {

                        Level.BrickType brType = Level.BrickType.NORMAL;
                        int random = 0;
                        if (startupConfig.num_levels < 2)
                        {
                            random = rand.Next(0, 1);
                        }
                        else if (startupConfig.num_levels >= 2 & startupConfig.num_levels < 5)
                        {
                            random = rand.Next(0, 2);
                        }
                        else if (startupConfig.num_levels >= 5)
                        {
                            random = rand.Next(0, 3);
                        }

                        if (random == 0)
                            brType = Level.BrickType.NORMAL;
                        else if (random == 1)
                            brType = Level.BrickType.STONE;
                        else if (random == 2)
                            brType = Level.BrickType.DIAMOND;

                        bricks.Add(new Brick(new Point(j * width, i * Brick.height), width, brType));

                    }
                }

                startupConfig.num_levels++;
                string FileName = "..//..//..//levels/level_" + startupConfig.num_levels + ".bb";
                IFormatter serializeFormatter = new BinaryFormatter();

                using (FileStream fileStream = new FileStream(FileName, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fileStream, new Level(bricks, startupConfig));
                }

                startupConfig.levels.Add(new Level(startupConfig.num_levels, FileName));
            }
            Config.serializeConfig(startupConfig, Config.confFilePath);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            generateMap();
        }
    }
}
