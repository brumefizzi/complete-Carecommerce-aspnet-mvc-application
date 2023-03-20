using System.ComponentModel.DataAnnotations;

namespace CarSalesApp.Models
{
    public class Car_Salesman
    {
        public int CarId { get; set; }
        public Car? Car { get; set; }

        public int SalesmanId { get; set; }
        public Salesman? Salesman { get; set; }  
    }
}
