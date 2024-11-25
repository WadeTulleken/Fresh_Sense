using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fresh_Sense.Controllers
{
    public class PurchasingController : Controller
    {
        [Authorize(Roles = "Purchasing Manager")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
