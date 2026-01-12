using SportPlus.Data.Repositories;

namespace SportPlus.Repositories;

using Microsoft.EntityFrameworkCore;

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync() => await _context.Users.ToListAsync();

        public async Task<User?> GetByIdAsync(int id) => await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);

        public async Task AddAsync(User user) => await _context.Users.AddAsync(user);

        public async Task UpdateAsync(User user) => _context.Users.Update(user);

        public async Task DeleteAsync(User user) => _context.Users.Remove(user);

        public async Task<bool> ExistsAsync(int id) => await _context.Users.AnyAsync(u => u.UserId == id);
    }
