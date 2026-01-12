namespace SportPlus.Services;

public interface IProduseService
{
    Task<List<Produse>> GetAllAsync();
    Task<Produse?> GetByIdAsync(int id);
    Task AddAsync(Produse produs);
    Task UpdateAsync(Produse produs);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
