using MomentozWebClient.ServiceLayer;
using MomentozWebClient.Models;
namespace MomentozWebClient.BusinessLogicLayer
{
    public class TicketLogic
    {
        private readonly TicketService _ticketServiceAccess;
        public TicketLogic(IConfiguration inConfiguration)
        {
            _ticketServiceAccess = new TicketService(inConfiguration);
        }
        public async Task<Ticket> GetTicketByFlightId(int flightId)
        {
            Ticket foundTicket;
            try
            {
                foundTicket = await _ticketServiceAccess.GetTicketByFlightId(flightId);
            }
            catch
            {
                foundTicket = null;
            }
            return foundTicket;
        }
        public async Task<Ticket> createTicketWithFlightId(Ticket newTicket)
        {
            Ticket createdTicket = null;

            try
            {
                createdTicket = await _ticketServiceAccess.SaveTicket(newTicket);
            } catch
            {
                createdTicket = null;
            }
            return createdTicket;
        }
        public async Task updateTicket(Ticket ticket)
        {
            Ticket createdTicket = null;

            try
            {
                await _ticketServiceAccess.UpdateTicket(ticket);
            }
            catch
            {
                createdTicket = null;
            }
        }
    }
}
