using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPhoenix
{
    public class Global
    {

        public static STATUS playerStatus = new STATUS();
        public static EJob playerJob = EJob.Warrior;
        public static int playerGold = 1000;
        public static string playerName = "Kim";
        public static Inventory playerInventory = new Inventory();
        public static LevelSystem playerLevel = new LevelSystem();

        public static Player player = new Player();

        public static Table table = new Table();

        public static List<Item> itemList = new List<Item>();

    }
}
