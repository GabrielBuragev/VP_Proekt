    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace VP_Proekt
{
    public partial class GameScreen : Form
    {
        Level lvl;
        private string FileName;
        LevelGenerator lvlGenerator;
        private float prevX = 0;
        private float prevY = 0;
        private bool firstStartForBall;
        public GameScreen()
        {
            InitializeComponent();
            DoubleBuffered = true;
            firstStartForBall = true;
            lvl = new Level(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lvl.addBrick(new Point(0, 0), 20);
            lvl.addBrick(new Point(50, 50), 20);

            Invalidate(true);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            lvl.DrawBricks(e.Graphics);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SaveFile();
        }

        private void SaveFile()
        {
            if (FileName == null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Save lines doc";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    FileName = sfd.FileName;
                }


            }
            if (FileName != null)
            {
                using (FileStream fileStream = new FileStream(FileName, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fileStream, lvl);
                }
            }

        }
        private void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Lines doc file (*.br)|*.br";
            openFileDialog.Title = "Open bricks file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog.FileName;
                try
                {
                    using (FileStream fileStream = new FileStream(FileName, FileMode.Open))
                    {
                        IFormatter formater = new BinaryFormatter();
                        lvl = (Level)formater.Deserialize(fileStream);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not read file: " + FileName);
                    FileName = null;
                    return;
                }
                Invalidate(true);
            }
        }

        public Size getSize()
        {
            return new Size(this.Width, this.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Brick> bricks = new List<Brick>();
            int width = 20;
            int rows = Level.maxHeight / Brick.height;
            int numberOfBriks = this.Width / width;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < numberOfBriks; j++)
                {
                    bricks.Add(new Brick(new Point(j * width, i * Brick.height), width));
                    lvl.addBrick(new Point(j * width, i * Brick.height), width);

                }
            }
            lvl.setBricks(bricks);
            Invalidate(true);
        }

        private void GameScreen_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.X > 0 && e.X <= 800 - lvl.slider.width)
            {
                if (firstStartForBall)
                {

                    float dx = e.X;
                    lvl.slider.Move(dx);
                    lvl.ball.MoveWithSlider(dx + lvl.slider.width/2);
                    Invalidate(true);
                }
                else
                {
                    float dx = e.X;
                    lvl.slider.Move(dx);
                    Invalidate(true);
                }
            }
        }

        private void GameScreen_MouseClick(object sender, MouseEventArgs e)
        {
            firstStartForBall = false;
        }
       
    }
}
