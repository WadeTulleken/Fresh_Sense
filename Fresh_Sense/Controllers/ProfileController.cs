using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Fresh_Sense.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Fresh_Sense.Areas.Identity;
using Fresh_Sense.Data;
using Microsoft.EntityFrameworkCore;

[Authorize]
public class ProfileController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public ProfileController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    [Authorize(Roles = "Customer")]
    public async Task<IActionResult> Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var customer = _context.Customers.FirstOrDefault(c => c.Id == userId);
        var user = await _userManager.FindByIdAsync(userId);

        var model = new ProfileViewModel
        {
            Customer = customer,
            ApplicationUser = user
        };

        return View(model);
    }

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //    [Route("/updateProfile")]
    //    public async Task<IActionResult> UpdateProfile(Customer customer)
    //    {
    //        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    //        var existingCustomer = _context.Customers.FirstOrDefault(c => c.Id == userId);

    //        if (existingCustomer != null)
    //        {
    //            existingCustomer.BusinessName = customer.BusinessName;
    //            existingCustomer.Address = customer.Address;

    //            _context.Update(existingCustomer);
    //            await _context.SaveChangesAsync();
    //            return Json(new { success = true });
    //        }
    //        return Json(new { success = false });
    //    }
    //}





    [HttpPost]
    [Route("/updateProfile")]
    public async Task<IActionResult> UpdateProfile(Customer customer)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var existingCustomer = _context.Customers.FirstOrDefault(c => c.Id == userId);

        if (existingCustomer != null)
        {
            existingCustomer.BusinessName = customer.BusinessName;
            existingCustomer.Address = customer.Address;

            _context.Update(existingCustomer);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Profile updated successfully." });
        }
        return Json(new { success = false, message = "Profile update failed. Please try again." });
    }
}