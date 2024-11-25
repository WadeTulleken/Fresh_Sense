using Fresh_Sense.Data;
using Fresh_Sense.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Fresh_Sense.Controllers
{
    public class ProcessQuotationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProcessQuotationController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var requests = await _context.Quotations
                .Include(pr => pr.Supplier)
                .ToListAsync();
            return View(requests);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var quotation = await _context.Quotations
                .Include(q => q.Supplier)
                .FirstOrDefaultAsync(q => q.QuotationID == id);

            if (quotation == null) return NotFound();

            return View(quotation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuotationID,QuotationStatus,QuotationDeadline,SupplierId")] ProcessQuotation model)
        {
            if (id != model.QuotationID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Create", "PurchaseOrder");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuotationExists(model.QuotationID)) return NotFound();
                    else throw;
                }
            }
            return View(model);
        }

        private bool QuotationExists(int id)
        {
            return _context.Quotations.Any(e => e.QuotationID == id);
        }
    }
}
