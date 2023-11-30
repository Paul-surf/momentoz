// Inkluderer ModelLayer-navneområdet, som indeholder data-modellerne, herunder Order-modellen.
using MomentozClientApp.ModelLayer;

// Definerer navneområdet for servicelaget i MomentozClientApp-applikationen.
namespace MomentozClientApp.ServiceLayer
{
    // IOrderAccess er et interface, der definerer kontrakten for ordreadgang.
    // Alle klasser, der implementerer dette interface, skal implementere disse metoder.
    public interface IOrderAccess
    {
        // Asynkron metode til at hente en ordre baseret på dens id.
        // Returnerer et Order-objekt eller null, hvis ordren ikke findes.
        Task<Order> GetOrderById(int id);

        // Asynkron metode til at hente alle tilgængelige ordrer.
        // Returnerer en liste af Order-objekter.
        Task<List<Order>> GetOrderAll();

        // Asynkron metode til at oprette en ny ordre.
        // Modtager et Order-objekt som parameter og returnerer en identifikator for den oprettede ordre.
        Task<int> CreateOrder(Order order);

        // Asynkron metode til at opdatere en eksisterende ordre.
        // Modtager et Order-objekt som parameter. Returnerer 'true', hvis opdateringen lykkes, ellers 'false'.
        Task<bool> UpdateOrder(Order order);

        // Asynkron metode til at slette en ordre baseret på dens id.
        // Returnerer 'true', hvis sletningen lykkes, ellers 'false'.
        Task<bool> DeleteOrderById(int id);

        // Asynkron metode til at hente en ordre baseret på en brugers id.
        // Returnerer det relevante Order-objekt, hvis det findes, ellers null.
        Task<Order> GetOrderByUserId(string loginUserId);
    }
}
