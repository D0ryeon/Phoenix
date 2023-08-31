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
                        
                    }
                }
            }

            Console.Clear();

            Console.WriteLine("[판매하기]");
            Console.WriteLine($"소지금 : {Global.player.gold} G");
            Console.WriteLine("물건을 판매하실 수 있습니다.");


        }

        public override SceneBase End()
        {

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            var select = Utility.SelectInt(0, shopItemList.Count, ">>");
            if (select == 0)
            {
                nextScene = null;
            }
            else
            {
                //Sell_Item(shopItemList[select]);
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
            shopItemList.Clear();
            foreach (var ShopItem in Global.itemList)
            {
                shopItemList.Add(ShopItem);
            }

            Console.Clear();

            Console.WriteLine("[구매하기]");
            Console.WriteLine($"소지금 : {Global.player.gold} G");
            Console.WriteLine("물건을 구매하실 수 있습니다.");


        }

        public override SceneBase End()
        {

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            var select = Utility.SelectInt(0, shopItemList.Count, ">>");
            if (select == 0)
            {
                nextScene = null;
            }
            else
            {
                if (shopItemList[select-1].gold <= Global.player.gold)
                {
                    Shop.BuyItem(shopItemList[select-1]);
                }
                else
                {
                    Console.WriteLine("플레이어 소지금이 부족합니다");
                }

                nextScene = this;
            }

            return nextScene;

        }

        public override void Update()
        {

            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < shopItemList.Count; ++i)
            {
                Console.Write($"- {i + 1}. ");
                for(int z = 0; z < equipItemList.Count;z++)
                {
                    if (equipItemList[z].item.identifier == shopItemList[i].identifier)
                    {
                        Console.Write("[구매완료]");
                    }

                }
                Shop.PrintBuyItem(shopItemList[i]);
            }

        }
        List<Item> shopItemList = new List<Item>();
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
            Console.WriteLine("1.구매하기");
            Console.WriteLine("2.판매하기");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            SceneBase nextScene = null;
            Utility.MethodSelector methodSelector = new Utility.MethodSelector();
            methodSelector.dictionary.Add(0, (_) => nextScene = null);
            methodSelector.dictionary.Add(1, (_) => { nextScene = this; RunScene(new ShopBuyScene()); });
            methodSelector.dictionary.Add(2, (_) => { nextScene = this; RunScene(new ShopSellScene()); });
            methodSelector.Select(">>");

            return nextScene;

        }

        public override void Update()
        {
        }

    }


    public class Shop
    {
        static public void BuyItem(Item item)
        {

            
                Dictionary<int, InventoryItem> i = Global.player.inventory.itemDictionary;

                Global.player.inventory.itemDictionary.Add(i.Count, new InventoryItem(new ITEM(item.identifier), 1));



                Global.player.gold -= item.gold;
            
            

        }

        static public void SellItem(Item item)
        {

            Dictionary<int, InventoryItem> i = Global.player.inventory.itemDictionary;

            Global.player.inventory.itemDictionary.Add(i.Count, new InventoryItem(new ITEM(item.identifier), 1));

            Global.player.gold += item.gold/2;

        }


        public static void PrintBuyItem(Item item)
        {

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
                    Console.WriteLine($"{item.name} | {item.manual}");
                    break;
            }

        }
    }





}
