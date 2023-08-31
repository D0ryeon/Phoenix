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

            Global.player.status.attack = 10;
            Global.player.status.armor = 1;
            Global.player.status.health = 35;
            Global.player.status.mana = 50;

            Global.itemList.Add(new EquipItem(0, "무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", new STATUS(0, 5, 0, 0), 100));
            Global.itemList.Add(new EquipItem(1, "낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", new STATUS(2, 0, 0, 0), 100));
            Global.itemList.Add(new EquipItem(2, "마체테", "무언가 자르기 좋아보입니다.", new STATUS(8, 0, 0, 0), 1500));
            Global.itemList.Add(new EquipItem(3, "무쇠신발", "무쇠로 만들어져 튼튼한 신발입니다.", new STATUS(0, 5, 0, 0), 500));
            Global.itemList.Add(new EquipItem(4, "무쇠투구", "무쇠로 만들어져 튼튼한 투구입니다.", new STATUS(0, 8, 0, 0), 2000));


            Global.player.inventory.itemDictionary.Add(0, new InventoryItem(new ITEM(0), 1));
            Global.player.inventory.itemDictionary.Add(1, new InventoryItem(new ITEM(1), 1));

            game.Run();

        }

    }

}