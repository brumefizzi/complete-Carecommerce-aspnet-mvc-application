using CarSalesApp.Data.Services;
using CarSalesApp.Data.Static;
using CarSalesApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarSalesApp.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CarsController : Controller
    {
        private readonly ICarsService _service;

        public CarsController(ICarsService service)
        {
            _service = service ;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCars = await _service.GetAllAsync(n => n.Branch);
            return View(allCars);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allCars = await _service.GetAllAsync(n => n.Branch);

            if(!string.IsNullOrEmpty(searchString)) 
            {
                var filteredResult = allCars.Where(n => n.Make.Contains(searchString) || n.Description.Contains
                (searchString)).ToList();    
                return View("Index",filteredResult);
            }

            return View("Index", allCars);
        }

        //GET: Cars/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var carDetails = await _service.GetCarByIdAsync(id);
            return View(carDetails);
        }

        //GET: Cars/Create
        public async Task<IActionResult> Create()
        {
            var carDropdownsData = await _service.GetNewCarDropdownsValues();

            ViewBag.Branches = new SelectList (carDropdownsData.Branches, "Id" , "Name");
            ViewBag.Salesmen = new SelectList(carDropdownsData.Salesmen, "Id", "Name");
            ViewBag.Make = new SelectList(carDropdownsData.Manufacturers, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewCarVM car) 
        {
            if (!ModelState.IsValid) 
            {
                var carDropdownsData = await _service.GetNewCarDropdownsValues();

                ViewBag.Branches = new SelectList(carDropdownsData.Branches, "Id", "Name");
                ViewBag.Salesmen = new SelectList(carDropdownsData.Salesmen, "Id", "Name");
                ViewBag.Make = new SelectList(carDropdownsData.Manufacturers, "Id", "Name");
                return View(car); 
            }
            await _service.AddNewCarAsync(car);
            return RedirectToAction(nameof(Index));
        }

        //GET: Cars/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var carDetails = await _service.GetCarByIdAsync(id);
            if (carDetails == null) return View("NotFound");

            var response = new NewCarVM()
            {
                Id = carDetails.Id,
                Make = carDetails.Make,
                Model = carDetails.Model,
                Colour = carDetails.Colour,
                Price = carDetails.Price,
                Year = carDetails.Year,
                BodyType = carDetails.BodyType,
                ListDate = carDetails.ListDate,
                AvailableDate = carDetails.AvailableDate,
                Condition = carDetails.Condition,
                ImageURL = carDetails.ImageURL,
                BranchId = carDetails.BranchId,
                SalesmanId = carDetails.SalesmanId,
                Description = carDetails.Description,
            };



            var carDropdownsData = await _service.GetNewCarDropdownsValues();

            ViewBag.Branches = new SelectList(carDropdownsData.Branches, "Id", "Name");
            ViewBag.Salesmen = new SelectList(carDropdownsData.Salesmen, "Id", "Name");
            ViewBag.Make = new SelectList(carDropdownsData.Manufacturers, "Id", "Name");
            
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewCarVM car)
        {
            if (id != car.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var carDropdownsData = await _service.GetNewCarDropdownsValues();

                ViewBag.Branches = new SelectList(carDropdownsData.Branches, "Id", "Name");
                ViewBag.Salesmen = new SelectList(carDropdownsData.Salesmen, "Id", "Name");
                ViewBag.Make = new SelectList(carDropdownsData.Manufacturers, "Id", "Name");
                return View(car);
            }
            await _service.UpdateCarAsync(car);
            return RedirectToAction(nameof(Index));
        }

    }
}
