﻿using MomentozClientApp.DTOs;
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

        public CustomerDto? Get(int id)
        {
            try
            {

                var foundCustomer = _customerAccess.GetCustomerById(id).Result;
                return ModelConversion.CustomerDtoConvert.FromCustomer(foundCustomer);
            }
            catch
            {
                return null;
            }
        }

        public List<CustomerDto>? Get()
        {
            try
            {

                var foundCustomers = _customerAccess.GetCustomerAll().Result;
                return ModelConversion.CustomerDtoConvert.FromCustomerCollection(foundCustomers);
            }
            catch
            {
                return null;
            }
        }

        public int Add(CustomerDto customerToAdd)
        {
            try
            {
                var newCustomer = ModelConversion.CustomerDtoConvert.ToCustomer(customerToAdd);
                if (newCustomer != null)
                {
                    return _customerAccess.CreateCustomer(newCustomer).Result;
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        public bool Put(CustomerDto customerToUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CustomerDto? GetByUserId(string loginUserId)
        {
            try
            {
                var foundCustomer = _customerAccess.GetCustomerByUserId(loginUserId).Result;
                return foundCustomer != null ? ModelConversion.CustomerDtoConvert.FromCustomer(foundCustomer) : null;
            }
            catch
            {
                return null;
            }
        }
    }
}
