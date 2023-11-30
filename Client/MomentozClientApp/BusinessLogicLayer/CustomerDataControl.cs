// Inkluderer nødvendige navneområder for DTOs og servicelaget.
using MomentozClientApp.DTOs;
using MomentozClientApp.Servicelayer;

// Definerer navneområdet for business logic laget i MomentozClientApp-applikationen.
namespace MomentozClientApp.BusinessLogicLayer
{
    // CustomerDataControl-klassen implementerer ICustomerdata-interface og styrer logikken omkring kunder.
    public class CustomerDataControl : ICustomerdata
    {
        // En skrivebeskyttet reference til ICustomerAccess for at interagere med kunde data.
        private readonly ICustomerAccess _customerAccess;

        // Konstruktøren initialiserer CustomerDataControl med en ICustomerAccess instans.
        public CustomerDataControl(ICustomerAccess inCustomerAccess)
        {
            _customerAccess = inCustomerAccess;
        }

        // Metode til at hente en specifik kunde baseret på id og konvertere den til en CustomerDto.
        public CustomerDto? Get(int id)
        {
            try
            {
                // Forsøger at hente kunden fra data laget og konvertere til CustomerDto.
                var foundCustomer = _customerAccess.GetCustomerById(id).Result;
                return ModelConversion.CustomerDtoConvert.FromCustomer(foundCustomer);
            }
            catch
            {
                // Returnerer null, hvis der opstår en fejl.
                return null;
            }
        }

        // Metode til at hente alle kunder og konvertere dem til en liste af CustomerDto.
        public List<CustomerDto>? Get()
        {
            try
            {
                // Forsøger at hente alle kunder og konvertere til CustomerDto-liste.
                var foundCustomers = _customerAccess.GetCustomerAll().Result;
                return ModelConversion.CustomerDtoConvert.FromCustomerCollection(foundCustomers);
            }
            catch
            {
                // Returnerer null, hvis der opstår en fejl.
                return null;
            }
        }

        // Metode til at tilføje en ny kunde og returnere det nye id for den oprettede kunde.
        public int Add(CustomerDto customerToAdd)
        {
            try
            {
                // Konverterer CustomerDto til Customer og forsøger at oprette den i databasen.
                var newCustomer = ModelConversion.CustomerDtoConvert.ToCustomer(customerToAdd);
                if (newCustomer != null)
                {
                    return _customerAccess.CreateCustomer(newCustomer).Result;
                }
                return 0;
            }
            catch
            {
                // Returnerer -1 som indikator for fejl.
                return -1;
            }
        }

        // Metoder, der endnu ikke er implementeret, og som kaster NotImplementedException.
        public bool Put(CustomerDto customerToUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        // Metode til at hente en kunde baseret på en brugers id og konvertere den til en CustomerDto.
        public CustomerDto? GetByUserId(string loginUserId)
        {
            try
            {
                // Forsøger at hente kunden baseret på loginUserId og konvertere til CustomerDto.
                var foundCustomer = _customerAccess.GetCustomerByUserId(loginUserId).Result;
                return foundCustomer != null ? ModelConversion.CustomerDtoConvert.FromCustomer(foundCustomer) : null;
            }
            catch
            {
                // Returnerer null, hvis der opstår en fejl.
                return null;
            }
        }
    }
}
