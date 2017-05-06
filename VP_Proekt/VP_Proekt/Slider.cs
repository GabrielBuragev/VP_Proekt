using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace VP_Proekt
{
    class Slider
    {
 
        public Point start { get; set; }
        public int width { get; set; }
        public static int height = 20; 
        public Color fillColor { get; set; }
        public Slider(int width,Color fillColor,Form1 form) {
            this.width = width;
            this.fillColor = fillColor;
            Size formSize = form.getSize();

            int sliderX = (formSize.Width/2) - (width/2) ;
            int sliderY = formSize.Height - height - 45;
            start = new Point(sliderX,sliderY);
        }
        public void Draw(Graphics g) {
            Brush brush = new SolidBrush(fillColor);
            g.FillRectangle(brush,start.X,start.Y,width,height);
            brush.Dispose();
        }
    }
}
