using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using GildedRoseKata;

namespace GildedRose
{
    public class GildedRose
    {
        readonly IList<Item> _items;
        public GildedRose(IList<Item> items)
        {
            this._items = items;
        }


        public void UpdateQualityOfItems()
        {
            foreach (var item in _items)
            {
                var qualityMultiplier = (item.SellIn > 0) ? 1 : 2;
                IsSulfurasItem(item);
                if (item.Quality is < 50 and > 0 )
                {
                    if (IsConjured(item)) item.Name = "Conjured";
                    switch (item.Name)
                    {
                        case "Aged Brie":
                            item.Quality += qualityMultiplier;
                            break;
                        case "Backstage passes to a TAFKAL80ETC concert":
                            item.Quality = Math.Min(BackstageQualityMethod(item, qualityMultiplier), 50);
                            break;
                        case "Sulfuras, Hand of Ragnaros":
                            item.Quality = 80;
                            item.SellIn = 0;
                            break;
                        case "Conjured":
                            item.Quality -= (qualityMultiplier * 2);
                            break;
                        default:
                            item.Quality -= qualityMultiplier;
                            break;
                    }
                }
                item.SellIn -= 1;
            }
        }

        private static bool IsConjured(Item item)
        {
            var currentItemName = item.Name.Split(" ");
            return currentItemName[0] == "Conjured";
        }

        private static void IsSulfurasItem(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros") return;
            item.Quality = 80;
            item.SellIn = 0;
        }

        private static int BackstageQualityMethod(Item item, int qualityMultiplier)
        {
            if (item.SellIn < 11) item.Quality += (qualityMultiplier * 2);

            if (item.SellIn < 6) item.Quality += (qualityMultiplier * 3);

            if (item.SellIn == 0) item.Quality = 0;

            else item.Quality += qualityMultiplier;

            return item.Quality;
        }
    }
}
    

