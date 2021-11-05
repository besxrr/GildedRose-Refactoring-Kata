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
                if (item.Quality is < 50 and > 0 )
                {

                    switch (item.Name)
                    {
                        case "Aged Brie":
                            item.Quality += 1;
                            break;
                        case "Backstage passes to a TAFKAL80ETC concert":
                            BackstagePassesMethod(item);
                            break;
                        case "Sulfuras, Hand of Ragnaros":
                            item.Quality = 80;
                            break;
                        default:
                            item.Quality -= 1;
                            break;
                    }
                }
            }
        }
        
        private void BackstagePassesMethod(Item item)
        {
            if (item.SellIn < 11) item.Quality += 2;

            if (item.SellIn < 6) item.Quality += 3;

            if (item.SellIn == 0) item.Quality = 0;

            else item.Quality += 1;
        }
        

        (_items[item].Name != "Sulfuras, Hand of Ragnaros")
                {
                    _items[item].SellIn = _items[item].SellIn - 1;
                }

                if (_items[item].SellIn < 0)
                {
                    if (_items[item].Name != "Aged Brie")
                    {
                        if (_items[item].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (_items[item].Quality > 0)
                            {
                                if (_items[item].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    _items[item].Quality = _items[item].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            _items[item].Quality = _items[item].Quality - _items[item].Quality;
                        }
                    }
                    else
                    {
                        if (_items[item].Quality < 50)
                        {
                            _items[item].Quality = _items[item].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
