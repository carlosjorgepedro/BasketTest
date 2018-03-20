namespace Basket
{
    public class BasketItem
    {
        public BasketItem(Product product, int count = 1)
        {
            Product = product;
            Count = count;
        }

        public int Count { get; set; }

        public Product Product { get; }
    }
}