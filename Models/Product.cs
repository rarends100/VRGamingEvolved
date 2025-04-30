using System.ComponentModel.DataAnnotations;

namespace VRGamingEvolved.Models
{
    public class Product //This class is only for inhertance to treat other objects as products easily.
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "You must enter a product name.")]
        [StringLength(100, ErrorMessage = "Product name must not be greater than 50 characters in length.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "You must enter a product type.")]
        public string ProductType { get; set; }

        

    }
}
