using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chat_App.Data;
using Chat_App.Models;
using Chat_App.services;

namespace Chat_App.Controllers
{
    public class RatesController : Controller
    {
        private readonly IRateService _service;

        public RatesController(Chat_AppContext context)
        {
            _service = new RateService();
        }

        // GET: Rates
        public IActionResult Index()
        {
              ViewData["Average"] = _service.Average();
              return View(_service.GetAll());
        }

        // GET: Rates
        public IActionResult Search()
        {
            ViewData["Average"] = _service.Average();
            return View(_service.GetAll());
        }

        // POST: Rates
        [HttpPost]

        public IActionResult Search(string query)
        {
            if(query == null) 
            { 
                return View(_service.GetAll().ToList()); 
            }
            var q = from rate in _service.GetAll()
                    where rate.Description.Contains(query)
                    select rate;

            ViewData["Average"] = _service.Average();
            return View(q.ToList());
        }

        // GET: Rates/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rate = _service.Get((int)id);
           
            if (rate == null)
            {
                return NotFound();
            }

            return View(rate);
        }

        // GET: Rates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,UserName,Description,Value")] Rate rate)
        {
            if (ModelState.IsValid)
            {
                _service.Create(rate.UserName, rate.Description, rate.Value);   
                return RedirectToAction(nameof(Search));
            }
            return View(rate);
        }

        // GET: Rates/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rate = _service.Get((int)id);
            if (rate == null)
            {
                return NotFound();
            }
            return View(rate);
        }

        // POST: Rates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,UserName,Description,Value")] Rate rate)
        {
            if (id != rate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Edit(id, rate.UserName, rate.Description, rate.Value);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Search));
            }
            return View(rate);
        }

        // GET: Rates/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rate = _service.Get((int)id);
            if (rate == null)
            {
                return NotFound();
            }

            return View(rate);
        }

        // POST: Rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_service.Get((int)id) == null)
            {
                return Problem("Entity set 'Chat_AppContext.Rate'  is null.");
            }
            var rate = _service.Get((int)id);
            if (rate != null)
            {
                _service.Delete(id);
            }
            return RedirectToAction(nameof(Search));
        }
    }
}
