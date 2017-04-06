namespace GildedRose
{
    public interface IQualityCalculatorFactory
    {
        IQualityCalculator CreateQualityCalculator(string itemName);
    }
}