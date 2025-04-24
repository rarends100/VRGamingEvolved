using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VRGamingEvolved.Models;

namespace VRGamingEvolved.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<Users> userManager;
        private SignInManager<Users> signInManager;

        public AccountController(UserManager<Users> userMngr, 
            SignInManager<Users> signInMngr)
        {
            userManager = userMngr;
            signInManager = signInMngr;
        }

        //Register(), Login(), and logout methods come next
    }
}
