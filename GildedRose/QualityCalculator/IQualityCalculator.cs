using GildedRose.Entities;

namespace GildedRose.QualityCalculators
{
    public interface IQualityCalculator
    {
        void UpdateQuality(Item item);
    }
}