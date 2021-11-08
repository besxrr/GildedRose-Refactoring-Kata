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
                var qualityMultiplier = UpdateQualityMultiplierValue(item);
                HandleSulfurasItem(item);
                if (item.Quality is >= 50 or <= 0) continue;
                if (IsConjured(item)) item.Name = "Conjured";
                UpdateQualityMultiplierByName(item, qualityMultiplier);
            }
        }

        public void UpdateSellInOfItems()
        {
            foreach (var item in _items)
            {
                item.SellIn -= 1;
            }
        }

        private static int UpdateQualityMultiplierValue(Item item)
        {
            var qualityMultiplier = (item.SellIn > 0) ? 1 : 2;
            return qualityMultiplier;
        }

        private static void UpdateQualityMultiplierByName(Item item, int qualityMultiplier)
        {
            
            switch (item.Name)
            {
                case "Aged Brie":
                    item.Quality = Math.Min(item.Quality += qualityMultiplier, 50);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    UpdateBackstagePassQuality(item, qualityMultiplier);
                    break;
                case "Conjured":
                    item.Quality -= (qualityMultiplier * 2);
                    break;
                default:
                    item.Quality -= qualityMultiplier;
                    break;
            }
        }
        
        private static bool IsConjured(Item item)
        {
            var currentItemName = item.Name.Split(" ");
            return currentItemName[0] == "Conjured";
        }

        private static void HandleSulfurasItem(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros") return;
            item.Quality = 80;
            item.SellIn = 0;
        }

        private static void UpdateBackstagePassQuality(Item item, int qualityMultiplier)
        {
            switch (item.SellIn)
            {
                case 0:
                    item.Quality = 0;
                    break;
                case < 6:
                    item.Quality += (qualityMultiplier * 3);
                    break;
                case < 11:
                    item.Quality += (qualityMultiplier * 2);
                    break;
                default:
                    item.Quality += qualityMultiplier;
                    break;
            }
            item.Quality = Math.Min(item.Quality, 50);
        }
    }
}
    

