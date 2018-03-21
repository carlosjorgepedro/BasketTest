namespace Basket
{
    public class PriceProvider : IPriceProvider
    {
        public decimal GetPrice(string productName)
        {
            switch (productName)
            {
                case Products.Bread:
                    return 1.00m;
                case Products.Milk:
                    return 1.15m;
                case Products.Butter:
                    return 0.80m;
                default: return 0.0m;
            }
        }
    }
}