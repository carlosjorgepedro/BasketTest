using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace Basket.UnitTests
{
    [TestFixture]
    public class ButterBreadDiscountTests
    {
        [TestCase(2, 1, ExpectedResult = 6)]
        [TestCase(4, 1, ExpectedResult = 6)]
        [TestCase(4, 2, ExpectedResult = 12)]
        [TestCase(0, 2, ExpectedResult = 0)]
        [TestCase(10, 0, ExpectedResult = 0)]
        [TestCase(0, 0, ExpectedResult = 0)]
        public decimal CalculateDiscount(int butterCount, int breadCount)
        {
            var priceProviderMock = new Mock<IPriceProvider>();
            priceProviderMock.Setup(x => x.GetPrice(It.IsAny<string>()))
                .Returns(12m);

            var basketItems = new List<BasketItem>
            {
                new BasketItem(Products.Butter, butterCount),
                new BasketItem(Products.Bread, breadCount),
                new BasketItem(Products.Milk, 5),
            };
            var discount = new ButterBreadDiscount(priceProviderMock.Object);
            return discount.GetDiscount(basketItems);
        }
    }
}