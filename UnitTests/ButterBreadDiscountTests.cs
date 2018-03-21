using System.Collections.Generic;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace Basket.UnitTests
{
    [TestFixture]
    public class ButterBreadDiscountTests
    {
        private readonly Product _butter = new Product("butter", 10m);
        private readonly Product _bread = new Product("bread", 12m);

        [TestCase(2, 1, 6)]
        [TestCase(4, 1, 6)]
        [TestCase(4, 2, 12)]
        [TestCase(0, 2, 0)]
        [TestCase(10, 0, 0)]
        public void CalculateDiscount(int butterCount, int breadCount, decimal expectedDiscount)
        {
            var basketItems = new List<BasketItem> {
                new BasketItem(_butter, butterCount),
                new BasketItem(_bread, breadCount)
                };
            var discount = new ButterBreadDiscount();
            var discountValue = discount.GetDiscount(basketItems);

            Assert.AreEqual(expectedDiscount, discountValue);
        }
    }
}