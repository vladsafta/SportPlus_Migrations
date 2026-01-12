using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportPlus.Services;

namespace SportPlus.Controllers
{
    public class ProduseController : Controller
    {
        private readonly IProduseService _produseService;
        private readonly ICategorieService _categorieService; // pentru dropdown categorii

        public ProduseController(IProduseService produseService, ICategorieService categorieService)
        {
            _produseService = produseService;
            _categorieService = categorieService;
        }

        public async Task<IActionResult> Index()
        {
            var produse = await _produseService.GetAllAsync();
            return View(produse);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var produs = await _produseService.GetByIdAsync(id.Value);
            if (produs == null) return NotFound();

            return View(produs);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] = new SelectList(await _categorieService.GetAllAsync(), "CategorieId", "Nume");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produse produs)
        {
            if (ModelState.IsValid)
            {
                await _produseService.AddAsync(produs);
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(await _categorieService.GetAllAsync(), "CategorieId", "Nume", produs.CategoryId);
            return View(produs);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var produs = await _produseService.GetByIdAsync(id.Value);
            if (produs == null) return NotFound();

            ViewData["CategoryId"] = new SelectList(await _categorieService.GetAllAsync(), "CategorieId", "Nume", produs.CategoryId);
            return View(produs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produse produs)
        {
            if (id != produs.ProduseId) return NotFound();

            if (ModelState.IsValid)
            {
                await _produseService.UpdateAsync(produs);
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(await _categorieService.GetAllAsync(), "CategorieId", "Nume", produs.CategoryId);
            return View(produs);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var produs = await _produseService.GetByIdAsync(id.Value);
            if (produs == null) return NotFound();

            return View(produs);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _produseService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
