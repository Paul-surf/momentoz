using MomentozWebClient.ServiceLayer;
using MomentozWebClient.Models;

namespace MomentozWebClient.BusinessLogicLayer
{
    public class FlightLogic
    {


        private readonly FlightService _flightServiceAccess;

        public FlightLogic(IConfiguration inConfiguration)
        {
            _flightServiceAccess = new FlightService(inConfiguration);
        }

        

        public async Task<List<Flight>> GetAllFlights()
        {
            List<Flight> foundFlights;
            try
            {
                foundFlights = await _flightServiceAccess.GetAllFlights();
            }
            catch
            {
                foundFlights = null;
            }
            return foundFlights;
        }
    }
}
