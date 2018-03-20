using System.Collections.Generic;

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
            _basketItems.Add(new BasketItem(product, count));
        }

        public decimal Total => _discountCalculator.Calculate(_basketItems);
    }
}
