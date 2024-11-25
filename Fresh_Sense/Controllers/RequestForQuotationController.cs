using Fresh_Sense.Data;
using Fresh_Sense.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Fresh_Sense.Controllers
{
    public class RequestForQuotationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequestForQuotationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create()
        {
            var suppliers = await _context.Suppliers.ToListAsync();
            ViewBag.Suppliers = suppliers;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RequestForQuotation model)
        {
            if (ModelState.IsValid)
            {
                _context.RequestForQuotation.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("PurchasingTechn", "Home");
            }
            var suppliers = await _context.Suppliers.ToListAsync();
            ViewBag.Suppliers = suppliers;
            return View(model);
        }
    }
}
