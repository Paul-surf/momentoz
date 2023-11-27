using MomentozClientApp.Model;
using MomentozClientApp.Servicelayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomentozClientApp.Controller
{
    public class FlightController
    {
        readonly IFlightServiceAccess _flightAccess;
        public FlightController()
        {
            _flightAccess = new FlightServiceAccess();
        }
        public async Task<List<Flight>?> GetAllFlights()
        {
            List<Flight>? foundFlights = null;
            try
            {
                foundFlights = await _flightAccess.GetFlights();
            }
            catch
            {
                foundFlights = null;
            }

            return foundFlights;
        }
    }
}
