﻿using CustomerRestService.DTOs;

namespace CustomerRestService.BusinessLogicLayer
{

    public interface IFlightdata
    {

        List<FlightDto>? Get();
        int Add(FlightDto flightToAdd);
        bool Put(FlightDto flightToUpdate);
        bool Delete(int id);

    }
}
