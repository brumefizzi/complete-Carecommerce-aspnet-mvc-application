using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CarSalesApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Full name")]
        public string FullName { get; set; }
    }
}
