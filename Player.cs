using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPhoenix
{


    public class Player : ISaveLoadable
    {

        //ISaveLoadable implement

        public void Save(JObject? json)
        {

            var status = new[] { playerStatus.attack, playerStatus.armor, playerStatus.health };

            int[]   identifier      = new int[Global.playerInventory.itemDictionary.Count];
            int[]   num             = new int[Global.playerInventory.itemDictionary.Count];
            int     count           = 0;
            foreach (KeyValuePair<int, InventoryItem> item in Global.playerInventory.itemDictionary)
            {
                identifier[item.Key] = item.Value.item.identifier;
                num[item.Key] = item.Value.number;
                count++;
            }

            json?.Add("EJOB", playerJob.ToString());
            json?.Add("GOLD", playerGold);
            json?.Add("NAME", playerName);
            json?.Add("STATUS", JArray.FromObject(status));
            json?.Add("COUNT", count);
            json?.Add("IDEN", JArray.FromObject(identifier));
            json?.Add("NUM", JArray.FromObject(num));

            playerLevel.Save(json);

        }

        public void Load(JObject? json)
        {

            playerStatus.attack = int.Parse(json["STATUS"][0].ToString());
            playerStatus.armor  = int.Parse(json["STATUS"][1].ToString());
            playerStatus.health = int.Parse(json["STATUS"][2].ToString());
            playerJob           = (EJob)Enum.Parse(typeof(EJob), json["EJOB"].ToString());
            playerGold          = int.Parse(json["GOLD"].ToString());
            playerName          = json["NAME"].ToString();
            //Global.playerLevel.level = int.Parse(json["LEVEL"].ToString());
            int v = int.Parse(json["COUNT"].ToString());
            playerInventory = new Inventory();
            for (int i = 0; i < v; i++)
            {
                playerInventory.itemDictionary.Add(i, new InventoryItem(new ITEM(int.Parse(json["IDEN"][i].ToString())), int.Parse(json["NUM"][i].ToString())));
            }

            playerLevel.Load(json);

        }

        public static STATUS            playerStatus = new STATUS();
        public static EJob              playerJob = EJob.Warrior;
        public static int               playerGold = 1000;
        public static string            playerName = "Kim";
        public static Inventory         playerInventory = new Inventory();
        public static LevelSystem       playerLevel = new LevelSystem();

    }

}
