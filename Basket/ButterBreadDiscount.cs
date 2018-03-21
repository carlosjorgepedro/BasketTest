using System.Collections.Generic;
using System.Linq;

namespace Basket
{
    public class ButterBreadDiscount : IDiscount
    {
        private readonly IPriceProvider _priceProvider;

        public ButterBreadDiscount(IPriceProvider priceProvider)
        {
            _priceProvider = priceProvider;
        }
        public decimal GetDiscount(List<BasketItem> basketItem)
        {
            var butterCount = basketItem
                .Where(x => x.Product.Name == "butter")
                .Sum(x => x.Count);

            var breadCount = basketItem
                .Where(x => x.Product.Name == "bread")
                .Sum(x => x.Count);

            var maxDiscountBreads = butterCount / 2;
            var discountedBreads = breadCount > maxDiscountBreads ? maxDiscountBreads : breadCount;

            return discountedBreads * _priceProvider.GetPrice(Products.Bread) / 2;
        }
    }
}
