using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPhoenix
{
    public class ShopSellScene : SceneBase
    {

        public override void Start()
        {

            equipItemList.Clear();
            foreach (var inventoryItem in Global.player.inventory.itemDictionary)
            {
                if (Global.itemList[inventoryItem.Value.item.identifier].classify == EItemClassify.Equip)
                {
                    equipItemList.Add(inventoryItem.Value);
                }
            }
            foreach (var ShopItem in Global.itemList)
            {
                shopItemList.Add(ShopItem);
            }

            for(int i=0; i<equipItemList.Count; i++)
            {
                for(int z = 0; z < shopItemList.Count; z++)
                {
                    if (shopItemList[z].identifier == equipItemList[i].item.identifier)
                    {
                        shopItemList.RemoveAt(z);
                    }
                }
            }

            Console.Clear();

            Console.WriteLine("[판매하기]");
            Console.WriteLine("물건을 판매하실 수 있으십니다.");


        }

        public override SceneBase End()
        {

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            var select = Utility.SelectInt(0, equipItemList.Count, ">>");
            if (select == 0)
            {
                nextScene = null;
            }
            else
            {
                equipItemList[select - 1].equip = !equipItemList[select - 1].equip;
                nextScene = this;
            }

            return nextScene;

        }

        public override void Update()
        {

            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < equipItemList.Count; ++i)
            {
                Console.Write($"- {i + 1}. ");
                if (equipItemList[i].equip)
                {
                    Console.Write("[E]");
                }
                Utility.PrintInventoryItem(equipItemList[i]);
            }

        }

        List<InventoryItem> equipItemList = new List<InventoryItem>();
        List<Item> shopItemList = new List<Item>();
        private SceneBase nextScene = null;

    }


    public class ShopBuyScene : SceneBase
    {

        public override void Start()
        {

            equipItemList.Clear();
            foreach (var inventoryItem in Global.player.inventory.itemDictionary)
            {
                if (Global.itemList[inventoryItem.Value.item.identifier].classify == EItemClassify.Equip)
                {
                    equipItemList.Add(inventoryItem.Value);
                }
            }

            Console.Clear();

            Console.WriteLine("[상점]");
            Console.WriteLine("상점에 오신걸 환영합니다. 원하는 물건을 구매 하거나 팔 수 있습니다");


        }

        public override SceneBase End()
        {

            Console.WriteLine("1.구매하기");
            Console.WriteLine("2.판매하기");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            var select = Utility.SelectInt(0, equipItemList.Count, ">>");
            if (select == 0)
            {
                nextScene = null;
            }
            else
            {
                equipItemList[select - 1].equip = !equipItemList[select - 1].equip;
                nextScene = this;
            }

            return nextScene;

        }

        public override void Update()
        {

            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < equipItemList.Count; ++i)
            {
                Console.Write($"- {i + 1}. ");
                if (equipItemList[i].equip)
                {
                    Console.Write("[E]");
                }
                Utility.PrintInventoryItem(equipItemList[i]);
            }

        }

        List<InventoryItem> equipItemList = new List<InventoryItem>();

        private SceneBase nextScene = null;

    }


    public class ShopScene : SceneBase
    {

        public override void Start()
        {

            Console.Clear();

            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < Global.player.inventory.itemDictionary.Count; ++i)
            {
                Utility.PrintInventoryItem(Global.player.inventory.itemDictionary[i]);
            }

        }

        public override SceneBase End()
        {

            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            SceneBase nextScene = null;
            Utility.MethodSelector methodSelector = new Utility.MethodSelector();
            methodSelector.dictionary.Add(0, (_) => nextScene = null);
            methodSelector.dictionary.Add(1, (_) => { nextScene = this; RunScene(new InventoryEquipScene()); });
            methodSelector.Select(">>");

            return nextScene;

        }

        public override void Update()
        {
        }

    }


    public class Shop
    {
        public static void PrintShopItem(InventoryItem inventoryItem)
        {
            var item = Global.itemList[inventoryItem.item.identifier];

            switch (item.classify)
            {
                case EItemClassify.ETC:
                    Console.WriteLine($"{item.name} | {item.manual}");
                    break;
                case EItemClassify.Equip:
                    var equipItem = (EquipItem)item;
                    string option = "";
                    if (equipItem.status.attack != 0)
                    {
                        option += equipItem.status.attack > 0 ? "공격력 +" : "공격력 ";
                        option += equipItem.status.attack;
                    }
                    if (equipItem.status.armor != 0)
                    {
                        option += equipItem.status.armor > 0 ? "방어력 +" : "방어력 ";
                        option += equipItem.status.armor;
                    }
                    if (equipItem.status.health != 0)
                    {
                        option += equipItem.status.health > 0 ? "체력 +" : "체력 ";
                        option += equipItem.status.health;
                    }
                    Console.WriteLine($"{equipItem.name} | {option} | {equipItem.manual}");
                    break;
                case EItemClassify.Consume:
                    Console.WriteLine($"{item.name}({inventoryItem.number}) | {item.manual}");
                    break;
            }

        }
    }





}
