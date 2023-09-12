using MyTriApp.Data.Entities;

namespace MyTriApp.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetUserToken(User user);
    }
}
