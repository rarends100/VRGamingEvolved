using Microsoft.AspNetCore.Identity;

namespace VRGamingEvolved.Models

{
    public class Purchase
    {
        public int PurchaseID {  get; set; }
        public List<CartLine> PurchasedItems { get; set; }
        public decimal PurchaseTotal { get; set; }
        public UserManager<IdentityUser> User {  get; set; }
    }
}
