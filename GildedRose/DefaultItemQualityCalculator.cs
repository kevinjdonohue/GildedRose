using System;

namespace GildedRose
{
    public class DefaultItemQualityCalculator : IQualityCalculator
    {
        public void UpdateQuality(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "The item was null.");
            }

            item.Quality--;
            item.SellIn--;

            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality--;
            }
        }
    }
}