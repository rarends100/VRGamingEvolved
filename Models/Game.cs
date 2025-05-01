using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace VRGamingEvolved.Models
{
    public class Game : Product
    {
        //https://www.simplilearn.com/tutorials/asp-dot-net-tutorial/data-annotation-attributes-in-asp-dot-net-mvc used as a reference guide
        //https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.regularexpressionattribute?view=net-9.0 used as a reference guide
        //Used this site to verify regex works
        //https://regex101.com/
       
        [RegularExpression("^\\d{1,3}.\\d{1,4}$", ErrorMessage = "The version must be in the format xxx.xxxx with at least one required x on each side.")]
        [Required]
        public String GameVersion { get; set; }


        public String GameDescription { get; set; }

    }
}
