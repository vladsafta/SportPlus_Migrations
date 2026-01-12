using SportPlus.Interfaces;

namespace SportPlus.Repositories;

using Microsoft.EntityFrameworkCore;
using SportPlus.Models;

public class ComandaRepository : IComandaRepository
{
    private readonly ApplicationDbContext _context;

    public ComandaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Comanda>> GetAllAsync()
    {
        return await _context.Comenzi.Include(c => c.User).ToListAsync();
    }

    public async Task<Comanda?> GetByIdAsync(int id)
    {
        return await _context.Comenzi
            .Include(c => c.User)
            .Include(c => c.ComandaItems)
            .FirstOrDefaultAsync(c => c.ComandaId == id);
    }

    public async Task AddAsync(Comanda comanda)
    {
        await _context.Comenzi.AddAsync(comanda);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Comanda comanda)
    {
        _context.Comenzi.Update(comanda);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Comanda comanda)
    {
        _context.Comenzi.Remove(comanda);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Comenzi.AnyAsync(c => c.ComandaId == id);
    }
}
