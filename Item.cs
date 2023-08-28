using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix
{
    public class Item
    {
        public bool equip { get; set; }
        public string name { get; }
        public string content { get; }
        public int damage { get; }
        public int defense { get; }
        public int gold { get; }

        public Item(string name, string content, int damage, int defense, int gold)
        {
            this.name = name;
            this.content = content;
            this.damage = damage;
            this.defense = defense;
            this.gold = gold;
            this.equip = false;
        }
    }
}
