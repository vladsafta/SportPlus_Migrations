namespace SportPlus.Interfaces;

public interface IComandaRepository
{
    Task<IEnumerable<Comanda>> GetAllAsync();
    Task<Comanda?> GetByIdAsync(int id);
    Task AddAsync(Comanda comanda);
    Task UpdateAsync(Comanda comanda);
    Task DeleteAsync(Comanda comanda);
    Task<bool> ExistsAsync(int id); 
}
