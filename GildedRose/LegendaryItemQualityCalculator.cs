using System;

namespace GildedRose
{
    public class LegendaryItemQualityCalculator : IQualityCalculator
    {
        public void UpdateQuality(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "The item was null.");
            }            
        }
    }
}