using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace Basket.UnitTests
{
    [TestFixture]
    public class MilkDiscountTests
    {
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(4, ExpectedResult = 10)]
        [TestCase(8, ExpectedResult = 20)]
        public decimal CalculateDiscount(int milkCount)
        {
            var priceProviderMock = new Mock<IPriceProvider>();
            priceProviderMock.Setup(x => x.GetPrice(It.IsAny<string>()))
                .Returns(10m);

            var basketItems = new List<BasketItem>
            {
                new BasketItem(Products.Butter, 6),
                new BasketItem(Products.Bread, 10),
                new BasketItem(Products.Milk, milkCount)
            };

            var milkDiscount = new MilkDiscount(priceProviderMock.Object);
            return milkDiscount.GetDiscount(basketItems);
        }

    }
}