using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Basket.IntegrationTests
{
    [Binding]
    public sealed class BasketStepDefinition
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [Given("the basket has (.*) bread")]
        [Given("(.*) bread")]
        public void AddBread(int count)
        {
        }

        [Given("the basket has (.*) milk")]
        [Given("(.*) milk")]
        public void AddMilk(int count)
        {
        }

        [Given("the basket has (.*) butter")]
        [Given("(.*) butter")]
        public void AddButter(int count)
        {
        }

        [When("I total the basket")]
        public void GetTotal()
        {
        }

        [Then("the total should be £(.*)")]
        public void ThenTheResultShouldBe(decimal expectedTotal)
        {
        }
    }
}
