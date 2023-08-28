using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix
{
    public class Shop
    {
        public List<Item> shop { get; set; }

        public Shop()
        {
            shop = new List<Item>();
            addShop(new Item("고글", "햄이네의 잃어버렸던 고글, 사실 침대옆에 짱박혀있었다.", 0, 3, 100));
            addShop(new Item("비둘기", "지나가던 비둘기, 진짜 그냥 비둘기이다.", 0, 0, 9));
            addShop(new Item("돌잔치모자", "돌잔치에 썻던 모자", 0, 4, 400));
            addShop(new Item("아잉눈", "햄이네가 끼면 필살기", 6, 0, 1000));
            addShop(new Item("홍삼스틱", "이걸 보자 햄이네가 도망쳤다", 9, 0, 2400));
            addShop(new Item("도끼", "아이네가 쓰던 도끼", 99, 0, 99999));
        }

        public void addShop(Item item)
        {
            shop.Add(item);
        }

        public Item Buy(Item item, Player player)
        {
            if (player.gold >= item.gold)
            {

                player.gold = player.gold - item.gold;
                return item;
            }
            else
            {
                return null;
            }
        }

        public int Sell(Item item)
        {
            return item.gold;
        }
    }
}
