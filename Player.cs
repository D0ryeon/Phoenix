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

            var statusDataArray = new[] { status.attack, status.armor, status.health };

            int[]   identifier      = new int[inventory.itemDictionary.Count];
            int[]   num             = new int[inventory.itemDictionary.Count];
            int     count           = 0;
            foreach (KeyValuePair<int, InventoryItem> item in inventory.itemDictionary)
            {
                identifier[item.Key] = item.Value.item.identifier;
                num[item.Key] = item.Value.number;
                count++;
            }

            json?.Add("EJOB", job.ToString());
            json?.Add("GOLD", gold);
            json?.Add("NAME", name);
            json?.Add("STATUS", JArray.FromObject(statusDataArray));
            json?.Add("COUNT", count);
            json?.Add("IDEN", JArray.FromObject(identifier));
            json?.Add("NUM", JArray.FromObject(num));

            level.Save(json);

        }

        public void Load(JObject? json)
        {

            status.attack = int.Parse(json["STATUS"][0].ToString());
            status.armor  = int.Parse(json["STATUS"][1].ToString());
            status.health = int.Parse(json["STATUS"][2].ToString());
            job           = (EJob)Enum.Parse(typeof(EJob), json["EJOB"].ToString());
            gold          = int.Parse(json["GOLD"].ToString());
            name          = json["NAME"].ToString();
            //Global.playerLevel.level = int.Parse(json["LEVEL"].ToString());
            int v = int.Parse(json["COUNT"].ToString());
            inventory = new Inventory();
            for (int i = 0; i < v; i++)
            {
                inventory.itemDictionary.Add(i, new InventoryItem(new ITEM(int.Parse(json["IDEN"][i].ToString())), int.Parse(json["NUM"][i].ToString())));
            }

            level.Load(json);

        }

        public STATUS            status     = new STATUS();
        public EJob              job        = EJob.Warrior;
        public int               gold       = 1000;
        public string            name       = "Kim";
        public Inventory         inventory  = new Inventory();
        public LevelSystem       level      = new LevelSystem();

    }

}
