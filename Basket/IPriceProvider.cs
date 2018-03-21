namespace Basket
{
    public interface IPriceProvider
    {
        decimal GetPrice(string productName);
    }
}
