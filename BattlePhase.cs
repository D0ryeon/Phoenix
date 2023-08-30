using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPhoenix
{
    public class BattlePhase : GameSystem
    {
        public void StartBattle()
        {
            Monster Minion = new Monster("Lv2 미니언", 15, 5);
            Monster Voidworm = new Monster("Lv3 공허충", 10, 9);
            Monster Cannonminion = new Monster("Lv5 대포미니언", 25, 8);
            // 플레이어의 턴으로 시작!
            List<Monster> monsters = Monster.MonsterSpawner(Minion, Voidworm, Cannonminion);
            while (true)
            {
                Console.WriteLine("Battle !");
                for (int i = 0; i < monsters.Count; i++)
                {
                    Console.WriteLine((i+1)+"." + monsters[i].Name +"  "+ monsters[i].Atk +"  "+ monsters[i].HP);

                }
                Console.WriteLine(" ");
                Console.WriteLine("[내 정보]");
                Console.WriteLine(Global.playerName);
                Console.WriteLine(Global.playerStatus.attack);
                Console.WriteLine(Global.playerStatus.health);
                Console.WriteLine(" ");
                Console.WriteLine("공격할 대상을 선택하시오");
                int select = int.Parse(Console.ReadLine());
                for(int j = 0; j < monsters.Count; j++)
                {
                    if (j == (select - 1))
                    {
                        Console.WriteLine(Global.playerName + "의 공격!");
                        Console.WriteLine(monsters[j].Name + "을(를) 맞췄습니다.");
                        int chance = Chance();
                        GetHit(chance, monsters[j].HP,Global.playerStatus.attack);
                    }
                    else
                    {
                        Console.WriteLine(" 잘못된 입력입니다. ");
                    }
                }
                select = default;
                // 적의 턴 시작!
                Console.WriteLine("Enemy Phase!");
                for(int k = 0; k < monsters.Count; k++)
                {
                    int chance = Chance();
                    GetHit(chance, Global.playerStatus.health, monsters[k].Atk);
                    Console.WriteLine(Global.playerName);
                    Console.WriteLine(Global.playerStatus.health);
                }
                // 게임오버 유무 판단!
                int totalHP = 0;
                for(int l = 0; l < monsters.Count; l++)
                {
                    totalHP += monsters[l].HP;
                }
                if(totalHP == 0)
                {
                    Console.WriteLine("Victory");
                    break;
                }else if(Global.playerStatus.health == 0)
                {
                    Console.WriteLine("You Died");
                    break;
                }
                Console.Clear();

            }
            // GetHit(10, Global.playerStatus.health, Global.playerStatus.attack);
        }
    }

    public class GameSystem
    {
        Random rand = new Random();
        public int Chance()
        {
            // 주사위 굴려서 나온 숫자 리턴
            int chance = rand.Next(1,21);
            return chance;
        }
        public void GetHit(int chance, int HP, int Atk) 
        {
            // 주사위 눈의 수를 기반으로 맞았는 지 아닌 지 판별
            // 몬스터 체력이 깍이는 거는 플레이어 공격력*0.9, *1.1사이의 랜덤값
            // 플레이어 체력도 동일한 방식으로 감소
            double AtkError = Math.Ceiling(Atk * 0.1);
            int min = Atk - (int)AtkError;
            int max = Atk + (int)AtkError;
            int Attack = rand.Next(min, max);
            if(chance > 10)
            {
                HP -= Attack;
            }else if(chance < 10)
            {
                Console.WriteLine("빗나감!");
            }
        }

        public bool isDead(int HP)
        {
            bool isdead = false;
            if(HP <= 0)
            {
                isdead = true;
            }
            else
            {
                isdead = false;
            }
            return isdead;
        }
    }

    public class Monster
    {
        
        public string Name { get; }
        public int HP { get; set; }
        public int Atk { get; set; }

        public Monster(string _name, int _hp, int _atk) 
        {
            Name = _name;
            HP = _hp;
            Atk = _atk;
        }
        

        static public List<Monster> MonsterSpawner(Monster monster1, Monster monster2, Monster monster3)
        {
            Random random = new Random();
            List<Monster> monsters = new List<Monster>();

            //Monster Minion = new Monster("Lv2 미니언", 15, 5);
            //Monster Voidworm = new Monster("Lv3 공허충", 10, 9);
            //Monster Cannonminion = new Monster("Lv5 대포미니언", 25, 8);

            int MonsterCount = random.Next(1, 5);
            for(int i = 0; i < MonsterCount; i++)
            {
                int RandomMonster=random.Next(1, 4);
                if(RandomMonster == 1)
                {
                    monsters.Add(monster1);
                }else if(RandomMonster == 2)
                {
                    monsters.Add(monster2);
                }else if(RandomMonster == 3)
                {
                    monsters.Add(monster2);
                }
            }
            return monsters;
        }

    }
}
