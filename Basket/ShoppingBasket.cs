using System.Collections.Generic;
using System.Linq;

namespace Basket
{
    public class ShoppingBasket
    {
        private readonly ITotalCalculator _totalCalculator;
        private readonly List<BasketItem> _basketItems = new List<BasketItem>();

        public ShoppingBasket(ITotalCalculator totalCalculator)
        {
            _totalCalculator = totalCalculator;
        }

        public void Add(string product, int count = 1)
        {
            var item = _basketItems
                .FirstOrDefault(x => x.Product == product);

            if (item == null)
            {
                _basketItems.Add(new BasketItem(product, count));
            }
            else
            {
                item.Count += count;
            }
        }

        public decimal Total => _totalCalculator.Calculate(_basketItems);
    }
}
