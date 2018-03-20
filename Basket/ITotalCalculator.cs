using System.Collections.Generic;

namespace Basket
{
    public interface ITotalCalculator
    {
        decimal Calculate(List<BasketItem> basketItems);
    }
}