using System;
using GildedRose.Entities;

namespace GildedRose.QualityCalculators
{
    public class BaseQualityCalculator
    {
        public void ValidateItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "The item was null.");
            }
        }
    }
}