using System;

namespace GildedRose
{
    public class BackstagePassItemQualityCalculator : IQualityCalculator
    {
        public void UpdateQuality(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "The item was null.");
            }

            item.SellIn--;
            item.Quality++;

            if (item.SellIn < 11)
            {
                item.Quality++;
            }

            if (item.SellIn < 6)
            {
                item.Quality++;
            }

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
    }
}