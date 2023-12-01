using MomentozClientApp.Model;
using MomentozClientApp.Servicelayer;

namespace MomentozClientApp.BusinessLogicLayer
{
    public class FlightdataControl : IFlightdata
    {
        private readonly IFlightAccess _flightAccess;

        public FlightdataControl(IFlightAccess flightAccess)
        {
            _flightAccess = flightAccess;
        }

        public Flight? Get(int id)
        {
            try
            {
                return _flightAccess.GetFlightById(id).Result;
            }
            catch
            {
                return null;
            }
        }

        public List<Flight>? Get()
        {
            try
            {
                return _flightAccess.GetFlightAll().Result;
            }
            catch
            {
                return null;
            }
        }

        public int Add(Flight flightToAdd)
        {
            try
            {
                if (flightToAdd != null)
                {
                    return _flightAccess.CreateFlight(flightToAdd).Result;
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        public bool Put(Flight flightToUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Flight? GetFlightById(int id)
        {
            try
            {
                return _flightAccess.GetFlightById(id).Result;
            }
            catch
            {
                return null;
            }
        }
    }
}
