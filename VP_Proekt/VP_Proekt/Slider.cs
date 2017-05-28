using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VP_Proekt
{
    [Serializable]
    public class Slider
    {
 
        public Point start { get; set; }
        public int width { get; set; }
        public static int height = 20; 
        public Color fillColor { get; set; }
        public Slider(int width,Color fillColor,int formWidth,int formHeight) {
          
            this.width = width;
            this.fillColor = fillColor;
            Size formSize = new Size(formWidth,formHeight);
            int sliderX = (formSize.Width / 2) - (width / 2);
            int sliderY = formSize.Height - height - 75;
            start = new Point(sliderX,sliderY);
        }
        public void Draw(Graphics g)
        {
            Image img = Bitmap.FromFile("slider.png");
            g.DrawImage(img, start.X, start.Y, width, 35);

        }
        public void Move(float dx)
        {
            start = new Point((int)dx, start.Y);
        }
    }
}
