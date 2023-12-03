
using Microsoft.AspNetCore.Mvc;
using MomentozWebClient.BusinessLogicLayer;
using MomentozWebClient.Models;


namespace MomentozWebClient.Controllers
{
    public class FlightController : Controller
    {
        // GET: DestinationController


        readonly FlightLogic _flightsLogic;

        public FlightController(IConfiguration inConfiguration)
        {
            _flightsLogic = new FlightLogic(inConfiguration);
        }

        public async Task<ActionResult> Flights()
        {
            List<Flight>? foundFlights = await _flightsLogic.GetAllFlights();
            return View(foundFlights);
        }

        // GET: DestinationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DestinationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DestinationController/Create
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

        // GET: DestinationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DestinationController/Edit/5
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

        // GET: DestinationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DestinationController/Delete/5
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
        // GET: DestinationController/Select/{id}
        public ActionResult Select(int id)
        {
            return View();
        }
    }
}
