using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace VP_Proekt
{
    [Serializable]
    public class Config  
    {
        public int width { get; set; }
        public int height { get; set; }
        public int num_levels { get; set; }
        public List<Level> levels;
        [NonSerialized] public static string confFilePath = "..//..//..//config.json";
        public enum GameDifficulty
        {
            EASY,
            MEDIUM,
            HARD
        };
        public GameDifficulty selectedGameDifficulty;

        /*
         Config constructor
         */
        public Config(int width = 800, int height = 600,int num_levels = 0, GameDifficulty GameDifficulty = GameDifficulty.EASY)
        {
            this.width = width;
            this.height = height;
            this.num_levels = num_levels;
            this.selectedGameDifficulty = GameDifficulty;
            levels = new List<Level>();
        }
        public void increaseNumLevels()
        {
            this.num_levels++;
        }

        /*
         Static function to serialize/save current settings into config.json file
         */
        public static void serializeConfig(Config confToSerialize,string confFilePath)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(confFilePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, confToSerialize);
            }

        }

        /*
         Static function to deserialize config.json file
         */
        public static Config deserializeConfig(string confFilePath)
        {

            Config tmp = new Config();
            if (new System.IO.FileInfo(confFilePath).Length != 0)
            {
                using (StreamReader r = new StreamReader(confFilePath))
                {
                    string json = r.ReadToEnd();
                    tmp = JsonConvert.DeserializeObject<Config>(json);
                }
            }
            else {
                Config.serializeConfig(tmp, confFilePath);
            }
            return tmp;
        }
        public static Level deserializeLevel(string pathName)
        {
            IFormatter formater = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(pathName, FileMode.Open))
                {
                    Level tmp = (Level)formater.Deserialize(fs);
                    Console.WriteLine(tmp.slider.start.ToString());
                    return tmp;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return null;
        }
        

    }
}
