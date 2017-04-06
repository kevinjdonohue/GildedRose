using GildedRose.Entities;

namespace GildedRose.QualityCalculators
{
    public class AgedItemQualityCalculator : BaseQualityCalculator, IQualityCalculator
    {
        public void UpdateQuality(Item item)
        {
            ValidateItem(item);

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