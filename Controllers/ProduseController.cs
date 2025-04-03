using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace SportPlus.Controllers
{
    public class ProduseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProduseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Produse
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Produse.Include(p => p.Categorie);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Produse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produse = await _context.Produse
                .Include(p => p.Categorie)
                .FirstOrDefaultAsync(m => m.ProduseId == id);
            if (produse == null)
            {
                return NotFound();
            }

            return View(produse);
        }

        // GET: Produse/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categorii, "CategorieId", "CategorieId");
            return View();
        }

        // POST: Produse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProduseId,Nume,Descriere,Pret,Stoc,CategoryId")] Produse produse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categorii, "CategorieId", "CategorieId", produse.CategoryId);
            return View(produse);
        }

        // GET: Produse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produse = await _context.Produse.FindAsync(id);
            if (produse == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categorii, "CategorieId", "CategorieId", produse.CategoryId);
            return View(produse);
        }

        // POST: Produse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProduseId,Nume,Descriere,Pret,Stoc,CategoryId")] Produse produse)
        {
            if (id != produse.ProduseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduseExists(produse.ProduseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categorii, "CategorieId", "CategorieId", produse.CategoryId);
            return View(produse);
        }

        // GET: Produse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produse = await _context.Produse
                .Include(p => p.Categorie)
                .FirstOrDefaultAsync(m => m.ProduseId == id);
            if (produse == null)
            {
                return NotFound();
            }

            return View(produse);
        }

        // POST: Produse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produse = await _context.Produse.FindAsync(id);
            if (produse != null)
            {
                _context.Produse.Remove(produse);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduseExists(int id)
        {
            return _context.Produse.Any(e => e.ProduseId == id);
        }
    }
}
