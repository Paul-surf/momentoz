// Inkluderer nødvendige navneområder for modellaget, JSON-håndtering og systemkonfiguration.
using MomentozClientApp.ModelLayer;
using Newtonsoft.Json;
using System.Configuration;

// Definerer navneområdet for servicelaget i MomentozClientApp-applikationen.
namespace MomentozClientApp.Servicelayer
{
    // BaggageAccess-klassen implementerer IBaggageAccess-interface og håndterer adgang til bagageoplysninger.
    public class BaggageAccess : IBaggageAccess
    {
        // En skrivebeskyttet instans af IServiceConnection, der bruges til at håndtere forbindelser til webtjenester.
        readonly IServiceConnection _baggageServiceConnection;
        // Basis-URL'en til servicen, hentet fra applikationskonfigurationen.
        readonly string? _serviceBaseUrl = ConfigurationManager.AppSettings.Get("ServiceUrlToUse");

        // Konstruktøren initialiserer BaggageAccess-klassen.
        public BaggageAccess()
        {
            // Initialiserer _baggageServiceConnection med en ny instans af ServiceConnection.
            _baggageServiceConnection = new ServiceConnection(_serviceBaseUrl);
        }

        // Asynkron metode til at hente alle bagageelementer.
        public async Task<List<Baggage>> GetBaggageAll()
        {
            // Liste til at holde de hentede bagageelementer.
            List<Baggage> listFromService = new List<Baggage>();
            // Sætter den specifikke URL for bagageendepunktet.
            _baggageServiceConnection.UseUrl = _baggageServiceConnection.BaseUrl + "baggages";
            try
            {
                // Forsøger at foretage et GET-kald til servicen.
                var serviceResponse = await _baggageServiceConnection.CallServiceGet();
                // Hvis kaldet er succesfuldt, og svaret er positivt, deserialiseres indholdet til en liste af bagageelementer.
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    listFromService = JsonConvert.DeserializeObject<List<Baggage>>(content) ?? listFromService;
                }
            }
            catch
            {
                // Håndtering af undtagelser mangler her.
            }
            return listFromService;
        }

        // Asynkron metode til at hente en specifik bagage baseret på dens id.
        public async Task<Baggage> GetBaggageById(int id)
        {
            // Variabel til at holde den fundne bagage.
            Baggage foundBaggage = null;
            // Sætter den specifikke URL for at hente en specifik bagage ved id.
            _baggageServiceConnection.UseUrl = _baggageServiceConnection.BaseUrl + "baggages/" + id;
            try
            {
                // Forsøger at foretage et GET-kald til servicen.
                var serviceResponse = await _baggageServiceConnection.CallServiceGet();
                // Hvis kaldet er succesfuldt, og svaret er positivt, deserialiseres indholdet til en bagage.
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    foundBaggage = JsonConvert.DeserializeObject<Baggage>(content);
                }
            }
            catch
            {
                // Håndtering af undtagelser mangler her.
            }
            return foundBaggage;
        }

        // Metoder, der endnu ikke er implementeret, og som kaster NotImplementedException.
        public Task<int> CreateBaggage(string newUsername, Baggage baggage)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBaggage(Baggage baggage)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBaggageById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateBaggage(Baggage baggage)
        {
            throw new NotImplementedException();
        }
    }
}
