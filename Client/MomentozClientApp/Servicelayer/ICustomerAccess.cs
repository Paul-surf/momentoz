using MomentozClientApp.ModelLayer;

namespace MomentozClientApp.Servicelayer
{

    public interface ICustomerAccess
    {
        Task<Customer> GetCustomerById(int id);
        Task<List<Customer>> GetCustomerAll();
        Task<int> CreateCustomer(Customer customer);
        Task<bool> UpdateCustomer(Customer customer);
        Task<bool> DeleteCustomerById(int id);
        Task<Customer> GetCustomerByUserId(string loginUserId);
    }

}
