using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace VP_Proekt
{
    [Serializable]
    public class Brick
    {

        public Level.BrickType brickType;
        public Point xy { get; set; }
        public int width { get; set; }
        public static int height = 20;
        public Color brickColor;
        public int lives;
        public Brick(Point xy, int width, Level.BrickType brickType)
        {
            this.xy = xy;
            this.width = width;
            this.brickType = brickType;

            if (brickType == Level.BrickType.NORMAL)
            {
                this.brickColor = Color.Gold;
                lives = 1;
            }
            else if (brickType == Level.BrickType.STONE)
            {
                this.brickColor = Color.LightGray;
                lives = 2;
            }

            else if (brickType == Level.BrickType.DIAMOND)
            {
                this.brickColor = Color.CornflowerBlue;
                lives = 3;
            }
        }
        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.White, 1);
            Brush brush = new SolidBrush(this.brickColor);
            g.FillRectangle(brush, xy.X, xy.Y, width, height);
            g.DrawRectangle(pen, xy.X, xy.Y, width, height);
            pen.Dispose();
            brush.Dispose();
        }
       
        public void changeColor()
        {
            if (lives == 1)
                brickColor = Color.Gold;
            else if (lives == 2)
                brickColor = Color.LightGray;
        }
        public bool isCrushed()
        {
            lives--;
            changeColor();
            if (lives == 0)
                return true;
            else
                return false;
        }


   
    }
}
