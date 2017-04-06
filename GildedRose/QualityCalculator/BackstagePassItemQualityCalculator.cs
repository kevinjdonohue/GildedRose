using GildedRose.Entities;

namespace GildedRose.QualityCalculators
{
    public class BackstagePassItemQualityCalculator : BaseQualityCalculator, IQualityCalculator
    {
        public void UpdateQuality(Item item)
        {
            ValidateItem(item);

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