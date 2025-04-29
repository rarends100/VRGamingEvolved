using Microsoft.AspNetCore.Identity;

namespace VRGamingEvolved.Models
{
    public class Users : IdentityUser
    {
        // Inherits all IdentityUser properties, so I do not need to make any adjustments.
        /*Properites
         UserName, Password, ConfirmPassword, Email, EmailConfirmed, PhoneNumber, PhoneNumberConfirmed*/

        public string UserType { get; set; }

    }
}
