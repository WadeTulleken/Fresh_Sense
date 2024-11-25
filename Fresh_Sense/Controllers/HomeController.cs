using Fresh_Sense.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fresh_Sense.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LandingPage()
        {
            return View();
        }

        [Authorize(Roles = "Customer")]
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [Authorize(Roles = "Customer")]
        public IActionResult FaultPortal()
        {
            return View();
        }
        public IActionResult FaultTechDashBoard()
        {
            return View();
        }

        [Authorize(Roles = "Customer")]
        public IActionResult MaintenancePortal()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize(Roles = "Fault Technician")]
        public IActionResult FaultTechn()
        {
            return View();
        }
        //[Authorize(Roles = "Maintenance Technician")]
        public IActionResult MaintenanceTechn()
        {
            return View();
        }
        [Authorize(Roles = "Purchasing Manager")]
        public IActionResult PurchasingTechn()
        {
            return View();
        }

        [Authorize(Roles = "Customer Liaison")]
        public IActionResult CustomerLiaisonPortal()
        {
            return View();
        }
        [Authorize(Roles = "Inventory Liaison")]
        public IActionResult InventoryLiaisonPortal()
        {
            return View();
        }
    }
}
