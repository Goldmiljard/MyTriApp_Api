using MyTriApp.Types;
using MyTriApp.Weather_API.DTOs;
using Newtonsoft.Json;
using RestSharp;
using System.Globalization;

namespace MyTriApp.Weather_API
{
    public class WeatherAPI : IWeatherAPI, IDisposable
    {
        readonly RestClient _client;
        public WeatherAPI(string apiKey, string apiKeySecret)
        {
            var options = new RestClientOptions("https://visual-crossing-weather.p.rapidapi.com/");

            _client = new RestClient(options);
            _client.AddDefaultHeader("Accept", "/*/"); //for some reason Accept application/json results in a 406 error
            _client.AddDefaultHeader("X-RapidAPI-Host", apiKey);
            _client.AddDefaultHeader("X-RapidAPI-Key", apiKeySecret);
        }

        public async Task<Result<WeatherDTO>> GetWeather(float lattitude, float longitude, DateTime dateTime)
        {
            var request = new RestRequest("history", Method.Get);

            string date = dateTime.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            string lat = lattitude.ToString(CultureInfo.InvariantCulture);
            string lng = longitude.ToString(CultureInfo.InvariantCulture);
            string location = $"{lat},{lng}";

            request.AddParameter("startDateTime", date);
            request.AddParameter("aggregateHours", "1");
            request.AddParameter("location", location);
            request.AddParameter("endDateTime", date);
            request.AddParameter("unitGroup", "metric");
            request.AddParameter("contentType", "json");

            var response = await _client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK && response.Content != null)
            {
                var rawData = JsonConvert.DeserializeObject<dynamic>(response.Content)?.locations[location].values[0];

                WeatherDTO weather = new WeatherDTO(rawData);
                return Result.Ok(weather);
            }
            else
            {
                return Result.Fail<WeatherDTO>("No weather data found");
            }
        }

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
