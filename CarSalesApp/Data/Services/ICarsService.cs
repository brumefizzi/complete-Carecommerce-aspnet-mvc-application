using CarSalesApp.Data.Base;
using CarSalesApp.Data.ViewModels;
using CarSalesApp.Models;

namespace CarSalesApp.Data.Services
{
    public interface ICarsService : IEntityBaseRepository<Car>
    {
        Task<Car> GetCarByIdAsync(int id);
        Task<NewCarDropdownsVM> GetNewCarDropdownsValues();
        Task AddNewCarAsync(NewCarVM data);
        Task UpdateCarAsync(NewCarVM data);
    }
}
