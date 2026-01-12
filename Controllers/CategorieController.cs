using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportPlus.Services;

namespace SportPlus.Controllers
{
    public class CategorieController : Controller
    {
        private readonly ICategorieService _categorieService;

        public CategorieController(ICategorieService categorieService)
        {
            _categorieService = categorieService;
        }

        // GET: Categorie
        public async Task<IActionResult> Index()
        {
            var categorii = await _categorieService.GetAllAsync();
            return View(categorii);
        }

        // GET: Categorie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var categorie = await _categorieService.GetByIdAsync(id.Value);
            if (categorie == null) return NotFound();

            return View(categorie);
        }

        // GET: Categorie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategorieId,Nume")] Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                await _categorieService.CreateAsync(categorie);
                return RedirectToAction(nameof(Index));
            }
            return View(categorie);
        }

        // GET: Categorie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var categorie = await _categorieService.GetByIdAsync(id.Value);
            if (categorie == null) return NotFound();

            return View(categorie);
        }

        // POST: Categorie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategorieId,Nume")] Categorie categorie)
        {
            if (id != categorie.CategorieId) return NotFound();

            if (ModelState.IsValid)
            {
                await _categorieService.UpdateAsync(categorie);
                return RedirectToAction(nameof(Index));
            }
            return View(categorie);
        }

        // GET: Categorie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var categorie = await _categorieService.GetByIdAsync(id.Value);
            if (categorie == null) return NotFound();

            return View(categorie);
        }

        // POST: Categorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categorieService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
