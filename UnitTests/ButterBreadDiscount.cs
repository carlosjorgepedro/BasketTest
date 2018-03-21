using System.Collections.Generic;
using System.Linq;

namespace Basket.UnitTests
{
    public class MilkDiscount : IDiscount
    {
        public decimal GetDiscount(List<BasketItem> basketItem)
        {
            var milkPrice = basketItem
                .Select(x => x.Product)
                .First(x => x.Name == "milk")
                .Price;

            var milkCount = basketItem
                .Where(x => x.Product.Name == "milk")
                .Sum(x => x.Count);

            return (milkCount / 4) * milkPrice;
        }
    }

    public class ButterBreadDiscount : IDiscount
    {
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

            return discountedBreads * (basketItem.First(x => x.Product.Name == "bread").Product.Price) / 2;
        }
    }
}
