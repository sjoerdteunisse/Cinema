using System;
using System.Dynamic;
using Cinema.Domain;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            var movie = new Movie(title: "Virus all over");
            
            //Virus movie will always start two hours from now
            var movieScreening = new MovieScreening(movie: movie, dateAndTime: DateTime.Now.AddDays(1), pricePerSeat: 15);
            var movieTicket = new MovieTicket(movieScreening: movieScreening, isPremiumTicket: true, seatRow: 10, seatNr: 10);

            var order = new Order(orderNr:1, isStudentOrder:false);
            order.AddSeatReservation(ticket: movieTicket);
            order.AddSeatReservation(ticket: movieTicket);
            order.AddSeatReservation(ticket: movieTicket);
            order.AddSeatReservation(ticket: movieTicket);
            order.AddSeatReservation(ticket: movieTicket);
            order.AddSeatReservation(ticket: movieTicket);

            PrintMovieStats(movieTicket);

            Console.WriteLine("Print Order price");
            Console.WriteLine(order.CalculatePrice());

            Console.ReadLine();
        }

        private static void PrintMovieStats(MovieTicket movieTicket)
        {
            Console.WriteLine("Confirmation");
            Console.WriteLine(movieTicket);
            Console.WriteLine($"Price for ticket {movieTicket.GetPrice()} pesos");
            Console.WriteLine("____________\n");
        }
    }
}
