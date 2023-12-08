using DatabaseData.ModelLayer;

namespace RESTfulService.ModelConversion
{
    public class CustomerDtoConvert
    {
        public static List<DTOs.CustomerDtoo> FromCustomerCollection(List<Customer> inCustomers)
        {
            if (inCustomers == null)
                return null;

            var aCustomerReadDtoList = new List<DTOs.CustomerDtoo>();
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

        public static DTOs.CustomerDtoo FromCustomer(Customer inCustomer)
        {
            if (inCustomer == null)
                return null;

            return new DTOs.CustomerDtoo(
                inCustomer.CustomerID,
                inCustomer.FirstName,
                inCustomer.LastName,
                inCustomer.MobilePhone,
                inCustomer.Email,
                inCustomer.ZipCode,
                inCustomer.StreetName,
                inCustomer.LoginUserId);
        }

        public static Customer ToCustomer(DTOs.CustomerDtoo inDto)
        {
            if (inDto == null)
                return null;

            // Antager at inDto.Id er tilgængelig og er af typen int
            return new Customer(
                inDto.CustomerID,
                inDto.FirstName,
                inDto.LastName,
                inDto.MobilePhone,
                inDto.Email,
                inDto.StreetName,
                inDto.ZipCode,
                inDto.LoginUserId?.ToString()); // Konverter LoginUserId til en streng
        }
    }
}
