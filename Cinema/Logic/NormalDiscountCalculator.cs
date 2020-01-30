using System.Linq;
using Cinema.Domain;
using Cinema.Extensions;

namespace Cinema.Logic
{
    public class NormalDiscountCalculator : IOrderPriceCalculator
    {
        /// <summary>
        /// Calculate price for non students;
        /// Rules:
        /// >=6 = price * 0.90
        /// day of week in range of mo-thu = second card free
        /// </summary>
        /// <param name="order"></param>
        /// <returns>Calculated price for the order based on given params</returns>
        public double CalculatePrice(Order order)
        {
            //Precision for extendability
            double discountModifier = 0;

            //Assuming that everybody days tickets for the same movie at the same time.
            var isWeekend = order.MovieTicket.FirstOrDefault()?.MovieScreening?.DateTimeLive.IsWeekend();
            
            //Cast required for nullable bool
            if (isWeekend == true)
            {
                if (order.MovieTicket.Count >= 6)
                    discountModifier = 10;
            }

            return SumPrice(discountModifier, order);
        }

        private double SumPrice(double discountModifier, Order order)
        {
            var freeSecondCardDay =
                order.MovieTicket.FirstOrDefault()?.MovieScreening?.DateTimeLive.IsReducedPriceDay();

            double totalPrice = 0;
            var ticketCount = order.MovieTicket.Count;

            for (var i = 0; i < ticketCount; i++)
            {
                //Check if free card is applicable
                if ( i != 0 && freeSecondCardDay == true && i + 1 <= ticketCount && (i + 1) % 2 == 0 )
                    continue;

                var movieTicket = order.MovieTicket[i];
                double local = 0;
                //Check premium
                if (movieTicket.IsPremiumTicket)
                    local += 3;

                //Set local to price
                local += movieTicket.GetPrice();

                //Finally add to total
                totalPrice += (local / 100) * (100 - discountModifier);
            }

            return totalPrice;
        }
    }
}
