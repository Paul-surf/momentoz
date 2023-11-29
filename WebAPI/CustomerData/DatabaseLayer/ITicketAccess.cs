using DatabaseData.ModelLayer;


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
