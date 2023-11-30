// Inkluderer ModelLayer-navneområdet for adgang til datamodeller.
using MomentozClientApp.ModelLayer;
// Inkluderer Newtonsoft.Json-navneområdet for JSON-serialisering og deserialisering.
using Newtonsoft.Json;
// Inkluderer System.Configuration-navneområdet for adgang til konfigurationsindstillinger.
using System.Configuration;

// Definerer navneområdet for servicelaget i applikationen.
namespace MomentozClientApp.Servicelayer
{
    // Definerer en klasse, der implementerer ITicketAccess-grænsefladen.
    public class TicketAccess : ITicketAccess
    {
        // Et skrivebeskyttet felt til serviceforbindelsesgrænsefladen.
        readonly IServiceConnection _ticketServiceConnection;
        // Henter basis-URL'en til tjenesten fra applikationsindstillingerne.
        readonly string? _serviceBaseUrl = ConfigurationManager.AppSettings.Get("ServiceUrlToUse");

        // Konstruktøren for TicketAccess-klassen.
        public TicketAccess()
        {
            // Initialiserer serviceforbindelsen med basis-URL'en.
            _ticketServiceConnection = new ServiceConnection(_serviceBaseUrl);
        }

        // Asynkront henter alle billetter fra tjenesten.
        public async Task<List<Ticket>> GetTicketAll()
        {
            // Initialiserer en tom liste til at holde billetter.
            List<Ticket> listFromService = new List<Ticket>();
            // Sætter den specifikke URL for at tilgå billetressourcen.
            _ticketServiceConnection.UseUrl = _ticketServiceConnection.BaseUrl + "tickets";
            try
            {
                // Foretager et GET-kald til tjenesten.
                var serviceResponse = await _ticketServiceConnection.CallServiceGet();
                // Hvis svaret er succesfuldt og ikke null, deserialiseres JSON-indholdet til en liste af billetter.
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    listFromService = JsonConvert.DeserializeObject<List<Ticket>>(content) ?? listFromService;
                }
            }
            catch
            {
                // Blok for undtagelseshåndtering, i øjeblikket tom.
            }
            // Returnerer listen af billetter.
            return listFromService;
        }

        // Asynkront henter en billet ved dens ID fra tjenesten.
        public async Task<Ticket> GetTicketById(int id)
        {
            // Initialiserer en variabel til at holde den fundne billet.
            Ticket foundTicket = null;
            // Sætter den specifikke URL for at tilgå billetressourcen ved ID.
            _ticketServiceConnection.UseUrl = _ticketServiceConnection.BaseUrl + "tickets/" + id;
            try
            {
                // Foretager et GET-kald til tjenesten.
                var serviceResponse = await _ticketServiceConnection.CallServiceGet();
                // Hvis svaret er succesfuldt og ikke null, deserialiseres JSON-indholdet til et Ticket-objekt.
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    foundTicket = JsonConvert.DeserializeObject<Ticket>(content);
                }
            }
            catch
            {
                // Blok for undtagelseshåndtering, i øjeblikket tom.
            }
            // Returnerer den fundne billet.
            return foundTicket;
        }

        // De følgende metoder er en del af ITicketAccess-grænsefladen, men er endnu ikke implementeret.
        public Task<int> CreateTicket(string newUsername, Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTicketById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
