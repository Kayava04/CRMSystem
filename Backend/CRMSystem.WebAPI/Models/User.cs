namespace CRMSystem.WebAPI.Models
{
    public class User
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public int RoleId { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private User(Guid id, string fullname, string email, string username, string passwordHash, int roleId)
        {
            Id = id;
            FullName = fullname;
            Email = email;
            Username = username;
            PasswordHash = passwordHash;
            RoleId = roleId;
            CreatedAt = DateTime.UtcNow;
        }
    
        public static User Create(Guid id, string fullname, string email, string username, string passwordHash, int roleId) =>
            new(id, fullname, email, username, passwordHash, roleId);
    }
}