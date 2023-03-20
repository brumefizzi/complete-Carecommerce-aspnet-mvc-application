using CarSalesApp.Data.Base;
using CarSalesApp.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace CarSalesApp.Models
{
    public class NewCarVM
    {
        public int Id { get; set; } 

        [Display(Name = "Select Car make")]
        [Required(ErrorMessage = "Make is required")]
        public string? Make { get; set; }

        [Display(Name = "Car model")]
        [Required(ErrorMessage = "Model is required")]
        public string? Model { get; set; }

        [Display(Name = "Car colour")]
        [Required(ErrorMessage = "Colour is required")]
        public string? Colour { get; set; }

        [Display(Name = "Year of manufacture")]
        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }

        [Display(Name = "Brief Description")]
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

        [Display(Name = "Car Price")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Car Picture URL")]
        [Required(ErrorMessage = "Car Picture URL is required")]
        public string? ImageURL { get; set; }

        [Display(Name = "Listing date")]
        [Required(ErrorMessage = "Listing date is required")]
        public DateTime ListDate { get; set; }

        [Display(Name = "Available date")]
        [Required(ErrorMessage = "Available date is required")]
        public DateTime AvailableDate { get; set; }

        [Display(Name = "Select a condition")]
        [Required(ErrorMessage = "Condition is required")]
        public Condition Condition { get; set; }

        [Display(Name = "Select a body type")]
        [Required(ErrorMessage = "Body type is required")]
        public BodyType BodyType { get; set; }

        //Relationships
        
        [Display(Name = "Select a branch")]
        [Required(ErrorMessage = "Branchis required")]
        public int BranchId { get; set; }

        [Display(Name = "Select a salesman")]
        [Required(ErrorMessage = "Salesman is required")]
        public int SalesmanId { get; set; }
     
    }
}
