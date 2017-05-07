﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace VP_Proekt
{   
    [Serializable]
    class Level
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
        public void addBrick(Point start, int width, BrickType brType)
        {
            Brick br = new Brick(start, width, brType);
            bricks.Add(br);
        }
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
        
        //Temporary function
        public void setBricks(List<Brick> bricks) {
            this.bricks = bricks;
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
    }
}
