using FluentAssertions;
using GildedRose;
using Xunit;

namespace GildedRoseTests
{
    public class LegendaryItemQualityCalculatorTests
    {
        [Fact]
        public void UpdateQuality_ShouldNotUpdateSellInOrQuality_GivenLegendaryItem()
        {
            //arrange
            LegendaryItemQualityCalculator calculator = new LegendaryItemQualityCalculator();
            Item item = new Item()
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = 20,
                Quality = 20
            };

            //act
            calculator.UpdateQuality(item);

            //assert
            item.SellIn.Should().Be(20, "because the SellIn for a Legendary Item should never change");
            item.Quality.Should().Be(20, "because the Quality for a Legendary Item should never change");
        }
    }
}