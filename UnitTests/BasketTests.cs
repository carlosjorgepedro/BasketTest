using NUnit.Framework;

namespace Basket.UnitTests
{
    [TestFixture]
    public class BasketTests
    {
        [Test]
        public void AddItemIncreasesTotal()
        {
            var basket = new Basket();
            var product = new Product("bread", 2.10m);

            basket.Add(product);
            Assert.AreEqual(2.10m, basket.Total);
        }
    }
}
