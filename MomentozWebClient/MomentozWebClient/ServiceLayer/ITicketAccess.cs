using MomentozWebClient.Models;
namespace MomentozWebClient.ServiceLayer
{
    public interface ITicketAccess
    {
        Task<List<Ticket>>? GetAllTickets();

        Task<Ticket> GetTicket(int id);
        Task<Ticket> GetTicketByFlightId(int flightId);

        Task<bool> AddTicket(Ticket ticket);

        Task UpdateTicket(Ticket ticket);

        Task<bool> DeleteTicket(int id);
    }
}
