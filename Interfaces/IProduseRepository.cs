namespace SportPlus.Repositories;

public interface IProduseRepository
{
    Task<List<Produse>> GetAllAsync();
    Task<Produse?> GetByIdAsync(int id);
    Task AddAsync(Produse produs);
    Task UpdateAsync(Produse produs);
    Task DeleteAsync(Produse produs);
    Task<bool> ExistsAsync(int id);
}