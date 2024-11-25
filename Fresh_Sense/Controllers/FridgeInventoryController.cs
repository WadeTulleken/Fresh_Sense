using Fresh_Sense.Data;
using Fresh_Sense.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fresh_Sense.Controllers
{
    public class FridgeInventoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public FridgeInventoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize(Roles = "Inventory Liaison")]
        public async Task<IActionResult> Index()
        {
            var FridgeInventory = await _dbContext.FridgeInventory.ToListAsync();
            return View(FridgeInventory);
        }

        public async Task<IActionResult> FridgeDetails(int id)
        {

            // Find the user by ID
            var fridge = await _dbContext.FridgeInventory
                .FirstOrDefaultAsync(u => u.FridgeInventoryID == id);

            if (fridge == null)
            {
                return NotFound();
            }

            return View(fridge);
        }
    }
}
