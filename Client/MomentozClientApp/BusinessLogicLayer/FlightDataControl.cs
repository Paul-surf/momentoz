using MomentozClientApp.DTOs;
using MomentozClientApp.Servicelayer;

namespace MomentozClientApp.BusinessLogicLayer
{
    public class FlightdataControl : IFlightdata
    {
        private readonly IFlightAccess _flightAccess;

        // Konstruktør, der modtager en IFlightAccess som parameter
        public FlightdataControl(IFlightAccess flightAccess)
        {
            _flightAccess = flightAccess;
        }

        // Metode til at hente en FlightDto baseret på ID
        public FlightDto? Get(int id)
        {
            try
            {
                // Forsøger at hente en flyvning baseret på ID
                var foundFlight = _flightAccess.GetFlightById(id).Result;
                return ModelConversion.FlightDtoConvert.FromFlight(foundFlight); // Konverterer til FlightDto og returnerer
            }
            catch
            {
                return null; // Håndterer eventuelle fejl ved at returnere null
            }
        }

        // Metode til at hente en liste af FlightDto'er
        public List<FlightDto>? Get()
        {
            try
            {
                // Forsøger at hente alle flyvninger
                var foundFlights = _flightAccess.GetFlightAll().Result;
                return ModelConversion.FlightDtoConvert.FromFlightCollection(foundFlights); // Konverterer til en liste af FlightDto'er og returnerer
            }
            catch
            {
                return null; // Håndterer eventuelle fejl ved at returnere null
            }
        }

        // Metode til at tilføje en ny flyvning
        public int Add(FlightDto flightToAdd)
        {
            try
            {
                // Forsøger at konvertere FlightDto til en flyvning og oprette den
                var newFlight = ModelConversion.FlightDtoConvert.ToFlight(flightToAdd);
                if (newFlight != null)
                {
                    return _flightAccess.CreateFlight(newFlight).Result; // Oprettelse af flyvning og returnerer dens ID
                }
                return 0; // Returnerer 0, hvis konverteringen mislykkes
            }
            catch
            {
                return -1; // Håndterer eventuelle fejl ved at returnere -1
            }
        }

        // Metode til at opdatere en flyvning (ikke implementeret)
        public bool Put(FlightDto flightToUpdate)
        {
            {
                throw new NotImplementedException(); // Kaster en NotImplementedException, da metoden ikke er implementeret endnu
            }
        }

        // Metode til at slette en flyvning (ikke implementeret)
        public bool Delete(int id)
        {
            throw new NotImplementedException(); // Kaster en NotImplementedException, da metoden ikke er implementeret endnu
        }

        // Metode til at hente en flyvning baseret på ID
        public FlightDto? GetFlightById(int id)
        {
            try
            {
                // Forsøger at hente en flyvning baseret på ID
                var foundFlight = _flightAccess.GetFlightById(id).Result;
                return foundFlight != null ? ModelConversion.FlightDtoConvert.FromFlight(foundFlight) : null; // Konverterer til FlightDto og returnerer eller returnerer null hvis flyvningen ikke findes
            }
            catch
            {
                return null; // Håndterer eventuelle fejl ved at returnere null
            }
        }
    }
}
