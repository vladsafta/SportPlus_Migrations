using Microsoft.AspNetCore.Mvc;
using SportPlus.Models;
using SportPlus.Services;

namespace SportPlus.Controllers
{
    public class ComandaController : Controller
    {
        private readonly IComandaService _comandaService;

        public ComandaController(IComandaService comandaService)
        {
            _comandaService = comandaService;
        }

        // GET: Comanda
        public async Task<IActionResult> Index()
        {
            var comenzi = await _comandaService.GetAllAsync();
            return View(comenzi);
        }

        // GET: Comanda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var comanda = await _comandaService.GetByIdAsync(id.Value);
            if (comanda == null) return NotFound();

            return View(comanda);
        }

        // GET: Comanda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comanda/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComandaId,UserId,DataComanda,PretTotal,Status")] Comanda comanda)
        {
            if (ModelState.IsValid)
            {
                await _comandaService.AddAsync(comanda);
                return RedirectToAction(nameof(Index));
            }

            return View(comanda);
        }

        // GET: Comanda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var comanda = await _comandaService.GetByIdAsync(id.Value);
            if (comanda == null) return NotFound();

            return View(comanda);
        }

        // POST: Comanda/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComandaId,UserId,DataComanda,PretTotal,Status")] Comanda comanda)
        {
            if (id != comanda.ComandaId) return NotFound();

            if (ModelState.IsValid)
            {
                await _comandaService.UpdateAsync(comanda);  // Nu mai verifici pentru succes
                return RedirectToAction(nameof(Index));
            }

            return View(comanda);
        }


        // GET: Comanda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var comanda = await _comandaService.GetByIdAsync(id.Value);
            if (comanda == null) return NotFound();

            return View(comanda);
        }

        // POST: Comanda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _comandaService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
