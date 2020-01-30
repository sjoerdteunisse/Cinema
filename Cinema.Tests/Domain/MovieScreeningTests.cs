using System;
using Xunit;
using Cinema.Domain;

namespace Cinema.Tests.Domain
{
    public class MovieScreeningTests
    {
        [Fact]
        public void GetPricePerSeat_StateUnderTest_ExpectedBehavior()
        {
            Movie movie = new Movie("Sea food all over");

            // Arrange
            var movieScreening = new MovieScreening(movie, DateTime.Now, 15);

            // Act
            var result = movieScreening.GetPricePerSeat();

            // Assert
            Assert.Equal(15, result);
        }

        [Fact]
        public void ToString_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Movie movie = new Movie("Sea food all over");


            // Arrange
            var date = DateTime.Now;
            var movieScreening = new MovieScreening(movie, DateTime.Now, 15);

            // Act
            var result = movieScreening.ToString();

            // Assert
            Assert.Contains(date.ToString(), movieScreening.ToString());
        }

        [Fact]
        public void ToString_StateUnderTest_ExpectedBehavior_Not_Contain_Price()
        {
            // Arrange
            Movie movie = new Movie("Sea food all over");


            // Arrange
            var date = DateTime.Now;
            var movieScreening = new MovieScreening(movie, DateTime.Now, 15);

            // Act
            var result = movieScreening.ToString();

            // Assert
            Assert.Contains(date.ToString(), result);
            Assert.DoesNotContain(movieScreening.GetPricePerSeat().ToString(), result);
        }
    }
}
