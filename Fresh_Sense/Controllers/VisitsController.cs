using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fresh_Sense.Controllers
{
    public class VisitsController : Controller
    {
        [Authorize(Roles = "Maintenance Technician")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
