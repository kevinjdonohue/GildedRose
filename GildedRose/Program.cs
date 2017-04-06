namespace GildedRose
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");
            InventoryManager inventoryManager = new InventoryManager(new QualityCalculatorFactory());
            inventoryManager.UpdateQuality();
            System.Console.ReadKey();
        }
    }
}
