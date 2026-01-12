using SportPlus.Data.Repositories;
using SportPlus.Services;

namespace SportPlus.Services;

    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly ApplicationDbContext _context;

        public UserService(IUserRepository repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<User?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task CreateAsync(User user)
        {
            await _repository.AddAsync(user);
            await _context.SaveChangesAsync();

            // creează cos automat
            var cos = new Cos { UserId = user.UserId };
            await _context.Cos.AddAsync(cos);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            await _repository.UpdateAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user != null)
            {
                await _repository.DeleteAsync(user);
                await _context.SaveChangesAsync();
            }
        }


        public object Users { get; set; }
    }

