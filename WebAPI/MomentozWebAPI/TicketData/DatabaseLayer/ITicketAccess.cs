using TicketData.ModelLayer;
using System;

namespace TicketData.DatabaseLayer
{

    public interface ITicketAccess
    {

        
        Ticket GetTicketById(int id);
        List<Ticket> GetTicketAll();
        int CreateTicket(Ticket ticketToAdd);
        bool UpdateTicket(Ticket ticketToUpdate);
        bool DeleteTicketById(int id);

    }
}
