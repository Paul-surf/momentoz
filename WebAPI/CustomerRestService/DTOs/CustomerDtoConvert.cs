﻿using CustomerData.ModelLayer;
using CustomerRestService.DTOs;
using System;

namespace CustomerRestService.ModelConversion
{
    public class CustomerDtoConvert
    {

        // Convert from Customer objects to CustomerDTO objects
        public static List<CustomerDto>? FromCustomerCollection(List<Customer> inCustomers)
        {
            List<CustomerDto>? aCustomerReadDtoList = null;
            if (inCustomers != null)
            {
                aCustomerReadDtoList = new List<CustomerDto>();
                TicketDto? tempDto;
                foreach (Customer aCustomer in inCustomers)
                {
                    if (aCustomer != null)
                    {
                        tempDto = FromCustomer(aCustomer);
                        aCustomerReadDtoList.Add(tempDto);
                    }
                }
            }
            return aCustomerReadDtoList;
        }

        // Convert from Customer object to PersonDTO object
        public static CustomerDto? FromCustomer(Customer inCustomer)
        {
            TicketDto? aCustomerReadDto = null;
            if (inCustomer != null)
            {
                aCustomerReadDto = new CustomerDto(inCustomer.FirstName, inCustomer.LastName, inCustomer.MobilePhone, inCustomer.Email);
            }
            return aCustomerReadDto;
        }

        // Convert from CustomerDTO object to Customer object
        public static Customer? ToCustomer(TicketDto inDto)
        {
            Customer? aCustomer = null;
            if (inDto != null)
            {
                aCustomer = new Customer(inDto.FirstName, inDto.LastName, inDto.MobilePhone, inDto.Email);
            }
            return aCustomer;
        }
    }
}