using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace VP_Proekt
{
    [Serializable]
    class Brick
    {

        public Point xy { get; set; }
        public int width { get; set; }
        public static int height = 20;
        public Brick(Point xy, int width) {
            this.xy = xy;
            this.width = width;
        }
        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.White, 1);
            Brush brush = new SolidBrush(Color.Black);
            g.FillRectangle(brush, xy.X, xy.Y, width, height);
            g.DrawRectangle(pen, xy.X, xy.Y, width, height);
            pen.Dispose();
            brush.Dispose();
        }
   
    }
}
