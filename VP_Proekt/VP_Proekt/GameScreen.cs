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
using Newtonsoft.Json;


namespace VP_Proekt
{
    public partial class GameScreen : Form
    {
        Level lvl;  
        LevelSelectScreen lss;
        private string FileName;
        private float prevX = 0;
        private float prevY = 0;
        private bool firstStartForBall;
        private Timer timer;
        private int leftX;
        private int topY;
        private int width;
        private int height;
        private bool proveriDupka;
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
            topY = 1;
            proveriDupka = false;
            
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
                    //ballsDoc.CheckColisions();
                   
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
            timer.Start();
        }

        private void lblStatusZivot_Paint(object sender, PaintEventArgs e)
        {
           // lblStatusZivot.Text = "Животи: " + lvl.lives + ", преостанати коцки: " + lvl.bricks.Count;
        }

        private void toolStripStatusLabel1_Paint(object sender, PaintEventArgs e)
        {
           
            toolStripStatusLabel1.Text = "Животи: " + lvl.lives + ", преостанати коцки: " + lvl.bricks.Count;
        }
        
        
    }
}
