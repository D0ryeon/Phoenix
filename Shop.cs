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

            inventoryList.Clear();
            foreach (var inventoryItem in Global.player.inventory.itemDictionary)
            {
                    inventoryList.Add(inventoryItem.Value);       
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

            var select = Utility.SelectInt(0, inventoryList.Count, ">>");
            if (select == 0)
            {
                nextScene = null;
            }
            else
            {
                
                Shop.SellItem(select-1);
                nextScene = this;
            }

            return nextScene;

        }

        public override void Update()
        {

            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < inventoryList.Count; ++i)
            {
                Console.Write($"- {i + 1}. ");
                if (inventoryList[i].equip)
                {
                    Console.Write("[E]");
                }
                Utility.PrintInventoryItem(inventoryList[i]);
            }

        }

        List<InventoryItem> inventoryList = new List<InventoryItem>();
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

            var select = Utility.SelectShopInt(0, shopItemList.Count, ">>");
            if (select == 0)
            {
                nextScene = null;
            }
            else
            {

                    Shop.BuyItem(shopItemList[select-1]);

                nextScene = this;
            }

            return nextScene;

        }

        public override void Update()
        {

            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < shopItemList.Count; ++i)
            {
                if (shopItemList[i].isMine == false)
                {
                    Console.Write($"- {i + 1}. ");
                }
                else
                {
                    Console.Write("[구매완료]");
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
            for (int i = 0; i < 15; ++i)
            {
                if (Global.player.inventory.itemDictionary.ContainsKey(i))
                {
                    Utility.PrintInventoryItem(Global.player.inventory.itemDictionary[i]);
                }
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
            bool invenNull = true;
            if (item.isMine==false)
            {
                
                Dictionary<int, InventoryItem> i = Global.player.inventory.itemDictionary;
                for(int z =0; z < i.Count; z++)
                {
                    if (!(i.ContainsKey(z)))
                    {
                        Global.player.inventory.itemDictionary.Add(z, new InventoryItem(new ITEM(item.identifier), 1));
                        invenNull = false;
                        break;
                    }
                }
                if (invenNull)
                {
                    Global.player.inventory.itemDictionary.Add(i.Count, new InventoryItem(new ITEM(item.identifier), 1));
                }
                item.isMine = true;
                Global.player.gold -= item.gold;
            }
            else
            {

            }

        }

        static public void SellItem(int select)
        {

            var element = Global.player.inventory.itemDictionary.ElementAt(select);

            if (Global.player.inventory.itemDictionary.Count != 0)
            {
                Global.itemList[element.Value.item.identifier].isMine = false;
                Global.player.inventory.itemDictionary.Remove(element.Key);
            }

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
                    Console.WriteLine($"{equipItem.name} | {option} | {equipItem.manual} | {equipItem.gold} G");
                    break;
                case EItemClassify.Consume:
                    Console.WriteLine($"{item.name} | {item.manual} | {item.gold}" );
                    break;
            }

        }
    }





}
