// Inkluderer nødvendige navneområder for DTOs og servicelaget.
using MomentozClientApp.DTOs;
using MomentozClientApp.Servicelayer;

// Definerer navneområdet for business logic laget i MomentozClientApp-applikationen.
namespace MomentozClientApp.BusinessLogicLayer
{
    // BaggageDataControl-klassen implementerer IBaggagedata-interface og styrer logikken omkring bagage.
    public class BaggageDataControl : IBaggagedata
    {
        // En skrivebeskyttet reference til IBaggageAccess for at interagere med bagage data.
        private readonly IBaggageAccess _baggageAccess;

        // Konstruktøren initialiserer BaggageDataControl med en IBaggageAccess instans.
        public BaggageDataControl(IBaggageAccess inBaggageAccess)
        {
            _baggageAccess = inBaggageAccess;
        }

        // Metode til at hente en specifik bagage baseret på id og konvertere den til en BaggageDto.
        public BaggageDto? Get(int id)
        {
            try
            {
                // Forsøger at hente bagage fra data laget og konvertere til BaggageDto.
                var foundBaggage = _baggageAccess.GetBaggageById(id).Result;
                return ModelConversion.BaggageDtoConvert.FromBaggage(foundBaggage);
            }
            catch
            {
                // Returnerer null, hvis der opstår en fejl.
                return null;
            }
        }

        // Metode til at hente alle bagageelementer og konvertere dem til en liste af BaggageDto.
        public List<BaggageDto>? Get()
        {
            try
            {
                // Forsøger at hente alle bagageelementer og konvertere til BaggageDto-liste.
                var foundBaggages = _baggageAccess.GetBaggageAll().Result;
                return ModelConversion.BaggageDtoConvert.FromBaggageCollection(foundBaggages);
            }
            catch
            {
                // Returnerer null, hvis der opstår en fejl.
                return null;
            }
        }

        // Metode til at tilføje en ny bagage og returnere det nye id for den oprettede bagage.
        public int Add(BaggageDto baggageToAdd)
        {
            try
            {
                // Konverterer BaggageDto til Baggage og forsøger at oprette den i databasen.
                var newBaggage = ModelConversion.BaggageDtoConvert.ToBaggage(baggageToAdd);
                if (newBaggage != null)
                {
                    return _baggageAccess.CreateBaggage(newBaggage).Result;
                }
                return 0;
            }
            catch
            {
                // Returnerer -1 som indikator for fejl.
                return -1;
            }
        }

        // Metoder, der endnu ikke er implementeret, og som kaster NotImplementedException.
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
