using System.Collections.Generic;

namespace Basket
{
    public interface IDiscountCalculator
    {
        decimal Calculate(List<BasketItem> basketItems);
    }
}