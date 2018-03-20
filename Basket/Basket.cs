using System.Collections.Generic;
using System.Linq;

namespace Basket
{
    public class Basket
    {
        private readonly IDiscountCalculator _discountCalculator;
        private readonly List<BasketItem> _basketItems = new List<BasketItem>();

        public Basket(IDiscountCalculator discountCalculator)
        {
            _discountCalculator = discountCalculator;
        }

        public void Add(Product product, int count = 1)
        {
            var item = _basketItems
                .FirstOrDefault(x => x.Product.Name == product.Name);

            if (item == null)
            {
                _basketItems.Add(new BasketItem(product, count));
            }
            else
            {
                item.Count += count;
            }
        }

        public decimal Total => _discountCalculator.Calculate(_basketItems);
    }
}
