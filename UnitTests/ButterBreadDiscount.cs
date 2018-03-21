using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.UnitTests
{
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

            return discountedBreads * basketItem.First(x => x.Product.Name == "bread").Product.Price / 2;
        }
    }
}
