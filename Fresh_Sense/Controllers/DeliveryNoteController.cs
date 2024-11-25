using Fresh_Sense.Data;
using Fresh_Sense.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Fresh_Sense.Controllers
{
    public class ProcessDeliveryNoteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProcessDeliveryNoteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var deliveryNotes = await _context.DeliveryNote
                .Include(dn => dn.Supplier)
                .ToListAsync();
            return View(deliveryNotes);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var deliveryNote = await _context.DeliveryNote
                .Include(dn => dn.Supplier)
                .FirstOrDefaultAsync(dn => dn.DNId == id);

            if (deliveryNote == null) return NotFound();

            return View(deliveryNote);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DNId,SupplierId,FridgeModel,DNQuantity,DNStatus")] ProcessDeliveryNoteModel deliveryNote)
        {
            if (id != deliveryNote.DNId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryNote);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryNoteExists(deliveryNote.DNId)) return NotFound();
                    else throw;
                }
            }
            return View(deliveryNote);
        }

        private bool DeliveryNoteExists(int id)
        {
            return _context.DeliveryNote.Any(dn => dn.DNId == id);
        }
    }
}
