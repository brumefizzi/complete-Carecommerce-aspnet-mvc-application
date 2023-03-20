using CarSalesApp.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace CarSalesApp.Models
{
    public class Salesman : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string? ProfilePicURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="Full Name must be between 3 and 50 chars")]
        public string? Name { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        public int? PhoneNumber { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        

        //Relationships
        public List<Car_Salesman>? CarSalesmen { get; set; }
        
    }
}
