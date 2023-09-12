using MyTriApp.Data.Entities;
using MyTriApp.Services.DTOs;

namespace MyTriApp.Strava_API
{
    public interface IStravaAPI
    {
        Task<AccessTokenDTO> GetStravaAccessToken(string authorizationCode);
        Task<List<ActivityDTO>> GetActivities(StravaAccessToken accessToken);
        Task<AccessTokenDTO> RefreshStravaAccessToken(StravaAccessToken accessToken);
    }
}