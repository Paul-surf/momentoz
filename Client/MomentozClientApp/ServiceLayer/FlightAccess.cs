using MomentozClientApp.Model;

namespace MomentozClientApp.Servicelayer
{
    public class FlightAccess : IFlightAccess
    {
        private readonly IFlightAccess _flightServiceAccess;

        public FlightAccess()
        {
            _flightServiceAccess = new FlightAccess();
        }

        public Task<int> CreateFlight(Flight flight)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFlightById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Flight>?> GetAllFlights()

        {
            List<Flight>? foundFlights;
            try
            {
                foundFlights = await _flightServiceAccess.GetFlightAll();
            }
            catch
            {
                foundFlights = null;
            }

            return foundFlights;
        }

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
