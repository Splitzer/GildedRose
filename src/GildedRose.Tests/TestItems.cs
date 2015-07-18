using Xunit;
using GildedRose.Console;
using System.Collections;

namespace GildedRose.Tests
{
    public static class TestItems
    {
        public static Item CommonItem
        {
            get
            {
                return new Item { Name = "Common Tunic", SellIn = 1, Quality = 1 };
            }
        }

        public static Item BackstagePass
        {
            get
            {
                return new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 3 };
            }
        }

        public static Item AgingItem
        {
            get
            {
                return new Item { Name = "Aged Brie", SellIn = 1, Quality = 1 };
            }
        }

        public static Item LegendaryItem
        {
            get
            {
                return new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
            }
        }
    }
}
