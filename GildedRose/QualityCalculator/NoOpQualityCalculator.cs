using GildedRose.Entities;

namespace GildedRose.QualityCalculators
{
    public class NoOpQualityCalculator : IQualityCalculator
    {
        public void UpdateQuality(Item item)
        {
        }
    }
}