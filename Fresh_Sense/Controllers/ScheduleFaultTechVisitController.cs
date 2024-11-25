using Fresh_Sense.Data;
using Fresh_Sense.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fresh_Sense.Controllers
{
    public class ScheduleFaultTechVisitController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ScheduleFaultTechVisitController(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public async Task<IActionResult> Index()
        {
            var visits = await dbContext.scheduleFaultTechVisits.ToListAsync();
            return View(visits);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ScheduleFaultTechVisit visit)
        {
            if (ModelState.IsValid)
            {
                dbContext.scheduleFaultTechVisits.Add(visit);
                dbContext.SaveChanges();


            }
            return View(visit);
        }


    }
}
