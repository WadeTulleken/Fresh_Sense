using Fresh_Sense.Data;
using Fresh_Sense.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Fresh_Sense.Controllers
{
    public class FaultController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public FaultController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        [Authorize(Roles = "Fault Technician")]
        public IActionResult Index()
        {
            IEnumerable<Fault> objList = dbContext.Faults.ToList();
            return View(objList);
        }

        [Authorize(Roles = "Fault Technician")]
        public IActionResult ViewFault(int id)
        {
            var fault = dbContext.Faults.FirstOrDefault(f => f.faultID == id);
            if (fault == null)
            {
                return NotFound();
            }

            return View(fault);
        }

        [Authorize(Roles = "Customer")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Fault fault)
        {
            if (ModelState.IsValid)
            {
                dbContext.Faults.Add(fault);
                dbContext.SaveChanges();

                // Return the fault ID as a JSON response
                return Json(new { faultID = fault.faultID });
            }
            return View(fault);
        }


        [Authorize(Roles = "Customer")]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public IActionResult Search(int id)
        {
            var fault = dbContext.Faults.FirstOrDefault(f => f.faultID == id);

            if (fault == null)
            {
                ViewBag.Message = "Nothing found for this Fault Number";
                return View("Search");
            }

            return View("CustomerViewFault", fault); // Redirect to the new customer view
        }


        [Authorize(Roles = "Fault Technician")]
        public IActionResult Edit(int id)
        {
            var fault = dbContext.Faults.FirstOrDefault(f => f.faultID == id);
            if (fault == null)
            {
                return NotFound();
            }
            return View(fault);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Fault Technician")]
        public IActionResult Edit(Fault fault)
        {
            if (ModelState.IsValid)
            {
                dbContext.Faults.Update(fault);
                dbContext.SaveChanges();
                return RedirectToAction("ViewFault", new { id = fault.faultID });
            }
            return View(fault);
        }
    }
}
