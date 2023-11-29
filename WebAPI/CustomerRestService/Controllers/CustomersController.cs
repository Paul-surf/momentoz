using RESTfulService.BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using RESTfulService.DTOs;

namespace RESTfulService.Controllers
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
        public ActionResult<List<CustomerDtoo>> Get()
        {
            ActionResult<List<CustomerDtoo>> foundReturn;
            // retrieve data - converted to DTO
            List<CustomerDtoo>? foundCustomers = _businessLogicCtrl.Get();
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



        /*// URL: api/customers/{id}
        [HttpGet, Route("{id}")]
        public ActionResult<CustomerDtoo> Get(int id)
        {
            return null;
        }*/

        /*// URL: api/customers
        [HttpPost]
        public ActionResult<int> PostNewCustomer(CustomerDtoo inCustomerDto)
        {
            ActionResult<int> foundReturn;
            int insertedId = -1;
            if (inCustomerDto != null)
            {
                insertedId = _businessLogicCtrl.Add(inCustomerDto);
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
        }*/

        // URL: api/customers
        [HttpPost]
        public ActionResult<CustomerDtoo> CreateNewCustomer(CustomerDtoo inCustomer)
        {
            ActionResult<CustomerDtoo> foundReturn;
            CustomerDtoo? createdCustomer = null;
            if (inCustomer != null)
            {
                createdCustomer = _businessLogicCtrl.Add(inCustomer);
            }
            // Evaluate
            if (createdCustomer is not null)
            {
                foundReturn = Ok(createdCustomer);
            }
            else
            {
                foundReturn = new StatusCodeResult(500);    // Internal server error
            }
            return foundReturn;
        }


        // URL: api/customers/{loginid}
        [HttpGet, Route("{loginid}")]
        public ActionResult<CustomerDtoo?> Get(string loginid)
        {
            ActionResult<CustomerDtoo> foundReturn;
            // retrieve and convert data
            CustomerDtoo? foundCustomer = _businessLogicCtrl.GetByUserId(loginid);
            // evaluate
            if (foundCustomer != null)
            {
                if (!String.IsNullOrEmpty(foundCustomer.LoginUserId))
                {
                    foundReturn = Ok(foundCustomer);                 // Statuscode 200
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




    }



}

