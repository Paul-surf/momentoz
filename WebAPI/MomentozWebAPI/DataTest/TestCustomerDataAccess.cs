using DatabaseData.DatabaseLayer;
using DatabaseData.ModelLayer;
using Xunit;
using Xunit.Abstractions;

namespace DataTest
{
    [TestClass]
    public class TestCustomerDataAccess
    {
        private readonly ITestOutputHelper _extraOutput;
        readonly private ICustomerAccess _customerAccess;
        readonly string _connectionString = "Server=hildur.ucn.dk; Database=DMA-CSD-S222_10461241; User Id=DMA-CSD-S222_10461241; Password=Password1!; Encrypt=False;";
        // readonly string _connectionString = "Server=localhost,1401; Database=momentoz; User Id=sa; Password=Password1!; Encrypt=True; TrustServerCertificate=False; CertificateFile=<path-to-certificate>; CertificatePassword=<certificate-password>;";

        public TestCustomerDataAccess(ITestOutputHelper output)
        {
            _extraOutput = output;
            _customerAccess = new CustomerDatabaseAccess(_connectionString);
        }
        [Fact]
        public void TestGetCustomerAll()
        {
            // Arrange
            _customerAccess = new CustomerDatabaseAccess(_connectionString);
            // Act
            List<Customer> readCustomers = _customerAccess.GetCustomerAll();
            bool customersWereRead = (readCustomers.Count > 0);
            // Print additional output
            _extraOutput.WriteLine("Number of customers: " + readCustomers.Count);

            // Assert
            Assert.IsTrue(customersWereRead);
        }
    }
}