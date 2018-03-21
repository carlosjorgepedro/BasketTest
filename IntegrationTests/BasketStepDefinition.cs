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


        [SetUp]
        public void Setup()
        {
            this.basket = new ShoppingBasket(new TotalCalculator(
                new List<IDiscount>
                {
                    new ButterBreadDiscount(),
                    new MilkDiscount()
                }));
        }

        [Given("the basket has (.*) bread")]
        [Given("(.*) bread")]
        public void AddBread(int count)
        {
            basket.Add(new Product("bread", 1.00m), count);
        }

        [Given("the basket has (.*) milk")]
        [Given("(.*) milk")]
        public void AddMilk(int count)
        {
            basket.Add(new Product("milk", 1.15m), count);
        }

        [Given("the basket has (.*) butter")]
        [Given("(.*) butter")]
        public void AddButter(int count)
        {
            basket.Add(new Product("butter", 1.00m), count);
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
