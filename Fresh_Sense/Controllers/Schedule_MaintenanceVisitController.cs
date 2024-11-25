using Fresh_Sense.Data;
using Fresh_Sense.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fresh_Sense.Controllers
{
    public class Schedule_MaintenanceVisitController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public Schedule_MaintenanceVisitController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Displays the form for scheduling a visit
        public IActionResult Create()
        {
            return View();
        }

        // Handles form submission for scheduling a visit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Schedule_MaintenanceVisit scheduleMaintenanceVisit)
        {
            if (ModelState.IsValid)
            {
                // Add the visit to the database
                _dbContext.scheduleMaintenanceVisits.Add(scheduleMaintenanceVisit);
                await _dbContext.SaveChangesAsync();

                // Redirect to the Manage Visits page after successful submission
               /* return RedirectToAction("Index", "Manage_ScheduleVisit")*/;
            }
            return View(scheduleMaintenanceVisit); // Return form with validation errors if invalid
        }

        // Displays the form to reschedule an existing visit
        public async Task<IActionResult> Reschedule(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visit = await _dbContext.scheduleMaintenanceVisits.FindAsync(id);

            if (visit == null)
            {
                return NotFound();
            }

            return View(visit); // Return the reschedule form with the existing visit details
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reschedule(int id, Schedule_MaintenanceVisit updatedVisit)
        {
            if (id != updatedVisit.ScheduleMaintenanceVisitID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingVisit = await _dbContext.scheduleMaintenanceVisits.FindAsync(id);
                if (existingVisit == null)
                {
                    return NotFound();
                }

                // Update visit details
                existingVisit.Date = updatedVisit.Date;
                existingVisit.Time = updatedVisit.Time;
                existingVisit.Notes = updatedVisit.Notes;  // Only rescheduling fields are updated

                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index", "ViewAppointments"); // Redirect back to appointments page
            }

            return View(updatedVisit); // Return form with validation errors
        }


    }
}




