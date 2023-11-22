using DatabaseData.ModelLayer;


namespace DatabaseData.DatabaseLayer
{

    public interface ICustomerAccess
    {

        Customer GetCustomerById(int id);
        List<Customer> GetCustomerAll();
        int CreateCustomer(Customer customerToAdd);
        bool UpdateCustomer(Customer customerToUpdate);
        bool DeleteCustomerById(int id);

    }
}
