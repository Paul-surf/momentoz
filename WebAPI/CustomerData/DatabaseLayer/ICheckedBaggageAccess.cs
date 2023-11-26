



using DatabaseData.ModelLayer;
using System;
using System.Net.Sockets;


namespace DatabaseData.DatabaseLayer
{

    public interface ICheckedBaggageAccess
    {


        CheckedBaggage GetCheckedBaggageById(int id);
        List<Baggage> GetCheckedBaggageAll();
        int CreateCheckedBaggage(CheckedBaggage checkedbaggageToAdd);
        bool UpdateCheckedBaggage(CheckedBaggage cCheckedToUpdate);
        bool DeleteCheckedBaggageById(int id);

    }
}
