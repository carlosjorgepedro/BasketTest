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

            var totalCalculator = new TotalCalculator(new List<IDiscount>
            {
                firstDiscountMock.Object, secondDiscountMock.Object
            });

            var basketItems = new List<BasketItem>
            {
                new BasketItem(new Product("test_product",0.0m))
            };

            totalCalculator.Calculate(basketItems);

            firstDiscountMock.Verify(x => x.GetDiscount(basketItems), Times.Once);
            secondDiscountMock.Verify(x => x.GetDiscount(basketItems), Times.Once);
        }

        [Test]
        public void CalculateReturnsTotalWithSumOfDiscounts()
        {
            var basketItems = new List<BasketItem>
            {
                new BasketItem(new Product("test_product",100.0m))
            };

            var firstDiscountMock = new Mock<IDiscount>();
            var secondDiscountMock = new Mock<IDiscount>();
            firstDiscountMock
                .Setup(x => x.GetDiscount(basketItems))
                .Returns(10m);
            secondDiscountMock
                .Setup(x => x.GetDiscount(basketItems))
                .Returns(2m);

            var totalCalculator = new TotalCalculator(new List<IDiscount>
            {
                firstDiscountMock.Object, secondDiscountMock.Object
            });

            var total = totalCalculator.Calculate(basketItems);
            Assert.AreEqual(88m, total);
        }
    }
}
