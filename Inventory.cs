using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPhoenix
{


    public class Inventory
    {
        public Dictionary<int, InventoryItem> itemDictionary = new Dictionary<int, InventoryItem>();
    }

    public class InventoryItem
    {

        public ITEM item;
        public int number;
        public int inventoryIndex;
        public bool equip;

        public InventoryItem(ITEM item, int number)
        {
            this.item = item;
            this.number = number;
            this.inventoryIndex = 0;
        }

    }
}
