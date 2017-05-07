using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace VP_Proekt
{   
    [Serializable]
    class Level
    {
        public static int maxHeight = 200;

        public List<Brick> bricks { get; set; }
        public Slider slider { get; set; }
        public Ball ball { get; set; }
        public GameScreen form;
        public Level(GameScreen form) {
            this.form = form;
            bricks = new List<Brick>();
            slider = new Slider(200,Color.Black,form);
            ball = new Ball(new Point(slider.start.X + slider.width/2,slider.start.Y-23),Color.Black);
        }
        public Level(List<Brick> listBricks) {
            bricks = listBricks;
        }
        public void addBrick(Point start, int width) {
            Brick br = new Brick(start, width);
            bricks.Add(br);
        }
        public void DrawBricks(Graphics g) {
            ball.Draw(g);
            slider.Draw(g);
            foreach (Brick br in bricks) {
                br.Draw(g);
            }
        }
        //Temporary function
        public void setBricks(List<Brick> bricks) {
            this.bricks = bricks;
        }
    }
}
