using System;

namespace GildedRose
{
    public class AgedItemQualityCalculator : IQualityCalculator
    {
        public void UpdateQuality(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "The item was null.");
            }

            if (item.Quality < 50)
            {
                item.Quality++;
            }

            item.SellIn--;

            if (item.SellIn < 0)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                }
            }
        }
    }
}