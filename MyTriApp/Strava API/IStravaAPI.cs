using MyTriApp.Data.Entities;
using MyTriApp.Services.DTOs;
using MyTriApp.Strava_API.DTOs;

namespace MyTriApp.Strava_API
{
    public interface IStravaAPI
    {
        Task<AccessTokenDTO> GetStravaAccessToken(string authorizationCode);
        Task<AccessTokenDTO> RefreshStravaAccessToken(StravaAccessToken accessToken);
        Task<List<DetailedActivityDTO>> GetInitialActivities(Guid userId);
        Task<List<ActivityDTO>> GetActivities(StravaAccessToken accessToken);
        Task<DetailedActivityDTO?> GetActivityById(StravaAccessToken accessToken, long activityId);
    }
}