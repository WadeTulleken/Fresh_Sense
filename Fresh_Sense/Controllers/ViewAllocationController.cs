using Fresh_Sense.Data;
using Fresh_Sense.Migrations;
using Fresh_Sense.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Fresh_Sense.Controllers
{
    public class ViewAllocationController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ViewAllocationController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize(Roles = "Maintenance Technician")]
        public async Task<IActionResult> Index()
        {
            var fridgeAllocations  = await _dbContext.fridgeAllocations.ToListAsync();
            return View(fridgeAllocations);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fridgeAllocation = _dbContext.fridgeAllocations.Find(id);
            if (fridgeAllocation == null)
            {
                return NotFound();
            }

            ViewData["Title"] = "Customer Fridge Allocation"; // Setting ViewData title
            return View(fridgeAllocation); // Passing the fault model to the view
        }
    }
}
