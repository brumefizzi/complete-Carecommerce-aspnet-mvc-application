using CarSalesApp.Data;
using CarSalesApp.Data.Services;
using CarSalesApp.Data.Static;
using CarSalesApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarSalesApp.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ManufacturersController : Controller
    {
        private readonly IManufacturerService _service;

        public ManufacturersController(IManufacturerService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        //Get: Manufacturers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("LogoURL,Name,Address")] Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return View(manufacturer);
            }
            await _service.AddAsync(manufacturer);
            return RedirectToAction(nameof(Index));
        }

        //Get: Manufacturers/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var manufacturerDetails =await _service.GetByIdAsync(id);
            if (manufacturerDetails == null) return View("NotFound");
            return View(manufacturerDetails);
        }
        //Get: Manufacturers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var manufacturerDetails =await _service.GetByIdAsync(id);
            if (manufacturerDetails == null) return View("NotFound");
            return View(manufacturerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LogoURL,Name,Address")] Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return View(manufacturer);
            }
            await _service.UpdateAsync(id, manufacturer);
            return RedirectToAction(nameof(Index));
        }

        //Get: Manufacturers/Delete/1
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var manufacturerDetails = await _service.GetByIdAsync(id);
            if (manufacturerDetails == null) return View("NotFound");
            return View(manufacturerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manufacturerDetails = await _service.GetByIdAsync(id);
            if (manufacturerDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
