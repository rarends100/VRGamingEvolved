using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VRGamingEvolved.Data;
using VRGamingEvolved.Models;

namespace VRGamingEvolved.Controllers
{
    public class UsersController : Controller
    {

        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        ///Display customers
        /// </summary>
        /// <returns>Customer list containing all customers</returns>

        [Authorize(Roles = "Admin, Employee")]
        public IActionResult AllUsers()
        {
            if (_context.users == null)
            {
                return NotFound();
            }
            else
            {

                List<Users> allCustomers = _context.users.ToList();
                return View(allCustomers);
            }


        }
    }
}
