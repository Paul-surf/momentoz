
using DatabaseData.ModelLayer;
using System;
using System.Net.Sockets;


namespace DatabaseData.DatabaseLayer
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
