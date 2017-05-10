using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace VP_Proekt
{   
    [Serializable]
    public class Level
    {

        public enum BrickType
        {
            NORMAL,
            STONE,
            DIAMOND
        }
        public static int maxHeight = 200;
        public List<Brick> bricks { get; set; }
        public Slider slider { get; set; }
        public Ball ball { get; set; }
        public int lives = 3;
        public int id { get; set; }
        public String filePathName { get; set; }
        /*
         * Default constructor.
         * Used only by the JSONDeserializator.
         * It really has no other function
         */
        public Level(){}
        /*
         Constructor for creating a level with all the required data (Bricks,Ball,Slider)
         */
        public Level(List<Brick> listBricks)
        {
            bricks = listBricks;
            slider = new Slider(200, Color.Black);
            ball = new Ball(new Point(slider.start.X + slider.width / 2, slider.start.Y - 23), Color.Black);
        }
        /*
         Custom constructor for serializing level into config.json file (null -> ignored by JSONFormatter)
         */
        public Level(int id, string filePathName) {
            this.bricks = null;
            this.slider = null;
            this.ball = null;
            this.id = id;
            this.filePathName = filePathName;
        }
        /*
         * Add a brick to the level (used only when generating the maps) 
         **/
        public void addBrick(Point start, int width, BrickType brType)
        {
            Brick br = new Brick(start, width, brType);
            bricks.Add(br);
        }
        /*
         * Draw the brick on the game screen 
         **/
        public void DrawBricks(Graphics g) {
            if (!ball.isDead)
            {
                ball.Draw(g);
            }
            slider.Draw(g);
            foreach (Brick br in bricks) {
                br.Draw(g);
            }
        }
        public void BallColidingWithBrick()
        {
            for (int i = 0; i < bricks.Count; i++)
            {
                Point xy = bricks[i].xy;
                if ((ball.Center.X) >= xy.X && (ball.Center.X) <= (xy.X + bricks[i].width)
                    && (ball.Center.Y - Ball.RADIUS) <= xy.Y + Brick.height)
                {
                    ball.velocityY = -ball.velocityY;
                    bricks.Remove(bricks[i]);
                    //ball.Center = new Point((int)(ball.Center.X + ball.velocityX), (int)(ball.Center.Y + ball.velocityY));
                }
            }
        }
        public BrickType getBrickType(int index)
        {
            if (index == 0)
                return BrickType.NORMAL;
            else if (index == 1)
                return BrickType.STONE;
            else if (index == 2)
                return BrickType.DIAMOND;
            else
                return BrickType.NORMAL;

        }
        public void resetComponents() {
            slider = new Slider(200, Color.Black);
            ball = new Ball(new Point(slider.start.X + slider.width / 2, slider.start.Y - 23), Color.Black);
        }
    }
}
