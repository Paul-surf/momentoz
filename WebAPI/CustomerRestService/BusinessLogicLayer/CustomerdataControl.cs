using DatabaseData.ModelLayer;
using DatabaseData.DatabaseLayer;
using RESTfulService.DTOs;
using RESTfulService.BusinessLogicLayer;

namespace RESTfulService.BusinesslogicLayer
{

    public class CustomerdataControl : ICustomerdata
    {
        private readonly ICustomerAccess _customerAccess;

        public CustomerdataControl(ICustomerAccess inCustomerAccess) { 
            _customerAccess = inCustomerAccess;
           
        }
        public CustomerDtoo? Get(int idToMatch)
        {
            CustomerDtoo? foundCustomerDto;
            try
            {
                Customer? foundCustomer = _customerAccess.GetCustomerById(idToMatch);
                foundCustomerDto = ModelConversion.CustomerDtoConvert.FromCustomer(foundCustomer);
            }
            catch
            {
                foundCustomerDto = null;
            }
            return foundCustomerDto;
        }

        public List<CustomerDtoo>? Get(string? email)
        {
            List<CustomerDtoo>? foundDtos;
            try
            {
                List<Customer>? foundCustomers;
                if (email == null)
                {
                 foundCustomers = _customerAccess.GetCustomerAll();
                } else
                {

                  Customer c = _customerAccess.GetByEmail(email);
                    foundCustomers = new List<Customer> { c };
                }
                foundDtos = ModelConversion.CustomerDtoConvert.FromCustomerCollection(foundCustomers);
            }
            catch
            {
                foundDtos = null;
            }
            return foundDtos;
        }
        public CustomerDtoo? Add(CustomerDtoo customerToAdd)
        {
            CustomerDtoo? createdCustomer = null;
            try
            {
                Customer? dbCustomer = ModelConversion.CustomerDtoConvert.ToCustomer(customerToAdd);
                if (dbCustomer is not null)
                {
                    Customer createdDbCustomer = _customerAccess.CreateCustomerMinimal(dbCustomer);
                    createdCustomer = ModelConversion.CustomerDtoConvert.FromCustomer(dbCustomer);
                }
            }
            catch
            {

                createdCustomer = null;
            }
            return createdCustomer;
        }


        public CustomerDtoo Put(CustomerDtoo customerToUpdate)
        {
            CustomerDtoo? createdCustomer = null;
            try
            {
                Customer? dbCustomer = ModelConversion.CustomerDtoConvert.ToCustomer(customerToUpdate);
                if (dbCustomer is not null)
                {
                    Customer createdDbCustomer = _customerAccess.UpdateCustomer(dbCustomer);
                    createdCustomer = ModelConversion.CustomerDtoConvert.FromCustomer(dbCustomer);
                }
            }
            catch
            {

                createdCustomer = null;
            }
            return createdCustomer;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CustomerDtoo? GetByUserId(string loginUserId)
        {
            CustomerDtoo? foundCustomerDto = null;
            try
            {
                Customer? foundCustomer = _customerAccess.GetCustomerByUserId(loginUserId);
                if (foundCustomer != null)
                {
                    foundCustomerDto = ModelConversion.CustomerDtoConvert.FromCustomer(foundCustomer);
                }
            }
            catch
            {
                foundCustomerDto = null;
            }
            return foundCustomerDto;
        }

        public CustomerDtoo? GetByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
