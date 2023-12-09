using System.Configuration;
using System.Text;
using Newtonsoft.Json;
using MomentozClientApp.Model;
using MomentozClientApp.Servicelayer;

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
            catch (Exception ex)
            {
                // Håndter fejl på en mere specifik måde
                Console.WriteLine("Fejl ved hentning af ordrer: " + ex.Message);
            }

            return listFromService;
        }

        public async Task<Order> GetOrderById(int orderID)
        {
            Order foundOrder = null;
            _orderServiceConnection.UseUrl = _orderServiceConnection.BaseUrl + "orders/" + orderID;

            try
            {
                var serviceResponse = await _orderServiceConnection.CallServiceGet();
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    foundOrder = JsonConvert.DeserializeObject<Order>(content);
                }
            }
            catch (Exception ex)
            {
                // Håndter fejl på en mere specifik måde
                Console.WriteLine("Fejl ved hentning af ordre: " + ex.Message);
            }

            return foundOrder;
        }

        public async Task<Order> CreateOrder(Order orderToAdd)
        {
            var json = JsonConvert.SerializeObject(orderToAdd);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var serviceConnection = _orderServiceConnection as ServiceConnection;
            var requestUrl = serviceConnection?.BaseUrl + "orders";

            if (serviceConnection != null && requestUrl != null)
            {
                try
                {
                    var response = await serviceConnection.HttpClient.PostAsync(requestUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var createdOrderID = JsonConvert.DeserializeObject<int>(responseContent);
                        Order createdOrder = new Order();
                        createdOrder.OrderID = createdOrderID;
                        return orderToAdd; // Return the deserialized Order object
                    }
                    else
                    {
                        Console.WriteLine("Response was not successful: " + response.StatusCode);
                        return null; // Return null if the response was not successful
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return null; // Return null if an exception was thrown
                }
            }
            else
            {
                Console.WriteLine("Service connection or request URL is null.");
                return null; // Return null if the service connection or request URL was null
            }
        }


        Order IOrderAccess.GetOrderById(int orderID)
        {
            throw new NotImplementedException();
        }

        List<Order> IOrderAccess.GetOrderAll()
        {
            throw new NotImplementedException();
        }

        int IOrderAccess.CreateOrder(Order orderToAdd)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrder(Order orderToUpdate)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrderById(int orderID)
        {
            throw new NotImplementedException();
        }

        public Order? GetOrderByCustomerId(int orderID)
        {
            throw new NotImplementedException();
        }
    }
}

