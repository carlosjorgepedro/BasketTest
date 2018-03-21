using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Basket.IntegrationTests
{
    [Binding]
    public sealed class BasketStepDefinition
    {
        private ShoppingBasket basket;

        private decimal _total;
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef


        [Before]
        public void Setup()
        {
            var priceProvider = new PriceProvider();
            this.basket = new ShoppingBasket(new TotalCalculator(
                new List<IDiscount>
                {
                    new ButterBreadDiscount(priceProvider),
                    new MilkDiscount(priceProvider)
                }, priceProvider));
        }

        [Given("the basket has (.*) (.*)")]
        [Given("(.*) (.*)")]
        public void AddProduct(int count, string product)
        {
            basket.Add(product, count);
        }

        [When("I total the basket")]
        public void GetTotal()
        {
            _total = basket.Total;
        }

        [Then("the total should be £(.*)")]
        public void ThenTheResultShouldBe(decimal expectedTotal)
        {
            Assert.AreEqual(expectedTotal, _total);
        }
    }
}
