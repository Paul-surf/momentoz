using RESTfulService.BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using RESTfulService.DTOs;
using DatabaseData.ModelLayer;

namespace RESTfulService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerdata _businessLogicCtrl;

        public CustomersController(ICustomerdata inBusinessLogicCtrl)
        {
            _businessLogicCtrl = inBusinessLogicCtrl;
        }

        // URL: api/customers?email=value
        [HttpGet]
        public ActionResult<List<CustomerDtoo>> Get([FromQuery] string? email)
        {
            List<CustomerDtoo> foundCustomerDtos = _businessLogicCtrl.Get(email);
            if (foundCustomerDtos != null && foundCustomerDtos.Count > 0)
            {
                return Ok(foundCustomerDtos); // Statuscode 200
            }
            else if (foundCustomerDtos != null)
            {
                return NoContent(); // Statuscode 204 - Ok, but no content
            }
            else
            {
                return StatusCode(500); // Internal server error
            }
        }

        // URL: api/customers/login/{loginid}
        [HttpGet("login/{loginid}")]
        public ActionResult<CustomerDtoo?> GetByLoginId(string loginid)
        {
            CustomerDtoo foundCustomer = _businessLogicCtrl.GetByUserId(loginid);
            if (foundCustomer != null)
            {
                return Ok(foundCustomer); // Statuscode 200
            }
            else
            {
                return StatusCode(500); // Internal server error
            }
        }

        // URL: api/customers
        [HttpPost]
        public ActionResult<CustomerDtoo> CreateNewCustomer(CustomerDtoo inCustomer)
        {
            var createdCustomer = _businessLogicCtrl.Add(inCustomer);
            if (createdCustomer != null)
            {
                return Ok(createdCustomer);
            }
            else
            {
                return StatusCode(500); // Internal server error
            }
        }

        // URL: api/customers/{loginid}
        [HttpPut("{loginid}")]
        public ActionResult<CustomerDtoo> UpdateCustomer([FromBody] CustomerDtoo customer)
        {
            var updatedCustomer = _businessLogicCtrl.Put(customer);
            if (updatedCustomer != null)
            {
                return Ok(updatedCustomer); // Statuscode 200
            }
            else
            {
                return StatusCode(500); // Internal server error
            }
        }

        // ... yderligere metoder, såsom Delete, hvis de er implementeret ....
    }
}
