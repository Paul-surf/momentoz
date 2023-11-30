using MomentozWebClient.ServiceLayer;
using MomentozWebClient.Models;

namespace MomentozWebClient.BusinessLogicLayer
{
    public class OrderLogic
    {


        private readonly OrderService _orderServiceAccess;

        public OrderLogic(IConfiguration inConfiguration)
        {
            _orderServiceAccess = new OrderService(inConfiguration);
        }



        public async Task<List<Order>> GetAllOrders()
        {
            List<Order> foundOrders;
            try
            {
                foundOrders = await _orderServiceAccess.GetAllOrders();
            }
            catch
            {
                foundOrders = null;
            }
            return foundOrders;
        }

        public async Task<Order> GetOrderByTicketId(int ticketId)
        {
            Order foundOrder;
            try
            {
                foundOrder = await _orderServiceAccess.getOrderByTicketId(ticketId);
            } 
            catch
            {
                foundOrder = null;
            }
            return foundOrder;
        }
    }
}
