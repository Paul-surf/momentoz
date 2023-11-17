using MomentozClientApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomentozClientApp.Servicelayer
{
    internal interface IServiceConnection
    {
        Task<String> establishConnection();
        Task<List<Customer>?> GetCustomerDataAsync();
    }
}
