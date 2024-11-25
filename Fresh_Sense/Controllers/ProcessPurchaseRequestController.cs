using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fresh_Sense.Data;
using Fresh_Sense.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Fresh_Sense.Controllers
{
    public class ProcessPurchaseRequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProcessPurchaseRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var requests = await _context.PurchaseRequestProcess
                .Include(pr => pr.Supplier)
                .ToListAsync();
            return View(requests);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var request = await _context.PurchaseRequestProcess
                .Include(pr => pr.Supplier)
                .FirstOrDefaultAsync(pr => pr.RequestId == id);

            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProcessPurchaseRequest request)
        {
            if (id != request.RequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessPurchaseRequestExists(request.RequestId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(request);
        }

        private bool ProcessPurchaseRequestExists(int id)
        {
            return _context.PurchaseRequestProcess.Any(e => e.RequestId == id);
        }
    }
}
