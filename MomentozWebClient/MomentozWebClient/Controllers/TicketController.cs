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
    }
}
