using MyTriApp.Data.Entities;

namespace MyTriApp.Services.Interfaces
{
    public interface IStravaAccessTokenService
    {
        Task<StravaAccessToken> CreateStravaAccessToken(StravaAccessToken straveAccessToken);
        Task<StravaAccessToken?> GetStravaAccessToken(long stravaAthleteId);
        Task<StravaAccessToken?> UpdateStravaAccessToken(StravaAccessToken stravaAccessToken);
        Task<bool> DeleteStravaAccessToken(long stravaAthleteId);
    }
}
