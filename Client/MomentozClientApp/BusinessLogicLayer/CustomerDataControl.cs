using MomentozClientApp.Model;
using MomentozClientApp.Servicelayer;

namespace MomentozClientApp.BusinessLogicLayer
{
    public class CustomerDataControl : ICustomerdata
    {
        private readonly ICustomerAccess _customerAccess;

        public CustomerDataControl(ICustomerAccess inCustomerAccess)
        {
            _customerAccess = inCustomerAccess;
        }

        public Customer? Get(string email)
        {
            try
            {
                return _customerAccess.GetCustomerByEmail(email).Result;
            }
            catch
            {
                return null;
            }
        }


        public List<Customer>? Get()
        {
            try
            {
                return _customerAccess.GetCustomerAll().Result;
            }
            catch
            {
                return null;
            }
        }

        public int Add(Customer customerToAdd)
        {
            try
            {
                if (customerToAdd != null)
                {
                    return _customerAccess.CreateCustomer(customerToAdd).Result;
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        public bool Put(Customer customerToUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Customer? GetByUserId(string loginUserId)
        {
            try
            {
                return _customerAccess.GetCustomerByUserId(loginUserId).Result;
            }
            catch
            {
                return null;
            }
        }

        Customer ICustomerdata.Get(string email)
        {
            throw new NotImplementedException();
        }
    }
}
