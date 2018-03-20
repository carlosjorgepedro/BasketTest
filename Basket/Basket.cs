namespace Basket
{
    public class Basket
    {
        public void Add(Product product)
        {
            Total = product.Price;
        }

        public decimal Total { get; private set; }
    }
}
