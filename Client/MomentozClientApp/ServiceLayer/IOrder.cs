using MomentozClientApp.Model;


// Definerer navneområdet for servicelaget i MomentozClientApp-applikationen.
namespace MomentozClientApp.ServiceLayer
{
    // IOrderAccess er et interface, der definerer kontrakten for ordreadgang.
    // Alle klasser, der implementerer dette interface, skal implementere disse metoder.
    public interface IOrderAccess
    {
        Order GetOrderById(int orderID);
        List<Order> GetOrderAll();
        int CreateOrder(Order orderToAdd);
        bool UpdateOrder(Order orderToUpdate);
        bool DeleteOrderById(int orderID);
        Order? GetOrderByCustomerId(int customerID);
    }
}
