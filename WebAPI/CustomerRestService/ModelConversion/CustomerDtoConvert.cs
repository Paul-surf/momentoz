using CustomerData.ModelLayer;
using CustomerRestService.DTOs;


namespace CustomerRestService.ModelConversion
{
    public class CustomerDtoConvert
    {

        // Convert from Customer objects to CustomerDTO objects
        public static List<DTOs.CustomerDtoo>? FromCustomerCollection(List<Customer> inCustomers)
        {
            List<DTOs.CustomerDtoo>? aCustomerReadDtoList = null;
            if (inCustomers != null)
            {
                aCustomerReadDtoList = new List<DTOs.CustomerDtoo>();
                DTOs.CustomerDtoo? tempDto;
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

        // Convert from Customer object to CustomerDTO object
        public static DTOs.CustomerDtoo? FromCustomer(Customer inCustomer)
        {
            DTOs.CustomerDtoo? aCustomerReadDto = null;
            if (inCustomer != null)
            {
                aCustomerReadDto = new DTOs.CustomerDtoo(inCustomer.FirstName, inCustomer.LastName, inCustomer.MobilePhone, inCustomer.Email);
            }
            return aCustomerReadDto;
        }

        // Convert from CustomerDTO object to Customer object
        public static Customer? ToCustomer(DTOs.CustomerDtoo inDto)
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
