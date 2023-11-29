using MomentozClientApp.DTOs;

namespace MomentozClientApp.BusinessLogicLayer
{
    public interface ICustomerdata
    {

        CustomerDto Get(int id);
        List<CustomerDto>? Get();
        int Add(CustomerDto customerToAdd);
        bool Put(CustomerDto customerToUpdate);
        bool Delete(int id);
        CustomerDto? GetByUserId(string loginid);
    }
}
