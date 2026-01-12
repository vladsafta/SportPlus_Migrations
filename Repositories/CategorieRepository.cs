namespace SportPlus.Repositories;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

    public class CategorieRepository : ICategorieRepository
    {
        private readonly ApplicationDbContext _context;

        public CategorieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categorie>> GetAllAsync()
        {
            return await _context.Categorii.ToListAsync();
        }

        public async Task<Categorie> GetByIdAsync(int id)
        {
            return await _context.Categorii.FirstOrDefaultAsync(c => c.CategorieId == id);
        }

        public async Task AddAsync(Categorie categorie)
        {
            _context.Categorii.Add(categorie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Categorie categorie)
        {
            _context.Categorii.Update(categorie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Categorie categorie)
        {
            _context.Categorii.Remove(categorie);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Categorii.AnyAsync(e => e.CategorieId == id);
        }
    }

