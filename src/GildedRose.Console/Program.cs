using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;

        #region Program Constants
        public const int MinQuality = 0;
        public const int MaxQuality = 50;
        public const string HandOfRagnaros = "Sulfuras, Hand of Ragnaros";
        public const string AgedBrie = "Aged Brie";
        public const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        public const string ConjuredCake = "Conjured Mana Cake";
        public IList<string> NormalItem = new List<string> { "+5 Dexterity Vest", "Elixir of the Mongoose" };
        #endregion

        static void Main(string[] args)
        {
            System.Console.WriteLine("KEKBUR 50 DKP MINUS!");

            Program app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                }
            };
            
            app.UpdateQuality();

            System.Console.ReadKey();
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name != HandOfRagnaros)
                {
                    MaturingItemsUpdate(item);                    
                    item.SellIn--;
                    ExpiredItemsUpdate(item);
                }
            }
        }

        private void MaturingItemsUpdate(Item item)
        {
            if (item.Name != AgedBrie && item.Name != BackstagePass)
            {
                if (item.Quality > MinQuality)
                {
                    if (item.Name != HandOfRagnaros)
                    {
                        item.Quality--;
                    }
                }
            }
            else
            {
                if (item.Quality < MaxQuality)
                {
                    item.Quality++;

                    if (item.Name == BackstagePass)
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < MaxQuality)
                            {
                                item.Quality++;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < MaxQuality)
                            {
                                item.Quality++;
                            }
                        }
                    }
                }
            }
        }
        private static void ExpiredItemsUpdate(Item item)
        {
            if (item.SellIn < MinQuality)
            {
                if (item.Name != AgedBrie)
                {
                    if (item.Name != BackstagePass)
                    {
                        if (item.Quality > MinQuality)
                        {
                            if (item.Name != HandOfRagnaros)
                            {
                                item.Quality--;
                            }
                        }
                    }
                    else
                    {
                        item.Quality = MinQuality;
                    }
                }
                else
                {
                    if (item.Quality < MaxQuality)
                    {
                        item.Quality++;
                    }
                }
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
