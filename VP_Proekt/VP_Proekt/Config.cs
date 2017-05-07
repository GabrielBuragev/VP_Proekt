using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VP_Proekt
{
    public class Config
    {
        public int width { get; set; }
        public int height { get; set; }
        public int num_levels { get; set; }
        public enum GameDifficulty : int
        {
            EASY,
            MEDIUM,
            HARD
        };
        public GameDifficulty selectedGameDifficulty;
        public Config(int width = 800, int height = 600,int num_levels = 0, GameDifficulty GameDifficulty = GameDifficulty.EASY)
        {
            this.width = width;
            this.height = height;
            this.num_levels = num_levels;
            this.selectedGameDifficulty = GameDifficulty;
        }
        public void increaseNumLevels(){
            this.num_levels++;
        }

    }
}
