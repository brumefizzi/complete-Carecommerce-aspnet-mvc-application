using CarSalesApp.Data.Base;
using CarSalesApp.Models;

namespace CarSalesApp.Data.Services
{
    public class SalesmansService: EntityBaseRepository<Salesman>,ISalesmanService
    {
        public SalesmansService(CarSalesAppContext context) : base(context) 
        {
        }
    }
}
