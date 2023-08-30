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
            GameSystem gameSystem = new GameSystem();
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
                Console.WriteLine("이  름 : " + Global.playerName);
                Console.WriteLine("공격력 : " + Global.playerStatus.attack);
                Console.WriteLine("체  력 : " + Global.playerStatus.health);
                Console.WriteLine(" ");
                //string message = "공격할 대상을 선택하시오";
                //int select = Utility.SelectInt(0, monsters.Count, message);
                Console.WriteLine("공격할 대상을 선택하시오 : ");
                int select = int.Parse(Console.ReadLine());
                for(int j = 0; j < monsters.Count; j++)
                {
                    if (j == (select - 1))
                    {
                        Console.WriteLine(Global.playerName + "의 공격!");
                        Console.WriteLine(monsters[j].Name + "을(를) 공격합니다.");
                        int chance = gameSystem.Chance();
                        monsters[j].HP = gameSystem.monsterHit(chance, monsters[j], Global.playerStatus.attack);
                        Thread.Sleep(1000);
                    }
                }
                select = default;
                // 적의 턴 시작!
                Console.WriteLine("Enemy Phase!");
                for(int k = 0; k < monsters.Count; k++)
                {
                    Console.WriteLine($"{monsters[k].Name}이 공격합니다!");
                    int chance = gameSystem.Chance();
                    bool isdead = gameSystem.isDead(monsters[k].HP);
                    if (isdead) { continue; }
                    Global.playerStatus.health = gameSystem.playerHit(chance, Global.playerStatus.health, monsters[k].Atk);
                    Thread.Sleep(1000);

                }
                // 게임오버 유무 판단!
                int totalHP = 0;
                for(int l = 0; l < monsters.Count; l++)
                {
                    totalHP += monsters[l].HP;
                }
                if(totalHP <= 0)
                {
                    Console.WriteLine("Victory");
                    Console.WriteLine($"던전에서 몬스터 {monsters.Count}마리를 잡았습니다.");
                    Console.WriteLine(Global.playerName);
                    Console.WriteLine(Global.playerStatus.health);
                    break;
                }else if(Global.playerStatus.health <= 0)
                {
                    Console.WriteLine("You Died");
                    Console.WriteLine(Global.playerName);
                    Console.WriteLine(Global.playerStatus.health);
                    break;
                }
                Console.Clear();

            }
            // GetHit(10, Global.playerStatus.health, Global.playerStatus.attack);
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
            if(chance > 12 || chance < 8)
            {
                Console.WriteLine("공격이 적중했습니다.");
                monster.HP -= Attack;
            }else if (chance == 8 || chance == 11 || chance == 12)
            {
                Console.WriteLine("공격이 치명타로 적중했습니다.");

                monster.HP = monster.HP - (Attack + (int)CriticalHit);
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
            if (chance > 12 || chance < 8)
            {
                Console.WriteLine("공격이 적중했습니다.");
                health -= Attack;
            }
            else if (chance == 8 || chance == 11 || chance == 12)
            {
                Console.WriteLine("공격이 치명타로 적중했습니다.");

                health = health - (Attack + (int)CriticalHit);
            }
            else // 9, 10일 경우 빗나감!
            {
                Console.WriteLine("빗나감!");
            }
            return health;
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
