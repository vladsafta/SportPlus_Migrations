namespace SportPlus.Services;

public interface ICategorieService
    {
        Task<IEnumerable<Categorie>> GetAllAsync();
        Task<Categorie?> GetByIdAsync(int id);
        Task CreateAsync(Categorie categorie);
        Task UpdateAsync(Categorie categorie);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
    
    