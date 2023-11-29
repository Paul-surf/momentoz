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
        internal Task<bool> ValidateLogin(string brugernavn, string adgangskode)
        {
            if (brugernavn == "bigboss" && adgangskode == "")
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
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
     }
}
