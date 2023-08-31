using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPhoenix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;

    namespace TeamPhoenix
    {
        public class CreateCharacter : SceneBase
        {
            public override void Start()
            {
                Console.Clear();

                Console.WriteLine("<캐릭터 생성창>");
                Console.WriteLine();
            }

            public override SceneBase End()
            {
                Console.WriteLine("생성하실 캐릭터의 이름을 적어주세요.");
                Global.player.name = Console.ReadLine();

                SceneBase nextScene = null;
                RunScene(new ChooseClass());

                return nextScene;
            }

            public override void Update()
            {

            }
        }


        public class ChooseClass : SceneBase
        {
            public override void Start()
            {
                Console.Clear();

                Console.WriteLine("캐릭터의 직업을 선택해 주세요.");
                Console.WriteLine();
            }

            public override SceneBase End()
            {
                Console.WriteLine();
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 궁수");
                Console.WriteLine("3. 마법사");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");

                SceneBase nextScene = null;
                Utility.MethodSelector methodSelector = new Utility.MethodSelector();
                methodSelector.dictionary.Add(0, (_) => nextScene = null);
                methodSelector.dictionary.Add(1, (_) => { nextScene = this; ChooseClass1("1"); RunScene(new CreatePlayerComplete()); });
                methodSelector.dictionary.Add(2, (_) => { nextScene = this; ChooseClass1("2"); RunScene(new CreatePlayerComplete()); });
                methodSelector.dictionary.Add(3, (_) => { nextScene = this; ChooseClass1("3"); RunScene(new CreatePlayerComplete()); });
                methodSelector.Select(">>");

                return nextScene;
            }

            public override void Update()
            {

            }

            static void ChooseClass1(string number)
            {

                switch (number)
                {
                    case "1":
                        Global.player.job = EJob.Warrior;
                        Global.player.status.health = 100;
                        Global.player.status.attack = 10;
                        Global.player.status.armor = 10;
                        break;
                    case "2":
                        Global.player.job = EJob.Archor;
                        Global.player.status.health = 70;
                        Global.player.status.attack = 13;
                        Global.player.status.armor = 7;
                        break;
                    case "3":
                        Global.player.job = EJob.Mage;
                        Global.player.status.health = 50;
                        Global.player.status.attack = 15;
                        Global.player.status.armor = 5;
                        break;
                }

            }
        }

        public class CreatePlayerComplete : SceneBase
        {
            public override void Start()
            {
                Console.Clear();

                Console.WriteLine("<캐릭터 생성완료>");
                Console.WriteLine();

                Console.WriteLine($"Lv.{Global.player.level}");
                Console.WriteLine($"{Global.player.name} ({Global.player.job.ToString()})");
                Console.WriteLine($"공격력 : {Global.player.status.attack}");
                Console.WriteLine($"방어력 : {Global.player.status.armor}");
                Console.WriteLine($"체 력 : {Global.player.status.health}");
                Console.WriteLine($"Gold : {Global.player.gold}");
                Console.WriteLine();
            }

            public override SceneBase End()
            {
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");

                SceneBase nextScene = null;
                Utility.MethodSelector methodSelector = new Utility.MethodSelector();
                methodSelector.dictionary.Add(0, (_) => { nextScene = this; RunScene(new IntroScene()); });
                methodSelector.Select(">>");

                return nextScene;

            }

            public override void Update()
            {

            }

        }
    }
}
