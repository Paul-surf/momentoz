using MomentozClientApp.DTOs;
using MomentozClientApp.ModelLayer;
using MomentozClientApp.Servicelayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MomentozClientApp.BusinessLogicLayer
{
    public class BaggageDataControl : IBaggagedata
    {
        private readonly IBaggageAccess _baggageAccess;
        public BaggageDataControl(IBaggageAccess inBaggageAccess)
        {
            _baggageAccess = inBaggageAccess;
        }
        public BaggageDto? Get(int id)
        {
            try
            {
                var foundBaggage = _baggageAccess.GetBaggageById(id).Result;
                return ModelConversion.BaggageDtoConvert.FromBaggage(foundBaggage);
            }
            catch
            {
                return null;
            }
        }
        public List<BaggageDto>? Get()
        {
            try
            {
                var foundBaggages = _baggageAccess.GetBaggageAll().Result;
                return ModelConversion.BaggageDtoConvert.FromBaggageCollection(foundBaggages);
            }
            catch
            {
                return null;
            }
        }
        public int Add(BaggageDto baggageToAdd)
        {
            try
            {
                var newBaggage = ModelConversion.BaggageDtoConvert.ToBaggage(baggageToAdd);
                if (newBaggage != null)
                {
                    return _baggageAccess.CreateBaggage(newBaggage).Result;
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }
        public bool Put(BaggageDto baggageToUpdate)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}