using System.Collections.Generic;

namespace Basket
{
    public interface IDiscount
    {
        decimal GetDiscount(List<BasketItem> basketItem);
    }
}