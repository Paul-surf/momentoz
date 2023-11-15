using Microsoft.AspNetCore.Mvc;
using CustomerRestService.BusinesslogicLayer;
using CustomerRestService.DTOs;

namespace CustomerRestService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ICustomerdata _businessLogicCtrl;

        // Constructor with Dependency Injection
        public CustomersController(ICustomerdata inBusinessLogicCtrl)
        {
            _businessLogicCtrl = inBusinessLogicCtrl;
        }

        // URL: api/customers
        [HttpGet]
        public ActionResult<List<CustomerDto>> Get()
        {
            ActionResult<List<CustomerDto>> foundReturn;
            // retrieve data - converted to DTO
            List<CustomerDto>? foundCustomers = _businessLogicCtrl.Get();
            // evaluate
            if (foundCustomers != null)
            {
                if (foundCustomers.Count > 0)
                {
                    foundReturn = Ok(foundCustomers);                 // Statuscode 200
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


        // URL: api/customers/{id}
        [HttpGet, Route("{id}")]
        public ActionResult<CustomerDto> Get(int id)
        {
            return null;
        }

        // URL: api/customers
        [HttpPost]
        public ActionResult PostNewCustomer(CustomerDto inCustomer)
        {
            return null;
        }

    }
}
