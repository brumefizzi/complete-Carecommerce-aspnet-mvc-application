using CarSalesApp.Data.Base;
using CarSalesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSalesApp.Data.Services
{
    public class ManufacturerService : EntityBaseRepository<Manufacturer>, IManufacturerService
    {
      public ManufacturerService(CarSalesAppContext context) : base(context) { }
         
    }
}
