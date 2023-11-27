using DatabaseData.ModelLayer;
using DatabaseData.DatabaseLayer;
using RESTfulService.DTOs;


namespace RESTfulService.BusinessLogicLayer
{
    public class BaggageDataControl : IBaggagedata
    {
        private readonly IBaggageAccess _baggageAccess;

        public BaggageDataControl(IBaggageAccess inBaggageAccess)
        {
            _baggageAccess = inBaggageAccess;
        }


        public BaggageDto Get(int idToMatch)
        {
            BaggageDto? foundBaggageDto;
            try
            {
                Baggage? foundBaggage = _baggageAccess.GetBaggageById(idToMatch);
                foundBaggageDto = ModelConversion.BaggageDtoConvert.FromBaggage(foundBaggage);
            }
            catch
            {
                foundBaggageDto = null;
            }
            return foundBaggageDto;
        }


        public List<BaggageDto> Get()
        {
            List<BaggageDto> foundDtos;
            try
            {
                List<Baggage> foundBaggages = _baggageAccess.GetBaggageAll();
                foundDtos = ModelConversion.BaggageDtoConvert.FromBaggageCollection(foundBaggages);
            }
            catch (Exception ex)
            {
                // Log exception her. Brug din logger afhængig af opsætningen, f.eks.:
                // _logger.LogError(ex, "Fejl under hentning af bagages.");

                // Kast exceptionen videre op i call stacken, så den kan håndteres opad.
                throw new ApplicationException("Fejl under hentning af baggages.", ex);
            }

            return foundDtos ?? new List<BaggageDto>(); // Returner en tom liste i stedet for null
        }



        public int Add(BaggageDto newBaggage)
        {
            int insertedId = 0;
            try
            {
                Baggage? foundBaggage = ModelConversion.BaggageDtoConvert.ToBaggage(newBaggage);
                if (foundBaggage != null)
                {
                    insertedId = _baggageAccess.CreateBaggage(foundBaggage);
                }
            }
            catch
            {
                insertedId = -1;
            }
            return insertedId;
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
