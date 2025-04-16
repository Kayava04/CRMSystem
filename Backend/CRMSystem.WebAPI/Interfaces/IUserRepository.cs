using CRMSystem.WebAPI.Models;

namespace CRMSystem.WebAPI.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetByUsernameAsync(string username);
        Task<bool> IsEmptyAsync();
        Task<User?> GetUserByIdAsync(Guid userId);
        Task UpdateAsync(User user);
    }
}