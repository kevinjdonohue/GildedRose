using FluentAssertions;
using GildedRose;
using GildedRose.Entities;
using GildedRose.QualityCalculators;
using Xunit;

namespace GildedRoseTests
{
    public class DefaultItemQualityCalculatorTests
    {
        [Fact]
        public void UpdateQuality_Should_DecreaseSellInAndQualityByOne_GivenANonZeroSellIn()
        {
            //arrange
            DefaultItemQualityCalculator calculator = new DefaultItemQualityCalculator();
            Item item = new Item()
            {
                Name = "Foo",
                Quality = 2,
                SellIn = 2
            };

            //act
            calculator.UpdateQuality(item);

            //assert
            item.Quality.Should().Be(1, "because Quality for a normal item should be decreased by one");
            item.SellIn.Should().Be(1, "because SellIn should be decreased by one");
        }

        [Fact]
        public void UpdateQuality_Should_DecreaseSellInByOne_And_QualityByTwo_GivenAZeroSellIn()
        {
            //arrange
            DefaultItemQualityCalculator calculator = new DefaultItemQualityCalculator();
            Item item = new Item()
            {
                Name = "Foo",
                Quality = 2,
                SellIn = 0
            };

            //act
            calculator.UpdateQuality(item);

            //assert
            item.Quality.Should().Be(0, "because Quality for a normal item should be decreased by two when the SellIn is less than zero");
            item.SellIn.Should().Be(-1, "because SellIn should be decreased by one");
        }
    }
}