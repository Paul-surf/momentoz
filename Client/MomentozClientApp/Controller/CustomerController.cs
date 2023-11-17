using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MomentozClientApp.Model;
using MomentozClientApp.Servicelayer;

namespace MomentozClientApp.Controller
{
    public class CustomerController
    {
        public CustomerController() { }
        public async Task<List<Customer>?> getCustomers()
        {
            IServiceConnection ServiceConnection = new ServiceConnection();
            List<Customer>? customers = await ServiceConnection.GetCustomerDataAsync();
            return customers;
        }
        public async Task<String> grabJsonInfo()
        {
            ServiceConnection ServiceConnection = new ServiceConnection();
            String result = await ServiceConnection.establishConnection();
            return result;
        }
    }
}
