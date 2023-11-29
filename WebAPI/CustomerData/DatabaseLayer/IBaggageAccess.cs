
using DatabaseData.ModelLayer;


namespace DatabaseData.DatabaseLayer
{

    public interface IBaggageAccess
    {


        Baggage GetBaggageById(int id);
        List<Baggage> GetBaggageAll();
        int CreateBaggage(Baggage baggageToAdd);
        bool UpdateBaggage(Baggage baggageToUpdate);
        bool DeleteBaggageById(int id);

    }
}
