using Fresh_Sense.Data;
using Fresh_Sense.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Fresh_Sense.Controllers
{
    public class Manage_ScheduleVisitController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public Manage_ScheduleVisitController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize(Roles = "Maintenance Technician")]
        public async Task<IActionResult> Index()
        {
            var scheduledVisits = await _dbContext.scheduleMaintenanceVisits.ToListAsync();
            return View(scheduledVisits);
        }

        // GET: Edit Visit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var visit = await _dbContext.scheduleMaintenanceVisits.FindAsync(id);
            if (visit == null)
            {
                return NotFound();
            }
            return View(visit);
        }

        // POST: Edit Visit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Schedule_MaintenanceVisit visit)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Update(visit);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(visit);
        }

        // GET: Delete Visit
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var visit = await _dbContext.scheduleMaintenanceVisits.FindAsync(id);
            if (visit == null)
            {
                return NotFound();
            }
            return View(visit);
        }

        // POST: Delete Visit
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visit = await _dbContext.scheduleMaintenanceVisits.FindAsync(id);
            if (visit != null)
            {
                _dbContext.scheduleMaintenanceVisits.Remove(visit);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
