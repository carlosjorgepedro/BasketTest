using System.Collections.Generic;
using System.Linq;

namespace Basket
{
    public class TotalCalculator : ITotalCalculator
    {
        private readonly IEnumerable<IDiscount> _discounts;
        private readonly IPriceProvider _priceProvider;

        public TotalCalculator(IEnumerable<IDiscount> discounts, IPriceProvider priceProvider)
        {
            _priceProvider = priceProvider;
            _discounts = discounts;
        }

        public decimal Calculate(List<BasketItem> basketItems)
        {
            var discount = _discounts.Sum(x => x.GetDiscount(basketItems));
            var basketTotal = basketItems.Sum(item => _priceProvider.GetPrice(item.Product.Name) * item.Count);
            return basketTotal - discount;
        }
    }
}