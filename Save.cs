using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPhoenix
{

    public interface ISaveLoadable
    {

        void Save(JObject? json);
        void Load(JObject? json);

    }

    public class Save
    {
        public void CreateSave()
        {
            string path = "Save.json";

            if (!File.Exists(path))
            {
                using (File.Create(path))
                {
                    Console.WriteLine("파일생성");

                }
                InputJson(path);
            }
            else
            {
                using (File.Create(path))
                {
                    Console.WriteLine("파일생성");

                }
                InputJson(path);
            }
        }

        public void LoadSave()
        {

            string jsonFilePath = @"Save.json";
            string str = string.Empty;
            string users = string.Empty;


            //// Json 파일 읽기
            using (StreamReader file = File.OpenText(jsonFilePath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {

                JObject json = (JObject)JToken.ReadFrom(reader);

                Global.player.Load(json);

                Console.WriteLine("불러오기 완료");

            }

        }


        public void InputJson(string path)
        {

            JObject dbSpec = new JObject();
            Global.player.Save(dbSpec);

            Console.WriteLine();
            File.WriteAllText(path, dbSpec.ToString());

            Console.WriteLine("저장완료");

        }
    }


    public class SaveScene : SceneBase
    {
        Save save = new Save();
        public override void Start()
        {

            STATUS status = new STATUS();
            foreach (var inventoryItem in Global.player.inventory.itemDictionary)
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

            Console.WriteLine($"Lv.{Global.player.level.level}");
            Console.WriteLine($"{Global.player.name} ({Global.player.job.ToString()})");
            Console.WriteLine($"공격력 : {Global.player.status.attack}" + (status.attack > 0 ? $" (+{status.attack})" : (status.attack < 0 ? $" ({status.attack})" : "")));
            Console.WriteLine($"방어력 : {Global.player.status.armor}" + (status.armor > 0 ? $" (+{status.armor})" : (status.armor < 0 ? $" ({status.armor})" : "")));
            Console.WriteLine($"체 력 : {Global.player.status.health}" + (status.health > 0 ? $" (+{status.health})" : (status.health < 0 ? $" ({status.health})" : "")));
            Console.WriteLine($"Gold : {Global.player.gold}");
            Console.WriteLine();

        }

        public override SceneBase End()
        {

            Console.WriteLine("1. 저장하기");
            Console.WriteLine("2. 불러오기");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            SceneBase nextScene = null;
            Utility.MethodSelector methodSelector = new Utility.MethodSelector();
            methodSelector.dictionary.Add(0, (_) => nextScene = null);
            methodSelector.dictionary.Add(1, (_) => { nextScene = this; save.CreateSave(); });
            methodSelector.dictionary.Add(2, (_) => { nextScene = this; save.LoadSave(); });
            methodSelector.Select(">>");

            return nextScene;

        }

        public override void Update()
        {
        }

    }

}
