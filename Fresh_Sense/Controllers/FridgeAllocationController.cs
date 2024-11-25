using Fresh_Sense.Data;
using Fresh_Sense.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Fresh_Sense.Controllers
{
    public class FridgeAllocationController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public FridgeAllocationController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize(Roles = "Customer Liaison")]
        public async Task<IActionResult> Create()
        {
            // Fetch customers with corresponding ApplicationUser information
            var customerNames = await _dbContext.Customers
                .Join(_dbContext.ApplicationUsers,
                    customer => customer.Id, // Customer's UserId
                    user => user.Id, // ApplicationUser's Id
                    (customer, user) => new
                    {
                        Id = customer.Id,
                        FullName = $"{user.FirstName} {user.LastName}" // Combine first and last names
                    })
                .ToListAsync();

            ViewBag.Customers = customerNames; // Pass the customer names to the view
            return View();
        }

        // Handles form submission for allocating a fridge
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FridgeAllocation fridge)
        {
            if (ModelState.IsValid)
            {
                // Save fridge allocation to the database
                _dbContext.fridgeAllocations.Add(fridge);
                await _dbContext.SaveChangesAsync();

                // Redirect to the Manage Visits page after successful submission
                return RedirectToAction("Create", "FridgeAllocation");
            }

            // Re-fetch the customer names if the model state is invalid to repopulate the dropdown
            var customerNames = await _dbContext.Customers
                .Join(_dbContext.ApplicationUsers,
                    customer => customer.Id,
                    user => user.Id,
                    (customer, user) => new
                    {
                        Id = customer.Id,
                        FullName = $"{user.FirstName} {user.LastName}"
                    })
                .ToListAsync();

            ViewBag.Customers = customerNames; // Repopulate ViewBag if model validation fails
            return View(fridge); // Return the form with validation errors
        }
    }
}
