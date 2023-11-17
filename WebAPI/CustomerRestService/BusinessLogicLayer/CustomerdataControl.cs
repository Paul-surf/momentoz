using CustomerData.ModelLayer;
using CustomerData.DatabaseLayer;
using CustomerRestService.DTOs;
using System;
using CustomerRestService.BusinessLogicLayer;

namespace CustomerRestService.BusinesslogicLayer
{

    public class CustomerdataControl : ICustomerdata
    {
        private readonly ICustomerAccess _customerAccess;

        public CustomerdataControl(ICustomerAccess inCustomerAccess) { 
            _customerAccess = inCustomerAccess;
            }


        public CustomerDto? Get(int idToMatch)
        {
            CustomerDto? foundCustomerDto;
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


        public List<CustomerDto>? Get()
        {
            List<CustomerDto>? foundDtos;
            try
            {
                List<Customer>? foundCustomers = _customerAccess.GetCustomerAll();
                foundDtos = ModelConversion.CustomerDtoConvert.FromCustomerCollection(foundCustomers);
            }
            catch
            {
                foundDtos = null;
            }
            return foundDtos;
        }


        public int Add(CustomerDto newCustomer)
        {
            int insertedId = 0;
            try
            {
                Customer? foundCustomer = ModelConversion.CustomerDtoConvert.ToCustomer(newCustomer);
                if (foundCustomer != null)
                {
                    insertedId = _customerAccess.CreateCustomer(foundCustomer);
                }
            }
            catch
            {
                insertedId = -1;
            }
            return insertedId;
        }


        public bool Put(CustomerDto customerToUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
