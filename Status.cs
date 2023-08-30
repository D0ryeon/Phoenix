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

        public STATUS(int attack, int armor, int health)
        {
            this.attack = attack;
            this.armor = armor;
            this.health = health;
        }

    }

    
}
