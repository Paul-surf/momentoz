using DatabaseData.ModelLayer;



namespace DatabaseData.DatabaseLayer
{

    public interface IHandBaggageAccess
    {


        Baggage GetHandBaggageById(int id);
        List<Baggage> GetHandBaggageAll();
        int CreateHandBaggage(Baggage handbaggageToAdd);
        bool UpdateHandBaggage(Baggage handbaggageToUpdate);
        bool DeleteHandBaggageById(int id);

    }
}
