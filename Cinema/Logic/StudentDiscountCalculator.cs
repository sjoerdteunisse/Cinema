using System;
using Cinema.Domain;
using Microsoft.VisualBasic;

namespace Cinema.Logic
{
    public class StudentDiscountCalculator : IOrderPriceCalculator
    {
        public double CalculatePrice(Order order)
        {
            double price = 0;
            var ticketCount = order.MovieTicket.Count;

            for (var i = 0; i < ticketCount; i++)
            {
                if (i != 0 && i + 1 <= ticketCount && (i + 1) % 2 == 0)
                    continue;

                //local var to calculate with to see additions per ticket
                double localPrice = 0;
                var localTicket = order.MovieTicket[i];

                if (localTicket.IsPremiumTicket)
                    localPrice += 2;
                
                localPrice += localTicket.GetPrice();
                price += localPrice;
            }

            return price;
        }
    }
}
