using MomentozClientApp.DTOs;

namespace MomentozClientApp.BusinessLogicLayer
{
    // Interface definition for IOrderdata, der beskriver operationer for ordrehåndtering
    public interface IOrderdata
    {
        // Metode til at hente en ordre baseret på ID
        OrderDto? Get(int id);

        // Metode til at hente en liste af ordrer
        List<OrderDto>? Get();

        // Metode til at tilføje en ny ordre
        int Add(OrderDto orderToAdd);

        // Metode til at opdatere en eksisterende ordre
        bool Put(OrderDto orderToUpdate);

        // Metode til at slette en ordre baseret på ID
        bool Delete(int id);
    }
}
