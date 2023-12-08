﻿using DatabaseData.ModelLayer;

namespace RESTfulService.ModelConversion
{
    public class CustomerDtoConvert
    {
        public static List<DTOs.CustomerDto>? FromCustomerCollection(List<Customer> inCustomers)
        {
            if (inCustomers == null)
                return null;

            var aCustomerReadDtoList = new List<DTOs.CustomerDto>();
            foreach (Customer aCustomer in inCustomers)
            {
                if (aCustomer != null)
                {
                    var tempDto = FromCustomer(aCustomer);
                    aCustomerReadDtoList.Add(tempDto);
                }
            }

            return aCustomerReadDtoList;
        }

        public static DTOs.CustomerDto? FromCustomer(Customer inCustomer)
        {
            if (inCustomer == null)
                return null;

            return new DTOs.CustomerDto(
                inCustomer.Id,
                inCustomer.FirstName,
                inCustomer.LastName,
                inCustomer.MobilePhone,
                inCustomer.Email,
                inCustomer.Street,
                inCustomer.ZipCode,
                inCustomer.LoginUserId);
        }

        public static Customer? ToCustomer(DTOs.CustomerDto inDto)
        {
            if (inDto == null)
                return null;

            // Antager at inDto.Id er tilgængelig og er af typen int
            return new Customer(
                inDto.Id,
                inDto.FirstName,
                inDto.LastName,
                inDto.MobilePhone,
                inDto.Email,
                inDto.Street,
                inDto.ZipCode,
                inDto.LoginUserId?.ToString()); // Konverter LoginUserId til en streng
        }
    }
}
