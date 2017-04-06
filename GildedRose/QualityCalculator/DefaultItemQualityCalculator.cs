using GildedRose.Entities;

namespace GildedRose.QualityCalculators
{
    public class DefaultItemQualityCalculator : BaseQualityCalculator, IQualityCalculator
    {
        public void UpdateQuality(Item item)
        {
            ValidateItem(item);

            item.Quality--;
            item.SellIn--;

            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality--;
            }
        }
    }
}