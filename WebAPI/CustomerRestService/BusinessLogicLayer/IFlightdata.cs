using RESTfulService.DTOs;

namespace RESTfulService.BusinessLogicLayer
{
    public interface IFlightdata
    {  List<FlightDto>? Get();
        FlightDto? GetFlightById(int flightId); 
        int Add(FlightDto flightToAdd);
        bool Put(FlightDto flightToUpdate);
        bool Delete(int id);
    }
}
