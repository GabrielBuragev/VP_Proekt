using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace VP_Proekt
{
    class LevelGenerator
    {
        List<Brick> bricks;
        GameScreen form;
        int width = 50;
        public LevelGenerator(GameScreen form, Level lvl)
        {
            this.form = form;
            int rows = Level.maxHeight / Brick.height;
            int numberOfBriks = form.Width / width;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; i < numberOfBriks; i++)
                {
                    bricks.Add(new Brick(new Point(j * width, i * Brick.height), width));
                    lvl.addBrick(new Point(j * width, i * Brick.height), width);
                    
                }
            }
           // lvl.DrawBricks(Graphics g);
        }
    }
}

