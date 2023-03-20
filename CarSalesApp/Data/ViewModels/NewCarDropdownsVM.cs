using CarSalesApp.Models;

namespace CarSalesApp.Data.ViewModels
{
    public class NewCarDropdownsVM
    {
        public NewCarDropdownsVM()
        {
            Branches = new List<Branch>();
            Salesmen = new List<Salesman>();
            Manufacturers = new List<Manufacturer>();

        }

        public List<Branch> Branches { get; set; }
        public List<Salesman> Salesmen { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }
    }
}
