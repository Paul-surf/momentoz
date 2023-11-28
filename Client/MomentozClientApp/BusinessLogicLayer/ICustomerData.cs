using MomentozClientApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
