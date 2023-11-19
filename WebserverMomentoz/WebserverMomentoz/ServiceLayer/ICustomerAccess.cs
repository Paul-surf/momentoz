using WebserverMomentoz.Models;

namespace WebserverMomentoz.ServiceLayer
{
    public interface ICustomerAccess
    {

        Task<List<Customer>>? GetAllCustomers();

        Task<Customer> GetCustomer(int id);

        Task<bool> AddCustomer(Customer customer);

        Task<bool> UpdateCustomer(Customer customer);

        Task<bool> DeleteCustomer(int id);
    }
}
