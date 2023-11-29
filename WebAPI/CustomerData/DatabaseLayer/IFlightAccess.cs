using DatabaseData.ModelLayer;


namespace DatabaseData.DatabaseLayer
{
    public interface IFlightAccess
    {

        Flight GetFlightById(int id);
        List<Flight> GetFlightAll();
        int CreateFlight(Flight flightToAdd);
        bool UpdateFlight(Flight flightToUpdate);
        bool DeleteFlightById(int id);

    }
}
