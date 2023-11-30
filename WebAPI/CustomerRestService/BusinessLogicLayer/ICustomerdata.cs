using RESTfulService.DTOs;

namespace RESTfulService.BusinessLogicLayer
{

    public interface ICustomerdata
    {

        CustomerDtoo? Get(int id);
        List<CustomerDtoo>? Get();
        CustomerDtoo Put(CustomerDtoo customerToUpdate);
        bool Delete(int id);
        CustomerDtoo? GetByUserId(string loginid);
        CustomerDtoo? Add(CustomerDtoo customerToAdd);
    }
}
