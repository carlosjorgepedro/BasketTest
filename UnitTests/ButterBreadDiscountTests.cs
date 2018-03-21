using System.Collections.Generic;
using NUnit.Framework;

namespace Basket.UnitTests
{
    [TestFixture]
    public class ButterBreadDiscountTests
    {
        private readonly Product _butter = new Product("butter", 10m);
        private readonly Product _bread = new Product("bread", 12m);
        private readonly Product _milk = new Product("milk", 11m);

        [TestCase(2, 1, ExpectedResult = 6)]
        [TestCase(4, 1, ExpectedResult = 6)]
        [TestCase(4, 2, ExpectedResult = 12)]
        [TestCase(0, 2, ExpectedResult = 0)]
        [TestCase(10, 0, ExpectedResult = 0)]
        [TestCase(0, 0, ExpectedResult = 0)]
        public decimal CalculateDiscount(int butterCount, int breadCount)
        {
            var basketItems = new List<BasketItem>
            {
                new BasketItem(_butter, butterCount),
                new BasketItem(_bread, breadCount),
                new BasketItem(_milk, 5),
            };
            var discount = new ButterBreadDiscount();
            return discount.GetDiscount(basketItems);
        }
    }
}