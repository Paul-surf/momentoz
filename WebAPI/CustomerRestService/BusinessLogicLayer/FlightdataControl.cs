using DatabaseData.ModelLayer;
using DatabaseData.DatabaseLayer;
using RESTfulService.DTOs;
using RESTfulService.BusinessLogicLayer;

namespace RESTfulService.BusinesslogicLayer
{
    public class FlightdataControl : IFlightdata
    {
        private readonly IFlightAccess _flightAccess;

        public FlightdataControl(IFlightAccess inFlightAccess)
        {
            _flightAccess = inFlightAccess;
        }


        public FlightDto? Get(int idToMatch)
        {
            FlightDto? foundFlightDto;
            try
            {
                Flight? foundFlight = _flightAccess.GetFlightById(idToMatch);
                foundFlightDto = ModelConversion.FlightDtoConvert.FromFlight(foundFlight);
            }
            catch
            {
                foundFlightDto = null;
            }
            return foundFlightDto;
        }

        public List<FlightDto>? Get()
        {
            List<FlightDto>? foundDtos;
            try
            {
                List<Flight>? foundFlights = _flightAccess.GetFlightAll();
                foundDtos = ModelConversion.FlightDtoConvert.FromFlightCollection(foundFlights);
            }
            catch
            {
                foundDtos = null;
            }
            return foundDtos;
        }

        public int Add(FlightDto flightToAdd)
        {
            int insertedId = 0;
            try
            {
                Flight? newFlight = ModelConversion.FlightDtoConvert.ToFlight(flightToAdd);
                if (newFlight != null)
                {
                    insertedId = _flightAccess.CreateFlight(newFlight);
                }
            }
            catch (Exception es)
            {
                Console.WriteLine("Caught exception:" + es);
                insertedId = -1;
            }
            return insertedId;
        }

        public bool Put(FlightDto flightToUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
        public bool TryLockFlight(int flightId)
        {
            try
            {
                return _flightAccess.TryLockFlight(flightId);
            }
            catch (Exception es)
            {
                Console.WriteLine("Caught exception:" + es);
                return false;
            }
        }

        public bool ReleaseFlightLock(int flightId)
        {
            try
            {
                return _flightAccess.ReleaseLockFlight(flightId);
            }
            catch (Exception es)
            {
                Console.WriteLine("Caught exception:" + es);
                return false;
            }
        }
    }
}
