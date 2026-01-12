namespace SportPlus.Repositories;

    public interface ICosRepository
    {
        Task<Cos?> GetByUserIdAsync(int userId);
        Task AddAsync(Cos cos);
        Task SaveAsync();
        Task RemoveItemAsync(CosItem item);
        Task ClearAsync(int userId);
        Task<CosItem?> GetItemByIdAsync(int cosItemId);
    }

