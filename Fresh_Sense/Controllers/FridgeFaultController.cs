using Fresh_Sense.Data;
using Fresh_Sense.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Fresh_Sense.Controllers
{
    public class FridgeFaultController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public FridgeFaultController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Index()
        {
            var Maintenancefault = await _dbContext.maintenance_Faults.ToListAsync();
            return View(Maintenancefault);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fault = _dbContext.maintenance_Faults.Find(id);
            if (fault == null)
            {
                return NotFound();
            }

            ViewData["Title"] = "Maintenance Fault"; // Setting ViewData title
            return View(fault); // Passing the fault model to the view
        }
    }
}


        