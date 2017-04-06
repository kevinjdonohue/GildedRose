using System.Collections.Generic;
using GildedRose.Entities;
using GildedRose.Factory;

namespace GildedRose
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");
            List<Item> inventory = new InventoryService().LoadInventory();
            InventoryManager inventoryManager = new InventoryManager(new QualityCalculatorFactory(), inventory);
            inventoryManager.UpdateQuality();
            System.Console.ReadKey();
        }
    }
}
