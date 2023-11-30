// Inkluderer nødvendige navneområder for DTOs (Data Transfer Objects).
using MomentozClientApp.DTOs;

// Definerer navneområdet for business logic laget i MomentozClientApp-applikationen.
namespace MomentozClientApp.BusinessLogicLayer
{
    // IBaggagedata er et interface, der definerer kontrakten for operationer relateret til bagage-data.
    public interface IBaggagedata
    {
        // Metode til at hente en specifik bagage baseret på dens id og returnere den som en BaggageDto.
        BaggageDto? Get(int id);

        // Metode til at hente en liste af alle bagageelementer og returnere dem som BaggageDto'er.
        List<BaggageDto>? Get();

        // Metode til at tilføje en ny bagage. Modtager en BaggageDto og returnerer et id for den tilføjede bagage.
        int Add(BaggageDto baggageToAdd);

        // Metode til at opdatere en eksisterende bagage. Modtager en BaggageDto og returnerer en boolsk værdi, der indikerer, om opdateringen var succesfuld.
        bool Put(BaggageDto baggageToUpdate);

        // Metode til at slette en bagage baseret på dens id. Returnerer en boolsk værdi, der indikerer, om sletningen var succesfuld.
        bool Delete(int id);
    }
}
