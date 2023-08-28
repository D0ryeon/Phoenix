using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix
{
    public class Inventory
    {
        public List<Item> items { get; set; }
        public Inventory()
        {
            items = new List<Item>();
            addItem(new Item("0", "0", 0, 0, 0));
            addItem(new Item("무쇠갑옷", "햄이네가 주워온 종이상자입니다. 매직으로 무쇠갑옷이라 써 있습니다.", 0, 1, 0));
            addItem(new Item("전설의 검", "햄이네가 전설의 검이라고 이름 붙인 나뭇가지입니다. 용감해진 기분입니다", 1, 0, 0));
            addItem(new Item("강철투구", "평범한 빨간색 바가지입니다. 매직으로 까맣게 칠해져 있습니다.", 0, 1, 0));
        }

        public void addItem(Item item)
        {
            items.Add(item);
        }

        public void removeItem(string itemName)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].name == itemName)
                {
                    items.Remove(items[i]);
                    Console.WriteLine("저런 " + itemName + "을 잃으셨군요");
                }
            }
        }
    }

    static public class InvenView
    {
        // 인벤토리 뷰
        static public void InventoryView(List<Item> inven)
        {
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 1; i < inven.Count; i++)
            {
                Console.Write("- ");
                if (inven[i].equip == true)
                {
                    Console.Write(" [E]\t");
                }
                else
                {
                    Console.Write("\t");
                }
                Console.Write(inven[i].name);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("   \t| ");
                Console.ResetColor();
                if (inven[i].damage != 0)
                {
                    Console.Write("공격력 ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("+" + inven[i].damage);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" | ");
                    Console.ResetColor();
                }
                else if (inven[i].defense != 0)
                {
                    Console.Write("방어력 ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("+" + inven[i].defense);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" | ");
                    Console.ResetColor();
                }
                Console.Write(inven[i].content);
                Console.Write('\n');
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("1");
            Console.ResetColor();
            Console.WriteLine(". 장착관리");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("0");
            Console.ResetColor();
            Console.WriteLine(". 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
        }

        // 장비착용 뷰
        public static void InventoryEquipView(List<Item> inven)
        {
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 1; i < inven.Count; i++)
            {
                Console.Write("- ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(i + ".");
                Console.ResetColor();
                if (inven[i].equip == true)
                {
                    Console.Write(" [E]\t");
                }
                else
                {
                    Console.Write("\t");
                }
                Console.Write(inven[i].name);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("   \t| ");
                Console.ResetColor();
                if (inven[i].damage != 0)
                {
                    Console.Write("공격력 ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("+" + inven[i].damage);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" | ");
                    Console.ResetColor();
                }
                else if (inven[i].defense != 0)
                {
                    Console.Write("방어력 ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("+" + inven[i].defense);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" | ");
                    Console.ResetColor();
                }
                Console.Write(inven[i].content);
                Console.Write('\n');
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("0");
            Console.ResetColor();
            Console.WriteLine(". 나가기");
            Console.WriteLine();
            Console.WriteLine("장착하고 싶은 장비의 번호를 입력해주세요.");
        }

    }

}

