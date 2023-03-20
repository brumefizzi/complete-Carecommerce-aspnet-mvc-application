using CarSalesApp.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace CarSalesApp.Models
{
    public class Branch : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Branch Photo")]
        public string? Logo { get; set; }

        [Display(Name = "Branch Name")]
        public string? Name { get; set; }

        [Display(Name = "Branch Details")]
        public string? Description { get; set; }

       
    }
}
