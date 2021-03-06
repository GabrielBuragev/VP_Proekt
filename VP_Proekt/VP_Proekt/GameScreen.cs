﻿    using System;
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
using Newtonsoft.Json;


namespace VP_Proekt
{
    public partial class GameScreen : Form
    {
        Level lvl;  
        public static int  dynamicHeigth = 25;
        LevelSelectScreen lss;
        private string FileName;
        private bool firstStartForBall;
        private Timer timer;
        private int leftX;
        private int topY;
        private int width;
        private int height;
        public Config startupConfig;
        private Graphics grap;
        
        public static Size formSize;
        public GameScreen(Level lvl,LevelSelectScreen lss)
        {
            InitializeComponent();
            grap = this.CreateGraphics();
            formSize = this.getSize();
            this.lvl = lvl;
            this.lss = lss;
            this.startupConfig = Config.deserializeConfig(Config.confFilePath);
           
            DoubleBuffered = true;
            firstStartForBall = true;
            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += new EventHandler(timer_Tick);
            leftX = 1;
            topY = dynamicHeigth;
            
            this.Width = startupConfig.width + 18;
            this.Height = startupConfig.height + 18;

            width = startupConfig.width;
            height = this.Height - (int)(2.5 * topY);
            
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (!lvl.ball.isDead)
            {
                if (firstStartForBall == false)
                {
                  
                    if (lvl.bricks.Count == 0)
                    {
                        timer.Stop();
                        if (MessageBox.Show("Честито, успешно го завршивте нивото бр." + lvl.id + " !", "Играта заврши", MessageBoxButtons.OK) == System.Windows.Forms.DialogResult.OK)
                        {
                            lss.Show();
                            this.Hide();
                        }
                    }
                    
                    lvl.ball.Move(leftX, topY, width, height);
                    lvl.ball.IsColiding(lvl.slider);
                    lvl.BallColidingWithBrick();
                    
                   
                 }
            }
            else {
                timer.Stop();
                if (!lvl.resetComponents(startupConfig))
                {
                    Invalidate(true);
                    if (MessageBox.Show("Вие изгубивте!", "Играта заврши", MessageBoxButtons.OK) == System.Windows.Forms.DialogResult.OK)
                    {
                        lss.Show();
                        this.Hide();
                    }

                }
                firstStartForBall = true;

            }
            Invalidate(true);
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Invalidate(true);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            lvl.DrawBricks(e.Graphics);
            
        }
        public Size getSize()
        {
            return new Size(this.Width, this.Height);
        }

        private void GameScreen_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.X > 0 && e.X <= width - lvl.slider.width)
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
            lvl.ball.velocityY = (float)-lvl.ball.Velocity;
            timer.Start();
        }


        private void toolStripStatusLabel1_Paint(object sender, PaintEventArgs e)
        {
           
            toolStripStatusLabel1.Text = "Животи: " + lvl.lives + ", преостанати коцки: " + lvl.bricks.Count;
        }

        //Save File
        private void saveFile()
        {
            if (FileName == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "BrickBreaker file (*.bb)|*.bb";
                saveFileDialog.Title = "Save BrickBreaker file";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = saveFileDialog.FileName;
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

        // Open File
        private void openFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "BrickBreaker file (*.bb)|*.bb";
            openFileDialog.Title = "Save BrickBreaker file";
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

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void tsbBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            lss.Show();
        }

        
    }
}
