using FluentAssertions;
using GildedRose;
using Xunit;

namespace GildedRoseTests
{
    public class BackstagePassItemQualityCalculatorTests
    {
        [Fact]
        public void UpdateQuality_Should_SubtractOneFromSellIn_And_AddOneToQuality_GivenBackstagePassItem_WithASellInOverEleven()
        {
            //arrange
            BackstagePassItemQualityCalculator calculator = new BackstagePassItemQualityCalculator();
            Item item = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 12,
                Quality = 18
            };

            //act
            calculator.UpdateQuality(item);

            //assert
            item.SellIn.Should().Be(11, "because a Backstage Pass item should have its SellIn decreased by one");
            item.Quality.Should().Be(19, "because a Backstage Pass item should have its Quality increased by one when the SellIn is over eleven");
        }

        [Fact]
        public void UpdateQuality_Should_SubtractOneFromSellIn_And_AddTwoToQuality_GivenABackstagePassItem_WithASellInLessThanTen()
        {
            //arrange
            BackstagePassItemQualityCalculator calculator = new BackstagePassItemQualityCalculator();
            Item item = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 18
            };

            //act
            calculator.UpdateQuality(item);

            //assert
            item.SellIn.Should().Be(9, "because a Backstage Pass item should have its SellIn decreased by one");
            item.Quality.Should().Be(20, "because a Backstage Pass item should have its Quality increased by two when the SellIn is under eleven");
        }

        [Fact]
        public void UpdateQuality_Should_SubtractOneFromSellIn_And_AddThreeToQuality_GivenABackstagePassItem_WithASellInLessThanSix()
        {
            //arrange
            BackstagePassItemQualityCalculator calculator = new BackstagePassItemQualityCalculator();
            Item item = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 6,
                Quality = 18
            };

            //act
            calculator.UpdateQuality(item);

            //assert
            item.SellIn.Should().Be(5, "because a Backstage Pass item should have its SellIn decreased by one");
            item.Quality.Should().Be(21, "because a Backstage Pass item should have its Quality increased by two when the SellIn is under eleven");
        }

        [Fact]
        public void UpdateQuality_Should_SetTheQualityToZero_GivenABackstagePassItem_WithASellInLessThanZero()
        {
            //arrange
            BackstagePassItemQualityCalculator calculator = new BackstagePassItemQualityCalculator();
            Item item = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = -5,
                Quality = 20
            };

            //act
            calculator.UpdateQuality(item);

            //assert
            item.SellIn.Should().Be(-6, "because a Backstage Pass item should have its SellIn value decreased by one (each day)");
            item.Quality.Should().Be(0, "because a Backstage Pass item should have its Quality set to zero, whenever the SellIn value is less than zero");
        }
    }
}