using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MomentozClientApp.Model;

namespace MomentozClientApp.Servicelayer
{
    public interface ICustomerServiceAccess
    {
        Task<List<Customer>?>? GetCustomers(int id = -1);
        Task<int> SaveCustomer(Customer personToSave);
    }
}
