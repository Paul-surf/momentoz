using DatabaseData.ModelLayer;
using RESTfulService.DTOs;

namespace RESTfulService.ModelConversion
{
    public class CustomerDtoConvert
    {
        public static List<CustomerDto> FromCustomerCollection(List<Customer> inCustomers)
        {
            if (inCustomers == null)
                return null;

            var aCustomerReadDtoList = new List<CustomerDto>();
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

        public static CustomerDto FromCustomer(Customer inCustomer)
        {
            if (inCustomer == null)
                return null;

            return new CustomerDto(inCustomer.FirstName, inCustomer.LastName, inCustomer.MobilePhone, inCustomer.Email, inCustomer.ZipCode, inCustomer.StreetName, inCustomer.LoginUserId);
        }

        public static Customer ToCustomer(CustomerDto inDto)
        {
            if (inDto == null)
                return null;

            // Antager at inDto.Id er tilgængelig og er af typen int
            return new Customer(inDto.FirstName, inDto.LastName, inDto.MobilePhone, inDto.Email, inDto.StreetName, inDto.ZipCode, inDto.LoginUserId?.ToString()); // Konverter LoginUserId til en streng
        }
    }
}
//public interface IOrderdata
//{
//    OrderDto? Get(int id);
//    List<OrderDto>? Get();
//    OrderDto CreateNewOrder(OrderDto orderToAdd);
//    OrderDto Put(OrderDto orderToUpdate);
//    bool Delete(int id);

//}