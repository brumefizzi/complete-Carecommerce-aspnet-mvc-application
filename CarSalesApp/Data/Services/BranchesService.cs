using CarSalesApp.Data.Base;
using CarSalesApp.Models;

namespace CarSalesApp.Data.Services
{
    public class BranchesService : EntityBaseRepository<Branch> , IBranchesService
    {
        public BranchesService(CarSalesAppContext context) : base(context) 
        { 
        
        }

    }
}
