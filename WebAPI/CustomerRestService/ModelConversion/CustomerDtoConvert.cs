using CustomerData.ModelLayer;
using CustomerRestService.DTOs;
using System;
using System.Collections.Generic;

namespace CustomerRestService.ModelConversion
{
    public class CustomerDtoConvert
    {
        // Convert from Customer objects to CustomerDTO objects
        public static List<CustomerDto> FromCustomerCollection(List<Customer> inCustomers)
        {
            var aCustomerReadDtoList = new List<CustomerDto>();
            foreach (Customer aCustomer in inCustomers)
            {
                var tempDto = FromCustomer(aCustomer);
                aCustomerReadDtoList.Add(tempDto);
            }
            return aCustomerReadDtoList;
        }

        // Convert from Customer object to CustomerDTO object
        public static CustomerDto FromCustomer(Customer inCustomer)
        {
            return new CustomerDto( inCustomer.FirstName, inCustomer.LastName, inCustomer.MobilePhone, inCustomer.Email);
        }

        // Convert from CustomerDTO object to Customer object
        public static Customer ToCustomer(CustomerDto inDto)
        {
            return new Customer(inDto.FirstName, inDto.LastName, inDto.MobilePhone, inDto.Email);
        }
    }
}
