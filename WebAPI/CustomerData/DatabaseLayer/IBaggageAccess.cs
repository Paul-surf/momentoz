

using DatabaseData.ModelLayer;
using System;
using System.Net.Sockets;


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
