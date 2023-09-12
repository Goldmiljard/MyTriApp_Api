using Microsoft.AspNetCore.Mvc;
using MyTriApp.Data.Entities;
using MyTriApp.DTO;

namespace MyTriApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
        Task<bool> DeleteUserById(int id);
        Task<List<User>> GetAllUsers();
        Task<User?> GetUserById(Guid externalId);
        Task<bool> LoginUser(LoginData loginData);
        Task<User?> UpdateUser(User stravaUser);
        Task<User?> GetUserByEmail(string email);
    }
}
