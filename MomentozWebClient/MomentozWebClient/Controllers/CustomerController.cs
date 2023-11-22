﻿using Microsoft.AspNetCore.Mvc;
using WebserverMomentoz.BusinessLogicLayer;
using WebserverMomentoz.Models;

namespace WebserverMomentoz.Controllers
{
    public class CustomerController : Controller
    {

        readonly CustomerLogic _customerLogic;

        public CustomerController(IConfiguration inConfiguration)
        {
            _customerLogic = new CustomerLogic(inConfiguration);
        }



        // GET: CustomerController. 

        public async Task<ActionResult> GetAllCustomers()
        {
            List<Customer>? foundCustomers = await _customerLogic.GetAllCustomers();
            return View(foundCustomers);

            
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
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

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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