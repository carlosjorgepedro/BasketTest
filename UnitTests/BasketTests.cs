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
            var basket = new ShoppingBasket(discountCalculator);

            basket.Add(Products.Bread);
            Assert.AreEqual(10m, basket.Total);
        }

        [Test]
        public void AddMultipleUnitsOfSameProduct()
        {
            var discountCalculator = new NoTotalCalculator();
            var basket = new ShoppingBasket(discountCalculator);
    

            basket.Add(Products.Milk, 3);
            Assert.AreEqual(30m, basket.Total);
        }

        [Test]
        public void AddMultipleUnitsOfSameProductOneUnitAtATime()
        {
            var discountCalculator = new NoTotalCalculator();
            var basket = new ShoppingBasket(discountCalculator);

            basket.Add(Products.Butter);
            basket.Add(Products.Butter);
            basket.Add(Products.Butter);

            Assert.AreEqual(30m, basket.Total);
        }
    }
}
