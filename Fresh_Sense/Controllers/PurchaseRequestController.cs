using Fresh_Sense.Data;
using Fresh_Sense.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fresh_Sense.Controllers
{
    public class PurchaseRequestController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public PurchaseRequestController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize(Roles = "Purchasing Manager")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Inventory Liaison")]
        public IActionResult Create()
        {
            ViewBag.Suppliers = _dbContext.Suppliers.ToList();
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

                _dbContext.PurchaseOrders.Add(newPurchaseOrder);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("InventoryLiaisonPortal", "Home");
            }

            ViewBag.Suppliers = _dbContext.Suppliers.ToList();
            return View(purchaseOrder);
        }
    }
}