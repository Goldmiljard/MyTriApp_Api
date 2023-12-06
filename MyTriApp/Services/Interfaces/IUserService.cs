using MyTriApp.Data.Entities;

namespace MyTriApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
        Task<List<User>> GetAllUsers();
        Task<User?> GetUserById(Guid externalId);
        Task<User?> GetUserByEmail(string email);
        Task<User?> UpdateUser(User stravaUser);
        Task<bool> DeleteUserById(int id);
    }
}
