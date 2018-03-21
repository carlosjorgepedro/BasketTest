using System.Collections.Generic;
using NUnit.Framework;

namespace Basket.UnitTests
{
    [TestFixture]
    public class MilkDiscountTests
    {
        private readonly Product _milk = new Product("milk", 10m);
        private readonly Product _butter = new Product("butter", 10m);
        private readonly Product _bread = new Product("bread", 12m);

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(4, ExpectedResult = 10)]
        [TestCase(8, ExpectedResult = 20)]
        public decimal CalculateDiscount(int milkCount)
        {
            var basketItems = new List<BasketItem>
            {
                new BasketItem(_butter, 6),
                new BasketItem(_bread, 10),
                new BasketItem(_milk, milkCount)
            };

            var milkDiscount = new MilkDiscount();
            return milkDiscount.GetDiscount(basketItems);
        }

    }
}