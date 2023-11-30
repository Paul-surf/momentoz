using RESTfulService.BusinessLogicLayer;
using RESTfulService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace RESTfulService.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class TicketsController : ControllerBase
    {
        private readonly ITicketdata _businessLogicCtrl;

        // Constructor with Dependency Injection
        public TicketsController(ITicketdata inBusinessLogicCtrl)
        {
            _businessLogicCtrl = inBusinessLogicCtrl;
        }

        // URL: api/Tickets

        [HttpGet]
        public ActionResult<List<TicketDto>> Get()
        {
            ActionResult<List<TicketDto>> foundReturn;
            // retrieve data - converted to DTO
            List<TicketDto>? foundTicket = _businessLogicCtrl.Get();
            // evaluate
            if (foundTicket != null)
            {
                if (foundTicket.Count > 0)
                {
                    foundReturn = Ok(foundTicket);                 // Statuscode 200
                }
                else
                {
                    foundReturn = new StatusCodeResult(204);    // Ok, but no content
                }
            }
            else
            {
                foundReturn = new StatusCodeResult(500);        // Internal server error
            }
            // send response back to client
            return foundReturn;
        }


        // URL: api/Ticket/{FlightId}
        [HttpGet, Route("{FlightId}")]
        public ActionResult<TicketDto> Get(int flightId)
        {
            ActionResult<TicketDto> foundReturn;
            // retrieve data - converted to DTO
            TicketDto? foundTicket = _businessLogicCtrl.GetTicketByFlightId(flightId);
            // evaluate
            if (foundTicket != null)
            {
                if (foundTicket.FlightID != flightId)
                {
                    foundReturn = new StatusCodeResult(204);    // Ok, but no content
                }
                else
                {
                    foundReturn = Ok(foundTicket);                 // Statuscode 200
                }
            }
            else
            {
                foundReturn = new StatusCodeResult(500);        // Internal server error
            }
            // send response back to client
            return foundReturn;
        }

        // URL: api/Ticket

        [HttpPost]
        public ActionResult<int> PostNewTicket(TicketDto inTicket)
        {
            ActionResult<int> foundReturn;
            int insertedId = -1;

            {
                insertedId = _businessLogicCtrl.Add(inTicket);
            }
            // Evaluate
            if (insertedId > 0)
            {
                foundReturn = Ok(insertedId);
            }
            else if (insertedId == 0)
            {
                foundReturn = BadRequest();     // missing input
            }
            else
            {
                foundReturn = new StatusCodeResult(500);    // Internal server error
            }
            return foundReturn;
        }
    }
}
