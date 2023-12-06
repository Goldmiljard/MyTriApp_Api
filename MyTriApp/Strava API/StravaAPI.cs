using MyTriApp.Data.Entities;
using MyTriApp.Secrets;
using MyTriApp.Services.DTOs;
using MyTriApp.Services.Interfaces;
using MyTriApp.Strava_API.DTOs;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace MyTriApp.Strava_API
{
    public class StravaAPI : IStravaAPI
    {
        private readonly SecretsProvider _secretsProvider;
        private readonly IUserService _userService;
        private readonly IStravaAccessTokenService _stravaAccessTokenService;

        public StravaAPI(SecretsProvider secretsProvider, IUserService userService, IStravaAccessTokenService stravaAccessTokenService)
        {
            _secretsProvider = secretsProvider;
            _userService = userService;
            _stravaAccessTokenService = stravaAccessTokenService;
        }

        public async Task<AccessTokenDTO> GetStravaAccessToken(string authorizationCode)
        {
            RestClient client = new RestClient("https://www.strava.com/api/v3");

            var request = new RestRequest("/oauth/token?", Method.Post);
            request.AddParameter("client_id", "111830");
            request.AddParameter("client_secret", _secretsProvider.GetSecretAsync("StravaClientSecret").Result);
            request.AddParameter("code", authorizationCode);
            request.AddParameter("grant_type", "authorization_code");
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            var result = await client.ExecuteAsync(request);

            client.Dispose();

            if (result.StatusCode == HttpStatusCode.OK && result.Content != null)
            {
                var dto = JsonConvert.DeserializeObject<AccessTokenDTO>(result.Content);
                return dto != null ? dto : new AccessTokenDTO();
            }
            else
            {
                return new AccessTokenDTO();
            }
        }

        public async Task<AccessTokenDTO> RefreshStravaAccessToken(StravaAccessToken accessToken)
        {
            RestClient client = new RestClient("https://www.strava.com/api/v3");

            var request = new RestRequest("/oauth/token?", Method.Post);
            request.AddParameter("client_id", "111830");
            request.AddParameter("client_secret", _secretsProvider.GetSecretAsync("StravaClientSecret").Result);
            request.AddParameter("grant_type", "refresh_token");
            request.AddParameter("refresh_token", accessToken.RefreshToken);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            var result = await client.ExecuteAsync(request);
            client.Dispose();

            if (result.StatusCode == HttpStatusCode.OK && result.Content != null)
            {
                var dto = JsonConvert.DeserializeObject<AccessTokenDTO>(result.Content);
                return dto != null ? dto : new AccessTokenDTO();
            }
            else
            {
                return new AccessTokenDTO();
            }
        }

        public async Task<List<DetailedActivityDTO>> GetInitialActivities(Guid userId)
        {
            var user = await _userService.GetUserById(userId);
            var activities = new List<DetailedActivityDTO>();
            if (user?.StravaAccessToken == null)
            {
                return activities;
            }
            if (DateTimeOffset.FromUnixTimeSeconds(user.StravaAccessToken.ExpiresAt).DateTime < DateTime.Now)
            {
                var accessTokenDTO = await RefreshStravaAccessToken(user.StravaAccessToken);
                var stravaAccessToken = StravaAccessToken.From(accessTokenDTO, user.ExternalId);
                await _stravaAccessTokenService.UpdateStravaAccessToken(stravaAccessToken);
            }
            var activityDTOs = await GetActivities(user.StravaAccessToken);

            foreach (var activityDTO in activityDTOs)
            {
                if (activityDTO != null)
                {
                    var detailedActivityDTO = await GetActivityById(user.StravaAccessToken, activityDTO.id);
                    if (detailedActivityDTO != null)
                    {
                        activities.Add(detailedActivityDTO);
                    }
                }
            }
            return activities;
        }

        public async Task<List<ActivityDTO>> GetActivities(StravaAccessToken accessToken)
        {            
            RestClient client = new RestClient("https://www.strava.com/api/v3");

            var request = new RestRequest("/athlete/activities?", Method.Get);
            request.AddParameter("access_token", accessToken.AccessToken);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            var result = await client.ExecuteAsync(request);

            client.Dispose();
            if (result.StatusCode == HttpStatusCode.OK && result.Content != null)
            {
                return JsonConvert.DeserializeObject<List<ActivityDTO>>(result.Content)!;
            }
            else
            {
                return new List<ActivityDTO>();
            }
        }

        public async Task<DetailedActivityDTO?> GetActivityById(StravaAccessToken accessToken, long activityId)
        {
            RestClient client = new RestClient("https://www.strava.com/api/v3");

            var request = new RestRequest($"/activities/{activityId}", Method.Get);
            request.AddParameter("access_token", accessToken.AccessToken);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            var result = await client.ExecuteAsync(request);

            client.Dispose();
            if (result.StatusCode == HttpStatusCode.OK && result.Content != null)
            {
                return JsonConvert.DeserializeObject<DetailedActivityDTO>(result.Content)!;
            }
            else
            {
                return null;
            }
        }
    }
}
