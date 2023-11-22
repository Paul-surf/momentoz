using MomentozWebClient.Models;
using MomentozWebClient.ServiceLayer;

namespace MomentozWebClient.BusinessLogicLayer
{
    public class CustomerLogic
    {


        private readonly CustomerService _customerServiceAccess;

        public CustomerLogic(IConfiguration inConfiguration)
        {
            _customerServiceAccess = new CustomerService(inConfiguration);
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            List<Customer> foundCustomers;
            try
            {
                foundCustomers = await _customerServiceAccess.GetAllCustomers();
            }
            catch
            {
                foundCustomers = null;
            }
            return foundCustomers;
        }
    }
}
