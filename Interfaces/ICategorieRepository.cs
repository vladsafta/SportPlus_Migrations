namespace SportPlus.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICategorieRepository
    {
        Task<List<Categorie>> GetAllAsync();
        Task<Categorie> GetByIdAsync(int id);
        Task AddAsync(Categorie categorie);
        Task UpdateAsync(Categorie categorie);
        Task DeleteAsync(Categorie categorie);
        Task<bool> ExistsAsync(int id);
    }
