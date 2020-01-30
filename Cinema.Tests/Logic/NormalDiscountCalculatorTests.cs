using System;
using Cinema.Domain;
using Cinema.Logic;
using Xunit;

namespace Cinema.Tests.Logic
{
    public class NormalDiscountCalculatorTests
    {
        [Fact]
        public void CalculatePrice_StateUnderTest_ExpectedBehavior()
        {
            SystemHelper.RunOnAction((movie, movieScreening, movieTicket, order) =>
            {
                // Arrange
                var normalDiscountCalculator = new NormalDiscountCalculator();

                // Act
                var result = normalDiscountCalculator.CalculatePrice(
                    order);

                // Assert

                // As three are discounted on the day of Sytem Helper data for a non student.
                Assert.Equal((movieTicket.GetPrice() + 3) * 3, result);
            });
        }

        [Fact]
        public void CalculatePrice_StateUnderTest_ExpectedBehavior_Edge_Start()
        {
            SystemHelper.RunOnAction((movie, movieScreening, movieTicket, order) =>
            {
                // Arrange
                var normalDiscountCalculator = new NormalDiscountCalculator();

                DateTime dateTime = DateTime.Parse("2005-05-06"); //friday
                movieScreening = new MovieScreening(movie, dateTime, 15);


                var newOrder = new Order(12, false);

                var x = new MovieTicket[2]
                {
                    new MovieTicket(movieScreening, true, 1, 2),
                    new MovieTicket(movieScreening, true, 1, 2)
                };

                foreach (var movieTicketSelect in x)
                {
                    newOrder.AddSeatReservation(movieTicketSelect);
                }


                // Act
                var result = normalDiscountCalculator.CalculatePrice(
                    newOrder);

                // Assert
                // Full amount as day is friday.
                Assert.Equal((x[0].GetPrice() + 3) * x.Length, result);
            });
        }

        [Fact]
        public void CalculatePrice_StateUnderTest_ExpectedBehavior_Edge_WeekEnd()
        {
            SystemHelper.RunOnAction((movie, movieScreening, movieTicket, order) =>
            {
                // Arrange
                var normalDiscountCalculator = new NormalDiscountCalculator();

                DateTime dateTime = DateTime.Parse("2005-05-08"); //Sun
                movieScreening = new MovieScreening(movie, dateTime, 15);


                var newOrder = new Order(12, false);

                var x = new MovieTicket[2]
                {
                    new MovieTicket(movieScreening, true, 1, 2),
                    new MovieTicket(movieScreening, true, 1, 2)
                };

                foreach (var movieTicketSelect in x)
                {
                    newOrder.AddSeatReservation(movieTicketSelect);
                }


                // Act
                var result = normalDiscountCalculator.CalculatePrice(
                    newOrder);

                // Assert
                // Full amount as day is friday.
                Assert.Equal((x[0].GetPrice() + 3) * x.Length, result);
            });
        }

        [FactAttribute]
        public void CalculatePrice_StateUnderTest_ExpectedBehavior_Edge_End()
        {
            SystemHelper.RunOnAction((movie, movieScreening, movieTicket, order) =>
            {
                // Arrange
                var normalDiscountCalculator = new NormalDiscountCalculator();

                DateTime dateTime = DateTime.Parse("2005-05-05"); //friday
                //overwrite
                movieScreening = new MovieScreening(movie, dateTime, 15);

                var newOrder = new Order(12, false);

                var x = new MovieTicket[2]
                {
                        new MovieTicket(movieScreening, true, 1, 2),
                        new MovieTicket(movieScreening, true, 1, 2)
                };

                foreach (var movieTicketSelect in x)
                {
                    newOrder.AddSeatReservation(movieTicketSelect);
                }


                // Act
                var result = normalDiscountCalculator.CalculatePrice(
                newOrder);

                // Assert
                // Only one card, as second is free on applicable days.
                Assert.Equal((x[0].GetPrice() + 3), result);
            });
        }



        [Fact]
        public void CalculatePrice_StateUnderTest_ExpectedBehavior_Sum()
        {
            SystemHelper.RunOnAction((movie, movieScreening, movieTicket, order) =>
            {
                // Arrange
                var normalDiscountCalculator = new NormalDiscountCalculator();

                DateTime dateTime = DateTime.Parse("2005-05-05"); //Thursday
                //overwrite
                movieScreening = new MovieScreening(movie, dateTime, 15);
                
                var newOrder = new Order(12, false);

                var x = new MovieTicket[6]
                {
                    new MovieTicket(movieScreening, true, 1, 2),
                    new MovieTicket(movieScreening, true, 1, 2),
                    new MovieTicket(movieScreening, true, 1, 2),
                    new MovieTicket(movieScreening, true, 1, 2),
                    new MovieTicket(movieScreening, true, 1, 2),
                    new MovieTicket(movieScreening, true, 1, 2)
                };

                foreach (var movieTicketSelect in x)
                {
                    newOrder.AddSeatReservation(movieTicketSelect);
                }


                // Act
                var result = normalDiscountCalculator.CalculatePrice(
                    newOrder);

                // Assert
                // Discount for 3 cards.
                Assert.Equal((x[0].GetPrice() + 3) * 3, result);
            });
        }
    }
}
