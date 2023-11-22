using WebserverMomentoz.ServiceLayer;
using Microsoft.Extensions.DependencyInjection;
using WebserverMomentoz.Models;
using Newtonsoft.Json;

namespace WebserverMomentoz.ServiceLayer
{
    public class CustomerService : ICustomerAccess

    {
        readonly IServiceConnection _customerServiceConnection;

        public CustomerService(IConfiguration inConfiguration)
        {
            UseServiceUrl = inConfiguration["ServiceUrlToUse"];
            _customerServiceConnection = new ServiceConnection(UseServiceUrl);
        }

        public string UseServiceUrl { get; set; }


        public async Task<List<Customer>>? GetAllCustomers()
        {
            List<Customer>? customersFromService = null;

            _customerServiceConnection.UseUrl = _customerServiceConnection.BaseUrl;
            _customerServiceConnection.UseUrl += "customers";


            if (_customerServiceConnection != null)
            {
                try
                {
                    var serviceResponse = await _customerServiceConnection.CallServiceGet();
                    if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                    {
                        var content = await serviceResponse.Content.ReadAsStringAsync();

                        customersFromService = JsonConvert.DeserializeObject<List<Customer>>(content);
                        
                    }
                    else
                    {
                        if (serviceResponse != null && serviceResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            customersFromService = new List<Customer>();
                        }
                        else
                        {
                            customersFromService = null;
                        }
                    }
                }
                catch
                {
                    customersFromService = null;
                }
            }
            return customersFromService;
        }









        public bool AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        

        public Customer GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        Task<Customer> ICustomerAccess.GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICustomerAccess.AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICustomerAccess.UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICustomerAccess.DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
