// Inkluderer ModelLayer-navneområdet, som indeholder data-modellerne, herunder Customer-modellen.
// Inkluderer også nødvendige navneområder for konfiguration og JSON-håndtering.
using MomentozClientApp.ModelLayer;
using System.Configuration;
using Newtonsoft.Json;
using MomentozClientApp.Servicelayer;
using System.Diagnostics;

// Definerer navneområdet for servicelaget i MomentozClientApp-applikationen.
namespace MomentozClientApp.ServiceLayer
{
    // CustomerAccess-klassen implementerer ICustomerAccess-interface og håndterer adgang til kundeoplysninger.
    public class CustomerAccess : ICustomerAccess
    {
        // En skrivebeskyttet instans af IServiceConnection, der bruges til at håndtere forbindelser til webtjenester.
        readonly IServiceConnection _customerServiceConnection;
        // Basis-URL'en til servicen, hentet fra applikationskonfigurationen.
        readonly string? _serviceBaseUrl = ConfigurationManager.AppSettings.Get("ServiceUrlToUse");

        // Konstruktøren initialiserer CustomerAccess-klassen.
        public CustomerAccess()
        {
            // Initialiserer _customerServiceConnection med en ny instans af ServiceConnection.
            _customerServiceConnection = new ServiceConnection(_serviceBaseUrl);
        }

        // Asynkron metode til at hente alle kunder.
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
            catch (Exception ex)
            {
                // Log the exception and handle it as per your error handling policy
                Debug.WriteLine($"An error occurred while fetching all customers: {ex.Message}");
                // Depending on the policy, you might want to rethrow, return an empty list, or handle the exception differently
            }

            return listFromService;
        }

        // Asynkron metode til at hente en kunde baseret på dens id.
        public async Task<Customer> GetCustomerByEmail(string email)
        {
            Customer  foundCustomer = null;
            List<Customer> foundCustomers = null;
            // Assuming that the base URL ends with "/", if not you might need to adjust this line.
            _customerServiceConnection.UseUrl = $"{_customerServiceConnection.BaseUrl}customers?email={Uri.EscapeDataString(email)}";

            try
            {
                var serviceResponse = await _customerServiceConnection.CallServiceGet();
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    foundCustomers = JsonConvert.DeserializeObject<List<Customer>>(content);
                    foundCustomer = foundCustomers.First();
                }
            }
            catch (Exception ex)
            {
                // Log the exception and handle it as per your error handling policy
                Debug.WriteLine($"An error occurred while fetching customer by email: {ex.Message}");
                // Depending on the policy, you might want to rethrow, return null, or handle the exception differently
            }

            return foundCustomer;
        }



        // Metoder, der endnu ikke er implementeret, og som kaster NotImplementedException.
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



        // Stub for at oprette en kunde.
        public Task<int> CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();


        }
    }
}