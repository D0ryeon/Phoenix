using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPhoenix
{
    

    internal class Program
    {

        static void Main(string[] args)
        {

            Game game = new Game();

            var configuration = new GAME_START_CONFIGURATION();
            configuration.startScene = new IntroScene();
            game.gameStartConfiguration = configuration;

            Global.playerStatus.attack = 10;
            Global.playerStatus.armor = 1;
            Global.playerStatus.health = 35;

            Global.itemList.Add(new EquipItem(0, "무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", new STATUS(0, 5, 0)));
            Global.itemList.Add(new EquipItem(1, "낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", new STATUS(2, 0, 0)));

            Global.playerInventory.itemDictionary.Add(0, new InventoryItem(new ITEM(0), 1));
            Global.playerInventory.itemDictionary.Add(1, new InventoryItem(new ITEM(1), 1));

            game.Run();

        }

    }

}