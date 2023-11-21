using Microsoft.AspNetCore.Mvc;
using WebserverMomentoz.Models;

namespace WebserverMomentoz.Controllers
{
    public class LoginController : Controller
    {


        // Get
        public IActionResult Login()
        {
            return View();
        }


        // POST: Account/Login
        [HttpPost]
        public ActionResult Login(Customer model)
        {
            // Validate user credentials (replace this with your authentication logic)
            if (IsValidUser(model))
            {
                // Successful login
                return RedirectToAction("GetAllCustomers", "Customer");
            }

            // Failed login
            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }

        private bool IsValidUser(Customer model)
        {
            // This is a simple example. Replace it with actual authentication logic.
            return model.Email == "jens@example.com" && model.MobilePhone == "12345678";
        }
    }
}
