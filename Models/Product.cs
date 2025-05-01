using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required(ErrorMessage = "You must enter a cost for the product.")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Cost { get; set; }


        [Required(ErrorMessage = "You must enter a sell amount for the product.")]
        [DisplayFormat(DataFormatString = "{0:C}")]

        public decimal Sell {  get; set; }

        public string? FileName { get; set; }

        //May integrate categories if we have time


    }
}
