// Inkluderer ModelLayer-navneområdet, som indeholder data-modellerne, herunder Baggage-modellen.
using MomentozClientApp.ModelLayer;

// Definerer navneområdet for servicelaget i MomentozClientApp-applikationen.
namespace MomentozClientApp.Servicelayer
{
    // IBaggageAccess er et interface, der definerer kontrakten for adgang til bagageoplysninger.
    // Alle klasser, der implementerer dette interface, skal implementere disse metoder.
    public interface IBaggageAccess
    {
        // Asynkron metode til at hente en specifik bagage baseret på dens id.
        // Returnerer et Baggage-objekt eller null, hvis den specifikke bagage ikke findes.
        Task<Baggage> GetBaggageById(int id);

        // Asynkron metode til at hente alle tilgængelige bagageelementer.
        // Returnerer en liste af Baggage-objekter.
        Task<List<Baggage>> GetBaggageAll();

        // Asynkron metode til at oprette en ny bagage.
        // Modtager et Baggage-objekt som parameter og returnerer en identifikator for den oprettede bagage.
        Task<int> CreateBaggage(Baggage baggage);

        // Asynkron metode til at opdatere en eksisterende bagage.
        // Modtager et Baggage-objekt som parameter. Returnerer 'true', hvis opdateringen lykkes, ellers 'false'.
        Task<bool> UpdateBaggage(Baggage baggage);

        // Asynkron metode til at slette en bagage baseret på dens id.
        // Returnerer 'true', hvis sletningen lykkes, ellers 'false'.
        Task<bool> DeleteBaggageById(int id);
    }
}
