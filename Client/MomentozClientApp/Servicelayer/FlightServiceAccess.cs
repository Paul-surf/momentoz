using MomentozClientApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomentozClientApp.Servicelayer
{
    public class FlightServiceAccess : IFlightConnection
    {
        private readonly IFlightServiceAccess _flightServiceAccess;

        public FlightServiceAccess()
        {
            _flightServiceAccess = new FlightServiceAccess();
        }

        public async Task<List<Flight>?> GetAllFlights()

        {
            List<Flight>? foundFlights;
            try
            {
                foundFlights = await _flightServiceAccess.GetLines();
            }
            catch
            {
                foundFlights = null;
            }

            return foundFlights;
        }
    }
}
