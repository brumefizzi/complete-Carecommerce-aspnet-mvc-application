using CarSalesApp.Data.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CarSalesApp.Models
{
    public class Manufacturer:IEntityBase 
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Manufacturer Logo")]
        [Required(ErrorMessage = "Logo is Required")]
        public string? LogoURL { get; set; }
        
        [Display(Name = "Manufacturer Name")]
        [Required(ErrorMessage = "Manufacturer name is Required")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="Manufacturer Name must be between 3 and 50 chars")]
        public string? Name { get; set; }
        
        [Display(Name = "Country of Manufacture")]
        [Required(ErrorMessage = "Country is Required")]
        public string? Address { get; set; }

       


    }
}
