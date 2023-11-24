﻿using DatabaseData.ModelLayer;
using DatabaseData.DatabaseLayer;
using CustomerRestService.DTOs;
using CustomerRestService.BusinessLogicLayer;

namespace CustomerRestService.BusinesslogicLayer
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
                Console.WriteLine("Caught execption:" + es);
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



      
    }
}
