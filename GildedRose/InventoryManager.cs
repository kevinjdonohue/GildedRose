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

        public InventoryManager(IQualityCalculatorFactory qualityCalculatorFactory, List<Item> inventory)
        {
            _qualityCalculatorFactory = qualityCalculatorFactory;
            Items = inventory;
        }

        public InventoryManager(IQualityCalculatorFactory qualityCalculatorFactory) : this(qualityCalculatorFactory, new List<Item>()) { }

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
    }
}