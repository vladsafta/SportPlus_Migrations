namespace SportPlus.Services;

public interface IComandaService
{
        Task<IEnumerable<Comanda>> GetAllAsync();
        Task<Comanda?> GetByIdAsync(int id);
        Task AddAsync(Comanda comanda);
        Task<bool> UpdateAsync(Comanda comanda); // dacă ai validare în interior
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
}
