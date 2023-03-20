using CarSalesApp.Data;
using CarSalesApp.Data.Services;
using CarSalesApp.Data.Static;
using CarSalesApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarSalesApp.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class SalesmanController : Controller
    {
        private readonly ISalesmanService _service;

        public SalesmanController(ISalesmanService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allSalesmen = await _service.GetAllAsync();
            return View(allSalesmen);
        }

        //GET: salesman/details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var salesmanDetails = await _service.GetByIdAsync(id);
            if (salesmanDetails == null) return View("NotFound");
            return View(salesmanDetails);
        }

        //GET: salesman/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePicURL,Name,PhoneNumber,Address,Email,Branch")] Salesman salesman)
        {
            if (!ModelState.IsValid) return View(salesman);

            await _service.AddAsync(salesman);
            return RedirectToAction(nameof(Index));
        }

        //GET: salesman/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var salesmanDetails = await _service.GetByIdAsync(id);
            if (salesmanDetails == null) return View("NotFound");
            return View(salesmanDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePicURL,Name,PhoneNumber,Address,Email,Branch")] Salesman salesman)
        {
            if (!ModelState.IsValid) return View(salesman);

            if (id == salesman.Id)
            {
                await _service.UpdateAsync(id, salesman);
                return RedirectToAction(nameof(Index));
            }
            return View(salesman);
        }

        //GET: Salesman/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var salesmanDetails = await _service.GetByIdAsync(id);
            if (salesmanDetails == null) return View("NotFound");
            return View(salesmanDetails);
        }
            [HttpPost, ActionName("Delete")]
            public async Task<IActionResult> DeleteConfirmed(int id)

            {
                var salesmanDetails = await _service.GetByIdAsync(id);
                if (salesmanDetails == null) return View("NotFound");

                await _service.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
        }
    }


