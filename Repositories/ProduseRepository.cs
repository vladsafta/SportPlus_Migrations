using Microsoft.EntityFrameworkCore;

namespace SportPlus.Repositories;

public class ProduseRepository : IProduseRepository
{
    private readonly ApplicationDbContext _context;

    public ProduseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Produse>> GetAllAsync()
    {
        return await _context.Produse.Include(p => p.Categorie).ToListAsync();
    }

    public async Task<Produse?> GetByIdAsync(int id)
    {
        return await _context.Produse.Include(p => p.Categorie)
            .FirstOrDefaultAsync(p => p.ProduseId == id);
    }

    public async Task AddAsync(Produse produs)
    {
        _context.Produse.Add(produs);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Produse produs)
    {
        _context.Produse.Update(produs);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Produse produs)
    {
        _context.Produse.Remove(produs);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Produse.AnyAsync(p => p.ProduseId == id);
    }
}
