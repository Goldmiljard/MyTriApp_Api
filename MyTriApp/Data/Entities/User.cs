using System.Diagnostics.CodeAnalysis;

namespace MyTriApp.Data.Entities
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; } = DateTime.MinValue;
        public bool IsAdmin { get; set; } = false;
        public StravaAccessToken? StravaAccessToken { get; set; } // reference navigation to dependent

        public User(string email, string passwordHash)
        {
            ExternalId = Guid.NewGuid();
            Email = email;
            PasswordHash = passwordHash;
        }
    }
}
