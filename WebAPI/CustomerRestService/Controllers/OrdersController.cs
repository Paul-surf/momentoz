using RESTfulService.BusinessLogicLayer;
using RESTfulService.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace RESTfulService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderdata _businessLogicCtrl;
        private readonly IFlightdata _flightDataCtrl;

        // Constructor with Dependency Injection
        public OrdersController(IOrderdata inBusinessLogicCtrl, IFlightdata inFlightDataCtrl)
        {
            _businessLogicCtrl = inBusinessLogicCtrl;
            _flightDataCtrl = inFlightDataCtrl;
        }


        // URL: api/Orders
        [HttpGet]
        public ActionResult<List<OrderDto>> Get()
        {
            ActionResult<List<OrderDto>> foundReturn;
            // retrieve data - converted to DTO
            List<OrderDto>? foundOrders = _businessLogicCtrl.Get();
            // evaluate
            if (foundOrders != null)
            {
                if (foundOrders.Count > 0)
                {
                    foundReturn = Ok(foundOrders);                 // Statuscode 200
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

        // URL: api/Orders
        [HttpPost]
        public ActionResult<int> PostNewOrder(OrderDto inOrderDto)
        {
            // Tjek for null input
            if (inOrderDto == null)
            {
                return BadRequest("Order data is required.");
            }

            try
            {
                int insertedId = _businessLogicCtrl.CreateNewOrder(inOrderDto);

                if (insertedId > 0)
                {
                    return Ok(insertedId); // Ordren blev succesfuldt oprettet
                }
                else
                {
                    return Conflict("The flight is already booked."); // Flighten er allerede booket
                }
            }
            catch (Exception ex)
            {
                // Håndter fejl og returner en fejlstatuskode
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
    

