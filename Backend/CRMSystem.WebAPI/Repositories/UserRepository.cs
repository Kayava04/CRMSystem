using AutoMapper;
using CRMSystem.WebAPI.Core;
using CRMSystem.WebAPI.Entities.Auth;
using CRMSystem.WebAPI.Interfaces;
using CRMSystem.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMSystem.WebAPI.Repositories
{
    public class UserRepository(SchoolDbContext context, IMapper mapper)
        : IUserRepository
    {
        public async Task AddAsync(User user)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Username = user.Username,
                PasswordHash = user.PasswordHash,
                RoleId = user.RoleId,
                CreatedAt = user.CreatedAt
            };
            
            await context.Users.AddAsync(userEntity);
            await context.SaveChangesAsync();
        }
        
        public async Task<User> GetByUsernameAsync(string username)
        {
            var userEntity = await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Username == username);
            
            return mapper.Map<User>(userEntity);
        }

        public async Task<bool> IsEmptyAsync() => !await context.Users.AnyAsync();
    }
}