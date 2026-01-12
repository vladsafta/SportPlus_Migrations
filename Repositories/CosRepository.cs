
using Microsoft.EntityFrameworkCore;
using SportPlus.Data.Repositories;

namespace SportPlus.Repositories
{
    public class CosRepository : ICosRepository
    {
        private readonly ApplicationDbContext _context;

        public CosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Cos?> GetByUserIdAsync(int userId)
        {
            return await _context.Cos
                .Include(c => c.CosItems)
                .ThenInclude(ci => ci.Produs)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task AddAsync(Cos cos)
        {
            await _context.Cos.AddAsync(cos);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveItemAsync(CosItem cosItem)
        {
            _context.CosItems.Remove(cosItem);
            await _context.SaveChangesAsync();
        }

        public async Task ClearAsync(int userId)
        {
            var cos = await _context.Cos
                .Include(c => c.CosItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cos != null)
            {
                _context.CosItems.RemoveRange(cos.CosItems);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        // Implementarea metodei GetItemByIdAsync
        public async Task<CosItem?> GetItemByIdAsync(int cosItemId)
        {
            // Căutăm CosItem în baza de date după cosItemId
            return await _context.CosItems
                .Include(ci => ci.Produs) // Dacă este necesar să încarci și produsul
                .FirstOrDefaultAsync(ci => ci.CosItemId == cosItemId);
        }
    }
}
