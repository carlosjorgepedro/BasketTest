using System.Collections.Generic;
using System.Linq;

namespace Basket
{
    public class Basket
    {
        private readonly ITotalCalculator _totalCalculator;
        private readonly List<BasketItem> _basketItems = new List<BasketItem>();

        public Basket(ITotalCalculator totalCalculator)
        {
            _totalCalculator = totalCalculator;
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

        public decimal Total => _totalCalculator.Calculate(_basketItems);
    }
}
