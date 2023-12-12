using DatabaseData.DatabaseLayer;
using DatabaseData.ModelLayer;
using Moq;
using Xunit;
using Microsoft.Extensions.Configuration;

namespace DataTest;

public class OrderDatabaseAccessTests
    {
        [Fact]
        public void CreateOrder_Test()
        {
            // Mock IConfiguration
            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration
                .Setup(config => config.GetConnectionString(It.IsAny<string>()))
                .Returns("Momentoz");

            // Opret en instans af OrderDatabaseAccess med den mocked IConfiguration
            var orderDatabaseAccess = new OrderDatabaseAccess(mockConfiguration.Object);

        var aOrder = new Order
        {
            // Angiv de nødvendige egenskaber for Order-klassen
            TotalPrice = 100.0,
            PurchaseDate = DateTime.Now,
            CustomerID = 1,
            FlightID = 1
        };

        // Act
        var result = orderDatabaseAccess.CreateOrder(aOrder);

        // Assert
        Assert.Equals(1, result); // Bekræft, at den returnerede ID er som forventet
    }
}
