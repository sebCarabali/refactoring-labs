using Domain.Models;

namespace Domain.Ports.Repositories
{
    public interface IUserRepository
    {
        Task<bool> IsUsernameUniqueAsync(string username);
        Task<bool> IsEmailUniqueAsync(string email);
        Task AddUserAsync(User user);
    }
}
