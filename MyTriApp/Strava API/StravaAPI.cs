using Microsoft.Extensions.Configuration;
using MyTriApp.Data.Entities;
using MyTriApp.Services.DTOs;
using MyTriApp.Services.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Reflection.PortableExecutable;

namespace MyTriApp.Strava_API
{
    public class StravaAPI : IStravaAPI
    {
        private readonly IConfiguration _configuration;

        public StravaAPI(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
        }

        public async Task<AccessTokenDTO> GetStravaAccessToken(string authorizationCode)
        {
            RestClient client = new RestClient("https://www.strava.com/api/v3");

            var request = new RestRequest("/oauth/token?", Method.Post);
            request.AddParameter("client_id", "111830");
            request.AddParameter("client_secret", _configuration.GetValue<string>("StravaClientSecret")!);
            request.AddParameter("code", authorizationCode);
            request.AddParameter("grant_type", "authorization_code");
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            var result = await client.ExecuteAsync(request);

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

        public async Task<List<ActivityDTO>> GetActivities(StravaAccessToken accessToken)
        {            
            RestClient client = new RestClient("https://www.strava.com/api/v3");

            var request = new RestRequest("/athlete/activities?", Method.Get);
            request.AddParameter("access_token", accessToken.AccessToken);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            var result = await client.ExecuteAsync(request);

            if (result.StatusCode == HttpStatusCode.OK && result.Content != null)
            {
                return JsonConvert.DeserializeObject<List<ActivityDTO>>(result.Content)!;
            }
            else
            {
                return new List<ActivityDTO>();
            }
        }

        public async Task<AccessTokenDTO> RefreshStravaAccessToken(StravaAccessToken accessToken)
        {
            RestClient client = new RestClient("https://www.strava.com/api/v3");

            var request = new RestRequest("/oauth/token?", Method.Post);
            request.AddParameter("client_id", "111830");
            request.AddParameter("client_secret", _configuration.GetValue<string>("StravaClientSecret")!);
            request.AddParameter("grant_type", "refresh_token");
            request.AddParameter("refresh_token", accessToken.RefreshToken);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            var result = await client.ExecuteAsync(request);

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
    }
}
