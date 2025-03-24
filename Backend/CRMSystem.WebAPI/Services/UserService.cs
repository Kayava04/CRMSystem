using CRMSystem.WebAPI.Auth;
using CRMSystem.WebAPI.Interfaces;
using CRMSystem.WebAPI.Models;

namespace CRMSystem.WebAPI.Services
{
    public class UserService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtProvider jwtProvider)
    {
        public async Task SignUp(string fullname, string email, string username, string password)
        {
            var hashedPassword = passwordHasher.Generate(password);

            var isFirstUser = await userRepository.IsEmptyAsync();
            var roleId = isFirstUser ? 1 : 2;
        
            var user = User.Create(Guid.NewGuid(), fullname, email, username, hashedPassword, roleId);
        
            await userRepository.AddAsync(user);
        }

        public async Task<string> SignIn(string username, string password)
        {
            var user = await userRepository.GetByUsernameAsync(username);
            var result = passwordHasher.Verify(password, user.PasswordHash);
        
            if (result == false)
                throw new InvalidOperationException("Invalid username or password");
        
            var token = jwtProvider.GenerateToken(user);
            return token;
        }
    }
}