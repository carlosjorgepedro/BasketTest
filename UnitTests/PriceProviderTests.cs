using NUnit.Framework;

namespace Basket.UnitTests
{
    [TestFixture]
    public class PriceProviderTests
    {
        [Test]
        public void GetBreadPrice()
        {
            var priceProvider = new PriceProvider();
            var breadPrice = priceProvider.GetPrice(Products.Bread);
            Assert.AreEqual(1.00m, breadPrice);
        }

        [Test]
        public void GetMilkPrice()
        {
            var priceProvider = new PriceProvider();
            var milkPrice = priceProvider.GetPrice(Products.Milk);
            Assert.AreEqual(1.15m, milkPrice);
        }

        [Test]
        public void GetButterPrice()
        {
            var priceProvider = new PriceProvider();
            var milkPrice = priceProvider.GetPrice(Products.Butter);
            Assert.AreEqual(0.80m, milkPrice);
        }

        [Test]
        public void GetPriceForItemNotInPriceList()
        {
            var priceProvider = new PriceProvider();
            var price = priceProvider.GetPrice("testProduct");
            Assert.AreEqual(0.0m, price);
        }
    }
}
