
using Microsoft.AspNetCore.Mvc;
using MomentozWebClient.BusinessLogicLayer;
using MomentozWebClient.Models;
using System.Security.Claims;

namespace MomentozWebClient.Controllers
{
    public class OrderController : Controller
    {
        readonly OrderLogic _ordersLogic;
        readonly CustomerLogic _customerLogic;

        public OrderController(IConfiguration inConfiguration)
        {
            _ordersLogic = new OrderLogic(inConfiguration);
            _customerLogic = new CustomerLogic(inConfiguration);
        }

        // GET: OrderController
        public ActionResult CreateOrder(int id, double price)
        {
            Order order = new Order();
            order.FlightID = id;
            order.TotalPrice += price;
            order.PurchaseDate = DateTime.Now;
            return View(order);
        }

        // POST: api/Order/{Order}
        [HttpPost("Order")]
        public async Task<ActionResult> CreateOrderReceipt(Order order)
        {
            string userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Customer customerFromService = await _customerLogic.GetCustomerByUserId(userId);

            if (customerFromService == null)
            {
                return RedirectToPagePermanent("/Account/Login");
            }

            order.CustomerID = customerFromService.CustomerID;
            Order submittedOrder = await _ordersLogic.postNewOrder(order);

            if (submittedOrder == null)
            {
                return View(null);
            }

            return View(submittedOrder);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
