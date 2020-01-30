using Cinema.Domain;
using System;
using Xunit;

namespace Cinema.Tests.Domain
{
    public class MovieTicketTests
    {

        [Fact]
        public void GetPrice_StateUnderTest_ExpectedBehavior()
        {
            SystemHelper.RunOnAction((movie, movieScreening, movieTicket, order) =>
            {
                // Act
                var result = movieTicket.GetPrice();

                // Assert
                Assert.Equal(15, result);
            });
        }

        [Fact]
        public void ToString_StateUnderTest_ExpectedBehavior()
        {
            SystemHelper.RunOnAction((movie, movieScreening, movieTicket, order) =>
            {
                // Act
                var result = movieTicket.ToString();

                // Assert
                Assert.Contains("Premium", result.ToString());
            });
        }
    }
}
