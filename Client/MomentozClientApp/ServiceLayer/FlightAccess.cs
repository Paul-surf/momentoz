// Inkluderer Model-navneområdet, som indeholder data-modellerne, herunder Flight-modellen.
using MomentozClientApp.Model;

// Definerer navneområdet for servicelaget i MomentozClientApp-applikationen.
namespace MomentozClientApp.Servicelayer
{
    // FlightAccess-klassen implementerer IFlightAccess-interface og håndterer adgang til flyoplysninger.
    public class FlightAccess : IFlightAccess
    {
        // En privat readonly instans af IFlightAccess, anvendt til at delegere ansvaret for flyoplysninger.
        private readonly IFlightAccess _flightServiceAccess;

        // Konstruktøren initialiserer FlightAccess-klassen.
        public FlightAccess()
        {
            // Initialiserer _flightServiceAccess med en ny instans af FlightAccess.
            // Bemærk: Dette kan føre til en stack overflow-fejl, da det er en rekursiv initialisering.
            _flightServiceAccess = new FlightAccess();
        }

        // Metoder, der endnu ikke er implementeret, og som kaster NotImplementedException.
        public Task<int> CreateFlight(Flight flight)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFlightById(int id)
        {
            throw new NotImplementedException();
        }

        // Asynkron metode til at hente alle flyvninger. 
        // Fanger og håndterer eventuelle undtagelser, der opstår under hentningen.
        public async Task<List<Flight>?> GetAllFlights()
        {
            List<Flight>? foundFlights;
            try
            {
                // Forsøger at hente alle flyvninger gennem _flightServiceAccess.
                foundFlights = await _flightServiceAccess.GetFlightAll();
            }
            catch
            {
                // Sætter foundFlights til null, hvis der opstår en fejl under hentningen.
                foundFlights = null;
            }

            return foundFlights;
        }

        // Metoder, der endnu ikke er implementeret, og som kaster NotImplementedException.
        public Task<List<Flight>> GetFlightAll()
        {
            throw new NotImplementedException();
        }

        public Task<Flight> GetFlightById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Flight> GetFlightByUserId(string loginUserId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateFlight(Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}
