using CarSalesApp.Data.Base;
using CarSalesApp.Data.ViewModels;
using CarSalesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSalesApp.Data.Services
{
    public class CarsService : EntityBaseRepository<Car>, ICarsService
    {
        private readonly CarSalesAppContext _context;
        public CarsService(CarSalesAppContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewCarAsync(NewCarVM data)
        {
            var newCar = new Car()
            {
                Make = data.Make,
                Model = data.Model,
                Colour = data.Colour,
                Price = data.Price,
                Year = data.Year,
                BodyType = data.BodyType,
                ListDate = data.ListDate,
                AvailableDate = data.AvailableDate,
                Condition = data.Condition,
                ImageURL = data.ImageURL,
                BranchId = data.BranchId,
                SalesmanId = data.SalesmanId,
                Description = data.Description,
            };
            await _context.Cars.AddAsync(newCar);
            await _context.SaveChangesAsync();

           
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            var carDetails = await _context.Cars
                .Include(b => b.Branch)
                .Include(s => s.Salesman)
                .FirstOrDefaultAsync(n => n.Id == id);

            return carDetails;
        }

        public async Task<NewCarDropdownsVM> GetNewCarDropdownsValues()
        {
            var response = new NewCarDropdownsVM()
            {
                Branches = await _context.Branches.OrderBy(n => n.Name).ToListAsync(),
                Salesmen = await _context.Salesmen.OrderBy(n => n.Name).ToListAsync(),
                Manufacturers = await _context.Manufacturers.OrderBy(n => n.Name).ToListAsync()
            };


            return response;
        }

        public async Task UpdateCarAsync(NewCarVM data)
        {
            var dbCar = await _context.Cars.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbCar != null)
            {
                dbCar.Make = data.Make;
                dbCar.Model = data.Model;
                dbCar.Colour = data.Colour;
                dbCar.Price = data.Price;
                dbCar.Year = data.Year;
                dbCar.BodyType = data.BodyType;
                dbCar.ListDate = data.ListDate;
                dbCar.AvailableDate = data.AvailableDate;
                dbCar.Condition = data.Condition;
                dbCar.ImageURL = data.ImageURL;
                dbCar.BranchId = data.BranchId;
                dbCar.SalesmanId = data.SalesmanId;
                dbCar.Description = data.Description;
                await _context.SaveChangesAsync();


            };





        }
    }
}

