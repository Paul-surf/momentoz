using MomentozClientApp.ModelLayer;

namespace MomentozClientApp.ModelConversion
{
    public class CustomerDtoConvert
    {

        // Convert from Customer objects to CustomerDTO objects
        public static List<DTOs.CustomerDto>? FromCustomerCollection(List<Customer> inCustomers)
        {
            List<DTOs.CustomerDto>? aCustomerReadDtoList = null;
            if (inCustomers != null)
            {
                aCustomerReadDtoList = new List<DTOs.CustomerDto>();
                DTOs.CustomerDto? tempDto;
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
        public static DTOs.CustomerDto? FromCustomer(Customer inCustomer)
        {
            DTOs.CustomerDto? aCustomerReadDto = null;
            if (inCustomer != null)
            {
                aCustomerReadDto = new DTOs.CustomerDto(inCustomer.FirstName, inCustomer.LastName, inCustomer.MobilePhone, inCustomer.Email, inCustomer.LoginUserId);
            }
            return aCustomerReadDto;
        }

        // Convert from CustomerDTO object to Customer object
        public static Customer? ToCustomer(DTOs.CustomerDto inDto)
        {
            Customer? aCustomer = null;
            if (inDto != null)
            {
                aCustomer = new Customer(inDto.FirstName, inDto.LastName, inDto.MobilePhone, inDto.Email, inDto.LoginUserId);
            }
            return aCustomer;
        }
    }
}
