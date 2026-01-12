using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SportPlus.Services;

namespace SportPlus.Controllers
{
    public class CosController : Controller
    {
        private readonly ICosService _cosService;

        public CosController(ICosService cosService)
        {
            _cosService = cosService;
        }

        // Afișează coșul
        public async Task<IActionResult> Index()
        {
            int userId = 1; // Înlocuiește cu utilizatorul logat

            var cos = await _cosService.GetCosByUserIdAsync(userId);
            return View(cos);
        }

        // Adaugă produs în coș
        public async Task<IActionResult> AddItem(int produsId)
        {
            int userId = 1; // Înlocuiește cu utilizatorul logat

            await _cosService.AddItemAsync(userId, produsId);
            return RedirectToAction("Index");
        }

        // Elimină un produs din coș
        public async Task<IActionResult> RemoveItem(int itemId)
        {
            await _cosService.RemoveItemAsync(itemId);
            return RedirectToAction("Index");
        }

        // Golește coșul
        public async Task<IActionResult> Clear()
        {
            int userId = 1; // Înlocuiește cu utilizatorul logat

            await _cosService.ClearCosAsync(userId);
            return RedirectToAction("Index");
        }

        // Confirmare comanda
        public IActionResult Confirmare()
        {
            return View();
        }
    }
}
