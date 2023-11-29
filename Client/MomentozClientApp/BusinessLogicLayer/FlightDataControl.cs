using MomentozClientApp.DTOs;
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

        public FlightDto? Get(int id)
        {
            try
            {
                var foundFlight = _flightAccess.GetFlightById(id).Result; ;
                return ModelConversion.FlightDtoConvert.FromFlight(foundFlight);
            }
            catch
            {
                return null;
            }
        }

        public List<FlightDto>? Get()
        {
            try
            {
                var foundFlights =  _flightAccess.GetFlightAll().Result;
                return ModelConversion.FlightDtoConvert.FromFlightCollection(foundFlights);
            }
            catch
            {
                return null;
            }
        }

        public int Add(FlightDto flightToAdd)
        {
            try
            {
                var newFlight = ModelConversion.FlightDtoConvert.ToFlight(flightToAdd);
                if (newFlight != null)
                {
                    return _flightAccess.CreateFlight(newFlight).Result;
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        public bool Put(FlightDto flightToUpdate)
        {
            {
                throw new NotImplementedException();
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
        public FlightDto? GetFlightById(int id)
        {
            try
            {
                var foundFlight = _flightAccess.GetFlightById(id).Result;
                return foundFlight != null ? ModelConversion.FlightDtoConvert.FromFlight(foundFlight) : null;
            }
            catch
            {
                return null;
            }
        }
    }
    
}
