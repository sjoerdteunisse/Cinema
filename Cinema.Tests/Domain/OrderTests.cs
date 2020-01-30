using Cinema.Domain;
using Xunit;

namespace Cinema.Tests.Domain
{
    public class OrderTests
    {
        [Fact]
        public void GetOrderNr_StateUnderTest_ExpectedBehavior()
        {
            SystemHelper.RunOnAction((movie, movieScreening, movieTicket, order) =>
            {
                // Act
                var result = order.GetOrderNr();

                // Assert
                Assert.Equal(1, result);
            });
        }

        [Fact]
        public void AddSeatReservation_StateUnderTest_ExpectedBehavior()
        {
            SystemHelper.RunOnAction((movie, movieScreening, movieTicket, order) =>
            {
                MovieTicket t = new MovieTicket(movieScreening, true, 1, 2);
                var shouldBe = order.CalculatePrice() + 18;

                // Act
                order.AddSeatReservation(
                    t);

                // Assert
                Assert.Equal(shouldBe, order.CalculatePrice());
            });
        }

        [Fact]
        public void CalculatePrice_StateUnderTest_ExpectedBehavior()
        {
            SystemHelper.RunOnAction((movie, movieScreening, movieTicket, order) =>
            {
                // Act
                var result = order.CalculatePrice();

                // Assert
                Assert.Equal(54, result);
            });
        }


        [Fact]
        public void Export_Prints_Properly_For_JSON()
        {
            SystemHelper.RunOnAction((movie, movieScreening, movieTicket, order) =>
            {
                // Act
                order.Export(TicketExportFormat.JSON);

                var fileNameStart = $"Order_{order.GetOrderNr()}.json";
                using var file = new System.IO.StreamReader(path: fileNameStart);
                var line = file.ReadLine();
                
                // Assert
                var movieName = order.ToString().Split("-")[0].Trim();
                Assert.Contains(movieName, line);
            });
        }


        [Fact]
        public void Export_Prints_Properly_For_txt()
        {
            SystemHelper.RunOnAction((movie, movieScreening, movieTicket, order) =>
            {
                // Act
                order.Export(TicketExportFormat.PLAINTEXT);

                var fileNameStart = $"Order_{order.GetOrderNr()}.txt";
                using var file = new System.IO.StreamReader(path: fileNameStart);
                var line = file.ReadLine();

                // Assert
                Assert.Contains(order.ToString(), line);
            });
        }

        [Fact]
        public void Order_ToString()
        {
            SystemHelper.RunOnAction((movie, movieScreening, movieTicket, order) =>
            {
                // Act
                var name = order.ToString();

                // Assert
                Assert.Contains("for a total of", name);
            });
        }
    }
}
