
using MomentozClientApp.ModelLayer;

namespace MomentozClientApp.BusinessLogicLayer
{
    // Interface definition for ITicketdata, der beskriver operationer for billetdatahåndtering
    public interface ITicketdata
    {
        // Metode til at hente en billet baseret på ID
        Ticket? Get(int id);

        // Metode til at hente en liste af billetter
        List<Ticket>? Get();

        // Metode til at tilføje en ny billet
        int Add(Ticket ticketToAdd);

        // Metode til at opdatere en eksisterende billet
        bool Put(Ticket ticketToUpdate);

        // Metode til at slette en billet baseret på ID
        bool Delete(int id);
    }
}
