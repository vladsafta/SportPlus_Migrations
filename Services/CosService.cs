
using SportPlus.Repositories;
using SportPlus.Interfaces;
namespace SportPlus.Services
{
    public class CosService : ICosService
    {
        private readonly ICosRepository _cosRepository;

        public CosService(ICosRepository cosRepository)
        {
            _cosRepository = cosRepository;
        }

        public async Task<Cos?> GetCosByUserIdAsync(int userId)
        {
            return await _cosRepository.GetByUserIdAsync(userId);
        }

        public async Task AddItemAsync(int userId, int produsId)
        {
            var cos = await _cosRepository.GetByUserIdAsync(userId);

            if (cos == null)
            {
                cos = new Cos { UserId = userId, CosItems = new List<CosItem>() };
                await _cosRepository.AddAsync(cos);
            }

            var item = cos.CosItems.FirstOrDefault(i => i.ProdusId == produsId);
            if (item != null)
            {
                item.Cantitate++; // Crește cantitatea dacă produsul este deja în coș
            }
            else
            {
                cos.CosItems.Add(new CosItem { ProdusId = produsId, Cantitate = 1 }); // Adaugă un nou item în coș
            }

            // Salvează coșul actualizat în baza de date
            await _cosRepository.SaveAsync();
        }

        public async Task RemoveItemAsync(int cosItemId)
        {
            // Obține articolul din coș
            var item = await _cosRepository.GetItemByIdAsync(cosItemId);
            if (item != null)
            {
                await _cosRepository.RemoveItemAsync(item); // Șterge articolul din coș
                await _cosRepository.SaveAsync(); // Salvează modificările
            }
        }

        public async Task ClearCosAsync(int userId)
        {
            var cos = await _cosRepository.GetByUserIdAsync(userId);
            if (cos != null)
            {
                await _cosRepository.ClearAsync(userId); // Golește coșul
                await _cosRepository.SaveAsync(); // Salvează modificările
            }
        }
    }
}
