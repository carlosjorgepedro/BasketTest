using System.Collections.Generic;
using System.Linq;

namespace Basket
{
    public class TotalCalculator : ITotalCalculator
    {
        private readonly IEnumerable<IDiscount> _discounts;

        public TotalCalculator(IEnumerable<IDiscount> discounts)
        {
            _discounts = discounts;
        }

        public decimal Calculate(List<BasketItem> basketItems)
        {
            var discount = _discounts.Sum(x => x.GetDiscount(basketItems));
            var basketTotal = basketItems.Sum(item => item.Product.Price * item.Count);
            return basketTotal - discount;
        }
    }
}