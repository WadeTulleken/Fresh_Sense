using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fresh_Sense.Controllers
{
    public class FaultStatusController : Controller
    {
        [Authorize(Roles = "Customer")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
