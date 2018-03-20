using System.Collections.Generic;

namespace Basket
{
    public interface IDiscountCalculator
    {
        decimal Calculate(List<Product> products);
    }

    public class Basket
    {
        private readonly IDiscountCalculator _discountCalculator;
        private List<Product> _productList = new List<Product>();

        public Basket(IDiscountCalculator discountCalculator)
        {
            _discountCalculator = discountCalculator;
        }

        public void Add(Product product)
        {
            _productList.Add(product);
        }

        public decimal Total { get { return _discountCalculator.Calculate(_productList); } }
    }
}
