using CarSalesApp.Data.Base;
using CarSalesApp.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSalesApp.Models
{
    public class Car : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Colour { get; set; }
        public int Year { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? ImageURL { get; set; }
        public DateTime ListDate { get; set; }
        public DateTime AvailableDate { get; set; }

        public Condition Condition { get; set; }

        public BodyType BodyType { get; set; }

        //Relationships
        public List<Car_Salesman>? CarSalesmen { get; set; }

        //Branch
        public int BranchId { get; set; }
        
        public Branch? Branch { get; set; }

        //Salesman
        public int SalesmanId { get; set; }
       
        public Salesman? Salesman { get; set; }
    }
}
