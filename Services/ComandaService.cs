using SportPlus.Interfaces;

namespace SportPlus.Services;

public class ComandaService : IComandaService
{
    private readonly IComandaRepository _comandaRepository;

    public ComandaService(IComandaRepository comandaRepository)
    {
        _comandaRepository = comandaRepository;
    }

    public async Task<IEnumerable<Comanda>> GetAllAsync() =>
        await _comandaRepository.GetAllAsync();

    public async Task<Comanda?> GetByIdAsync(int id) =>
        await _comandaRepository.GetByIdAsync(id);

    public async Task AddAsync(Comanda comanda) =>
        await _comandaRepository.AddAsync(comanda);

    public async Task<bool> UpdateAsync(Comanda comanda)
    {
        await _comandaRepository.UpdateAsync(comanda);
        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var comanda = await _comandaRepository.GetByIdAsync(id);
        if (comanda != null)
        {
            await _comandaRepository.DeleteAsync(comanda);
        }
    }

    public async Task<bool> ExistsAsync(int id) =>
        await _comandaRepository.ExistsAsync(id);
}
