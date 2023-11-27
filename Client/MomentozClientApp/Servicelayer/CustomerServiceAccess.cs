using MomentozClientApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MomentozClientApp.Servicelayer
{
    public class CustomerServiceAccess : ICustomerAccess
    {
        readonly IServiceConnection _customerService; 
        readonly String _serviceBaseUrl = "https://localhost:5114/api/customers"; 
        public CustomerServiceAccess() {
            _customerService = new ServiceConnection(_serviceBaseUrl); 
        }
        // Method to retrieve Customer(s)
        public async Task<List<Customer>> GetCustomers(int id = -1)
        {
            List<Customer>? customerFromService = null;

            if (_customerService != null)
            {
                _customerService.UseUrl = _customerService.BaseUrl;
                bool oneCustomerById = (id > 0);
                if (oneCustomerById)
                {
                    _customerService.UseUrl += id;
                }
                try
                {
                    var serviceResponse = await _customerService.CallServiceGet();
                    // If success (200-299)
                    if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                    {
                        // 200 with data returned
                        if (serviceResponse.StatusCode == HttpStatusCode.OK)
                        {
                            var responseData = await serviceResponse.Content.ReadAsStringAsync();
                            // If 1 Customer returned - else all Customers returned
                            if (oneCustomerById)
                            {
                                Customer? foundCustomer = JsonConvert.DeserializeObject<Customer>(responseData);
                                if (foundCustomer != null)
                                {
                                    customerFromService = new List<Customer> { foundCustomer }; // Must return List
                                }
                            }
                            else
                            {
                                customerFromService = JsonConvert.DeserializeObject<List<Customer>>(responseData);
                            }
                        }
                        // 204 no data
                        else if (serviceResponse.StatusCode == HttpStatusCode.NoContent)
                        {
                            customerFromService = new List<Customer>(); 
                        }
                    }
                }
                catch
                {
                    customerFromService = null;
                }
            }

            return customerFromService;
        }

        public async Task<int> SaveCustomer(Customer customerToSave)
        {
            if (_customerService != null)
            {
                _customerService.UseUrl = _customerService.BaseUrl;
                try
                {
                    var json = JsonConvert.SerializeObject(customerToSave);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    var serviceResponse = await _customerService.CallServicePost(data);
                    if (serviceResponse.IsSuccessStatusCode)
                    {
                        var responseData = await serviceResponse.Content.ReadAsStringAsync();
                        var savedCustomer = JsonConvert.DeserializeObject<Customer>(responseData);
                        return savedCustomer?.Id ?? 0; // Assuming Id is the identifier in Customer
                    }
                    else
                    {
                        // Handle the case where the API response is not successful
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (ex.Message)
                    // Handle exceptions (e.g., network error, no response from server)
                    return 0;
                }
            }

            return 0;
        }

    }
}
