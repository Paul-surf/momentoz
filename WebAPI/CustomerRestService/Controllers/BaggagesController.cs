using RESTfulService.BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using RESTfulService.DTOs;

namespace RESTfulService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BaggagesController : ControllerBase
    {

        private readonly IBaggagedata _businessLogicCtrl;

        // Constructor with Dependency Injection
        public BaggagesController(IBaggagedata inBusinessLogicCtrl)
        {
            _businessLogicCtrl = inBusinessLogicCtrl;
        }


        // URL: api/customers


        [HttpGet]
        public ActionResult<List<BaggageDto>> Get()
        {
            ActionResult<List<BaggageDto>> foundReturn;
            // retrieve data - converted to DTO
            List<BaggageDto>? foundBaggages = _businessLogicCtrl.Get();
            // evaluate
            if (foundBaggages != null)
            {
                if (foundBaggages.Count > 0)
                {
                    foundReturn = Ok(foundBaggages);                 // Statuscode 200
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
        public ActionResult<BaggageDto> Get(int id)
        {
            return null;
        }

        // URL: api/customers
        [HttpPost]
        public ActionResult<int> PostNewBaggage(BaggageDto inBaggageDto)
        {
            ActionResult<int> foundReturn;
            int insertedId = -1;
            if (inBaggageDto != null)
            {
                insertedId = _businessLogicCtrl.Add(inBaggageDto);
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