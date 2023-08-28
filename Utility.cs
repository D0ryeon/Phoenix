using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPhoenix
{
    public delegate void MethodSelectMethod(int select);

    public class Utility
    {


        static public int SelectInt(int min, int max, string message)
        {

            while (true)
            {

                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out var select))
                {

                    if (select < min || select > max)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                    else
                    {
                        return select;
                    }

                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }

            }

        }


        public class MethodSelector
        {

            public Dictionary<int, MethodSelectMethod> dictionary = new Dictionary<int, MethodSelectMethod>();

            public void Select(string message)
            {

                while (true)
                {
                    Console.Write(message);
                    if (int.TryParse(Console.ReadLine(), out var select))
                    {
                        if (dictionary.ContainsKey(select))
                        {
                            dictionary[select](select);
                            return;
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                        }

                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }

                }

            }

        }


        public static void PrintInventoryItem(InventoryItem inventoryItem)
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