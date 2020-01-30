using Cinema.Domain;
using System;
using Xunit;

namespace Cinema.Tests.Domain
{
    public class MovieTests
    {
        [Fact]
        public void GetTitle_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var movie = new Movie("test");

            // Act
            var result = movie.GetTitle();

            // Assert
            Assert.Equal("test", result);
        }

        [Fact]
        public void AddScreening_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var movie = new Movie("test");
            var liveDate = DateTime.Now;
            MovieScreening screening = new MovieScreening(movie, liveDate , 15);

            // Act
            movie.AddScreening(
                screening);

            // Assert
            Assert.Equal("test", screening.Movie.GetTitle());
            Assert.Equal(15, screening.GetPricePerSeat());
            Assert.Equal("test", movie.GetTitle());
            Assert.Equal(liveDate, screening.DateTimeLive);
        }
    }
}
