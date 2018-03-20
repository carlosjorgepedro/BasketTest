using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace Basket.UnitTests
{
    [TestFixture]
    public class BasketTests
    {
        [Test]
        public void AddItemIncreasesTotal()
        {
            var discountCalculator = new NoTotalCalculator();
            var basket = new Basket(discountCalculator);
            var product = new Product("bread", 2.10m);

            basket.Add(product);
            Assert.AreEqual(2.10m, basket.Total);
        }

        [Test]
        public void AddMultipleUnitsOfSameProduct()
        {
            var discountCalculator = new NoTotalCalculator();
            var basket = new Basket(discountCalculator);
            var product = new Product("bread", 2.10m);

            basket.Add(product, 3);
            Assert.AreEqual(6.30m, basket.Total);
        }

        [Test]
        public void AddMultipleUnitsOfSameProductOneUnitAtATime()
        {
            var discountCalculator = new NoTotalCalculator();
            var basket = new Basket(discountCalculator);
            var product = new Product("bread", 2.10m);

            basket.Add(product);
            basket.Add(product);
            basket.Add(product);

            Assert.AreEqual(6.30m, basket.Total);
        }

        [Test]
        public void GettingTotalCalculateDiscount()
        {
            var discountCalculator = new NoTotalCalculator();
            var basket = new Basket(discountCalculator);
            var milk = new Product("milk", 1.55m);
            var bread = new Product("bread", 21m);

            basket.Add(milk);
            basket.Add(bread);

            Assert.AreEqual(22.55m, basket.Total);
        }
    }
}
