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
        Config settingConfig;
        public static int maxHeight = 200;
        public List<Brick> bricks { get; set; }
        public Slider slider { get; set; }
        public Ball ball { get; set; }
        public int lives = 3;
        public int id { get; set; }
        public String filePathName { get; set; }
        public Dictionary<Point,Brick> bricksMap;
        public int formWidth;
        public int formHeight;
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
            settingConfig = config;
            Console.WriteLine(settingConfig.selectedGameDifficulty);
            if (settingConfig.selectedGameDifficulty == Config.GameDifficulty.EASY)
            {

                slider = new Slider(250, Color.Black, config.width, config.height);
            }
            else if (settingConfig.selectedGameDifficulty == Config.GameDifficulty.MEDIUM)
            {
                slider = new Slider(150, Color.Black, config.width, config.height);
            }
            else if (settingConfig.selectedGameDifficulty == Config.GameDifficulty.HARD)
            {
                slider = new Slider(100, Color.Black, config.width, config.height);
            }
            bricks = listBricks;
            
            ball = new Ball(new Point(slider.start.X + slider.width / 2, slider.start.Y - 30), Color.Black);
            bricksMap = new Dictionary<Point, Brick>();
            foreach (Brick b in bricks) {
                bricksMap.Add(b.xy,b);
            }
            this.formWidth = config.width;
            this.formHeight = config.height;
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
            int minDistX = int.MaxValue , minDistY = int.MaxValue;
            Brick brickHit = null;
            float finalVelocityX = 0, finalVelocityY = 0;
            for (int i = 0; i < bricks.Count; i++)
            {
                float velocityX = ball.velocityX;
                float velocityY = ball.velocityY;
                Point xy = bricks[i].xy;
                int brickWidth = bricks[i].width;
                Point brickCenter = new Point((xy.X + brickWidth / 2), (xy.Y + brickHeight / 2));
                bool cornerMayBeKicked = false;
                int cornerHit = 0; 
                
                int ballX = 0;
                int ballY = 0;
                

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



                int distanceX = Math.Abs(ballX - brickCenter.X);
                int distanceY = Math.Abs(ballY - brickCenter.Y);

                if (distanceX <= brickWidth / 2 && distanceY <= brickHeight / 2)
                {
                    if ((ball.Center.X <= xy.X || ball.Center.X >= xy.X + brickWidth) && (ball.Center.Y >= xy.Y && ball.Center.Y <= xy.Y + brickHeight))
                    {
                        velocityX = -ball.velocityX;

                    }
                    else if ((xy.Y >= ball.Center.Y || xy.Y + brickHeight <= ball.Center.Y) && (ball.Center.X >= xy.X && ball.Center.X <= xy.X + brickWidth))
                        velocityY = -ball.velocityY;
                    else if ((ball.Center.X < xy.X || ball.Center.X > xy.X + brickWidth) && (ball.Center.Y < xy.Y || ball.Center.Y > xy.Y + brickHeight))
                    {

                        List<int> brickSurrounding = checkSurrounding(bricks[i]);
                        cornerMayBeKicked = true;

                        //top-left corner (-X, -Y)
                        if (ball.Center.X < xy.X && ball.Center.Y < xy.Y && brickSurrounding.Contains(1))
                        {

                            if (ball.velocityX >= 0)
                                velocityX = -ball.velocityX;
                            if (ball.velocityY >= 0)
                                velocityY = -ball.velocityY;
                            cornerHit = 1;
                        }
                        //top-right corner (X, -Y)
                        else if (ball.Center.X > xy.X + brickWidth && ball.Center.Y < xy.Y && brickSurrounding.Contains(2))
                        {
                            velocityX = Math.Abs(ball.velocityX);
                            if (ball.velocityY >= 0)
                            {
                                velocityY = -ball.velocityY;
                            }
                            cornerHit = 2;
                        }
                        //bottom-left corner (-X, Y)
                        else if (ball.Center.X < xy.X && ball.Center.Y > xy.Y + brickHeight && brickSurrounding.Contains(3))
                        {
                            velocityY = Math.Abs(ball.velocityY);
                            if (ball.velocityX >= 0)
                            {
                                velocityX = -ball.velocityX;
                            }
                            cornerHit = 3;
                        }
                        //bottom-right corner (X, Y)
                        else if (ball.Center.X > xy.X + brickWidth && ball.Center.Y > xy.Y + brickHeight && brickSurrounding.Contains(4))
                        {
                            velocityY = Math.Abs(ball.velocityY);
                            velocityX = Math.Abs(ball.velocityX);
                            cornerHit = 4;
                        }

                        if (cornerHit == 0) {
                            velocityX = -ball.velocityX;
                        }
                            
                    }

                    //If it hits a unhittable corner do this
                    
                    //if (cornerHit == 1 && !brickSurrounding.Contains(cornerHit))
                    //{
                            
                    //}
                    //else if (cornerHit == 2 && !brickSurrounding.Contains(cornerHit))
                    //{

                    //}
                    //else if (cornerHit == 3)
                    //{

                    //}
                    //else if (cornerHit == 4)
                    //{

                    //}
                    

                    if (minDistX >= distanceX && minDistY >= distanceY)
                    {
                        finalVelocityY = velocityY;
                        finalVelocityX = velocityX;
                        minDistX = distanceX;
                        minDistY = distanceY;
                        brickHit = bricks[i];
                    }

                }
            }
            if(finalVelocityY != 0)
            ball.velocityY = finalVelocityY;
            if(finalVelocityX != 0)
            ball.velocityX = finalVelocityX;
            if (brickHit != null && brickHit.isCrushed())
            {
                bricks.Remove(brickHit);
                bricksMap.Remove(brickHit.xy);
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
            if (settingConfig.selectedGameDifficulty == Config.GameDifficulty.EASY)
            {
                slider = new Slider(250, Color.Black, config.width, config.height);
            }
            else if (settingConfig.selectedGameDifficulty == Config.GameDifficulty.MEDIUM)
            {
                slider = new Slider(150, Color.Black, config.width, config.height);
            }
            else if (settingConfig.selectedGameDifficulty == Config.GameDifficulty.HARD)
            {
                slider = new Slider(100, Color.Black, config.width, config.height);
            }
                
                ball = new Ball(new Point(slider.start.X + slider.width / 2, slider.start.Y - 30), Color.Black);

            return true;
        }
        public List<int> checkSurrounding(Brick b) {
            List<int> brickSurrounding = new List<int>();
            int xTopLeft = b.xy.X;
            int yTopLeft = b.xy.Y;
            int xTopRight = b.xy.X + b.width;
            int yTopRight = b.xy.Y;
            int xBottomLeft = xTopLeft;
            int yBottomLeft = b.xy.Y + Brick.height;
            int xBottomRight = xTopRight;
            int yBottomRight = yBottomLeft;

            Point leftBrick = new Point(xTopLeft - b.width, yTopLeft);
            Point leftTopBrick = new Point(xTopLeft - b.width, yTopLeft - Brick.height);
            Point topBrick = new Point(xTopLeft, yTopLeft - Brick.height);
            Point rightTopBrick = new Point(xTopRight, yTopRight - Brick.height);
            Point rightBrick = new Point(xTopRight,yTopRight);
            Point bottomRightBrick = new Point(xBottomRight,yBottomRight);
            Point bottomBrick = new Point(xTopLeft,yBottomLeft);
            Point bottomLeftBrick = new Point(xTopLeft - b.width, yBottomLeft);

            bool containsLeftBrick = (leftBrick.X >= 0 && leftBrick.Y >= 0) && (leftBrick.X <= formWidth && leftBrick.Y <= formHeight) && bricksMap.ContainsKey(leftBrick);
            bool containsTopLeftBrick = (leftTopBrick.X >= 0 && leftTopBrick.Y >= 0) && (leftTopBrick.X <= formWidth && leftTopBrick.Y <= formHeight) && bricksMap.ContainsKey(leftTopBrick);
            bool containsTopBrick = (topBrick.X >= 0 && topBrick.Y >= 0) && (topBrick.X <= formWidth && topBrick.Y <= formHeight) && bricksMap.ContainsKey(topBrick);
            bool containsTopRightBrick = (rightTopBrick.X >= 0 && rightTopBrick.Y >= 0) && (rightTopBrick.X <= formWidth && rightTopBrick.Y <= formHeight) && bricksMap.ContainsKey(rightTopBrick);
            bool containsRightBrick = (rightBrick.X >= 0 && rightBrick.Y >= 0) && (rightBrick.X <= formWidth && rightBrick.Y <= formHeight) && bricksMap.ContainsKey(rightBrick);
            bool containsBottomRightBrick = (bottomRightBrick.X >= 0 && bottomRightBrick.Y >= 0) && (bottomRightBrick.X <= formWidth && bottomRightBrick.Y <= formHeight) && bricksMap.ContainsKey(bottomRightBrick);
            bool containsBottomBrick = (bottomBrick.X >= 0 && bottomBrick.Y >= 0) && (bottomBrick.X <= formWidth && bottomBrick.Y <= formHeight) && bricksMap.ContainsKey(bottomBrick);
            bool containsBottomLeftBrick = (bottomLeftBrick.X >= 0 && bottomLeftBrick.Y >= 0) && (bottomLeftBrick.X <= formWidth && bottomLeftBrick.Y <= formHeight) && bricksMap.ContainsKey(bottomLeftBrick);

            //Can hit top left corner
            if (!containsLeftBrick && !containsTopLeftBrick && !containsTopBrick )
            {
                brickSurrounding.Add(1); 
            }
            //Can hit top right corner
            if(!containsTopBrick && !containsTopRightBrick && !containsRightBrick)
            {
                brickSurrounding.Add(2);
            }
            //Can hit bottom left corner
            if (!containsLeftBrick && !containsBottomLeftBrick && !containsBottomBrick) {
                brickSurrounding.Add(3);
            }
            //Can hit bottom right corner
            if(!containsRightBrick && !containsBottomRightBrick && !containsBottomBrick){
                brickSurrounding.Add(4);
            }

            return brickSurrounding;
        }
        
    }
}
