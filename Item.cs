﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPhoenix
{
    public enum EItemClassify
    {
        ETC,
        Equip,
        Consume
    }

    public class Item
    {

        public int identifier;
        public EItemClassify classify;
        public string name;
        public string manual;
        public int gold;

        public Item(int identifier, EItemClassify classify, string name, string manual, int gold)
        {
            this.identifier = identifier;
            this.classify = classify;
            this.name = name;
            this.manual = manual;
            this.gold = gold;
        }

    }

    public class EquipItem : Item
    {

        public STATUS status;

        public EquipItem(int identifier, string name, string manual, STATUS status,int gold) : base(identifier, EItemClassify.Equip, name, manual,gold)
        {
            this.status = status;
        }

    }

    public struct ITEM
    {

        public int identifier;

        public ITEM(int _identifier)
        {
            identifier = _identifier;
        }

    }

}
