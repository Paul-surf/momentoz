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
        internal bool ValidateLogin(string brugernavn, string adgangskode)
        {
            if (brugernavn == "bigboss" && adgangskode == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Task<int> CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

     }
}
