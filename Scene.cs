using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamPhoenix.TeamPhoenix;

namespace TeamPhoenix
{
    public abstract class SceneBase
    {

        public abstract void Start();

        public abstract SceneBase End();

        public abstract void Update();

        public SceneBase Run()
        {

            Start();

            Update();

            return End();

        }

        static public void RunScene(SceneBase scene)
        {

            do
            {
                scene = scene.Run();
            } while (scene != null);

        }


    }

    public class IntroScene : SceneBase
    {

        public override void Start()
        {

            Console.Clear();

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();

        }

        public override SceneBase End()
        {

            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 전투");
            Console.WriteLine("4. 테스트용 사용시 Nearby에 몇번 사용한다고 지정해주세요");
            Console.WriteLine("5. 세이브/로드");
            Console.WriteLine("6. 캐릭터 생성");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            Utility.MethodSelector selector = new Utility.MethodSelector();
            selector.dictionary.Add(1, (_) => RunScene(new StatusScene()));
            selector.dictionary.Add(2, (_) => RunScene(new InventoryScene()));
            selector.dictionary.Add(3, (_) => RunScene(new BattleScene()));
            selector.dictionary.Add(4, (_) => RunScene(new ShopScene()));
            selector.dictionary.Add(5, (_) => RunScene(new SaveScene()));
            selector.dictionary.Add(6, (_) => RunScene(new CreateCharacter()));
            selector.Select(">>");

            return this;

        }

        public override void Update()
        {
        }

    }

    public class StatusScene : SceneBase
    {

        public override void Start()
        {

            STATUS status = new STATUS();
            foreach (var inventoryItem in Global.playerInventory.itemDictionary)
            {

                if (inventoryItem.Value.equip)
                {

                    var item = (EquipItem)Global.itemList[inventoryItem.Value.item.identifier];

                    status.attack += item.status.attack;
                    status.armor += item.status.armor;
                    status.health += item.status.health;

                }

            }

            Console.Clear();

            Console.WriteLine($"Lv.{Global.playerLevel}");
            Console.WriteLine($"{Global.playerName} ({Global.playerJob.ToString()})");
            Console.WriteLine($"공격력 : {Global.playerStatus.attack}" + (status.attack > 0 ? $" (+{status.attack})" : (status.attack < 0 ? $" ({status.attack})" : "")));
            Console.WriteLine($"방어력 : {Global.playerStatus.armor}" + (status.armor > 0 ? $" (+{status.armor})" : (status.armor < 0 ? $" ({status.armor})" : "")));
            Console.WriteLine($"체 력 : {Global.playerStatus.health}" + (status.health > 0 ? $" (+{status.health})" : (status.health < 0 ? $" ({status.health})" : "")));
            Console.WriteLine($"Gold : {Global.playerGold}");
            Console.WriteLine();

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

    public class InventoryScene : SceneBase
    {

        public override void Start()
        {

            Console.Clear();

            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < Global.playerInventory.itemDictionary.Count; ++i)
            {
                Utility.PrintInventoryItem(Global.playerInventory.itemDictionary[i]);
            }

        }

        public override SceneBase End()
        {

            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            SceneBase nextScene = null;
            Utility.MethodSelector methodSelector = new Utility.MethodSelector();
            methodSelector.dictionary.Add(0, (_) => nextScene = null);
            methodSelector.dictionary.Add(1, (_) => { nextScene = this; RunScene(new InventoryEquipScene()); });
            methodSelector.Select(">>");

            return nextScene;

        }

        public override void Update()
        {
        }

    }

    public class InventoryEquipScene : SceneBase
    {

        public override void Start()
        {

            equipItemList.Clear();
            foreach (var inventoryItem in Global.playerInventory.itemDictionary)
            {
                if (Global.itemList[inventoryItem.Value.item.identifier].classify == EItemClassify.Equip)
                {
                    equipItemList.Add(inventoryItem.Value);
                }
            }

            Console.Clear();

        }

        public override SceneBase End()
        {

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            var select = Utility.SelectInt(0, equipItemList.Count, ">>");
            if (select == 0)
            {
                nextScene = null;
            }
            else
            {
                equipItemList[select - 1].equip = !equipItemList[select - 1].equip;
                nextScene = this;
            }

            return nextScene;

        }

        public override void Update()
        {

            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < equipItemList.Count; ++i)
            {
                Console.Write($"- {i + 1}. ");
                if (equipItemList[i].equip)
                {
                    Console.Write("[E]");
                }
                Utility.PrintInventoryItem(equipItemList[i]);
            }

        }

        List<InventoryItem> equipItemList = new List<InventoryItem>();

        private SceneBase nextScene = null;

    }

    public struct GAME_START_CONFIGURATION
    {

        public SceneBase startScene;

    }


    public class Game
    {

        public GAME_START_CONFIGURATION gameStartConfiguration
        {
            set
            {
                m_scene = value.startScene;
            }
        }

        public void Run()
        {
            SceneBase.RunScene(m_scene);
        }

        private SceneBase m_scene;

    }

}
