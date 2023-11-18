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
        readonly ICustomerServiceAccess _cAccess; 
        public CustomerController() { 
            _cAccess = new CustomerServiceAccess(); 
        }
        public async Task<List<Customer>?> GetAllCustomers() { 
            List<Customer>? foundCustomers = null;
            if (_cAccess != null) { 
                foundCustomers = await _cAccess.GetCustomers(); 
            } return foundCustomers; 
        }
        public async Task<int> SavePerson(string fName, string lName, string mPhone) {
            Customer newCustomer = new(fName, lName, mPhone); 
            int insertedId = await _cAccess.SaveCustomer(newCustomer);
            return insertedId; 
        }
    }
}
