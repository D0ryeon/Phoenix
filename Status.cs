using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix
{
    static internal class Status
    {
        

        // 상태창 뷰
        public static void StatusView(List<Item> inven,Player p)
        {
            int[] equip = EquipStatus(inven);
            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine("Lv. " + p.level);
            Console.WriteLine("Chad ( " + p.chad + " )");
            // 장비가 적용된 공격력 방어력 
            Console.Write("공격력 : " + p.damage);
            if (!(equip == null))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" ( + " + equip[0] + " )");
                Console.ResetColor();
            }
            Console.Write('\n');
            Console.Write("방어력 : " + p.defense);
            if (!(equip == null))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" ( + " + equip[1] + " )");
                Console.ResetColor();
            }
            Console.Write('\n');

            Console.WriteLine("체 력 : " + p.HP);
            Console.WriteLine("소지금 : " + p.gold + " G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
        }

        public static int[] EquipStatus(List<Item> inven)
        {
            // equip[0] : 착용 장비 총 공격력
            // equip[1] : 착용 장비 총 방어력
            int[] equip = { 0, 0 };
            int sum = 0;
            for (int i = 0; i < inven.Count; i++)
            {
                if (inven[i].equip == true)
                {
                    if (inven[i].damage != 0)
                    {
                        equip[0] += inven[i].damage;
                        sum++;
                    }
                    else if (inven[i].defense != 0)
                    {
                        equip[1] += inven[i].defense;
                        sum++;
                    }
                }
            }
            if (sum == 0)
            {
                return null;
            }
            return equip;
        }
    }
}
