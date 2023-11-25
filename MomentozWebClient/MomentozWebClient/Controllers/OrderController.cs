
using Microsoft.AspNetCore.Mvc;
using MomentozWebClient.BusinessLogicLayer;
using MomentozWebClient.Models;


namespace MomentozWebClient.Controllers
{
    public class OrderController : Controller
    {
        // GET: OrderController
        public ActionResult CreateOrder(int flightId)
        {
            // Her skal du tilføje logik til at oprette en ordre baseret på det valgte fly.
            // For eksempel, tilføj flyet til brugerens ordre session eller database.

            // Antag at vi omdirigerer brugeren til en 'ReviewOrder' view, hvor de kan gennemse deres ordre.
            return RedirectToAction("ReviewOrder");
        }

        readonly OrderLogic _ordersLogic;

        public OrderController(IConfiguration inConfiguration)
        {
            _ordersLogic = new OrderLogic(inConfiguration);
        }

        public async Task<ActionResult> GetAllOrders()
        {

            List<Order>? foundOrders = await _ordersLogic.GetAllOrders();
            return View(foundOrders);


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
