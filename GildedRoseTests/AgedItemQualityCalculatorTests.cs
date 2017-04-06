using FluentAssertions;
using GildedRose;
using GildedRose.Entities;
using GildedRose.QualityCalculators;
using Xunit;

namespace GildedRoseTests
{
    public class AgedItemQualityCalculatorTests
    {
        [Fact]
        public void UpdateQuality_Should_SubtractsOneFromSellIn_And_AddOneToQuality_GivenAgedItem()
        {
            //arrange
            AgedItemQualityCalculator calculator = new AgedItemQualityCalculator();
            Item item = new Item()
            {
                Name = "Aged Brie",
                SellIn = 2,
                Quality = 0
            };

            //act
            calculator.UpdateQuality(item);

            //assert
            item.Quality.Should().Be(1, "because the Quality of an Aged item should increase by one up to 50");
            item.SellIn.Should().Be(1, "because the SellIn of an Aged item should decrease by one");
        }
    }
}