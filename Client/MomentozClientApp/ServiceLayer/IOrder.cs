using MomentozClientApp.ModelLayer;

namespace MomentozClientApp.ServiceLayer
{
    public interface IOrderAccess
    {
        Task<Order> GetOrderById(int id);
        Task<List<Order>> GetOrderAll();
        Task<int> CreateOrder(Order order);
        Task<bool> UpdateOrder(Order order);
        Task<bool> DeleteOrderById(int id);
        Task<Order> GetOrderByUserId(string loginUserId);
    }

}
