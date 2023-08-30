using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPhoenix
{
    public class Save
    {
        public void CreateSave()
        {
            string path = @"C:\temp\Save.json";

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
            string jsonFilePath = @"C:\temp\Save.json";
            string str = string.Empty;
            string users = string.Empty;


            //// Json 파일 읽기
            using (StreamReader file = File.OpenText(jsonFilePath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {

                JObject json = (JObject)JToken.ReadFrom(reader);

                Global.playerStatus.attack = int.Parse(json["STATUS"][0].ToString());
                Global.playerStatus.armor = int.Parse(json["STATUS"][1].ToString());
                Global.playerStatus.health = int.Parse(json["STATUS"][2].ToString());
                Global.playerJob = (EJob)Enum.Parse(typeof(EJob), json["EJOB"].ToString());
                Global.playerGold = int.Parse(json["GOLD"].ToString());
                Global.playerName = (string)json["NAME"].ToString();
                Global.playerLevel = int.Parse(json["LEVEL"].ToString());
                int v = int.Parse(json["COUNT"].ToString());
                Global.playerInventory = new Inventory();
                for (int i = 0; i < v; i++)
                {
                    Global.playerInventory.itemDictionary.Add(i, new InventoryItem(new ITEM(int.Parse(json["IDEN"][i].ToString())), int.Parse(json["NUM"][i].ToString())));
                }

                Console.WriteLine("불러오기 완료");

            }
        }


        public void InputJson(string path)
        {
            //사용자 정보 배열로 선언
            var status = new[] { Global.playerStatus.attack, Global.playerStatus.armor, Global.playerStatus.health };
            //var item = Global.itemList[inventoryItem.item.identifier];


            int[] identifier = new int[Global.playerInventory.itemDictionary.Count];
            int[] num = new int[Global.playerInventory.itemDictionary.Count];
            int count = 0;
            foreach (KeyValuePair<int, InventoryItem> item in Global.playerInventory.itemDictionary)
            {
                identifier[item.Key] = item.Value.item.identifier;
                num[item.Key] = item.Value.number;
                count++;
            }
            JObject dbSpec = new JObject(
                new JProperty("EJOB", Global.playerJob.ToString()),
                new JProperty("GOLD", Global.playerGold),
                new JProperty("NAME", Global.playerName),
                new JProperty("LEVEL", Global.playerLevel),
                new JProperty("COUNT", count)
                );

            //Jarray 로 추가
            dbSpec.Add("STATUS", JArray.FromObject(status));


            dbSpec.Add("IDEN", JArray.FromObject(identifier));
            dbSpec.Add("NUM", JArray.FromObject(num));


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
