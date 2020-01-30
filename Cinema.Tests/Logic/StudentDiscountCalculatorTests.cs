using System;
using Xunit;
using Cinema.Logic;
using Cinema.Domain;

namespace Cinema.Tests.Logic
{
    public class StudentDiscountCalculatorTests
    {
        public void RunStudentCalculator(
            Action<MovieTicket[], Order,
            MovieScreening, double> movieAction
            )
        {
            // Arrange
            var normalDiscountCalculator = new NormalDiscountCalculator();
            var movie = new Movie(title: "Virus all over");

            var dateTime = DateTime.Parse("2005-05-06"); //friday
            var movieScreening = new MovieScreening(movie, dateTime, 15);

            var newOrder = new Order(12, true);

            var movies = new MovieTicket[2]
            {
                new MovieTicket(movieScreening, true, 1, 2),
                new MovieTicket(movieScreening, true, 1, 2)
            };

            foreach (var movietTicketSelect in movies)
            {
                newOrder.AddSeatReservation(movietTicketSelect);
            }

            // Act
            var resultSum = normalDiscountCalculator.CalculatePrice(
                newOrder);

            movieAction(movies, newOrder, movieScreening, resultSum);
        }


        [Fact]
        public void CalculatePrice_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var studentDiscountCalculator = new StudentDiscountCalculator();

            RunStudentCalculator((movies, newOrder, movieScreeningStudent, resultSum) =>
            {
                // Act
                var result = studentDiscountCalculator.CalculatePrice(
                    newOrder);

                //One premium card = 15 + 2 = 17; One because students get second free card.
                Assert.Equal(17, result); 
            });

        }
    }
}
