using Fresh_Sense.Areas.Identity;
using Fresh_Sense.Data;
using Fresh_Sense.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fresh_Sense.Controllers
{
    public class FridgeMaintenanceHistory : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly UserManager<ApplicationUser> _userManager;

        public FridgeMaintenanceHistory(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        //[Authorize(Roles = "Maintenance Techician")]
        public async Task<IActionResult> Index()
        {
            var roleName = "Customer";
            var usersInRole = await _userManager.GetUsersInRoleAsync(roleName);
            return View(usersInRole);
        }
        public async Task<IActionResult> ViewCustomer(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            // Find the user by ID
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            // Retrieve the customer details including address
            var customer = await _dbContext.Customers
                .FirstOrDefaultAsync(c => c.Id == id);

            // Prepare the view model
            var profileViewModel = new ProfileViewModel
            {
                ApplicationUser = user,
                Customer = customer
            };

            return View(profileViewModel);
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
    }
