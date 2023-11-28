using MomentozClientApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomentozClientApp.BusinessLogicLayer
{
    public interface IFlightdata
    {
        FlightDto Get(int id);
        List<FlightDto>? Get();
        int Add(FlightDto flightToAdd);
        bool Put(FlightDto flightToUpdate); // If this should be async
        bool Delete(int id); // If this should be async

        FlightDto? GetFlightById(int id);
    }

}
