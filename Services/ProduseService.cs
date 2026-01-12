using SportPlus.Repositories;

namespace SportPlus.Services;

public class ProduseService : IProduseService
{
    private readonly IProduseRepository _produseRepository;

    public ProduseService(IProduseRepository produseRepository)
    {
        _produseRepository = produseRepository;
    }

    public Task<List<Produse>> GetAllAsync() => _produseRepository.GetAllAsync();

    public Task<Produse?> GetByIdAsync(int id) => _produseRepository.GetByIdAsync(id);

    public Task AddAsync(Produse produs) => _produseRepository.AddAsync(produs);

    public Task UpdateAsync(Produse produs) => _produseRepository.UpdateAsync(produs);

    public async Task DeleteAsync(int id)
    {
        var produs = await _produseRepository.GetByIdAsync(id);
        if (produs != null)
        {
            await _produseRepository.DeleteAsync(produs);
        }
    }

    public Task<bool> ExistsAsync(int id) => _produseRepository.ExistsAsync(id);
}
