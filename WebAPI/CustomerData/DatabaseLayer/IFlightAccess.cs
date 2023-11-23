using DatabaseData.ModelLayer;

namespace DatabaseData.DatabaseLayer
{
    public interface IFlightAccess
    {

        List<Flight> GetFlightAll();
        int CreateFlight(Flight flightToAdd);
    }

}