using System.Collections.Generic;
using GildedRose.Entities;
using GildedRose.Factory;
using GildedRose.QualityCalculators;

namespace GildedRose
{
    public class InventoryManager
    {
        private readonly IQualityCalculatorFactory _qualityCalculatorFactory;
        private readonly Dictionary<string, IQualityCalculator> _qualityCalculators = new Dictionary<string, IQualityCalculator>();
        public IList<Item> Items { get; set; }

        public InventoryManager(IQualityCalculatorFactory qualityCalculatorFactory)
        {
            _qualityCalculatorFactory = qualityCalculatorFactory;
            LoadInventory();
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                IQualityCalculator qualityCalculator = GetQualityCalculator(item);
                qualityCalculator.UpdateQuality(item);
            }
        }

        private IQualityCalculator GetQualityCalculator(Item item)
        {
            IQualityCalculator qualityCalculator;

            _qualityCalculators.TryGetValue(item.Name, out qualityCalculator);

            if (qualityCalculator == null)
            {
                qualityCalculator = _qualityCalculatorFactory.CreateQualityCalculator(item.Name);
                _qualityCalculators.Add(item.Name, qualityCalculator);
            }

            return qualityCalculator;
        }

        private void LoadInventory()
        {
            Items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
        }
    }
}