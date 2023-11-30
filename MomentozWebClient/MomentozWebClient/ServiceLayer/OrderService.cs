using MomentozWebClient.ServiceLayer;
using Microsoft.Extensions.DependencyInjection;
using MomentozWebClient.Models;
using Newtonsoft.Json;

namespace MomentozWebClient.ServiceLayer
{
    public class OrderService : IOrderAccess

    {
        readonly IServiceConnection _orderServiceConnection;

        public OrderService(IConfiguration inConfiguration)
        {
            UseServiceUrl = inConfiguration["ServiceUrlToUse"];
            _orderServiceConnection = new ServiceConnection(UseServiceUrl);
        }

        public string UseServiceUrl { get; set; }


        public async Task<List<Order>>? GetAllOrders()
        {
            List<Order>? orderFromService = null;

            _orderServiceConnection.UseUrl = _orderServiceConnection.BaseUrl;
            _orderServiceConnection.UseUrl += "orders";


            if (_orderServiceConnection != null)
            {
                try
                {
                    var serviceResponse = await _orderServiceConnection.CallServiceGet();
                    if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                    {
                        var content = await serviceResponse.Content.ReadAsStringAsync();

                        orderFromService = JsonConvert.DeserializeObject<List<Order>>(content);

                    }
                    else
                    {
                        if (serviceResponse != null && serviceResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            orderFromService = new List<Order>();
                        }
                        else
                        {
                            orderFromService = null;
                        }
                    }
                }
                catch
                {
                    orderFromService = null;
                }
            }
            return orderFromService;
        }

        public bool AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Customer GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrdert(Order order)
        {
            throw new NotImplementedException();
        }

        Task<Order> IOrderAccess.GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IOrderAccess.AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        Task<bool> IOrderAccess.UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        Task<bool> IOrderAccess.DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> getOrderByTicketId(int ticketId)
        {
            Order? orderFromService = null;

            _orderServiceConnection.UseUrl = _orderServiceConnection.BaseUrl;
            _orderServiceConnection.UseUrl += "orders/" + ticketId;


            if (_orderServiceConnection != null)
            {
                try
                {
                    var serviceResponse = await _orderServiceConnection.CallServiceGet();
                    if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                    {
                        var content = await serviceResponse.Content.ReadAsStringAsync();

                        orderFromService = JsonConvert.DeserializeObject<Order>(content);

                    }
                    else
                    {
                        if (serviceResponse != null && serviceResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            orderFromService = new Order();
                        }
                        else
                        {
                            orderFromService = null;
                        }
                    }
                }
                catch
                {
                    orderFromService = null;
                }
            }
            return orderFromService;
        }
    }
}
