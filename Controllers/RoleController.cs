using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using VRGamingEvolved.Models;
using System.Security.Cryptography.X509Certificates;

namespace VRGamingEvolved.Controllers
{
    public class RoleController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateRolesandDefaultUsers()
        {
            bool roleExists;
            string[] roles = { "Admin", "Customer", "Employee"};

            foreach (string role in roles)
            {
                roleExists = await _roleManager.RoleExistsAsync(role);

                if (!roleExists)
                {
                    var newRoleName = new IdentityRole();
                    newRoleName.Name = role;
                    await _roleManager.CreateAsync(newRoleName);

                    var user = new Users();
                    string password = "Test$pass1234";

                    switch (role)
                    {
                        case "Admin":
                            user.UserName = "Geralt@VRGamesEvolved.com";
                            user.Email = "Geralt@VRGamesEvolved.com";
                            user.UserType = "Admin";

                            break;
                        case "Customer":
                            user.UserName = "firstCustomer@VRGamesEvolved.com";
                            user.Email = "firstCustomer@VRGamesEvolved.com";
                            user.UserType = "Customer";

                            break;
                        case "Employee":
                            user.UserName = "Employee@VRGamesEvolved.com";
                            user.Email = "Employee@VRGamesEvolved.com";
                            user.UserType = "Employee";

                            break;
                    }

                    IdentityResult chkUser = await _userManager.CreateAsync(user, password);

                    if (chkUser.Succeeded)
                    {
                        var addRole_Result = await _userManager.AddToRoleAsync(user, role);
                        ViewData[role + "Message"] =
                            String.Format("{0} created and user {1} created", role, user.UserName); //Will only ever be one of these messages for each roll processed.
                        
                    }
                    else
                    {
                        ViewData[role + "Message"] = String.Format("Problem Creating the user {0}", user.UserName);
                        
                    }

                }
                else
                {
                    ViewData[role + "Message"] = String.Format("The {0} roles already exist.", role);
                    
                }
            }

            


            return View("CreateRolesandDefaultUsers"); //TODO: Not going to correct page.
        }

        public IActionResult AllCustomers()
        {
            return View();
        }
    }
}
