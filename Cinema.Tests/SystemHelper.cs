using System;
using Cinema.Domain;

namespace Cinema.Tests
{
    public class SystemHelper
    {
        public static void RunOnAction(Action<Movie, MovieScreening, MovieTicket, Order> action)
        {
            var movie = new Movie(title: "Virus all over");
            var dateTime = DateTime.Parse("2005-05-04"); 
            
            var movieScreening = new MovieScreening(movie: movie, dateAndTime: dateTime, pricePerSeat: 15);
            var movieTicket = new MovieTicket(movieScreening: movieScreening, isPremiumTicket: true, seatRow: 10, seatNr: 10);

            var order = new Order(orderNr: 1, isStudentOrder: false);
            order.AddSeatReservation(ticket: movieTicket);
            order.AddSeatReservation(ticket: movieTicket);
            order.AddSeatReservation(ticket: movieTicket);
            order.AddSeatReservation(ticket: movieTicket);
            order.AddSeatReservation(ticket: movieTicket);
            order.AddSeatReservation(ticket: movieTicket);

            action(movie, movieScreening, movieTicket, order);
        }
    }
}
