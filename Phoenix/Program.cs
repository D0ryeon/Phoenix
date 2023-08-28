using System.Diagnostics.CodeAnalysis;
using System.Net.Security;
using System.Reflection.Metadata.Ecma335;

namespace Phoenix
{


    internal class Program
    {
        static void Main(string[] args)
        {

            Player player = new Player("햄이네", "전사");
            Inventory inv = new Inventory();
            List<Item> inventory = inv.items;
            View.StartView();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("햄이네 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                string inputNum = Console.ReadLine();

                switch (inputNum)
                {
                    case "1":
                    status:
                        Console.Clear();

                        Status.StatusView(inventory,player);

                        string inputStatus = Console.ReadLine();

                        switch (inputStatus)
                        {
                            case "0":
                                break;
                            default:
                                Console.WriteLine("올바른 번호를 적어주세요.");
                                goto status;
                        }

                        break;
                    case "2":
                    invenMenu:
                        Console.Clear();

                        InvenView.InventoryView(inventory);

                        string inputInventory = Console.ReadLine();
                        switch (inputInventory)
                        {
                            case "0":
                                break;
                            case "1":
                            iquipMenu:
                                Console.Clear();
                                InvenView.InventoryEquipView(inventory);

                                string inputIquip = Console.ReadLine();
                                int num = 0;
                                bool isNum = int.TryParse(inputIquip, out num);
                                if (num < inventory.Count)
                                {
                                    if (inventory[num].equip == false)
                                    {
                                        inventory[num].equip = true;
                                    }
                                    else
                                    {
                                        inventory[num].equip = false;
                                    }
                                }
                                if (inputIquip == "0")
                                {
                                    goto invenMenu;
                                }
                                else if (num >= inventory.Count || isNum == false)
                                {
                                    Console.WriteLine("올바른 번호를 적어주세요.");
                                    Console.ReadLine();
                                    goto iquipMenu;
                                }
                                goto iquipMenu;
                            default:
                                Console.WriteLine("올바른 번호를 적어주세요.");
                                Console.ReadLine();
                                goto invenMenu;
                        }
                        break;
                    default:
                        Console.WriteLine("올바른 번호를 적어주세요.");
                        Console.ReadLine();
                        continue;
                }
            }

     
            


            


            
        }
    }
}
