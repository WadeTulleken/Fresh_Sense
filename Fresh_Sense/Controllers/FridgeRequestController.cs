using Fresh_Sense.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fresh_Sense.Models;

namespace Fresh_Sense.Controllers
{
    
    public class FridgeRequestController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public FridgeRequestController(ApplicationDbContext dBD)
        {
            dbContext = dBD;
        }


        public IActionResult Index()
        {
            IEnumerable<FridgeRequest> objList = dbContext.FridgeRequests;
            return View(objList);
        }
        [Authorize(Roles = "Customer")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Customer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FridgeRequest fridgeRequest)
        {
            if (ModelState.IsValid)
            {
                dbContext.FridgeRequests.Add(fridgeRequest);
                dbContext.SaveChanges();

                // Return the fridge request ID as a JSON response
                return Json(new { fridgeRequestID = fridgeRequest.RequsetID });
            }
            return View(fridgeRequest);
        }


        public IActionResult ViewRequest(int id)
        {
            var request = dbContext.FridgeRequests.FirstOrDefault(f => f.RequsetID == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        public IActionResult Edit(int id)
        {
            var request = dbContext.FridgeRequests.FirstOrDefault(f => f.RequsetID == id);
            if (request == null)
            {
                return NotFound();
            }
            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer Liaison")]
        public IActionResult Edit(FridgeRequest fridgeRequest)
        {
            if (ModelState.IsValid)
            {
                dbContext.FridgeRequests.Update(fridgeRequest);
                dbContext.SaveChanges();
                return RedirectToAction("ViewRequest", new { id = fridgeRequest.RequsetID });
            }
            return View(fridgeRequest);
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
            var fridgeRequest = dbContext.FridgeRequests.FirstOrDefault(f => f.RequsetID == id);

            if (fridgeRequest == null)
            {
                ViewBag.Message = "Nothing found for this Request Number";
                return View("Search");
            }

            return View("CustomerViewRequestStatus", fridgeRequest); // Redirect to the new customer view
        }

    }
}
