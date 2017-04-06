using System.Collections.Generic;
using GildedRose.Entities;

namespace GildedRose
{
    public interface IInventoryService
    {
        List<Item> LoadInventory();
    }
}