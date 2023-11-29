using MomentozClientApp.Model;
using MomentozClientApp.ModelLayer;
namespace MomentozClientApp.Servicelayer
{
    public interface ITicketAccess
    {
        Task<Ticket> GetTicketById(int id);
        Task<List<Ticket>> GetTicketAll();
        Task<int> CreateTicket(Ticket Ticket);
        Task<bool> UpdateTicket(Ticket Ticket);
        Task<bool> DeleteTicketById(int id);
    }
}