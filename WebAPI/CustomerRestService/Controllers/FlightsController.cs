using CustomerRestService.BusinessLogicLayer;
using CustomerRestService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRestService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {

        private readonly IFlightdata _businessLogicCtrl;

        // Constructor with Dependency Injection
        public FlightsController(IFlightdata inBusinessLogicCtrl)
        {
            _businessLogicCtrl = inBusinessLogicCtrl;
        }


        // URL: api/Flights


        [HttpGet]
        public ActionResult<List<FlightDto>> Get()
        {
            ActionResult<List<FlightDto>> foundReturn;
            // retrieve data - converted to DTO
            List<FlightDto>? foundFlights = _businessLogicCtrl.Get();
            // evaluate
            if (foundFlights != null)
            {
                if (foundFlights.Count > 0)
                {
                    foundReturn = Ok(foundFlights);                 // Statuscode 200
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



        // URL: api/Flights/{id}
        [HttpGet, Route("{id}")]
        public ActionResult<FlightDto> Get(int id)
        {
            return null;
        }

        // URL: api/Flights
        [HttpPost]
        public ActionResult<int> PostNewFlight(FlightDto inFlightDto)
        {
            ActionResult<int> foundReturn;
            int insertedId = -1;
            if (inFlightDto != null)
            {
                insertedId = _businessLogicCtrl.Add(inFlightDto);
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
