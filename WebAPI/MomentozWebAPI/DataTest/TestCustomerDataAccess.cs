using DatabaseData.DatabaseLayer;
using DatabaseData.ModelLayer;
using Xunit;
using Xunit.Abstractions;

namespace DataTest
{
    public class TestCustomerDataAccess
    {
        private readonly ITestOutputHelper _extraOutput;
        private readonly ICustomerAccess _customerAccess;
        private readonly IFlightAccess _flightAccess;

        public TestCustomerDataAccess(ITestOutputHelper output)
        {
            _extraOutput = output;
            _customerAccess = new CustomerDatabaseAccess("Server=hildur.ucn.dk; Database=DMA-CSD-S222_10461241; User Id=DMA-CSD-S222_10461241");
            _flightAccess = new FlightDatabaseAccess("Server=hildur.ucn.dk; Database=DMA-CSD-S222_10461241; User Id=DMA-CSD-S222_10461241");
        }

        [Fact]
        public void TestGetCustomerAll()
        {
            // Arrange is done in the constructor

            // Act
            List<Customer> readCustomers = _customerAccess.GetCustomerAll();
            bool customersWereRead = readCustomers.Any(); // Using LINQ to check if any customers were read

            // Print additional output
            _extraOutput.WriteLine("Number of customers: " + readCustomers.Count);

            // Assert
            Assert.IsTrue(customersWereRead);
        }

        [Fact]
        public void TestGetFlightAll()
        {
            // Arrange is done in the constructor

            // Act
            List<Flight> readFlights = _flightAccess.GetFlightAll();
            bool flightsWereRead = readFlights.Any(); // Using LINQ to check if any flights were read

            // Print additional output
            _extraOutput.WriteLine("Number of flights: " + readFlights.Count);

            // Assert
            Assert.IsTrue(flightsWereRead);
        }
    }
}
