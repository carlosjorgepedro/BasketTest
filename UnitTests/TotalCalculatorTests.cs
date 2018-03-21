using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace Basket.UnitTests
{
    [TestFixture]
    public class TotalCalculatorTests
    {
        [Test]
        public void CalculateCallsAllDiscounts()
        {
            var firstDiscountMock = new Mock<IDiscount>();
            var secondDiscountMock = new Mock<IDiscount>();
            var priceProviderMock = new Mock<IPriceProvider>();
            priceProviderMock
                .Setup(x => x.GetPrice(It.IsAny<string>()))
                .Returns(0m);
            var totalCalculator = new TotalCalculator(
                new List<IDiscount>
                {
                    firstDiscountMock.Object, secondDiscountMock.Object
                },
                priceProviderMock.Object);

            var basketItems = new List<BasketItem>
            {
                new BasketItem("test_product")
            };

            totalCalculator.Calculate(basketItems);

            firstDiscountMock.Verify(x => x.GetDiscount(basketItems), Times.Once);
            secondDiscountMock.Verify(x => x.GetDiscount(basketItems), Times.Once);
        }

        [Test]
        public void CalculateReturnsTotalWithSumOfDiscounts()
        {
            var priceProviderMock = new Mock<IPriceProvider>();
            priceProviderMock
                .Setup(x => x.GetPrice(It.IsAny<string>()))
                .Returns(100m);

            var basketItems = new List<BasketItem>
            {
                new BasketItem("test_product")
            };

            var firstDiscountMock = new Mock<IDiscount>();
            var secondDiscountMock = new Mock<IDiscount>();
            firstDiscountMock
                .Setup(x => x.GetDiscount(basketItems))
                .Returns(10m);
            secondDiscountMock
                .Setup(x => x.GetDiscount(basketItems))
                .Returns(2m);

            var totalCalculator = new TotalCalculator(
                new List<IDiscount>
                {
                    firstDiscountMock.Object, secondDiscountMock.Object
                },
                priceProviderMock.Object);

            var total = totalCalculator.Calculate(basketItems);
            Assert.AreEqual(88m, total);
        }
    }
}
