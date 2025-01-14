﻿using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose.GildedRose app = new GildedRose.GildedRose(Items);
            app.UpdateQualityOfItems();
            Assert.Equal("fixme", Items[0].Name);
        }
    }
}
