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
            foreach (var item in Enumerable.Range(1, _items.Count))
            {
                if (_items[item].Quality is < 50 and > 0 )
                {
                    switch (_items[item].Name)
                    {
                        case "Aged Brie":
                            _items[item].Quality += 1;
                            break;
                        case "Backstage passes to a TAFKAL80ETC concert":
                            if (_items[item].SellIn < 11) _items[item].Quality += 2;

                            if (_items[item].SellIn <= 5) _items[item].Quality += 3;

                            if (_items[item].SellIn == 0) _items[item].Quality = 0;
                            break;
                        case "Sulfuras, Hand of Ragnaros":
                            break;
                        default:
                            _items[item].Quality -= 1;
                            break;
                    }
                }
                
            }
        }


        if (_items[item].Name != "Sulfuras, Hand of Ragnaros")
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
