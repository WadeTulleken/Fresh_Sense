using Fresh_Sense.Data;
using Fresh_Sense.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fresh_Sense.Controllers
{

    public class Maintenance_FaultController : Controller
    {

        private readonly ApplicationDbContext _dbContext;

        public Maintenance_FaultController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Maintenance_Fault Maintenancefault)
        {
            if (ModelState.IsValid)
            {
                _dbContext.maintenance_Faults.Add(Maintenancefault);
                await _dbContext.SaveChangesAsync();
            }
            return View();
        }
    }
}



