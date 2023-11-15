using CustomerData.DatabaseLayer;
using CustomerData.ModelLayer;
using Xunit.Abstractions;

namespace PersonDataTest
{

    public class TestCustomerDataAccess
    {

        private readonly ITestOutputHelper _extraOutput;

        readonly private ICustomerAccess _personAccess;
         readonly string _connectionString = "Server=localhost,1401; Database=momentoz; User Id=sa; Password=Password1!; Encrypt=False;";
       // readonly string _connectionString = "Server=localhost,1401; Database=momentoz; User Id=sa; Password=Password1!; Encrypt=True; TrustServerCertificate=False; CertificateFile=<path-to-certificate>; CertificatePassword=<certificate-password>;";

        public TestCustomerDataAccess(ITestOutputHelper output)
        {
            _extraOutput = output;
            _personAccess = new CustomerDatabaseAccess(_connectionString);
        }
        [Fact]
        public void TestGetPersonAll()
        {
            // Arrange

            // Act
            List<Customer> readCustomers = _personAccess.GetCustomerAll();
            bool customersWereRead = (readCustomers.Count > 0);
            // Print additional output
            _extraOutput.WriteLine("Number of persons: " + readCustomers.Count);

            // Assert
            Assert.True(customersWereRead);
        }
    }
}
