using Cinema.Domain;

namespace Cinema.Logic
{
    interface IOrderPriceCalculator
    {
        double CalculatePrice(Order order);
    } 
}
