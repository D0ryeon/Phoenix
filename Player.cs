using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix
{
    public class Player
    {
        public string name { get; }
        public string chad { get; }
        public int level { get; }
        public int exp { get; }
        public int damage { get; }
        public int defense { get; }
        public int HP { get; }
        public int gold { get; set; }

        public Player(string name, string chad)
        {
            this.name = name;
            this.chad = chad;
            this.level = 1;
            this.exp = 0;
            this.damage = 10;
            this.defense = 5;
            this.HP = 100;
            this.gold = 0;
        }

    }
}
