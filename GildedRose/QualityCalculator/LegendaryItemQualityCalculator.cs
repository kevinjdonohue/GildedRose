using GildedRose.Entities;

namespace GildedRose.QualityCalculators
{
    public class LegendaryItemQualityCalculator : IQualityCalculator
    {
        public void UpdateQuality(Item item)
        {
            //for now, legendary items never have their SellIn or Quality affected
        }
    }
}