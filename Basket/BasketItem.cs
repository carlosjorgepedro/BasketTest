namespace Basket
{
    public class BasketItem
    {
        public BasketItem(string product, int count = 1)
        {
            Product = product;
            Count = count;
        }

        public int Count { get; set; }

        public string Product { get; }
    }
}