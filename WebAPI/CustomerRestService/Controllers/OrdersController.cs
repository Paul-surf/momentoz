using RESTfulService.BusinessLogicLayer;
using RESTfulService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace RESTfulService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class OrdersController : ControllerBase
        {
        private readonly IOrderdata _businessLogicCtrl;

        // Constructor with Dependency Injection
        public OrdersController(IOrderdata inBusinessLogicCtrl)
        {
            _businessLogicCtrl = inBusinessLogicCtrl;
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



        // URL: api/Orders/{ticketId}
        [HttpGet, Route("{ticketId}")]
        public ActionResult<OrderDto> Get(int ticketId)
        {
            ActionResult<OrderDto> foundReturn;
            // retrieve data - converted to DTO
            OrderDto? foundOrder = _businessLogicCtrl.GetOrderByTicketId(ticketId);
            // evaluate
            if (foundOrder != null)
            {
                if (foundOrder.TicketID == ticketId)
                {
                    foundReturn = Ok(foundOrder);                 // Statuscode 200
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
            ActionResult<int> foundReturn;
            int insertedId = -1;
            if (inOrderDto != null)
            {
                insertedId = _businessLogicCtrl.Add(inOrderDto);
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
