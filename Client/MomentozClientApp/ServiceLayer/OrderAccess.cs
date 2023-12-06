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
            catch (Exception ex)
            {
                // Håndter fejl på en mere specifik måde
                Console.WriteLine("Fejl ved hentning af ordre: " + ex.Message);
            }

            return foundOrder;
        }

        public async Task<bool> CreateOrder(Order order)
        {
            var json = JsonConvert.SerializeObject(order);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var serviceConnection = _orderServiceConnection as ServiceConnection;

            if (serviceConnection != null)
            {
                try
                {
                    var response = await serviceConnection.HttpClient.PostAsync(serviceConnection.UseUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        // Logik for behandling af succesfuldt svar
                        return true;
                    }
                    else
                    {
                        // Logik for behandling af fejlsvar
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    // Logik for fejlhåndtering
                    // Du kan logge fejlen eller vise en fejlmeddelelse til brugeren
                    return false;
                }
            }
            else
            {
                // Håndter situationen, hvor serviceConnection er null
                // Det kan betyde, at _orderServiceConnection ikke er af typen ServiceConnection
                return false;
            }
        }

        Task<int> IOrderAccess.CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByUserId(string loginUserId)
        {
            throw new NotImplementedException();
        }



        // Resten af dine metoder...
    }
}
