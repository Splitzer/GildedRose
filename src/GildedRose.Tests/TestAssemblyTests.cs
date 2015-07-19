using Xunit;
using GildedRose.Console;
using System.Collections.Generic;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        ///////////////////// /* Normal Items */ /////////////////////
        [Fact]
        public void QulityDecreaseTest()
        {
            Program app = new Program();

            app.Items = new List<Item> { new Item { Name = "Elixir of the Mongoose", SellIn = 1, Quality = 1 } };
            app.UpdateQuality();
            Assert.Equal(0, app.Items[0].Quality);
            Assert.Equal(0, app.Items[0].SellIn);
        }

        [Fact]
        public void ExpiredQulityDecreaseTest()
        {
            Program app = new Program();

            app.Items = new List<Item> { new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 3 } };
            app.UpdateQuality();
            Assert.Equal(1, app.Items[0].Quality);
            Assert.Equal(-1, app.Items[0].SellIn);
        }

        [Fact]
        public void ExpiredQulityZeroTest()
        {
            Program app = new Program();

            app.Items = new List<Item> { new Item { Name = "Elixir of the Mongoose", SellIn = -1, Quality = 0 } };
            app.UpdateQuality();
            Assert.Equal(0, app.Items[0].Quality);
            Assert.Equal(-2, app.Items[0].SellIn);
        }


        ///////////////////// /* Sulfuras, Hand of Ragnaros */ /////////////////////
        [Fact]
        public void LegendaryQulityTest()
        {
            Program app = new Program();

            app.Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            app.UpdateQuality();
            Assert.Equal(80, app.Items[0].Quality);
            Assert.Equal(0, app.Items[0].SellIn);
        }


        ///////////////////// /* Aged Brie */ /////////////////////
        [Fact]
        public void AgingQulityTest()
        {
            Program app = new Program();

            app.Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 1 } };
            app.UpdateQuality();
            Assert.Equal(2, app.Items[0].Quality);
            Assert.Equal(0, app.Items[0].SellIn);
        }

        [Fact]
        public void AgingMaxQulityTest()
        {
            Program app = new Program();

            app.Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 } };
            app.UpdateQuality();
            Assert.Equal(50, app.Items[0].Quality);
            Assert.Equal(0, app.Items[0].SellIn);
        }

        [Fact]
        public void AgedQulityTest()
        {
            Program app = new Program();

            app.Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 } };
            app.UpdateQuality();
            Assert.Equal(2, app.Items[0].Quality);
        }

        [Fact]
        public void AgedMaxQulityTest()
        {
            Program app = new Program();

            app.Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 } };
            app.UpdateQuality();
            Assert.Equal(50, app.Items[0].Quality);
            Assert.Equal(-1, app.Items[0].SellIn);
        }


        ///////////////////// /* LVL80 ETC Backstage Pass */ /////////////////////
        [Fact]
        public void ExpiredBackstagePassQulityTest()
        {
            Program app = new Program();

            app.Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 5 } };
            app.UpdateQuality();
            Assert.Equal(0, app.Items[0].Quality);
            Assert.Equal(-1, app.Items[0].SellIn);
        }

        [Fact]
        public void Factor3BackstagePassQulityTest()
        {
            Program app = new Program();

            app.Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 5 } };
            app.UpdateQuality();
            Assert.Equal(8, app.Items[0].Quality);
            Assert.Equal(1, app.Items[0].SellIn);
        }

        [Fact]
        public void Factor3BackstagePassMaxQulityTest()
        {
            Program app = new Program();

            app.Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 50 } };
            app.UpdateQuality();
            Assert.Equal(50, app.Items[0].Quality);
            Assert.Equal(1, app.Items[0].SellIn);
        }

        [Fact]
        public void Factor2BackstagePassQulityTest()
        {
            Program app = new Program();

            app.Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 8, Quality = 5 } };
            app.UpdateQuality();
            Assert.Equal(7, app.Items[0].Quality);
            Assert.Equal(7, app.Items[0].SellIn);
        }

        [Fact]
        public void Factor2BackstagePassMaxQulityTest()
        {
            Program app = new Program();

            app.Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 8, Quality = 50 } };
            app.UpdateQuality();
            Assert.Equal(50, app.Items[0].Quality);
            Assert.Equal(7, app.Items[0].SellIn);
        }

        [Fact]
        public void Factor1BackstagePassQulityTest()
        {
            Program app = new Program();

            app.Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 13, Quality = 5 } };
            app.UpdateQuality();
            Assert.Equal(6, app.Items[0].Quality);
            Assert.Equal(12, app.Items[0].SellIn);
        }

        [Fact]
        public void Factor1BackstagePassMaxQulityTest()
        {
            Program app = new Program();

            app.Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 13, Quality = 50 } };
            app.UpdateQuality();
            Assert.Equal(50, app.Items[0].Quality);
            Assert.Equal(12, app.Items[0].SellIn);
        }

        ///////////////////// /* Conjured Items */ /////////////////////
        [Fact]
        public void ConjuredQulityDecreaseTest()
        {
            Program app = new Program();

            app.Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 } };
            app.UpdateQuality();
            Assert.Equal(4, app.Items[0].Quality);
            Assert.Equal(2, app.Items[0].SellIn);
        }

        [Fact]
        public void ConjuredExpiredQulityDecreaseTest()
        {     
            Program app = new Program();
            
            app.Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 6 } };
            app.UpdateQuality();
            Assert.Equal(2, app.Items[0].Quality);
            Assert.Equal(-1, app.Items[0].SellIn);
        }

        [Fact]
        public void ConjuredQulityZeroTest()
        {
            Program app = new Program();

            app.Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 2, Quality = 0 } };
            app.UpdateQuality();
            Assert.Equal(0, app.Items[0].Quality);
            Assert.Equal(1, app.Items[0].SellIn);
        }

        [Fact]
        public void ConjuredExpiredQulityZeroTest()
        {
            Program app = new Program();

            app.Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 0 } };
            app.UpdateQuality();
            Assert.Equal(0, app.Items[0].Quality);
            Assert.Equal(-1, app.Items[0].SellIn);
        }
    }
}