using MomentozClientApp.ModelLayer;
using MomentozClientApp.Servicelayer;

namespace MomentozClientApp.BusinessLogicLayer
{
    public class BaggageDataControl : IBaggagedata
    {
        private readonly IBaggageAccess _baggageAccess;

        public BaggageDataControl(IBaggageAccess inBaggageAccess)
        {
            _baggageAccess = inBaggageAccess;
        }

        public Baggage? Get(int id)
        {
            try
            {
                return _baggageAccess.GetBaggageById(id).Result;
            }
            catch
            {
                return null;
            }
        }

        public List<Baggage>? Get()
        {
            try
            {
                return _baggageAccess.GetBaggageAll().Result;
            }
            catch
            {
                return null;
            }
        }

        public int Add(Baggage baggageToAdd)
        {
            try
            {
                if (baggageToAdd != null)
                {
                    return _baggageAccess.CreateBaggage(baggageToAdd).Result;
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        public bool Put(Baggage baggageToUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
