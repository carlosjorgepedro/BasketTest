using System.Collections.Generic;
using System.Linq;

namespace Basket
{
    public class MilkDiscount : IDiscount
    {
        private readonly IPriceProvider _priceProvider;

        public MilkDiscount(IPriceProvider priceProvider)
        {
            _priceProvider = priceProvider;
        }

        public decimal GetDiscount(List<BasketItem> basketItem)
        {
            var milkPrice = _priceProvider.GetPrice(Products.Milk);

            var milkCount = basketItem
                .Where(x => x.Product == Products.Milk)
                .Sum(x => x.Count);

            return (milkCount / 4) * milkPrice;
        }
    }
}