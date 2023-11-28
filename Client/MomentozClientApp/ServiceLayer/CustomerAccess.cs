using MomentozClientApp.ModelLayer;
using System.Configuration;
using Newtonsoft.Json;
using MomentozClientApp.Servicelayer;

namespace MomentozClientApp.ServiceLayer
{
    public class CustomerAccess : ICustomerAccess
    {
        readonly IServiceConnection _customerServiceConnection;
        readonly string? _serviceBaseUrl = ConfigurationManager.AppSettings.Get("ServiceUrlToUse");

        public CustomerAccess()
        {
            _customerServiceConnection = new ServiceConnection(_serviceBaseUrl);
        }

        public async Task<List<Customer>> GetCustomerAll()
        {
            List<Customer> listFromService = new List<Customer>();
            _customerServiceConnection.UseUrl = _customerServiceConnection.BaseUrl + "customers";

            try
            {
                var serviceResponse = await _customerServiceConnection.CallServiceGet();
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    listFromService = JsonConvert.DeserializeObject<List<Customer>>(content) ?? listFromService;
                }
            }
            catch
            {
                // Log the exception or handle it as needed
            }

            return listFromService;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            Customer foundCustomer = null;
            _customerServiceConnection.UseUrl = _customerServiceConnection.BaseUrl + "customers/" + id;

            try
            {
                var serviceResponse = await _customerServiceConnection.CallServiceGet();
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    foundCustomer = JsonConvert.DeserializeObject<Customer>(content);
                }
            }
            catch
            {
                // Log the exception or handle it as needed
            }

            return foundCustomer;
        }

        public Task<int> CreateCustomer(string newUsername, Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerByUserId(string loginUserId)
        {
            throw new NotImplementedException();
        }
        internal async Task<bool> ValidateLogin(string brugernavn, string adgangskode)
        {
            // Tjek om brugernavnet er "bigboss" og adgangskoden er "1234".
            if (brugernavn == "bigboss" && adgangskode == "1234")
            {
                // Brugernavn og adgangskode er korrekte, så returner true (gyldigt login).
                return true;
            }
            else
            {
                // Brugernavn og adgangskode er ikke korrekte, så returner false (ugyldigt login).
                return false;
            }
        }



        public Task<int> CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        // ... Resten af dine metoder her ...

        // Implementer de andre metoder baseret på interfacets krav, som du har gjort med GetCustomers og GetCustomerById
        // Husk at implementere alle metoder fra interfacet, også dem du måske endnu ikke har brug for; du kan markere dem med NotImplementedException(), indtil du har deres implementering klar.
    }
}
