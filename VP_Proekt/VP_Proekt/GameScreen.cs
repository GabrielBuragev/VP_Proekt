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
        public GameScreen()
        {
            InitializeComponent();
            DoubleBuffered = true;
            firstStartForBall = true;
            lvl = new Level(this);
            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            leftX = 0;
            topY = 0;
            proveriDupka = false;
            width = this.Width - (3 * leftX);
            height = this.Height - (int)(2.5 * topY);

            startupConfig = new Config();
            LoadMap();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (firstStartForBall == false)
            {
                
                lvl.ball.Move(leftX, topY, width, height, proveriDupka);
                //ballsDoc.CheckColisions();
                //i ovde isto proverka dali treba kopceto da se izgubi
                if (proveriDupka == true)
                {
                    lvl.ball.isDead = true;
                }
                Invalidate(true);
            }
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
            generateMap();
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
        private void serializeConfig()
        {
            var FileName = "config.json";
            JsonReader jReader;
            JsonSerializer serializer = new JsonSerializer();
            //using (StreamWriter sw = new StreamWriter(@"c:\json.txt"))
            //    using (JsonWriter writer = new JsonTextWriter(sw))
            //    {
            //        serializer.Serialize(writer, product);
            //        // {"ExpiryDate":new Date(1230375600000),"Price":0}
            //}
            using (StreamReader r = new StreamReader(@"..//..//..//config.json"))
            {
                string json = r.ReadToEnd();
                startupConfig = JsonConvert.DeserializeObject<Config>(json);

                Console.WriteLine(startupConfig.width + " " + startupConfig.height + " " + startupConfig.selectedGameDifficulty);
            }
        }
        private void LoadMap()
        {
            FileName = "..//..//..//levels/level1.bb";
            try
            {
                List<Brick> allBricks = new List<Brick>();
                using (FileStream fileStream = new FileStream(FileName, FileMode.Open))
                {

                    IFormatter formater = new BinaryFormatter();
                    allBricks = (List<Brick>)formater.Deserialize(fileStream);
                }
                lvl.bricks = allBricks;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not read file: " + FileName);
                FileName = null;
                return;
            }
            Invalidate(true);
        }
        private void generateMap()
        {

            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            Console.WriteLine(path);
            List<Brick> bricks = new List<Brick>();
            int width = 80;
            int rows = Level.maxHeight / Brick.height;
            int numberOfBricks = this.Width / width;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < numberOfBricks; j++)
                {
                    Random rand = new Random();
                    Level.BrickType brType = Level.BrickType.NORMAL;
                    int random = 0;
                    if (startupConfig.num_levels < 2)
                        random = rand.Next(0, 1);
                    else if (startupConfig.num_levels >= 2 & startupConfig.num_levels < 5)
                        random = rand.Next(0, 2);
                    else if (startupConfig.num_levels >= 5)
                        random = rand.Next(0, 3);

                    if (random == 0)
                        brType = Level.BrickType.NORMAL;
                    else if (random == 1)
                        brType = Level.BrickType.STONE;
                    else if (random == 2)
                        brType = Level.BrickType.DIAMOND;

                    bricks.Add(new Brick(new Point(j * width, i * Brick.height), width, brType));

                }
            }

            var FileName = "..//..//..//levels/level1.bb";
            IFormatter serializeFormatter = new BinaryFormatter();

            using (FileStream fileStream = new FileStream(FileName, FileMode.Create))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, bricks);
            }

            startupConfig.num_levels++;
            serializeConfig();


        }
    }
}
