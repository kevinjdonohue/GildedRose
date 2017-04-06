using GildedRose.QualityCalculators;

namespace GildedRose.Factory
{
    public interface IQualityCalculatorFactory
    {
        IQualityCalculator CreateQualityCalculator(string itemName);
    }
}