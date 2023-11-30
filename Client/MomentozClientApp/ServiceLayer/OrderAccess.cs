// Inkluderer nødvendige navneområder for konfiguration, JSON-håndtering og model- samt servicelag.
using System.Configuration;
using Newtonsoft.Json;
using MomentozClientApp.ModelLayer;
using MomentozClientApp.Servicelayer;

// Definerer navneområdet for servicelaget.
namespace MomentozClientApp.ServiceLayer
{
    // OrderAccess-klassen implementerer IOrderAccess-grænsefladen.
    public class OrderAccess : IOrderAccess
    {
        // Skrivebeskyttet felt der holder på en serviceforbindelse.
        readonly IServiceConnection _orderServiceConnection;
        // Felt der holder basis-URL'en til ordreservicen, hentet fra konfigurationsindstillingerne.
        readonly string? _serviceBaseUrl = ConfigurationManager.AppSettings.Get("ServiceUrlToUse");

        // Konstruktøren initialiserer OrderAccess-klassen.
        public OrderAccess()
        {
            // Initialiserer serviceforbindelsen med basis-URL'en.
            _orderServiceConnection = new ServiceConnection(_serviceBaseUrl);
        }

        // Asynkront henter alle ordrer fra servicen.
        public async Task<List<Order>> GetOrderAll()
        {
            // Liste til at holde de hentede ordrer.
            List<Order> listFromService = new List<Order>();
            // Sætter den specifikke URL til ordre-endepunktet.
            _orderServiceConnection.UseUrl = _orderServiceConnection.BaseUrl + "orders";

            try
            {
                // Forsøger at foretage et GET-kald til servicen.
                var serviceResponse = await _orderServiceConnection.CallServiceGet();
                // Hvis kaldet er succesfuldt, og svaret er positivt, deserialiseres indholdet til en liste af ordrer.
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    listFromService = JsonConvert.DeserializeObject<List<Order>>(content) ?? listFromService;
                }
            }
            catch
            {
                // Håndtering af fejl mangler her.
            }

            // Returnerer listen af ordrer.
            return listFromService;
        }

        // Asynkront henter en ordre baseret på dens id.
        public async Task<Order> GetOrderById(int id)
        {
            // Variabel til at holde den fundne ordre.
            Order foundOrder = null;
            // Sætter den specifikke URL for at hente en ordre ved hjælp af dens id.
            _orderServiceConnection.UseUrl = _orderServiceConnection.BaseUrl + "orders/" + id;

            try
            {
                // Forsøger at foretage et GET-kald til servicen.
                var serviceResponse = await _orderServiceConnection.CallServiceGet();
                // Hvis kaldet er succesfuldt, og svaret er positivt, deserialiseres indholdet til en ordre.
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    foundOrder = JsonConvert.DeserializeObject<Order>(content);
                }
            }
            catch
            {
                // Håndtering af fejl mangler her.
            }

            // Returnerer den fundne ordre.
            return foundOrder;
        }

        // De følgende metoder er stubbe og skal implementeres.
        // De kaster en NotImplementedException, hvis de bliver kaldt.
        public Task<int> CreateOrder(string newUsername, Order order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetOrderByUserId(string loginUserId)
        {
            throw new NotImplementedException();
        }

        // Stubbe for at oprette en ordre.
        public Task<int> CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        // Stubbe for at hente en ordre ved id.
        public Task<Order> GeOrderById(int id)
        {
            throw new NotImplementedException();
        }

        // Stubbe for at hente en ordre baseret på bruger-id.
        Task<Order> IOrderAccess.GetOrderByUserId(string loginUserId)
        {
            throw new NotImplementedException();
        }
    }
}
