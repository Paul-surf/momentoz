using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MomentozClientApp.Model;
using MomentozClientApp.Servicelayer;

namespace MomentozClientApp.Controller
{
    public class CustomerController
    {
        readonly ICustomerServiceAccess _cAccess; 
        public CustomerController() { 
            _cAccess = new CustomerServiceAccess(); 
        }
        public async Task<List<Customer>?> GetAllCustomers() { 
            List<Customer>? foundCustomers = null;
            if (_cAccess != null) { 
                foundCustomers = await _cAccess.GetCustomers(); 
            } return foundCustomers; 
        }
        public async Task<int> SavePerson(int id, string fName, string lName, string mPhone) {
            Customer newCustomer = new(id, fName, lName, mPhone); 
            int insertedId = await _cAccess.SaveCustomer(newCustomer);
            return insertedId; 
        }

        public async Task<bool> CreateCustomer(string username, string password)
        {
            // Tjek om brugernavnet allerede findes
            var existingCustomers = await GetAllCustomers();
            var customerExists = existingCustomers?.Any(c => c.Username == username);
            if (customerExists == true)
            {
                // Brugernavnet findes allerede, kan ikke oprette en ny kunde
                return false;
            }

            // Antag at 'Customer' klassen har en konstruktør der tager brugernavn og adgangskode
            var newCustomer = new Customer( username, password); // Du skal sørge for at hash adgangskoden!

            // Gem den nye kunde ved hjælp af service laget
            int insertedId = await _cAccess.SaveCustomer(newCustomer);

            // Check om en ny ID blev genereret for at bekræfte, at kunden blev gemt korrekt
            return insertedId > 0;
        }
        public async Task<bool> ValidateLogin(string username, string password)
        {
            // This is a placeholder implementation.
            // You would need to implement the actual login validation logic here,
            // possibly by calling a method on _cAccess that checks the credentials.

            // For example:
            // return await _cAccess.ValidateCredentials(username, password);

            // If you don't have such a method, you might need to implement it
            // in the service layer.

            // For the sake of example, let's assume that we are simply checking if the username is not empty.
            return !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password);
        }


    }
}
