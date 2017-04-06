using System.Collections.Generic;
using FluentAssertions;
using GildedRose;
using GildedRose.Entities;
using GildedRose.Factory;
using Xunit;

namespace GildedRoseTests
{
    public class InventoryManagerTests
    {
        private readonly InventoryManager _inventoryManager;

        public InventoryManagerTests()
        {
            //TODO:  should we mock the factory?
            _inventoryManager = new InventoryManager(new QualityCalculatorFactory());
        }

        [Theory]
        [InlineData("+5 Dexterity Vest", 10, 20, "+5 Dexterity Vest", 9, 19)]
        [InlineData("Elixir of the Mongoose", 5, 7, "Elixir of the Mongoose", 4, 6)]
        public void UpdateQuality_Should_SubtractOneFromSellInAndQuality_GivenNormalItem(string itemName, int sellIn, int quality, string expectedName, int expectedSellIn, int expectedQuality)
        {
            //arrange
            _inventoryManager.Items = BuildItemList(itemName, sellIn, quality);

            //act
            _inventoryManager.UpdateQuality();

            //assert
            _inventoryManager.Items[0].SellIn.Should().Be(expectedSellIn, "because a normal item should have its SellIn value decreased by one (each day)");
            _inventoryManager.Items[0].Quality.Should().Be(expectedQuality, "because a normal item should have its Quality value decreased by one (each day)");
        }

        [Fact]
        public void UpdateQuality_Should_SubtractTwoFromQuality_GivenANormalItem_WithASellInLessThanZero()
        {
            //arrange
            _inventoryManager.Items = BuildItemList("+5 Dexterity Vest", -5, 20);

            //act
            _inventoryManager.UpdateQuality();

            //assert
            _inventoryManager.Items[0].SellIn.Should().Be(-6, "because a normal item should have its SellIn value decreased by one (each day)");
            _inventoryManager.Items[0].Quality.Should().Be(18, "because a normal item should have its Quality value decreased by two whenever the SellIn value is less than zero");
        }

        [Fact]
        public void UpdateQuality_Should_SubtractsOneFromSellIn_And_AddOneToQuality_GivenAgedItem()
        {
            //arrange
            const string expectedName = "Aged Brie";
            _inventoryManager.Items = BuildItemList(expectedName, 2, 0);

            //act
            _inventoryManager.UpdateQuality();

            //assert
            _inventoryManager.Items[0].SellIn.Should().Be(1, "because an aged item should have its SellIn value decreased by one (each day)");
            _inventoryManager.Items[0].Quality.Should().Be(1, "because an aged item should have its Quality value increased by one (each day)");
        }

        [Fact]
        public void UpdateQuality_ShouldNotUpdateSellInOrQuality_GivenLegendaryItem()
        {
            //arrange
            const string expectedName = "Sulfuras, Hand of Ragnaros";
            const int expectedSellIn = 0;
            const int expectedQuality = 80;
            _inventoryManager.Items = BuildItemList(expectedName, expectedSellIn, expectedQuality);

            //act
            _inventoryManager.UpdateQuality();

            //assert
            _inventoryManager.Items[0].SellIn.Should().Be(expectedSellIn, "because a legendary item should NOT have its SellIn value changed ever");
            _inventoryManager.Items[0].Quality.Should().Be(expectedQuality, "because an aged item should NOT have its Quality value changed ever");
        }

        [Fact]
        public void UpdateQuality_Should_SubtractOneFromSellIn_And_AddOneToQuality_GivenBackstagePassItem_WithASellInOverEleven()
        {
            //arrange
            const string expectedName = "Backstage passes to a TAFKAL80ETC concert";
            _inventoryManager.Items = BuildItemList(expectedName, 15, 20);

            //act
            _inventoryManager.UpdateQuality();

            //assert
            _inventoryManager.Items[0].SellIn.Should().Be(14, "because a Backstage Pass item should have its SellIn value decreased by one (each day)");
            _inventoryManager.Items[0].Quality.Should().Be(21, "because a Backstage Pass item should have its Quality value increased by one (each day)");
        }

        [Fact]
        public void UpdateQuality_Should_SubtractOneFromSellIn_And_AddTwoToQuality_GivenABackstagePassItem_WithASellInLessThanTen()
        {
            //arrange
            const string expectedName = "Backstage passes to a TAFKAL80ETC concert";
            _inventoryManager.Items = BuildItemList(expectedName, 9, 20);

            //act
            _inventoryManager.UpdateQuality();

            //assert
            _inventoryManager.Items[0].SellIn.Should().Be(8, "because a Backstage Pass item should have its SellIn value decreased by one (each day)");
            _inventoryManager.Items[0].Quality.Should().Be(22, "because a Backstage Pass item should have its Quality value increased by two, whenever the SellIn value is less than ten but greater than five");
        }

        [Fact]
        public void UpdateQuality_Should_SubtractOneFromSellIn_And_AddThreeToQuality_GivenABackstagePassItem_WithASellInLessThanSix()
        {
            //arrange
            const string expectedName = "Backstage passes to a TAFKAL80ETC concert";
            _inventoryManager.Items = BuildItemList(expectedName, 5, 20);

            //act
            _inventoryManager.UpdateQuality();

            //assert
            _inventoryManager.Items[0].SellIn.Should().Be(4, "because a Backstage Pass item should have its SellIn value decreased by one (each day)");
            _inventoryManager.Items[0].Quality.Should().Be(23, "because a Backstage Pass item should have its Quality value increased by three, whenever the SellIn value is less than six");
        }

        [Fact]
        public void UpdateQuality_Should_SetTheQualityToZero_GivenABackstagePassItem_WithASellInLessThanZero()
        {
            //arrange
            const string expectedName = "Backstage passes to a TAFKAL80ETC concert";
            _inventoryManager.Items = BuildItemList(expectedName, -5, 20);

            //act
            _inventoryManager.UpdateQuality();

            //assert
            _inventoryManager.Items[0].SellIn.Should().Be(-6, "because a Backstage Pass item should have its SellIn value decreased by one (each day)");
            _inventoryManager.Items[0].Quality.Should().Be(0, "because a Backstage Pass item should have its Quality set to zero, whenever the SellIn value is less than zero");
        }

        [Fact]
        public void UpdateQuality_Should_SetTheQualityToZero_GivenAgedItem_WithASellInLessThanZero()
        {
            //arrange
            const string expectedName = "Aged Brie";
            _inventoryManager.Items = BuildItemList(expectedName, -5, 20);

            //act
            _inventoryManager.UpdateQuality();

            //assert
            _inventoryManager.Items[0].SellIn.Should().Be(-6, "because an Aged item should have its SellIn value decreased by one (each day)");
            _inventoryManager.Items[0].Quality.Should().Be(22, "because an Aged item should have its Quality increased by two, whenever the SellIn value is less than zero");
        }

        private static List<Item> BuildItemList(string name, int sellIn, int quality)
        {
            return new List<Item>()
            {
                new Item()
                {
                    Name = name,
                    SellIn = sellIn,
                    Quality = quality
                }
            };
        }
    }
}