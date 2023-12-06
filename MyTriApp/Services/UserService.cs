using Microsoft.EntityFrameworkCore;
using MyTriApp.Data;
using MyTriApp.Data.Entities;
using MyTriApp.Services.Interfaces;

namespace MyTriApp.Services
{
    public class UserService : IUserService
    {
        private readonly MyTriAppDbContext _context;

        public UserService(MyTriAppDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            var result = await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.Include(u => u.StravaAccessToken).ToListAsync();
        }

        public async Task<User?> GetUserById(Guid userGuid)
        {
            return await _context.Users.Include(e => e.StravaAccessToken).FirstOrDefaultAsync(x => x.ExternalId == userGuid);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<User?> UpdateUser(User user)
        {
            var userToUpdate = await _context.Users.FindAsync(user.ExternalId);
            if (userToUpdate == null)
            {
                return userToUpdate;
            }

            userToUpdate.PasswordHash = user.PasswordHash;
            userToUpdate.Email = user.Email;
            userToUpdate.RefreshToken = user.RefreshToken;
            userToUpdate.AccessToken = user.AccessToken;
            userToUpdate.ExpirationDate = user.ExpirationDate;
            userToUpdate.AccessToken = user.AccessToken;

            await _context.SaveChangesAsync();

            return userToUpdate;
        }

        public async Task<bool> DeleteUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            _context.Remove(user);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
