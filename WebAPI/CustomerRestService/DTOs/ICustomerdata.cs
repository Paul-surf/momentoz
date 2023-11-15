﻿namespace CustomerRestService.DTOs
{

    public interface ICustomerdata
    {

        CustomerDto? Get(int id);
        List<CustomerDto>? Get();
        int Add(CustomerDto customerToAdd);
        bool Put(CustomerDto customerToUpdate);
        bool Delete(int id);

    }
}
