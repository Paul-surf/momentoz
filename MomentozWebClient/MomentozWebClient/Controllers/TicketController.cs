using Microsoft.AspNetCore.Mvc;
using MomentozWebClient.BusinessLogicLayer;
using MomentozWebClient.Models;

namespace MomentozWebClient.Controllers
{
    public class TicketController : Controller
    {
        readonly TicketLogic _ticketsLogic;

        public TicketController(IConfiguration inConfiguration)
        {
            _ticketsLogic = new TicketLogic(inConfiguration);
        }
        public async Task<ActionResult> Tickets(int flightId)
        {
            Ticket foundOrders = await _ticketsLogic.GetTicketByFlightId(flightId);
            return View(foundOrders);

        }
/*        public async Task<ActionResult> newTicket(int flightId)
        {
            Ticket newTicket = new Ticket(flightId);
            newTicket = await _ticketsLogic.createTicketWithFlightId(newTicket);
            return View(newTicket);
        }*/
        public void updateTicket(Ticket ticket)
        {
             _ticketsLogic.updateTicket(ticket);
        }
    }
}
