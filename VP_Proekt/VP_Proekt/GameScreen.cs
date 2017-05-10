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
        
        public static Size formSize;
        public GameScreen(Level lvl,LevelSelectScreen lss)
        {
            
            InitializeComponent();

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
            width = this.Width - (3 * leftX);
            height = this.Height - (int)(2.5 * topY);
            
            
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (!lvl.ball.isDead)
            {
                if (firstStartForBall == false)
                {
                    lvl.ball.Move(leftX, topY, width, height);
                    lvl.ball.IsColiding(lvl.slider);
                    lvl.BallColidingWithBrick();
                    //ballsDoc.CheckColisions();
                 }
            }
            else {
                timer.Stop();
                lvl.resetComponents();
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
           // Pen pen = new Pen(Color.Black, 3);
           // e.Graphics.DrawRectangle(pen, leftX, topY, width, height);
            //pen.Dispose();
            
        }
        public Size getSize()
        {
            return new Size(this.Width, this.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lss.showForm();
            this.Hide();
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
            timer.Start();
        }
        
        private void generateMap()
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            List<Brick> bricks = new List<Brick>();
            int width = 80;
            int rows = Level.maxHeight / Brick.height;
            int numberOfBricks = this.Width / width;
            Random rand = new Random();
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
            var FileName = "..//..//..//levels/level_"+startupConfig.num_levels+".bb";
            IFormatter serializeFormatter = new BinaryFormatter();

            using (FileStream fileStream = new FileStream(FileName, FileMode.Create))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, new Level(bricks));
            }

            startupConfig.levels.Add(new Level(startupConfig.num_levels,FileName));
            Config.serializeConfig(startupConfig,Config.confFilePath);


        }
    }
}
