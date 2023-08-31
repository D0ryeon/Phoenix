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
                Global.playerName = Console.ReadLine();

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
                        Global.playerJob = EJob.Warrior;
                        Global.playerStatus.health = 100;
                        Global.playerStatus.attack = 10;
                        Global.playerStatus.armor = 10;
                        break;
                    case "2":
                        Global.playerJob = EJob.Archor;
                        Global.playerStatus.health = 70;
                        Global.playerStatus.attack = 13;
                        Global.playerStatus.armor = 7;
                        break;
                    case "3":
                        Global.playerJob = EJob.Mage;
                        Global.playerStatus.health = 50;
                        Global.playerStatus.attack = 15;
                        Global.playerStatus.armor = 5;
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

                Console.WriteLine($"Lv.{Global.playerLevel}");
                Console.WriteLine($"{Global.playerName} ({Global.playerJob.ToString()})");
                Console.WriteLine($"공격력 : {Global.playerStatus.attack}");
                Console.WriteLine($"방어력 : {Global.playerStatus.armor}");
                Console.WriteLine($"체 력 : {Global.playerStatus.health}");
                Console.WriteLine($"Gold : {Global.playerGold}");
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
