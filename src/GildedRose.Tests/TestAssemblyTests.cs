using Xunit;
using GildedRose.Console;
using System.Collections.Generic;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void QulityDecreaseTest()
        {
            //System.Diagnostics.Debugger.Launch();
            //System.Diagnostics.Debugger.Break();

            Program app = new Program();

            var commonItem = TestItems.CommonItem;
            app.Items = new List<Item> { commonItem };
            app.UpdateQuality();
            Assert.Equal(0, commonItem.Quality);
        }

        [Fact]
        public void LegendaryQulityTest()
        {
            Program app = new Program();

            var legendaryItem = TestItems.LegendaryItem;
            app.Items = new List<Item> { legendaryItem };
            app.UpdateQuality();
            Assert.Equal(80, legendaryItem.Quality);
        }

        [Fact]
        public void AgingQulityTest()
        {
            Program app = new Program();

            var agingItem = TestItems.AgingItem;
            app.Items = new List<Item> { agingItem };
            app.UpdateQuality();
            Assert.Equal(2, agingItem.Quality);
        }

        [Fact]
        public void BackstagePassQulityTest()
        {
            Program app = new Program();

            var backstagePass = TestItems.BackstagePass;
            app.Items = new List<Item> { backstagePass };
            app.UpdateQuality();
            Assert.Equal(0, backstagePass.Quality);
        }
    }
}