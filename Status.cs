using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPhoenix
{

    public enum EJob
    {
        None,Warrior,Archor,Mage
    }

    public struct STATUS
    {

        public int attack;
        public int armor;
        public int health;
        public int mana;

        public STATUS(int attack, int armor, int health, int mana)
        {
            this.attack = attack;
            this.armor  = armor;
            this.health = health;
            this.mana = mana;
        }

    }

    public struct MONSTER_STATUS
    {

        public int      identifier;
        public string   name;
        public int      level;
        public STATUS   status;

        public MONSTER_STATUS(int identifier, string name, int level, STATUS status)
        {
            this.identifier = identifier;
            this.name       = name;
            this.level      = level;
            this.status     = status;
        }

    }

    
}
