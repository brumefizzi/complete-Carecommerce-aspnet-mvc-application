using CarSalesApp.Data;
using CarSalesApp.Data.Services;
using CarSalesApp.Data.Static;
using CarSalesApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarSalesApp.Controllers
{
    [Authorize(Roles =UserRoles.Admin)]
    public class BranchController : Controller
    {
        private readonly IBranchesService _service;

        public BranchController(IBranchesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allBranches = await _service.GetAllAsync();
            return View(allBranches);
        }

        //Get: Branches/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Branch branch)
        {
            if (!ModelState.IsValid) return View(branch);
            await _service.AddAsync(branch);
            return RedirectToAction(nameof(Index));
        }

        //Get: Branches/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var branchDetails = await _service.GetByIdAsync(id);
            if (branchDetails == null) return View("NotFound");
            return View(branchDetails);
        }

        //Get: Branches/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var branchDetails = await _service.GetByIdAsync(id);
            if (branchDetails == null) return View("NotFound");
            return View(branchDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Branch branch)
        {
            if (!ModelState.IsValid) return View(branch);
            await _service.UpdateAsync(id, branch);
            return RedirectToAction(nameof(Index));
        }

        //Get: Branches/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var branchDetails = await _service.GetByIdAsync(id);
            if (branchDetails == null) return View("NotFound");
            return View(branchDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var branchDetails = await _service.GetByIdAsync(id);
            if (branchDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));


        }
    }
}
