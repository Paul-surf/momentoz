// Inkluderer ModelLayer-navneområdet, som indeholder data-modellerne, herunder Ticket-modellen.
using MomentozClientApp.ModelLayer;

// Definerer navneområdet for servicelaget i MomentozClientApp-applikationen.
namespace MomentozClientApp.Servicelayer
{
    // ITicketAccess er et interface, der definerer kontrakten for billetadgang.
    // Alle klasser, der implementerer dette interface, skal implementere disse metoder.
    public interface ITicketAccess
    {
        // Asynkron metode til at hente en billet baseret på dens id.
        // Returnerer et Ticket-objekt eller null, hvis billetten ikke findes.
        Task<Ticket> GetTicketById(int id);

        // Asynkron metode til at hente alle tilgængelige billetter.
        // Returnerer en liste af Ticket-objekter.
        Task<List<Ticket>> GetTicketAll();

        // Asynkron metode til at oprette en ny billet.
        // Modtager et Ticket-objekt som parameter og returnerer en identifikator for den oprettede billet.
        Task<int> CreateTicket(Ticket Ticket);

        // Asynkron metode til at opdatere en eksisterende billet.
        // Modtager et Ticket-objekt som parameter. Returnerer 'true', hvis opdateringen lykkes, ellers 'false'.
        Task<bool> UpdateTicket(Ticket Ticket);

        // Asynkron metode til at slette en billet baseret på dens id.
        // Returnerer 'true', hvis sletningen lykkes, ellers 'false'.
        Task<bool> DeleteTicketById(int id);
    }
}
