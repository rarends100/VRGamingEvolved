using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VRGamingEvolved.Data;
using VRGamingEvolved.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace VRGamingEvolved.Controllers
{
    public class PurchasesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public PurchasesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Thankyou([Bind("PurchasedItems, PurchaseTotal")]Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                //purchase.set = _userManager.GetUserName;
                return View("Thankyou", purchase);
            }
            return View("Thankyou", purchase);

        }
    }
}
