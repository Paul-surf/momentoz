using RESTfulService.DTOs;

namespace RESTfulService.BusinessLogicLayer
{

    public interface ICustomerdata
    {

        CustomerDto? Get(int id);
        List<CustomerDto>? Get(string? email);
        CustomerDto Put(CustomerDto customerToUpdate);
        bool Delete(int id);
        CustomerDto? GetByUserId(string loginid);
        CustomerDto? Add(CustomerDto customerToAdd);
    }
}
