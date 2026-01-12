using SportPlus.Models;
using SportPlus.Repositories;

namespace SportPlus.Services
{
    public class CategorieService : ICategorieService
    {
        private readonly ICategorieRepository _categorieRepository;

        public CategorieService(ICategorieRepository categorieRepository)
        {
            _categorieRepository = categorieRepository;
        }

        public async Task<IEnumerable<Categorie>> GetAllAsync()
        {
            return await _categorieRepository.GetAllAsync();
        }

        public async Task<Categorie?> GetByIdAsync(int id)
        {
            return await _categorieRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Categorie categorie)
        {
            await _categorieRepository.AddAsync(categorie);
        }

        public async Task UpdateAsync(Categorie categorie)
        {
            await _categorieRepository.UpdateAsync(categorie);
        }

        public async Task DeleteAsync(int id)
        {
            var categorie = await _categorieRepository.GetByIdAsync(id);
            if (categorie != null)
            {
                await _categorieRepository.DeleteAsync(categorie);
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _categorieRepository.ExistsAsync(id);
        }
    }
}