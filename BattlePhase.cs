using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPhoenix
{
    public class BattleScene : SceneBase
    {
        public override void Start()
        {
            Console.Clear();
            Random rand = new Random();
            GameSystem gameSystem = new GameSystem();
            // 플레이어의 턴으로 시작!
            List<Monster> monsters = Monster.MonsterSpawner();
            Global.player.status.health = 100;
            while (true)
            {
                Console.WriteLine("Battle !");
                for (int i = 0; i < monsters.Count; i++)
                {
                    if (monsters[i].HP > 0)
                    {
                        Console.WriteLine((i + 1) + "." + monsters[i].Name + "  " + monsters[i].Atk + "  " + monsters[i].HP);

                    }else if (monsters[i].HP <= 0)
                    {
                        Console.WriteLine((i + 1) + "." + monsters[i].Name + "  " + monsters[i].Atk + "  " + "Dead");

                    }

                }
                Console.WriteLine(" ");
                Console.WriteLine("[내 정보]");
                Console.WriteLine("이  름 : " + Global.player.name);
                Console.WriteLine("공격력 : " + Global.player.status.attack);
                Console.WriteLine("체  력 : " + Global.player.status.health);
                Console.WriteLine("마  나 : " + Global.player.status.mana);
                Console.WriteLine(" ");
                Console.WriteLine("행동을 선택하시오 ");
                Console.WriteLine(" 1. 일반 공격");
                Console.WriteLine(" 2. 스킬 사용");
                int select = int.Parse(Console.ReadLine());
                if (select == 1)
                {
                    Console.WriteLine("공격할 대상을 선택하시오 : ");
                    int select2 = int.Parse(Console.ReadLine());
                    for (int j = 0; j < monsters.Count; j++)
                    {
                        if (j == (select2-1))
                        {
                            Console.WriteLine(Global.player.name + "의 공격!");
                            Console.WriteLine(monsters[j].Name + "을(를) 공격합니다.");
                            int chance = gameSystem.Chance();
                            monsters[j].HP = gameSystem.monsterHit(chance, monsters[j], Global.player.status.attack);
                            Thread.Sleep(1000);
                        }
                    }
                }else if (select == 2)
                {
                    if(Global.player.status.mana < 10)
                    {
                        Console.WriteLine("마나가 부족해 스킬 사용에 실패했습니다. ");
                        Thread.Sleep(1000);
                        Console.Clear();
                        continue;
                    }
                    gameSystem.Skill(monsters);
                    Thread.Sleep(1000);
                }
                else if(select <= 0 || select > 2)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    continue;
                }
                Thread.Sleep(1000);
                Console.Clear();
                select = default;
                // 적의 턴 시작!
                Console.WriteLine("Enemy Phase!");
                for(int k = 0; k < monsters.Count; k++)
                {
                    Console.WriteLine($"{monsters[k].Name}의 턴!");
                    int chance = gameSystem.Chance();
                    bool isdead = gameSystem.isDead(monsters[k].HP);
                    if (isdead) 
                    {
                        Console.WriteLine("싸늘하다. 이미 시체인듯하다.");
                        Thread.Sleep(1000);
                        continue; 
                    }
                    Console.WriteLine($"{monsters[k].Name}이 공격합니다!");
                    Global.player.status.health = gameSystem.playerHit(chance, Global.player.status.health, monsters[k].Atk);
                    Console.WriteLine(" ");
                    Thread.Sleep(1000);

                }
                // 게임오버 유무 판단!
                int totalHP = 0;
                for(int l = 0; l < monsters.Count; l++)
                {
                    if (monsters[l].HP < 0)
                    {
                        monsters[l].HP = 0;
                    }
                    totalHP += monsters[l].HP;
                }
                if(totalHP <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Victory");
                    Console.WriteLine($"던전에서 몬스터 {monsters.Count}마리를 잡았습니다.");
                    Console.WriteLine(Global.player.name);
                    Console.WriteLine(Global.player.status.health);
                    break;
                }else if(Global.player.status.health <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("You Died");
                    Console.WriteLine(Global.player.name);
                    Console.WriteLine(Global.player.status.health);
                    break;
                }
                Console.Clear();

            }
        }
        public override SceneBase End()
        {

            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            Utility.SelectInt(0, 0, ">>");

            return null;

        }

        public override void Update()
        {
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
        public int monsterHit(int chance, Monster monster, int Atk) 
        {
            double AtkError = Math.Ceiling(Atk * 0.1);
            int min = Atk - (int)AtkError;
            int max = Atk + (int)AtkError;
            double CriticalHit = Atk * 0.6;
            int Attack = rand.Next(min, max);
            int Critical = Attack + (int)CriticalHit;
            if(chance > 12 || chance < 8)
            {
                Console.WriteLine($"공격이 적중했습니다. [데미지 : {Attack}]");
                monster.HP -= Attack;
            }else if (chance == 8 || chance == 11 || chance == 12)
            {
                Console.WriteLine($"공격이 치명타로 적중했습니다.[데미지 : {Critical}]");

                monster.HP = monster.HP - Critical;
            }
            else // 9, 10일 경우 빗나감!
            {
                Console.WriteLine("빗나감!");
            }
            return monster.HP;
        }
        public int playerHit(int chance, int health, int Atk)
        {
            double AtkError = Math.Ceiling(Atk * 0.1);
            int min = Atk - (int)AtkError;
            int max = Atk + (int)AtkError;
            double CriticalHit = Atk * 0.6;
            int Attack = rand.Next(min, max);
            int Critical = Attack + (int)CriticalHit;
            if (chance > 12 || chance < 8)
            {
                Console.WriteLine($"공격이 적중했습니다. [데미지 : {Attack}]");
                health -= Attack;
            }
            else if (chance == 8 || chance == 11 || chance == 12)
            {
                Console.WriteLine($"공격이 치명타로 적중했습니다.[데미지 : {Critical}]");

                health = health - Critical;
            }
            else // 9, 10일 경우 빗나감!
            {
                Console.WriteLine("빗나감!");
            }
            return health;
        }

        public void Skill(List<Monster> monsters)
        {
            Console.WriteLine(" ");
            Console.WriteLine("1. 알파 스트라이크 - MP10");
            Console.WriteLine("공격력 * 2 로 하나의 적을 공격합니다.");
            Console.WriteLine("2. 더블 스트라이크 - MP15");
            Console.WriteLine("공격력 * 1.5 로 두 명의 랜덤한 적을 공격합니다.");
            Console.WriteLine(" ");
            Console.WriteLine("사용할 스킬을 선택하시오 ");
            int select = int.Parse(Console.ReadLine());
            if (select == 1)
            {
                AlphaStrike(monsters);
                Global.player.status.mana -= 10;
            }else if(select == 2)
            {
                DoubleStrike(monsters);
                Global.player.status.mana -= 15;
            }
        }

        public void AlphaStrike(List<Monster> monsters)
        {
            Console.WriteLine("공격할 대상을 선택하시오");
            int select = int.Parse(Console.ReadLine())-1;
            int Atk = Global.player.status.attack * 2;
            Console.WriteLine("알파 스트라이크!");
            monsters[select].HP -= Atk;
        }

        public void DoubleStrike(List<Monster> monsters)
        {
            Console.WriteLine("랜덤한 대상을 공격합니다.");
            int select1 = rand.Next(0, monsters.Count);
            int select2 = rand.Next(0, monsters.Count);
            double Atk = Global.player.status.attack * 1.5;
            Console.WriteLine("더블 스트라이크!");
            monsters[select1].HP -= (int)Atk;
            monsters[select2].HP -= (int)Atk;
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
        

        static public List<Monster> MonsterSpawner()
        {
            Random random = new Random();
            List<Monster> monsters = new List<Monster>();

            int MonsterCount = random.Next(1, 5);
            for(int i = 0; i < MonsterCount; i++)
            {
                int RandomMonster=random.Next(1, 4);
                if(RandomMonster == 1)
                {
                    Monster Minion = new Monster("Lv2 미니언", 15, 5);
                    monsters.Add(Minion);
                }else if(RandomMonster == 2)
                {
                    Monster Voidworm = new Monster("Lv3 공허충", 10, 9);
                    monsters.Add(Voidworm);
                }else if(RandomMonster == 3)
                {
                    Monster Cannonminion = new Monster("Lv5 대포미니언", 25, 8);
                    monsters.Add(Cannonminion);
                }
            }
            return monsters;
        }

    }
}
