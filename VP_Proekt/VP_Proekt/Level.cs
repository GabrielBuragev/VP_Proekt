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
        public Level(List<Brick> listBricks,Config config)
        {
            bricks = listBricks;
            slider = new Slider(200, Color.Black, config.width, config.height);
            ball = new Ball(new Point(slider.start.X + slider.width / 2, slider.start.Y - 30), Color.Black);
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
        /*
         * Check if the ball hits a brick in any direction
         * **/
        public void BallColidingWithBrick()
        {
            int brickHeight = Brick.height;
            for (int i = 0; i < bricks.Count; i++)
            {
                Point xy = bricks[i].xy;
                int brickWidth = bricks[i].width;
                Point brickCenter = new Point((xy.X + brickWidth / 2), (xy.Y + brickHeight / 2));


                int ballX = 0;
                int ballY = 0;
                float velocityX = ball.velocityX;
                float velocityY = ball.velocityY;

                if (brickCenter.Y >= ball.Center.Y)
                {
                    ballY = ball.Center.Y + Ball.RADIUS;
                }
                else if (brickCenter.Y < ball.Center.Y)
                {
                    ballY = ball.Center.Y - Ball.RADIUS;
                }
                if (brickCenter.X >= ball.Center.X)
                {
                    ballX = ball.Center.X + Ball.RADIUS;
                }
                else if (brickCenter.X < ball.Center.X)
                {
                    ballX = ball.Center.X - Ball.RADIUS;
                }
                //if ((xy.X > ball.Center.X || xy.X + brickWidth < ball.Center.X) && (xy.Y < ball.Center.Y && xy.Y + brickHeight >ball.Center.Y))
                //    velocityX = -ball.velocityX;

                if (ball.Center.X < xy.X || ball.Center.X > xy.X + brickWidth && (ball.Center.Y >= xy.Y && ball.Center.Y <= xy.Y + brickHeight))
                    velocityX = -ball.velocityX;
                if ((xy.Y > ball.Center.Y || xy.Y + brickHeight < ball.Center.Y) && (ball.Center.X > xy.X && ball.Center.X < xy.X + brickWidth))
                    velocityY = -ball.velocityY;
                if (ball.Center.X < xy.X && ball.Center.Y > xy.Y + brickHeight)
                {
                    if (velocityX > 0 && velocityY < 0)
                    {
                        velocityX = -velocityX;
                        velocityY = -velocityY;
                    }
                    else
                    {
                        velocityX = -velocityX;
                    }

                }
                int distanceX = Math.Abs(ballX - brickCenter.X);
                int distanceY = Math.Abs(ballY - brickCenter.Y);

                if (distanceX <= brickWidth / 2 && distanceY <= brickHeight / 2)
                {
                    ball.velocityY = velocityY;
                    ball.velocityX = velocityX;
                    if (bricks[i].isCrushed())
                        bricks.Remove(bricks[i]);
                    break;
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
        public bool resetComponents(Config config) {
            lives--;
            if (lives == 0)
                return false;

                slider = new Slider(200, Color.Black, config.width, config.height);
                ball = new Ball(new Point(slider.start.X + slider.width / 2, slider.start.Y - 30), Color.Black);

            return true;
        }
    }
}
