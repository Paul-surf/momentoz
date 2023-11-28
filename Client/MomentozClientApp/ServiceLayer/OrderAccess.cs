


using System.Configuration;
using Newtonsoft.Json;

using global::MomentozClientApp.ModelLayer;
using global::MomentozClientApp.Servicelayer;

namespace MomentozClientApp.ServiceLayer
{
    public class OrderAccess : IOrderAccess
    {
        readonly IServiceConnection _orderServiceConnection;
        readonly string? _serviceBaseUrl = ConfigurationManager.AppSettings.Get("ServiceUrlToUse");

        public OrderAccess()
        {
            _orderServiceConnection = new ServiceConnection(_serviceBaseUrl);
        }

        public async Task<List<Order>> GetOrderAll()
        {
            List<Order> listFromService = new List<Order>();
            _orderServiceConnection.UseUrl = _orderServiceConnection.BaseUrl + "orders";

            try
            {
                var serviceResponse = await _orderServiceConnection.CallServiceGet();
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    listFromService = JsonConvert.DeserializeObject<List<Order>>(content) ?? listFromService;
                }
            }
            catch
            {
                // Log the exception or handle it as needed
            }

            return listFromService;
        }

        public async Task<Order> GetOrderById(int id)
        {
            Order foundOrder = null;
            _orderServiceConnection.UseUrl = _orderServiceConnection.BaseUrl + "orders/" + id;

            try
            {
                var serviceResponse = await _orderServiceConnection.CallServiceGet();
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    foundOrder = JsonConvert.DeserializeObject<Order>(content);
                }
            }
            catch
            {
                // Log the exception or handle it as needed
            }

            return foundOrder;
        }

        public Task<int> CreateOrder(string newUsername, Order order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetOrderByUserId(string loginUserId)
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



        public Task<int> CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GeOrderById(int id)
        {
            throw new NotImplementedException();
        }

        Task<Order> IOrderAccess.GetOrderByUserId(string loginUserId)
        {
            throw new NotImplementedException();
        }

        // ... Resten af dine metoder her ...

        // Implementer de andre metoder baseret på interfacets krav, som du har gjort med GetCustomers og GetCustomerById
        // Husk at implementere alle metoder fra interfacet, også dem du måske endnu ikke har brug for; du kan markere dem med NotImplementedException(), indtil du har deres implementering klar.
    }
}
