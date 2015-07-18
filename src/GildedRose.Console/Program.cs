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
        public IList<string> NormalItems = new List<string> { "+5 Dexterity Vest" };
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
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    MaturingItemsUpdate(item);                    
                    item.SellIn--;
                    ExpiredItemsUpdate(item);
                }
            }
        }

        private static void ExpiredItemsUpdate(Item item)
        {
            if (item.SellIn < MinQuality)
            {
                if (item.Name != "Aged Brie")
                {
                    if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.Quality > MinQuality)
                        {
                            if (item.Name != "Sulfuras, Hand of Ragnaros")
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

        private void MaturingItemsUpdate(Item item)
        {
            //NormalItems.Contains(item.Name);
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.Quality > MinQuality)
                {
                    if (item.Name != "Sulfuras, Hand of Ragnaros")
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

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
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
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
