using Microsoft.EntityFrameworkCore;
using MyTriApp.Data;
using MyTriApp.Data.Entities;

namespace MyTriApp.Services.Interfaces
{
    public class StravaAccessTokenService : IStravaAccessTokenService
    {
        private readonly MyTriAppDbContext _context;

        public StravaAccessTokenService(MyTriAppDbContext context)
        {
            _context = context;
        }

        public async Task<StravaAccessToken> CreateStravaAccessToken(StravaAccessToken stravaAccessToken)
        {
            var result = await _context.AddAsync(stravaAccessToken);
            await _context.SaveChangesAsync();
            return stravaAccessToken;
        }

        public async Task<StravaAccessToken?> GetStravaAccessToken(long stravaAthleteId)
        {
            return await _context.StravaAccessTokens.FirstOrDefaultAsync(x => x.AthleteId == stravaAthleteId);
        }

        public async Task<StravaAccessToken?> UpdateStravaAccessToken(StravaAccessToken stravaAccessToken)
        {
            var stravaAccessTokenToUpdate = await _context.StravaAccessTokens.FindAsync(stravaAccessToken.ExternalId);
            if (stravaAccessTokenToUpdate == null)
            {
                return stravaAccessTokenToUpdate;
            }

            stravaAccessTokenToUpdate.AccessToken = stravaAccessToken.AccessToken;
            stravaAccessTokenToUpdate.RefreshToken = stravaAccessToken.RefreshToken;
            stravaAccessTokenToUpdate.ExpiresIn = stravaAccessToken.ExpiresIn;
            stravaAccessTokenToUpdate.ExpiresAt = stravaAccessToken.ExpiresAt;
            stravaAccessTokenToUpdate.TokenType = stravaAccessToken.TokenType;

            await _context.SaveChangesAsync();

            return stravaAccessTokenToUpdate;
        }

        public async Task<bool> DeleteStravaAccessToken(long stravaAthleteId)
        {
            var stravaAccessToken = await _context.StravaAccessTokens.FirstAsync(x => x.AthleteId == stravaAthleteId);
            if (stravaAccessToken == null)
            {
                return false;
            }
            _context.Remove(stravaAccessToken);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
