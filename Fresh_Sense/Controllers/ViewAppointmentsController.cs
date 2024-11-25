using Fresh_Sense.Data;
using Fresh_Sense.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Fresh_Sense.Controllers
{
    public class ViewAppointmentsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ViewAppointmentsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Displays all scheduled visits for a customer with optional filters
        public async Task<IActionResult> Index(string technician, string fridgeModel, string startDate, string endDate)
        {
            var visits = from v in _dbContext.scheduleMaintenanceVisits
                         select v;

            // Apply filters based on the user input
            if (!string.IsNullOrEmpty(technician))
            {
                visits = visits.Where(v => v.TechnicianAllocation.Contains(technician));
            }
            if (!string.IsNullOrEmpty(fridgeModel))
            {
                visits = visits.Where(v => v.FridgeModel.Contains(fridgeModel));
            }
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                var start = DateTime.Parse(startDate);
                var end = DateTime.Parse(endDate);
                visits = visits.Where(v => DateTime.Parse(v.Date) >= start && DateTime.Parse(v.Date) <= end);
            }

            return View(await visits.ToListAsync());
        }
    }
}
