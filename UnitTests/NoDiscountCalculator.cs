using System.Collections.Generic;
using System.Linq;

namespace Basket.UnitTests
{
    public class NoDiscountCalculator : IDiscountCalculator
    {
        public decimal Calculate(List<Product> products)
        {
            return products.Sum(x => x.Price);
        }
    }
}