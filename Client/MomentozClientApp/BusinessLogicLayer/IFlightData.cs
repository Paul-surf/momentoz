using MomentozClientApp.DTOs;

namespace MomentozClientApp.BusinessLogicLayer
{
    public interface IFlightdata
    {
        FlightDto Get(int id);
        List<FlightDto>? Get();
        int Add(FlightDto flightToAdd);
        bool Put(FlightDto flightToUpdate);
        bool Delete(int id); 

        FlightDto? GetFlightById(int id);
    }

}
