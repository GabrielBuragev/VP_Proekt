using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace VP_Proekt
{
    [Serializable]
    public class Ball
    {
        public static readonly int RADIUS = 20;

        public Point Center { get; set; }
        public bool isDead { get; set; }
        public bool proveriDupka { get; set; }
        public Color Color { get; set; }

        public double Velocity { get; set; }
        public double Angle { get; set; }

        public float velocityX { get; set; }
        public float velocityY { get; set; }
        public Ball(Point center, Color color)
        {
            Center = center;
            Color = color;
            //IsColided = false;
            Velocity = 20;
            //Random r = new Random();
            //Angle = r.NextDouble() * 2 * Math.PI;
            velocityX = 0;
            velocityY = (float)Velocity;
        }

      /*  public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color);
            g.FillEllipse(brush, Center.X - RADIUS, Center.Y - RADIUS, RADIUS * 2, RADIUS * 2);
            brush.Dispose();
        }*/

        public void Draw(Graphics g)
        {
            //Bitmap bit = new Bitmap(100, 100);
            Image img = Bitmap.FromFile("ball1.ico");
            g.DrawImage(img, Center.X - RADIUS/2, Center.Y,30,30);

        }
        public void IsColiding(Slider slider)
        {
            Point leftPoint = slider.start;
            Point rightPoint = new Point(slider.start.X + slider.width, slider.start.Y);

            /*
             * Ball collided with slider on LEFT
             * */
            if ((Center.X + RADIUS / 2) >= leftPoint.X && (Center.X + RADIUS / 2) <= (leftPoint.X + (slider.width* 0.5)) && (Center.Y + RADIUS / 2) >= leftPoint.Y)
            {
                int sliderCollidingX = -(int)Math.Abs(((Center.X) - (leftPoint.X + (slider.width * 0.5))));
                velocityX = (int)(Velocity * ((sliderCollidingX / (slider.width * 0.5))));

                //Angle =  0.5 * (Math.PI);

                velocityY = -velocityY;
                if (velocityX > 0)
                    velocityX = -velocityX;

                Center = new Point((int)(Center.X + (velocityX)), (int)(Center.Y + (velocityY)));
            }

            /*
             * Ball collided with slider on RIGHT
             * */
            else if ((Center.X + RADIUS / 2) >= (rightPoint.X - (slider.width * 0.5)) && (Center.X + RADIUS / 2) <= (rightPoint.X) && (Center.Y + RADIUS / 2) >= (leftPoint.Y))
            {
                int sliderCollidingX = (int)Math.Abs(((rightPoint.X - (slider.width * 0.5)) - (Center.X)));

                //Angle = 0.5 * (Math.PI);

                velocityY = -velocityY;
                velocityX = (int)(Velocity * ((sliderCollidingX / (slider.width * 0.5))));

                Center = new Point((int)(Center.X + velocityX), (int)(Center.Y + velocityY));
            }
            
        }

        public void Move(int left, int top, int width, int height)
        {
            
            float nextX = Center.X + velocityX;
            float nextY = Center.Y + velocityY;
            if (nextY + RADIUS >= height)
            {
                isDead = true;
                return;
            }
            
            if (nextX - RADIUS <= left || nextX + RADIUS >= width + left)
            {
                velocityX = -velocityX;
            }
            if (nextY - RADIUS <= top || nextY + RADIUS >= height + top)
            {
                velocityY = -velocityY;
            }
            Center = new Point((int)(Center.X + velocityX), (int)(Center.Y + velocityY));
        }

        public void MoveWithSlider(float dx)
        {
            Center = new Point((int)dx, Center.Y);
        }
    }
}
