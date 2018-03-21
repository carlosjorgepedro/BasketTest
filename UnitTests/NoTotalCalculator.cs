using System.Collections.Generic;
using System.Linq;

namespace Basket.UnitTests
{
    /// <summary>
    /// Discount Calculator that does not apply discounts
    /// for unit test purposes, provides allows cleaner
    /// unit tests than using a Mocking interface.
    /// </summary>
    public class NoTotalCalculator : ITotalCalculator
    {
        public decimal Calculate(List<BasketItem> basketItems)
        {
            return basketItems.Sum(x => 10m * x.Count);
        }
    }
}