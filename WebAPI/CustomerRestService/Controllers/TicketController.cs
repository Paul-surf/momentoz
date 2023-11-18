﻿using CustomerRestService.BusinessLogicLayer;
using CustomerRestService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace PersonRestService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {

        private readonly ITicketdata _businessLogicCtrl;

        // Constructor with Dependency Injection
        public TicketController(ITicketdata inBusinessLogicCtrl)
        {
            _businessLogicCtrl = inBusinessLogicCtrl;
        }

        // URL: api/Ticket

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


        // URL: api/Ticket/{id}
        [HttpGet, Route("{id}")]
        public ActionResult<TicketDto> Get(int id)
        {
            return null;
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
