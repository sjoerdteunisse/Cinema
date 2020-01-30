using Cinema.Extensions;
using System;
using Xunit;

namespace Cinema.Tests.Extensions
{
    public class DateExtensionsTests
    {
        [Fact]
        public void IsWeekend_StateUnderTest_ExpectedBehavior_Edge_End()
        {
            // Arrange
            DateTime dateTime = DateTime.Parse("2005-05-08");

            // Act
            var result = dateTime.IsWeekend();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsWeekend_StateUnderTest_ExpectedBehavior_Returns_False_On_Day_Before()
        {
            // Arrange
            DateTime dateTime = DateTime.Parse("2005-05-04");

            // Act
            var result = dateTime.IsWeekend();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsWeekend_StateUnderTest_ExpectedBehavior_Edge_Start()
        {
            // Arrange
            DateTime dateTime = DateTime.Parse("2005-05-07");

            // Act
            var result = dateTime.IsWeekend();

            // Assert
            Assert.True(result);
        }


        [Fact]
        public void IsReducedPriceDay_StateUnderTest_ExpectedBehavior_Edge_End()
        {
            // Arrange
            DateTime dateTime = DateTime.Parse("2005-05-05"); //thursday

            // Act
            var result = dateTime.IsReducedPriceDay();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsReducedPriceDay_StateUnderTest_ExpectedBehavior_Edge_Middle()
        {
            // Arrange
            DateTime dateTime = DateTime.Parse("2005-05-04"); //thursday

            // Act
            var result = dateTime.IsReducedPriceDay();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsReducedPriceDay_StateUnderTest_ExpectedBehavior_Edge_Start()
        {
            // Arrange
            DateTime dateTime = DateTime.Parse("2005-05-02"); //monday

            // Act
            var result = dateTime.IsReducedPriceDay();

            // Assert
            Assert.True(result);
        }
    }
}
