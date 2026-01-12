
namespace SportPlus.Services;

    public interface ICosService
    {
        Task<Cos?> GetCosByUserIdAsync(int userId);
        Task AddItemAsync(int userId, int produsId);
        Task RemoveItemAsync(int itemId);
        Task ClearCosAsync(int userId);
    }

