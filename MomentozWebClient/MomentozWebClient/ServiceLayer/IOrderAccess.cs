using MomentozWebClient.Models;

namespace MomentozWebClient.ServiceLayer
{
    public interface IOrderAccess
    {

        Task<List<Order>>? GetAllOrders();

        Task<Order> GetOrder(int id);

        Task<bool> AddOrder(Order order);

        Task<bool> UpdateOrder(Order order);

        Task<bool> DeleteOrder(int id);

    }
}

