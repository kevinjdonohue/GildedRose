namespace GildedRose
{
    public class QualityCalculatorFactory : IQualityCalculatorFactory
    {
        public IQualityCalculator CreateQualityCalculator(string itemName)
        {
            switch (itemName)
            {
                case "Aged Brie":
                    return new AgedItemQualityCalculator();
                case "Sulfuras, Hand of Ragnaros":
                    return new LegendaryItemQualityCalculator();
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePassItemQualityCalculator();
                case "Conjured Mana Cake":
                    return new NoOpQualityCalculator();
                default:
                    return new DefaultItemQualityCalculator();
            }
        }
    }
}