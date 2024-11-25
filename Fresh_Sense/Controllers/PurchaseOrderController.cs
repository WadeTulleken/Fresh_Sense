using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fresh_Sense.Data;
using Fresh_Sense.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace Fresh_Sense.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchaseOrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            ViewBag.Suppliers = _context.Suppliers
                .Select(s => new SelectListItem
                {
                    Value = s.SupplierId.ToString(),
                    Text = s.SupplierName
                })
                .ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePurchaseOrderModel purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                var newPurchaseOrder = new CreatePurchaseOrderModel
                {
                    SupplierId = purchaseOrder.SupplierId,
                    FridgeModel = purchaseOrder.FridgeModel,
                    POQuantity = purchaseOrder.POQuantity,
                    PODateRequired = purchaseOrder.PODateRequired
                };

                _context.PurchaseOrders.Add(newPurchaseOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction("PurchasingTechn", "Home");
            }

            ViewBag.Suppliers = _context.Suppliers
                .Select(s => new SelectListItem
                {
                    Value = s.SupplierId.ToString(),
                    Text = s.SupplierName
                })
                .ToList();

            return View(purchaseOrder);
        }

        public async Task<IActionResult> Index()
        {
            var purchaseOrders = await _context.PurchaseOrders
                .Include(p => p.Supplier)
                .ToListAsync();
            return View(purchaseOrders);
        }
    }
}
