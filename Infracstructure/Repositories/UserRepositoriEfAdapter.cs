using Domain.Models;
using Domain.Ports.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepositoriEfAdapter : IUserRepository
    {
        private readonly SecurityDbContext _securityDbContext;

        public UserRepositoriEfAdapter(SecurityDbContext securityDbContext)
        {
            _securityDbContext = securityDbContext;
        }

        public async Task AddUserAsync(User user)
        {
            await _securityDbContext.Users.AddAsync(user);
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return !await _securityDbContext.Users
                .AnyAsync(u => u.Email == email);
        }

        public async Task<bool> IsUsernameUniqueAsync(string username)
        {
            return !await _securityDbContext.Users
                .AnyAsync(u => u.Username == username);
        }
    }
}
